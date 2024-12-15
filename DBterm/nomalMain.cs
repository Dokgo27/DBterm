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
using static DBterm.scheduleForm;

namespace DBterm
{
    public partial class nomalMain : Form
    {
        string _server = "localhost"; //DB 서버 주소, 로컬일 경우 localhost
        int _port = 3308; //DB 서버 포트
        string _database = "termdb"; //DB 이름
        string _id = "root"; //계정 아이디
        string _pw = "1234"; //계정 비밀번호
        string _connectionAddress = "";

        public nomalMain()
        {
            InitializeComponent();
            _connectionAddress = string.Format("Server={0};Port={1};Database={2};Uid={3};Pwd={4}", _server, _port, _database, _id, _pw);
        }

        private void nomalMain_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void nomalMain_Load(object sender, EventArgs e)
        {
            LoadMovies(); // 영화 정보를 로드합니다.
        }

        private void accountLabel_Click(object sender, EventArgs e)
        {
            accountInfoForm accountInfoFormInstance = new accountInfoForm();
            accountInfoFormInstance.ShowDialog();
        }

        private void reservationInfoLabel_Click(object sender, EventArgs e)
        {
            reservationInfoForm reservationInfoFormInstance = new reservationInfoForm();
            reservationInfoFormInstance.ShowDialog();
        }

        private void movieInfoButton_Click(object sender, EventArgs e)
        {
            if (movieListBox.SelectedItem is MovieItem selectedMovie)
            {
                using (MySqlConnection connection = new MySqlConnection(_connectionAddress))
                {
                    try
                    {
                        connection.Open();

                        // Query to fetch movie details
                        string query = "SELECT Title, Genre, Director, LeadActors, Poster FROM Movies WHERE MovieId = @MovieId";
                        MySqlCommand command = new MySqlCommand(query, connection);
                        command.Parameters.AddWithValue("@MovieId", selectedMovie.MovieId);

                        MySqlDataReader reader = command.ExecuteReader();

                        if (reader.Read())
                        {
                            // 영화 정보를 표시할 새 폼 생성
                            movieInfoForm infoForm = new movieInfoForm();

                            // 속성을 통해 값 설정
                            infoForm.MovieTitle = reader["Title"].ToString();
                            infoForm.MovieGenre = reader["Genre"].ToString();
                            infoForm.MovieDirector = reader["Director"].ToString();
                            infoForm.LeadActors = reader["LeadActors"].ToString();

                            // 포스터 이미지 처리
                            if (reader["Poster"] != DBNull.Value)
                            {
                                byte[] posterBytes = (byte[])reader["Poster"];
                                using (MemoryStream ms = new MemoryStream(posterBytes))
                                {
                                    infoForm.PosterImage = Image.FromStream(ms);
                                }
                            }

                            // 폼을 모달로 표시
                            infoForm.ShowDialog();
                        }
                        else
                        {
                            MessageBox.Show("영화 정보를 찾을 수 없습니다.");
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"영화 정보를 로드하는 중 오류 발생: {ex.Message}");
                    }
                }
            }
            else
            {
                MessageBox.Show("영화를 선택하세요.");
            }
        }

        // 예매하러 가는 버튼
        private void reserveButton_Click(object sender, EventArgs e)
        {
            if (movieListBox.SelectedItem is MovieItem selectedMovie &&
                roomListBox.SelectedItem != null &&
                timeListBox.SelectedItem != null)
            {
                // 선택된 정보
                string selectedRoom = roomListBox.SelectedItem.ToString();
                string selectedDate = datePicker.Value.ToString("yyyy-MM-dd");
                string selectedTime = timeListBox.SelectedItem.ToString();

                // 선택된 상영 시간의 DateTime 객체 생성
                DateTime selectedDateTime;
                if (!DateTime.TryParse($"{selectedDate} {selectedTime}", out selectedDateTime))
                {
                    MessageBox.Show("유효한 날짜 및 시간을 선택하세요.");
                    return;
                }

                // 현재 시간과 비교
                if (selectedDateTime <= DateTime.Now)
                {
                    MessageBox.Show("현재 시간보다 이전 시간으로는 예매를 할 수 없습니다.");
                    return;
                }

                // RoomId 추출
                if (int.TryParse(selectedRoom.Replace("관", "").Trim(), out int roomId))
                {
                    // 좌석 배치 가져오기
                    string seatLayout = GetSeatLayoutByRoomId(roomId);

                    if (!string.IsNullOrEmpty(seatLayout))
                    {
                        // reservationForm 인스턴스 생성
                        reservationForm resForm = new reservationForm(selectedMovie.Title, selectedRoom, selectedDate, selectedTime, seatLayout);

                        // 예약 폼 표시
                        resForm.ShowDialog();
                    }
                    else
                    {
                        MessageBox.Show("해당 상영관의 좌석 정보를 가져올 수 없습니다.");
                    }
                }
                else
                {
                    MessageBox.Show("유효한 상영관을 선택해주세요.");
                }
            }
            else
            {
                MessageBox.Show("영화, 상영관, 날짜 및 시간을 선택해주세요.");
            }
        }


        // 극장 정보 로드 - 특정 영화를 선택하면 해당 영화가 상영되는 극장 정보 표시
        private void LoadMovies()
        {
            using (MySqlConnection connection = new MySqlConnection(_connectionAddress))
            {
                try
                {
                    connection.Open();
                    string query = "SELECT DISTINCT Movies.MovieId, Movies.Title " +
                                   "FROM MovieSchedules " +
                                   "JOIN Movies ON MovieSchedules.MovieId = Movies.MovieId";
                    MySqlCommand command = new MySqlCommand(query, connection);
                    MySqlDataReader reader = command.ExecuteReader();

                    movieListBox.Items.Clear();
                    while (reader.Read())
                    {
                        movieListBox.Items.Add(new MovieItem
                        {
                            MovieId = Convert.ToInt32(reader["MovieId"]),
                            Title = reader["Title"].ToString()
                        });
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"영화 목록 로드 중 오류 발생: {ex.Message}");
                }
            }
        }
        // 상영 시간 정보 로드 - 선택된 영화, 극장, 날짜 기반으로 상영 시간 표시
        private void LoadScreeningTimes()
        {
            if (movieListBox.SelectedItem is MovieItem selectedMovie && roomListBox.SelectedItem != null)
            {
                // roomListBox의 선택 항목에서 숫자를 안전하게 추출
                string roomText = roomListBox.SelectedItem.ToString();
                if (!roomText.Contains("관") || !int.TryParse(roomText.Replace("관", "").Trim(), out int roomId))
                {
                    MessageBox.Show("유효한 극장 정보를 선택하세요.");
                    return;
                }

                DateTime selectedDate = datePicker.Value.Date;

                using (MySqlConnection connection = new MySqlConnection(_connectionAddress))
                {
                    try
                    {
                        connection.Open();
                        string query = "SELECT ScreeningTime " +
                                       "FROM MovieSchedules " +
                                       "WHERE MovieId = @MovieId AND RoomId = @RoomId AND DATE(ScreeningTime) = @SelectedDate";
                        MySqlCommand command = new MySqlCommand(query, connection);
                        command.Parameters.AddWithValue("@MovieId", selectedMovie.MovieId);
                        command.Parameters.AddWithValue("@RoomId", roomId);
                        command.Parameters.AddWithValue("@SelectedDate", selectedDate);

                        MySqlDataReader reader = command.ExecuteReader();
                        timeListBox.Items.Clear();

                        while (reader.Read())
                        {
                            DateTime time = reader.GetDateTime("ScreeningTime");
                            timeListBox.Items.Add(time.ToString("HH:mm"));
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"상영 시간 정보 로드 중 오류 발생: {ex.Message}");
                    }
                }
            }
        }


        // 예매 정보 표시 - 영화, 극장, 날짜, 시간 선택 시 자동으로 하단 텍스트박스에 값 표시
        private void UpdateSelectedInfo()
        {
            if (movieListBox.SelectedItem is MovieItem selectedMovie)
                selectedMovieTextBox.Text = selectedMovie.Title;

            if (roomListBox.SelectedItem != null)
                selectedRoomTextBox.Text = roomListBox.SelectedItem.ToString();

            selectedDateTextBox.Text = datePicker.Value.ToString("yyyy년 MM월 dd일");

            if (timeListBox.SelectedItem != null)
                selectedTimeTextBox.Text = timeListBox.SelectedItem.ToString();
        }

        private void movieListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (movieListBox.SelectedItem is MovieItem selectedMovie)
            {
                using (MySqlConnection connection = new MySqlConnection(_connectionAddress))
                {
                    try
                    {
                        connection.Open();
                        string query = "SELECT DISTINCT RoomId FROM MovieSchedules WHERE MovieId = @MovieId";
                        MySqlCommand command = new MySqlCommand(query, connection);
                        command.Parameters.AddWithValue("@MovieId", selectedMovie.MovieId);

                        MySqlDataReader reader = command.ExecuteReader();
                        roomListBox.Items.Clear();

                        while (reader.Read())
                        {
                            int roomId = reader.GetInt32("RoomId");
                            roomListBox.Items.Add($"{roomId}관"); // 항목 형식 유지
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"극장 정보 로드 중 오류 발생: {ex.Message}");
                    }
                }

                UpdateSelectedInfo(); // 선택한 영화 정보 업데이트
            }
        }

        private string GetSeatLayoutByRoomId(int roomId)
        {
            string seatLayout = string.Empty;

            using (MySqlConnection connection = new MySqlConnection(_connectionAddress))
            {
                try
                {
                    connection.Open();
                    string query = "SELECT SeatLayout FROM ScreeningRooms WHERE RoomId = @RoomId";
                    MySqlCommand command = new MySqlCommand(query, connection);
                    command.Parameters.AddWithValue("@RoomId", roomId);

                    object result = command.ExecuteScalar();
                    if (result != null)
                    {
                        seatLayout = result.ToString();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"좌석 정보를 가져오는 중 오류 발생: {ex.Message}");
                }
            }

            return seatLayout;
        }

        private void roomListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadScreeningTimes(); // 상영 시간 정보 로드
            UpdateSelectedInfo(); // 선택한 극장 정보 업데이트
        }

        private void timeListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateSelectedInfo(); // 선택한 시간 정보 업데이트
        }

        private void datePicker_ValueChanged(object sender, EventArgs e)
        {
            LoadScreeningTimes(); // 날짜 변경 시 상영 시간 갱신
        }
    }
}
