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
    public partial class managerMain : Form
    {
        string _server = "localhost"; //DB 서버 주소, 로컬일 경우 localhost
        int _port = 3308; //DB 서버 포트
        string _database = "termdb"; //DB 이름
        string _id = "root"; //계정 아이디
        string _pw = "1234"; //계정 비밀번호
        string _connectionAddress = "";

        public managerMain()
        {
            InitializeComponent();
            _connectionAddress = string.Format("Server={0};Port={1};Database={2};Uid={3};Pwd={4}", _server, _port, _database, _id, _pw);
        }

        private void managerMain_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void applyButton_Click(object sender, EventArgs e)
        {
            applyForm applyFormInstance = new applyForm();
            applyFormInstance.ShowDialog();
        }

        private void memberManageButton_Click(object sender, EventArgs e)
        {
            memberManageForm memberManageFormInstance = new memberManageForm();
            memberManageFormInstance.ShowDialog();
        }

        private void addMovieButton_Click(object sender, EventArgs e)
        {
            addMovieForm addMovieFormInstance = new addMovieForm();
            addMovieFormInstance.ShowDialog();
        }

        private void scheduleButton_Click(object sender, EventArgs e)
        {
            scheduleForm scheduleFormInstance = new scheduleForm();
            scheduleFormInstance.ShowDialog();
        }
        private void discountRateConvertButton_Click(object sender, EventArgs e)
        {
            // 모든 텍스트박스가 채워져 있는지 확인
            if (string.IsNullOrEmpty(vipNumTextBox.Text) ||
                string.IsNullOrEmpty(goldNumTextBox.Text) ||
                string.IsNullOrEmpty(silverNumTextBox.Text))
            {
                MessageBox.Show("모든 등급의 할인율을 입력해주세요.");
                return;
            }

            // 할인율 입력값 검증
            if (!int.TryParse(vipNumTextBox.Text, out int vipRate) ||
                !int.TryParse(goldNumTextBox.Text, out int goldRate) ||
                !int.TryParse(silverNumTextBox.Text, out int silverRate) ||
                vipRate < 0 || vipRate > 100 ||
                goldRate < 0 || goldRate > 100 ||
                silverRate < 0 || silverRate > 100)
            {
                MessageBox.Show("할인율은 0에서 100 사이의 숫자여야 합니다.");
                return;
            }

            // 할인율 업데이트
            using (MySqlConnection connection = new MySqlConnection(_connectionAddress))
            {
                try
                {
                    connection.Open();

                    // VIP 할인율 업데이트
                    string updateVIP = "UPDATE DiscountRates SET DiscountPercentage = @Discount WHERE Level = 'VIP'";
                    MySqlCommand updateVIPCommand = new MySqlCommand(updateVIP, connection);
                    updateVIPCommand.Parameters.AddWithValue("@Discount", vipRate);
                    updateVIPCommand.ExecuteNonQuery();

                    // GOLD 할인율 업데이트
                    string updateGOLD = "UPDATE DiscountRates SET DiscountPercentage = @Discount WHERE Level = 'GOLD'";
                    MySqlCommand updateGOLDCommand = new MySqlCommand(updateGOLD, connection);
                    updateGOLDCommand.Parameters.AddWithValue("@Discount", goldRate);
                    updateGOLDCommand.ExecuteNonQuery();

                    // SILVER 할인율 업데이트
                    string updateSILVER = "UPDATE DiscountRates SET DiscountPercentage = @Discount WHERE Level = 'SILVER'";
                    MySqlCommand updateSILVERCommand = new MySqlCommand(updateSILVER, connection);
                    updateSILVERCommand.Parameters.AddWithValue("@Discount", silverRate);
                    updateSILVERCommand.ExecuteNonQuery();

                    MessageBox.Show("등급별 할인율이 성공적으로 업데이트되었습니다.");

                    // 현재 할인율 갱신
                    UpdateDiscountRates();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"할인율 변경 중 오류 발생: {ex.Message}");
                }
            }
        }

        private void UpdateCounts()
        {
            using (MySqlConnection connection = new MySqlConnection(_connectionAddress))
            {
                try
                {
                    connection.Open();

                    // 가입 신청 대기 인원 수 쿼리
                    string pendingCountQuery = "SELECT COUNT(*) FROM SignupRequests WHERE Status = 'PENDING'";
                    MySqlCommand pendingCommand = new MySqlCommand(pendingCountQuery, connection);
                    int applyUserNum = Convert.ToInt32(pendingCommand.ExecuteScalar());
                    applyUserNumLabel.Text = applyUserNum.ToString(); // applyUserNumLabel에 값 반영

                    // 회원 수 쿼리
                    string userCountQuery = "SELECT COUNT(*) FROM Users";
                    MySqlCommand userCommand = new MySqlCommand(userCountQuery, connection);
                    int userNum = Convert.ToInt32(userCommand.ExecuteScalar());
                    userNumLabel.Text = userNum.ToString(); // userNumLabel에 값 반영
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"데이터 갱신 중 오류 발생: {ex.Message}");
                }
            }
        }

        private void UpdateDiscountRates()
        {
            using (MySqlConnection connection = new MySqlConnection(_connectionAddress))
            {
                try
                {
                    connection.Open();

                    // 할인율 쿼리
                    string query = "SELECT Level, DiscountPercentage FROM DiscountRates";
                    MySqlCommand command = new MySqlCommand(query, connection);
                    MySqlDataReader reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        string level = reader["Level"].ToString();
                        int discountPercentage = Convert.ToInt32(reader["DiscountPercentage"]);

                        if (level == "VIP")
                        {
                            vipNum.Text = $"{discountPercentage}%";
                        }
                        else if (level == "GOLD")
                        {
                            goldNum.Text = $"{discountPercentage}%";
                        }
                        else if (level == "SILVER")
                        {
                            silverNum.Text = $"{discountPercentage}%";
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"할인율 갱신 중 오류 발생: {ex.Message}");
                }
            }
        }


        private void managerMain_Load(object sender, EventArgs e)
        {
            UpdateCounts(); // 가입 신청 인원 및 회원 수 갱신
            UpdateDiscountRates(); // 등급별 할인율 갱신
        }
    }
}
