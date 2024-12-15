using MySql.Data.MySqlClient;
using System;
using System.Text;
using System.Windows.Forms;

namespace DBterm
{
    public partial class reservationInfoForm : Form
    {
        string _server = "localhost"; //DB 서버 주소, 로컬일 경우 localhost
        int _port = 3308; //DB 서버 포트
        string _database = "termdb"; //DB 이름
        string _id = "root"; //계정 아이디
        string _pw = "1234"; //계정 비밀번호
        string _connectionAddress = "";

        public reservationInfoForm()
        {
            InitializeComponent();
            _connectionAddress = string.Format("Server={0};Port={1};Database={2};Uid={3};Pwd={4}", _server, _port, _database, _id, _pw);

            // ListView 초기 설정
            reservationListView.View = View.Details;
            reservationListView.Columns.Add("영화", 150);
            reservationListView.Columns.Add("상영관", 100);
            reservationListView.Columns.Add("날짜", 120);
            reservationListView.Columns.Add("시간", 100);
            reservationListView.Columns.Add("좌석", 150);
            reservationListView.Columns.Add("금액", 100); // 금액 열 추가
            reservationListView.FullRowSelect = true;
        }

        private void reservationInfoForm_Load(object sender, EventArgs e)
        {
            userIdLabel.Text = LoggedInUser.UserId; // 현재 로그인한 사용자 아이디를 라벨에 표시
            LoadReservations(); // 예약 정보를 로드합니다.
        }

        private void LoadReservations()
        {
            using (MySqlConnection connection = new MySqlConnection(_connectionAddress))
            {
                try
                {
                    connection.Open();

                    string query = @"
                        SELECT MovieName, TheaterID, ReservationDate, ReservationTime, RowNumber, SeatNumber, Amount
                        FROM reservation
                        WHERE MemberID = @UserId
                        AND CONCAT(ReservationDate, ' ', ReservationTime) > NOW()";

                    MySqlCommand command = new MySqlCommand(query, connection);
                    command.Parameters.AddWithValue("@UserId", LoggedInUser.UserId);

                    using (MySqlDataReader reader = command.ExecuteReader())
                    {
                        reservationListView.Items.Clear(); // 기존 항목 초기화

                        while (reader.Read())
                        {
                            string[] row = new string[]
                            {
                                reader["MovieName"].ToString(),
                                reader["TheaterID"].ToString(),
                                Convert.ToDateTime(reader["ReservationDate"]).ToString("yyyy-MM-dd"),
                                reader["ReservationTime"].ToString(),
                                $"{reader["RowNumber"]}-{reader["SeatNumber"]}",
                                $"{reader["Amount"]:C}" // 금액 형식으로 표시
                            };
                            reservationListView.Items.Add(new ListViewItem(row));
                        }
                    }

                    if (reservationListView.Items.Count == 0)
                    {
                        MessageBox.Show("현재 예약된 정보가 없습니다.");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"예약 정보를 불러오는 중 오류가 발생했습니다: {ex.Message}");
                }
            }
        }

        private void reservationCancelButton_Click(object sender, EventArgs e)
        {
            if (reservationListView.SelectedItems.Count == 0)
            {
                MessageBox.Show("취소할 예약을 선택하세요.");
                return;
            }

            var selectedItem = reservationListView.SelectedItems[0];
            string movieName = selectedItem.SubItems[0].Text;
            string theaterId = selectedItem.SubItems[1].Text;
            string reservationDate = selectedItem.SubItems[2].Text;
            string reservationTime = selectedItem.SubItems[3].Text;

            DialogResult result = MessageBox.Show("선택한 예약을 취소하시겠습니까?", "예약 취소 확인", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (result == DialogResult.Yes)
            {
                using (MySqlConnection connection = new MySqlConnection(_connectionAddress))
                {
                    try
                    {
                        connection.Open();

                        string deleteQuery = @"
                            DELETE FROM reservation
                            WHERE MemberID = @UserId
                            AND MovieName = @MovieName
                            AND TheaterID = @TheaterID
                            AND ReservationDate = @ReservationDate
                            AND ReservationTime = @ReservationTime";

                        MySqlCommand deleteCommand = new MySqlCommand(deleteQuery, connection);
                        deleteCommand.Parameters.AddWithValue("@UserId", LoggedInUser.UserId);
                        deleteCommand.Parameters.AddWithValue("@MovieName", movieName);
                        deleteCommand.Parameters.AddWithValue("@TheaterID", theaterId);
                        deleteCommand.Parameters.AddWithValue("@ReservationDate", reservationDate);
                        deleteCommand.Parameters.AddWithValue("@ReservationTime", reservationTime);

                        deleteCommand.ExecuteNonQuery();

                        MessageBox.Show("예약이 성공적으로 취소되었습니다.");
                        LoadReservations(); // 업데이트된 예약 정보 다시 로드
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"예약 취소 중 오류가 발생했습니다: {ex.Message}");
                    }
                }
            }
        }
    }
}
