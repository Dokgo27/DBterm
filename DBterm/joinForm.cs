using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace DBterm
{
    public partial class joinForm : Form
    {
        string _server = "localhost"; // DB 서버 주소
        int _port = 3308; // DB 포트
        string _database = "termdb"; // DB 이름
        string _id = "root"; // DB 계정 ID
        string _pw = "1234"; // DB 비밀번호
        string _connectionAddress = "";

        public joinForm()
        {
            InitializeComponent();
            _connectionAddress = string.Format("Server={0};Port={1};Database={2};Uid={3};Pwd={4}", _server, _port, _database, _id, _pw);
        }

        private void Userid_label_Click(object sender, EventArgs e)
        {

        }

        private void passwordTextbox_TextChanged(object sender, EventArgs e)
        {

        }

        private void JoinButton2_Click(object sender, EventArgs e)
        {
            string username = nameTextbox.Text.Trim();    // 사용자 입력 이름
            string userid = UseridTextbox.Text.Trim();    // 사용자 입력 아이디
            string password = PasswordTextbox.Text.Trim(); // 사용자 입력 비밀번호
            string phonenum = PhoneNumberTextbox.Text.Trim(); // 사용자 입력 전화번호
            string cardnum = CardTextbox.Text.Trim();    // 사용자 입력 카드번호

            // 입력값 검증
            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(userid) || string.IsNullOrEmpty(password) ||
                string.IsNullOrEmpty(phonenum) || string.IsNullOrEmpty(cardnum))
            {
                MessageBox.Show("모든 필드를 입력하세요.");
                return;
            }

            // 비밀번호 해시 처리
            string hashedPassword = HashPassword(password);

            using (MySqlConnection connection = new MySqlConnection(_connectionAddress))
            {
                try
                {
                    connection.Open();
                    string query = "INSERT INTO SignupRequests (UserId, Password, Name, PhoneNumber, CardNumber) " +
                                   "VALUES (@UserId, @Password, @Name, @PhoneNumber, @CardNumber)";
                    MySqlCommand command = new MySqlCommand(query, connection);

                    command.Parameters.AddWithValue("@UserId", userid);
                    command.Parameters.AddWithValue("@Password", hashedPassword);
                    command.Parameters.AddWithValue("@Name", username);
                    command.Parameters.AddWithValue("@PhoneNumber", phonenum);
                    command.Parameters.AddWithValue("@CardNumber", cardnum);

                    int result = command.ExecuteNonQuery();

                    if (result > 0)
                    {
                        MessageBox.Show("회원가입 요청이 성공적으로 제출되었습니다. 관리자의 승인을 기다리세요.");
                        this.Close(); // 회원가입 폼 닫기
                    }
                    else
                    {
                        MessageBox.Show("회원가입에 실패했습니다.");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"회원가입 중 오류 발생: {ex.Message}");
                }
            }
        }
        // 비밀번호 해시 처리 함수
        private string HashPassword(string password)
        {
            using (SHA256 sha256 = SHA256.Create())
            {
                byte[] bytes = Encoding.UTF8.GetBytes(password);
                byte[] hash = sha256.ComputeHash(bytes);
                return Convert.ToBase64String(hash); // Base64로 인코딩하여 저장
            }
        }

    }
}
