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

namespace DBterm
{
    public partial class accountInfoForm : Form
    {
        string _server = "localhost"; //DB 서버 주소, 로컬일 경우 localhost
        int _port = 3308; //DB 서버 포트
        string _database = "termdb"; //DB 이름
        string _id = "root"; //계정 아이디
        string _pw = "1234"; //계정 비밀번호
        string _connectionAddress = "";

        public accountInfoForm()
        {
            InitializeComponent();
            _connectionAddress = string.Format("Server={0};Port={1};Database={2};Uid={3};Pwd={4}", _server, _port, _database, _id, _pw);
        }

        private void accountInfoForm_Load(object sender, EventArgs e)
        {
            // LoggedInUser의 기본 정보를 라벨에 표시
            nameLabel.Text = LoggedInUser.UserName;
            UserIdLabel.Text = LoggedInUser.UserId;
            userLevelLabel.Text = LoggedInUser.UserLevel;

            // 전화번호와 카드번호는 DB에서 가져옴
            using (MySqlConnection connection = new MySqlConnection(_connectionAddress))
            {
                try
                {
                    connection.Open();

                    string query = "SELECT PhoneNumber, CardNumber FROM users WHERE UserId = @UserId";
                    MySqlCommand command = new MySqlCommand(query, connection);
                    command.Parameters.AddWithValue("@UserId", LoggedInUser.UserId);

                    using (MySqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            phoneNumLabel.Text = reader["PhoneNumber"].ToString();
                            cardNumLabel.Text = reader["CardNumber"].ToString();
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"정보를 불러오는 중 오류가 발생했습니다: {ex.Message}");
                }
            }
        }

        private void checkButton_Click(object sender, EventArgs e)
        {
            string newPassword = passwordTextBox.Text.Trim();
            string confirmPassword = passwordCheckTextBox.Text.Trim();
            string newPhoneNumber = phoneNumTextBox.Text.Trim();
            string newCardNumber = cardNumTextBox.Text.Trim();

            if (!string.IsNullOrEmpty(newPassword) && newPassword != confirmPassword)
            {
                MessageBox.Show("비밀번호와 비밀번호 확인이 일치하지 않습니다.");
                return;
            }

            using (MySqlConnection connection = new MySqlConnection(_connectionAddress))
            {
                try
                {
                    connection.Open();

                    if (!string.IsNullOrEmpty(newPassword))
                    {
                        // 비밀번호 해싱
                        string hashedPassword = HashPassword(newPassword);

                        // 해싱된 비밀번호 수정
                        string updatePasswordQuery = "UPDATE users SET Password = @Password WHERE UserId = @UserId";
                        MySqlCommand passwordCommand = new MySqlCommand(updatePasswordQuery, connection);
                        passwordCommand.Parameters.AddWithValue("@Password", hashedPassword);
                        passwordCommand.Parameters.AddWithValue("@UserId", LoggedInUser.UserId);
                        passwordCommand.ExecuteNonQuery();
                    }

                    if (!string.IsNullOrEmpty(newPhoneNumber))
                    {
                        // 전화번호 수정
                        string updatePhoneQuery = "UPDATE users SET PhoneNumber = @PhoneNumber WHERE UserId = @UserId";
                        MySqlCommand phoneCommand = new MySqlCommand(updatePhoneQuery, connection);
                        phoneCommand.Parameters.AddWithValue("@PhoneNumber", newPhoneNumber);
                        phoneCommand.Parameters.AddWithValue("@UserId", LoggedInUser.UserId);
                        phoneCommand.ExecuteNonQuery();
                    }

                    if (!string.IsNullOrEmpty(newCardNumber))
                    {
                        // 카드번호 수정
                        string updateCardQuery = "UPDATE users SET CardNumber = @CardNumber WHERE UserId = @UserId";
                        MySqlCommand cardCommand = new MySqlCommand(updateCardQuery, connection);
                        cardCommand.Parameters.AddWithValue("@CardNumber", newCardNumber);
                        cardCommand.Parameters.AddWithValue("@UserId", LoggedInUser.UserId);
                        cardCommand.ExecuteNonQuery();
                    }

                    MessageBox.Show("계정 정보가 성공적으로 업데이트되었습니다.");

                    // 변경된 정보를 라벨에 반영
                    accountInfoForm_Load(sender, e);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"계정 정보를 업데이트하는 중 오류가 발생했습니다: {ex.Message}");
                }
            }
        }

        private void backButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void userDeleteButton_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show(
                "정말 회원 탈퇴를 하시겠습니까? 모든 예약 정보도 삭제됩니다.",
                "회원 탈퇴 확인",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning
            );

            if (result == DialogResult.Yes)
            {
                using (MySqlConnection connection = new MySqlConnection(_connectionAddress))
                {
                    try
                    {
                        connection.Open();

                        // 회원 예약 정보 삭제
                        string deleteReservationsQuery = "DELETE FROM reservation WHERE MemberID = @UserId";
                        MySqlCommand deleteReservationsCommand = new MySqlCommand(deleteReservationsQuery, connection);
                        deleteReservationsCommand.Parameters.AddWithValue("@UserId", LoggedInUser.UserId);
                        deleteReservationsCommand.ExecuteNonQuery();

                        // 회원 정보 삭제
                        string deleteUserQuery = "DELETE FROM users WHERE UserId = @UserId";
                        MySqlCommand deleteUserCommand = new MySqlCommand(deleteUserQuery, connection);
                        deleteUserCommand.Parameters.AddWithValue("@UserId", LoggedInUser.UserId);
                        deleteUserCommand.ExecuteNonQuery();

                        MessageBox.Show("회원 탈퇴가 완료되었습니다.");

                        // 프로그램 종료 또는 로그인 화면으로 이동
                        Application.Exit();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"회원 탈퇴 처리 중 오류가 발생했습니다: {ex.Message}");
                    }
                }
            }
        }


        // 비밀번호 해시 처리 함수 (Base64 사용)
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
