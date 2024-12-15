using System;
using System.Data;
using System.Security.Cryptography;
using System.Text;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace DBterm
{
    public partial class loginForm : Form
    {
        string _server = "localhost"; //DB 서버 주소, 로컬일 경우 localhost
        int _port = 3308; //DB 서버 포트
        string _database = "termdb"; //DB 이름
        string _id = "root"; //계정 아이디
        string _pw = "1234"; //계정 비밀번호
        string _connectionAddress = "";

        public loginForm()
        {
            InitializeComponent();
            _connectionAddress = string.Format("Server={0};Port={1};Database={2};Uid={3};Pwd={4}", _server, _port, _database, _id, _pw);
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        // 로그인 버튼 클릭
        private void loginButton_Click(object sender, EventArgs e)
        {
            string userId = idTextbox.Text.Trim();    // 사용자 입력 UserId
            string password = passwordTextbox.Text.Trim(); // 사용자 입력 Password

            if (string.IsNullOrEmpty(userId) || string.IsNullOrEmpty(password))
            {
                MessageBox.Show("아이디와 비밀번호를 입력하세요.");
                return;
            }

            // 입력된 비밀번호를 해싱
            string hashedPassword = HashPassword(password);

            using (MySqlConnection connection = new MySqlConnection(_connectionAddress))
            {
                try
                {
                    connection.Open(); // 데이터베이스 연결
                    string query = "SELECT IsAdmin FROM Users WHERE UserId = @UserId AND Password = @Password";
                    MySqlCommand command = new MySqlCommand(query, connection);
                    command.Parameters.AddWithValue("@UserId", userId);
                    command.Parameters.AddWithValue("@Password", hashedPassword);

                    object isAdminObj = command.ExecuteScalar();

                    if (isAdminObj != null) // 사용자 존재 여부 확인
                    {
                        int isAdmin = Convert.ToInt32(isAdminObj);

                        if (isAdmin == 1) // 관리자인 경우
                        {
                            MessageBox.Show("관리자로 로그인되었습니다.");
                            managerMain managerMainForm = new managerMain();
                            managerMainForm.Show();
                        }
                        else // 일반 사용자일 경우
                        {
                            MessageBox.Show("일반 사용자로 로그인되었습니다.");

                            query = "SELECT UserId, Name, UserLevel, IsAdmin FROM Users WHERE UserId = @UserId AND Password = @Password";
                            command = new MySqlCommand(query, connection);
                            command.Parameters.AddWithValue("@UserId", userId);
                            command.Parameters.AddWithValue("@Password", hashedPassword);

                            using (MySqlDataReader reader = command.ExecuteReader())
                            {
                                if (reader.Read())
                                {
                                    // 전역 사용자 정보 설정
                                    LoggedInUser.UserId = reader["UserId"].ToString();
                                    LoggedInUser.UserName = reader["Name"].ToString();
                                    LoggedInUser.UserLevel = reader["UserLevel"].ToString();
                                    LoggedInUser.IsAdmin = Convert.ToBoolean(reader["IsAdmin"]);
                                }
                            }

                            nomalMain nomalMainForm = new nomalMain();
                            nomalMainForm.Show();

                            this.Hide(); // 로그인 폼 숨기기
                        }



                        this.Hide(); // 로그인 폼 숨기기
                    }
                    else
                    {
                        MessageBox.Show("아이디 또는 비밀번호가 잘못되었습니다.");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"로그인 중 오류 발생: {ex.Message}");
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

        // 회원가입 버튼 클릭
        private void joinButton1_Click(object sender, EventArgs e)
        {
            joinForm joinFormInstance = new joinForm();
            joinFormInstance.ShowDialog();
        }

        private void loginForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void loginForm_Load(object sender, EventArgs e)
        {

        }
    }
}
