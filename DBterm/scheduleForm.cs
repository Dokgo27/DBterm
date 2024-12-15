using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DBterm
{
    public partial class scheduleForm : Form
    {
        string _server = "localhost"; //DB 서버 주소, 로컬일 경우 localhost
        int _port = 3308; //DB 서버 포트
        string _database = "termdb"; //DB 이름
        string _id = "root"; //계정 아이디
        string _pw = "1234"; //계정 비밀번호
        string _connectionAddress = "";
        public scheduleForm()
        {
            InitializeComponent();
            _connectionAddress = string.Format("Server={0};Port={1};Database={2};Uid={3};Pwd={4}", _server, _port, _database, _id, _pw);
        }

        private void scheduleForm_Load(object sender, EventArgs e)
        {
            // 상영관 ComboBox 초기화
            roomComboBox.Items.AddRange(new string[] { "1관", "2관", "3관" });
            roomComboBox.SelectedIndex = 0;

            // 영화 ComboBox 초기화
            LoadMoviesIntoComboBox();
        }

        // DB에서 영화 정보 로드하여 ComboBox에 추가
        private void LoadMoviesIntoComboBox()
        {
            using (MySqlConnection connection = new MySqlConnection(_connectionAddress))
            {
                try
                {
                    connection.Open();
                    string query = "SELECT MovieId, Title FROM Movies"; // Movies 테이블에서 영화 정보 가져오기
                    MySqlCommand command = new MySqlCommand(query, connection);
                    MySqlDataReader reader = command.ExecuteReader();

                    movieComboBox.Items.Clear(); // ComboBox 초기화

                    while (reader.Read())
                    {
                        // MovieItem 객체를 추가
                        movieComboBox.Items.Add(new MovieItem
                        {
                            MovieId = Convert.ToInt32(reader["MovieId"]),
                            Title = reader["Title"].ToString()
                        });
                    }

                    if (movieComboBox.Items.Count > 0)
                        movieComboBox.SelectedIndex = 0; // 첫 번째 영화 선택
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"영화 정보를 로드하는 중 오류 발생: {ex.Message}");
                }
            }
        }

        // 등록 버튼 클릭
        private void addScheduleButton_Click(object sender, EventArgs e)
        {
            if (roomComboBox.SelectedIndex < 0)
            {
                MessageBox.Show("상영관을 선택하세요.");
                return;
            }

            if (!(movieComboBox.SelectedItem is MovieItem selectedMovie))
            {
                MessageBox.Show("영화를 선택하세요.");
                return;
            }

            int roomId = roomComboBox.SelectedIndex + 1; // 1관, 2관, 3관
            int movieId = selectedMovie.MovieId; // 선택된 영화 ID

            DateTime selectedDate = timePicker.Value.Date; // DatePicker에서 선택된 날짜
            int hour, minute;

            // 시간 입력 확인 및 변환
            if (!int.TryParse(hourTextBox.Text.Trim(), out hour) || hour < 0 || hour > 23)
            {
                MessageBox.Show("유효한 시간을 입력하세요 (0~23).");
                return;
            }

            if (!int.TryParse(minuteTextBox.Text.Trim(), out minute) || minute < 0 || minute > 59)
            {
                MessageBox.Show("유효한 분을 입력하세요 (0~59).");
                return;
            }

            // 날짜와 시간 결합
            DateTime screeningTime = selectedDate.AddHours(hour).AddMinutes(minute);

            decimal ticketPrice;

            if (!decimal.TryParse(priceTextBox.Text.Trim(), out ticketPrice))
            {
                MessageBox.Show("유효한 요금을 입력하세요.");
                return;
            }

            using (MySqlConnection connection = new MySqlConnection(_connectionAddress))
            {
                try
                {
                    connection.Open();
                    string query = "INSERT INTO MovieSchedules (MovieId, RoomId, ScreeningTime, TicketPrice) VALUES (@MovieId, @RoomId, @ScreeningTime, @TicketPrice)";
                    MySqlCommand command = new MySqlCommand(query, connection);
                    command.Parameters.AddWithValue("@MovieId", movieId);
                    command.Parameters.AddWithValue("@RoomId", roomId);
                    command.Parameters.AddWithValue("@ScreeningTime", screeningTime);
                    command.Parameters.AddWithValue("@TicketPrice", ticketPrice);

                    command.ExecuteNonQuery();
                    MessageBox.Show("상영 시간표가 성공적으로 등록되었습니다.");
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"상영 시간표 등록 중 오류 발생: {ex.Message}");
                }
            }
        }


        // 취소 버튼 클릭
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


        // 상영관 콤보박스 이벤트 처리
        private void roomComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            string room = roomComboBox.SelectedItem.ToString();

            if (room == "1관")
                seatLayoutTextBox.Text = "A열: 3x10\nB열: 3x10";
            else if (room == "2관")
                seatLayoutTextBox.Text = "A열: 2x10\nB열: 2x10\nC열: 2x10";
            else if (room == "3관")
                seatLayoutTextBox.Text = "A열: 3x8\nB열: 3x8";
        }

        // ComboBox에서 사용할 영화 데이터 클래스
        public class MovieItem
        {
            public int MovieId { get; set; } // 영화 ID
            public string Title { get; set; } // 영화 제목

            public override string ToString()
            {
                return Title; // ComboBox에 표시될 텍스트
            }
        }

    }
}
