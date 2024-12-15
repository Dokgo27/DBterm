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
    public partial class reservationForm : Form
    {
        string _server = "localhost"; //DB 서버 주소, 로컬일 경우 localhost
        int _port = 3308; //DB 서버 포트
        string _database = "termdb"; //DB 이름
        string _id = "root"; //계정 아이디
        string _pw = "1234"; //계정 비밀번호
        string _connectionAddress = "";

        private string movieTitle;
        private string roomName;
        private string date;
        private string time;
        private string seatLayout;
        private List<Button> selectedSeats = new List<Button>();

        public reservationForm(string movieTitle, string roomName, string date, string time, string seatLayout)
        {
            InitializeComponent();
            _connectionAddress = string.Format("Server={0};Port={1};Database={2};Uid={3};Pwd={4}", _server, _port, _database, _id, _pw);

            this.movieTitle = movieTitle;
            this.roomName = roomName;
            this.date = date;
            this.time = time;
            this.seatLayout = seatLayout;

            DisplayReservationInfo();
            GenerateSeats(seatLayout); // 레이아웃에 따라서 좌석을 생성

            // Form Load 이벤트 핸들러 추가
            this.Load += reservationForm_Load;
        }
        private void GenerateSeats(string layout)
        {
            // 기존 좌석 초기화
            seatPanel.Controls.Clear();
            seatPanel.RowStyles.Clear();
            seatPanel.ColumnStyles.Clear();

            // Layout 파싱 (예: "A열:3x10,B열:2x10,C열:3x8")
            string[] rows = layout.Split(',');
            int currentRowIndex = 0;
            int totalRows = rows.Sum(row =>
            {
                var parts = row.Split(':');
                if (parts.Length != 2) return 0;
                var rowConfig = parts[1].Split('x');
                if (rowConfig.Length != 2) return 0;
                return int.Parse(rowConfig[0]); // 각 열의 행 개수 합산
            });
            int maxColumns = rows.Max(row =>
            {
                var parts = row.Split(':');
                if (parts.Length != 2) return 0;
                var rowConfig = parts[1].Split('x');
                if (rowConfig.Length != 2) return 0;
                return int.Parse(rowConfig[1]); // 열 개수 중 최대값
            });

            // TableLayoutPanel 행(Row) 및 열(Column) 설정
            seatPanel.RowCount = totalRows;
            seatPanel.ColumnCount = maxColumns;

            // RowStyles와 ColumnStyles 설정
            for (int i = 0; i < totalRows; i++)
            {
                seatPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 100f / totalRows));
            }
            for (int j = 0; j < maxColumns; j++)
            {
                seatPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100f / maxColumns));
            }

            // 좌석 버튼 생성
            foreach (string row in rows)
            {
                string[] rowInfo = row.Split(':');
                if (rowInfo.Length != 2) continue;

                string rowName = rowInfo[0].Trim(); // A열, B열 등
                string[] dimensions = rowInfo[1].Split('x');
                if (dimensions.Length != 2) continue;

                int rowCount = int.Parse(dimensions[0]); // 몇 행인지
                int seatCount = int.Parse(dimensions[1]); // 좌석 개수

                for (int r = 0; r < rowCount; r++)
                {
                    for (int c = 0; c < seatCount; c++)
                    {
                        Button seatButton = new Button
                        {
                            Text = $"{rowName}{r + 1}-{c + 1}", // 예: A1-1
                            Size = new Size(50, 50),
                            BackColor = Color.LightGreen,
                            Tag = $"{rowName}{r + 1}-{c + 1}" // 좌석 고유 ID
                        };

                        seatButton.Click += SeatButton_Click;
                        seatPanel.Controls.Add(seatButton, c, currentRowIndex + r); // 정확한 좌표에 추가
                    }
                }

                currentRowIndex += rowCount; // 다음 열로 이동
            }
        }

        private void SeatButton_Click(object sender, EventArgs e)
        {
            if (sender is Button seatButton)
            {
                if (selectedSeats.Contains(seatButton))
                {
                    // 선택 취소
                    selectedSeats.Remove(seatButton);
                    seatButton.BackColor = Color.LightGreen;
                }
                else
                {
                    if (selectedSeats.Count >= 3)
                    {
                        MessageBox.Show("최대 3개의 좌석만 선택할 수 있습니다.");
                        return;
                    }
                    // 선택
                    selectedSeats.Add(seatButton);
                    seatButton.BackColor = Color.Red;
                }

                UpdateSelectedSeatInfo();
            }
        }

        private void UpdateSelectedSeatInfo()
        {
            // 선택된 좌석 정보를 갱신
            var selectedRows = selectedSeats
                .Select(s => s.Tag.ToString().Split('-')[0]) // 열 정보 추출 (A1, B2 등)
                .Distinct(); // 중복 제거

            var selectedSeatsNumbers = selectedSeats
                .Select(s => s.Tag.ToString().Split('-')[1]) // 좌석 번호 추출 (1, 2 등)
                .Distinct(); // 중복 제거

            colNumLabel.Text = string.Join(", ", selectedRows); // 열 정보 표시
            locationNumLabel.Text = string.Join(", ", selectedSeatsNumbers); // 좌석 번호 표시

            // 선택된 좌석 수에 따른 할인된 가격 계산
            CalculateDiscountedPrice();
        }

        private void CalculateDiscountedPrice()
        {
            using (MySqlConnection connection = new MySqlConnection(_connectionAddress))
            {
                try
                {
                    connection.Open();

                    // 상영 일정의 TicketPrice 가져오기
                    string queryTicketPrice = @"
                                                SELECT TicketPrice
                                                FROM MovieSchedules
                                                WHERE MovieId = (SELECT MovieId FROM Movies WHERE Title = @MovieTitle)
                                                AND RoomId = @RoomId
                                                AND ScreeningTime = @ScreeningTime";

                    MySqlCommand command = new MySqlCommand(queryTicketPrice, connection);
                    command.Parameters.AddWithValue("@MovieTitle", movieTitle);
                    command.Parameters.AddWithValue("@RoomId", int.Parse(roomName.Replace("관", "").Trim()));
                    command.Parameters.AddWithValue("@ScreeningTime", DateTime.Parse($"{date} {time}"));

                    object ticketPriceObj = command.ExecuteScalar();

                    if (ticketPriceObj != null && decimal.TryParse(ticketPriceObj.ToString(), out decimal ticketPrice))
                    {
                        // 사용자의 등급 가져오기
                        string userLevel = !string.IsNullOrEmpty(LoggedInUser.UserLevel) ? LoggedInUser.UserLevel : "SILVER";

                        // 할인율 가져오기
                        string queryDiscountRate = "SELECT DiscountPercentage FROM DiscountRates WHERE Level = @UserLevel";
                        MySqlCommand discountCommand = new MySqlCommand(queryDiscountRate, connection);
                        discountCommand.Parameters.AddWithValue("@UserLevel", userLevel);
                        object discountPercentageObj = discountCommand.ExecuteScalar();

                        decimal discountRate = discountPercentageObj != null && decimal.TryParse(discountPercentageObj.ToString(), out decimal discount)
                            ? discount / 100
                            : 0;

                        // 좌석 수에 따른 최종 가격 계산
                        decimal totalPrice = selectedSeats.Count * ticketPrice * (1 - discountRate);
                        priceLabel.Text = $"{totalPrice:C}";
                    }
                    else
                    {
                        MessageBox.Show("티켓 가격을 불러오는 중 오류가 발생했습니다.");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"가격 계산 중 오류 발생: {ex.Message}");
                }
            }
        }

        private void DisplayReservationInfo()
        {
            // 좌석 레이아웃 및 예약 정보를 폼에 표시
            titleLabel.Text = movieTitle;
            theaterNumLabel.Text = roomName;
            reservationDateLabel.Text = date;
            timeLabel.Text = time;
        }

        private void checkButton_Click(object sender, EventArgs e)
        {
            if (selectedSeats.Count == 0)
            {
                MessageBox.Show("최소 하나의 좌석을 선택해야 합니다.");
                return;
            }

            string paymentMethod = cashRadioButton.Checked ? "Cash" : "Card";
            decimal totalPrice = 0;

            using (MySqlConnection connection = new MySqlConnection(_connectionAddress))
            {
                try
                {
                    connection.Open();

                    // TicketPrice 가져오기
                    string queryTicketPrice = @"
                                        SELECT TicketPrice
                                        FROM MovieSchedules
                                        WHERE MovieId = (SELECT MovieId FROM Movies WHERE Title = @MovieTitle)
                                        AND RoomId = @RoomId
                                        AND ScreeningTime = @ScreeningTime";

                    MySqlCommand ticketPriceCommand = new MySqlCommand(queryTicketPrice, connection);
                    ticketPriceCommand.Parameters.AddWithValue("@MovieTitle", movieTitle);
                    ticketPriceCommand.Parameters.AddWithValue("@RoomId", int.Parse(roomName.Replace("관", "").Trim()));
                    ticketPriceCommand.Parameters.AddWithValue("@ScreeningTime", DateTime.Parse($"{date} {time}"));
                    object ticketPriceObj = ticketPriceCommand.ExecuteScalar();

                    if (ticketPriceObj == null || !decimal.TryParse(ticketPriceObj.ToString(), out decimal ticketPrice))
                    {
                        MessageBox.Show("티켓 가격을 불러오는 중 오류가 발생했습니다.");
                        return;
                    }

                    // 할인율 적용
                    string userLevel = LoggedInUser.UserLevel ?? "SILVER";
                    string queryDiscountRate = "SELECT DiscountPercentage FROM DiscountRates WHERE Level = @UserLevel";
                    MySqlCommand discountCommand = new MySqlCommand(queryDiscountRate, connection);
                    discountCommand.Parameters.AddWithValue("@UserLevel", userLevel);
                    object discountPercentageObj = discountCommand.ExecuteScalar();

                    decimal discountRate = discountPercentageObj != null && decimal.TryParse(discountPercentageObj.ToString(), out decimal discount)
                        ? discount / 100
                        : 0;

                    totalPrice = selectedSeats.Count * ticketPrice * (1 - discountRate);

                    // 각 좌석 정보에 대해 예약 데이터 저장
                    foreach (var seat in selectedSeats)
                    {
                        string fullSeatInfo = seat.Tag.ToString(); // A1-1 형식
                        string[] seatParts = fullSeatInfo.Split('-');
                        if (seatParts.Length != 2)
                        {
                            MessageBox.Show("좌석 정보가 잘못되었습니다.");
                            continue;
                        }

                        string rowNumber = seatParts[0]; // A1
                        string seatNumber = seatParts[1]; // 1

                        string insertQuery = @"
                                       INSERT INTO reservation
                                       (MovieName, TheaterID, ReservationDate, ReservationTime, PaymentMethod, Amount, RowNumber, SeatNumber, MemberID)
                                       VALUES
                                       (@MovieName, @TheaterID, @ReservationDate, @ReservationTime, @PaymentMethod, @Amount, @RowNumber, @SeatNumber, @MemberID)";
                        MySqlCommand insertCommand = new MySqlCommand(insertQuery, connection);
                        insertCommand.Parameters.AddWithValue("@MovieName", movieTitle);
                        insertCommand.Parameters.AddWithValue("@TheaterID", roomName);
                        insertCommand.Parameters.AddWithValue("@ReservationDate", DateTime.Parse(date).ToString("yyyy-MM-dd"));
                        insertCommand.Parameters.AddWithValue("@ReservationTime", time);
                        insertCommand.Parameters.AddWithValue("@PaymentMethod", paymentMethod);
                        insertCommand.Parameters.AddWithValue("@Amount", ticketPrice * (1 - discountRate));
                        insertCommand.Parameters.AddWithValue("@RowNumber", rowNumber);
                        insertCommand.Parameters.AddWithValue("@SeatNumber", seatNumber);
                        insertCommand.Parameters.AddWithValue("@MemberID", LoggedInUser.UserId);

                        insertCommand.ExecuteNonQuery();
                    }

                    MessageBox.Show($"예약이 완료되었습니다!\n총 금액: {totalPrice:C}");
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"예약 처리 중 오류가 발생했습니다: {ex.Message}");
                }
            }
        }

        // 예약된 좌석의 정보를 가지고 예약되어있으면 예약을 할 수 없게 한다.
        private void LoadReservedSeats()
        {
            using (MySqlConnection connection = new MySqlConnection(_connectionAddress))
            {
                try
                {
                    connection.Open();

                    // 현재 상영 정보에 대한 예약된 좌석 가져오기
                    string queryReservedSeats = @"
                SELECT RowNumber, SeatNumber
                FROM reservation
                WHERE MovieName = @MovieName
                  AND TheaterID = @TheaterID
                  AND ReservationDate = @ReservationDate
                  AND ReservationTime = @ReservationTime";

                    MySqlCommand command = new MySqlCommand(queryReservedSeats, connection);
                    command.Parameters.AddWithValue("@MovieName", movieTitle);
                    command.Parameters.AddWithValue("@TheaterID", roomName);
                    command.Parameters.AddWithValue("@ReservationDate", DateTime.Parse(date).ToString("yyyy-MM-dd"));
                    command.Parameters.AddWithValue("@ReservationTime", time);

                    using (MySqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            string rowNumber = reader["RowNumber"].ToString(); // 열 정보 (예: A1)
                            string seatNumber = reader["SeatNumber"].ToString(); // 좌석 번호 (예: 1)
                            string fullSeatInfo = $"{rowNumber}-{seatNumber}"; // 좌석 고유 정보 (예: A1-1)

                            // 해당 좌석을 예약된 상태로 설정
                            foreach (Button button in seatPanel.Controls.OfType<Button>())
                            {
                                if (button.Tag.ToString() == fullSeatInfo)
                                {
                                    button.BackColor = Color.Red; // 예약된 좌석은 빨간색으로 설정
                                    button.Enabled = false; // 예약된 좌석은 선택할 수 없게 비활성화
                                }
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"예약 정보를 불러오는 중 오류가 발생했습니다: {ex.Message}");
                }
            }
        }


        private void reservationForm_Load(object sender, EventArgs e)
        {
            // LoggedInUser의 UserId를 userIdLabel에 표시
            useridLabel.Text = !string.IsNullOrEmpty(LoggedInUser.UserId) ? LoggedInUser.UserId : "알 수 없음";
            userlevelLabel.Text = !string.IsNullOrEmpty(LoggedInUser.UserLevel) ? LoggedInUser.UserLevel : "알 수 없음";

            // 예약된 좌석 정보를 가져와서 설정
            LoadReservedSeats();
        }
    }
}
