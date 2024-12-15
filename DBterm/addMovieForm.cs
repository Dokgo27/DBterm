using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DBterm
{
    public partial class addMovieForm : Form
    {
        string _server = "localhost"; //DB 서버 주소, 로컬일 경우 localhost
        int _port = 3308; //DB 서버 포트
        string _database = "termdb"; //DB 이름
        string _id = "root"; //계정 아이디
        string _pw = "1234"; //계정 비밀번호
        string _connectionAddress = "";
        public addMovieForm()
        {
            InitializeComponent();
            _connectionAddress = string.Format("Server={0};Port={1};Database={2};Uid={3};Pwd={4}", _server, _port, _database, _id, _pw);
        }

        private void UploadImageButton_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.bmp";

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    posterPictureBox.Image = Image.FromFile(openFileDialog.FileName); // PictureBox에 이미지 표시
                    posterPictureBox.Tag = openFileDialog.FileName; // 이미지 경로 저장
                }
            }
        }

        private void addMovieButton_Click(object sender, EventArgs e)
        {
            string title = titleTextBox.Text.Trim();
            string genre = genreComboBox.SelectedItem?.ToString();
            string director = directorTextBox.Text.Trim();
            string leadActors = actorsTextBox.Text.Trim();

            if (posterPictureBox.Image == null || string.IsNullOrEmpty(title) || string.IsNullOrEmpty(genre) || string.IsNullOrEmpty(director) || string.IsNullOrEmpty(leadActors))
            {
                MessageBox.Show("모든 필드를 입력해주세요.");
                return;
            }

            // 이미지 데이터를 바이트 배열로 변환
            byte[] posterData;
            using (MemoryStream ms = new MemoryStream())
            {
                posterPictureBox.Image.Save(ms, posterPictureBox.Image.RawFormat);
                posterData = ms.ToArray();
            }

            using (MySqlConnection connection = new MySqlConnection(_connectionAddress))
            {
                try
                {
                    connection.Open();
                    string query = "INSERT INTO Movies (Title, Genre, Director, LeadActors, Poster) VALUES (@Title, @Genre, @Director, @LeadActors, @Poster)";
                    MySqlCommand command = new MySqlCommand(query, connection);
                    command.Parameters.AddWithValue("@Title", title);
                    command.Parameters.AddWithValue("@Genre", genre);
                    command.Parameters.AddWithValue("@Director", director);
                    command.Parameters.AddWithValue("@LeadActors", leadActors);
                    command.Parameters.AddWithValue("@Poster", posterData);

                    command.ExecuteNonQuery();
                    MessageBox.Show("영화가 성공적으로 등록되었습니다.");
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"영화 등록 중 오류 발생: {ex.Message}");
                }
            }
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("현재 작업을 취소하고 이전 화면으로 돌아가시겠습니까?",
                                      "작업 취소",
                                      MessageBoxButtons.YesNo,
                                      MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                this.Close();
            }
        }
    }
}
