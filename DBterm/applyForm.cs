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
    public partial class applyForm : Form
    {
        string _server = "localhost"; // DB 서버 주소
        int _port = 3308; // DB 포트
        string _database = "termdb"; // DB 이름
        string _id = "root"; // DB 계정 ID
        string _pw = "1234"; // DB 비밀번호
        string _connectionAddress = "";

        public applyForm()
        {
            InitializeComponent();
            _connectionAddress = string.Format("Server={0};Port={1};Database={2};Uid={3};Pwd={4}", _server, _port, _database, _id, _pw);
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void apply_ok_Button_Click(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count == 0)
            {
                MessageBox.Show("승인할 요청을 선택하세요.");
                return;
            }

            string requestId = listView1.SelectedItems[0].Text; // 선택된 RequestId

            if (comboBoxUserLevel.SelectedItem == null)
            {
                MessageBox.Show("회원의 등급을 선택하세요.");
                return;
            }

            string userLevel = comboBoxUserLevel.SelectedItem.ToString(); // 콤보 박스 item

            using (MySqlConnection connection = new MySqlConnection(_connectionAddress))
            {
                try
                {
                    connection.Open();

                    // 승인 요청 데이터 가져오기
                    string selectQuery = "SELECT UserId, Password, Name, PhoneNumber, CardNumber FROM SignupRequests WHERE RequestId = @RequestId";
                    MySqlCommand selectCommand = new MySqlCommand(selectQuery, connection);
                    selectCommand.Parameters.AddWithValue("@RequestId", requestId);

                    MySqlDataReader reader = selectCommand.ExecuteReader();
                    if (reader.Read())
                    {
                        string userId = reader["UserId"].ToString();
                        string password = reader["Password"].ToString();
                        string name = reader["Name"].ToString();
                        string phoneNumber = reader["PhoneNumber"].ToString();
                        string cardNumber = reader["CardNumber"].ToString();
                        reader.Close();

                        // Users 테이블에 삽입
                        string insertQuery = "INSERT INTO Users (UserId, Password, Name, PhoneNumber, CardNumber, IsAdmin, UserLevel) " +
                                             "VALUES (@UserId, @Password, @Name, @PhoneNumber, @CardNumber, 0, @UserLevel)";
                        MySqlCommand insertCommand = new MySqlCommand(insertQuery, connection);
                        insertCommand.Parameters.AddWithValue("@UserId", userId);
                        insertCommand.Parameters.AddWithValue("@Password", password);
                        insertCommand.Parameters.AddWithValue("@Name", name);
                        insertCommand.Parameters.AddWithValue("@PhoneNumber", phoneNumber);
                        insertCommand.Parameters.AddWithValue("@CardNumber", cardNumber);
                        insertCommand.Parameters.AddWithValue("@UserLevel", userLevel);
                        insertCommand.ExecuteNonQuery();

                        // SignupRequests 상태 업데이트
                        string updateQuery = "UPDATE SignupRequests SET Status = 'APPROVED' WHERE RequestId = @RequestId";
                        MySqlCommand updateCommand = new MySqlCommand(updateQuery, connection);
                        updateCommand.Parameters.AddWithValue("@RequestId", requestId);
                        updateCommand.ExecuteNonQuery();

                        MessageBox.Show($"계정이 {userLevel} 등급으로 승인되었습니다.");
                        listView1.Items.Remove(listView1.SelectedItems[0]); // 리스트에서 제거
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"승인 처리 중 오류 발생: {ex.Message}");
                }
            }
        }


        private void apply_no_Button_Click(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count == 0)
            {
                MessageBox.Show("거부할 요청을 선택하세요.");
                return;
            }

            string requestId = listView1.SelectedItems[0].Text; // 선택된 RequestId

            using (MySqlConnection connection = new MySqlConnection(_connectionAddress))
            {
                try
                {
                    connection.Open();

                    string updateQuery = "UPDATE SignupRequests SET Status = 'REJECTED' WHERE RequestId = @RequestId";
                    MySqlCommand command = new MySqlCommand(updateQuery, connection);
                    command.Parameters.AddWithValue("@RequestId", requestId);
                    command.ExecuteNonQuery();

                    MessageBox.Show("계정 요청이 거부되었습니다.");
                    listView1.Items.Remove(listView1.SelectedItems[0]); // 리스트에서 제거
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"거부 처리 중 오류 발생: {ex.Message}");
                }
            }
        }

        private void applyForm_Load(object sender, EventArgs e)
        {
            // ListView 설정 (View 모드만 설정)
            listView1.View = View.Details; // 세부 보기 설정
            listView1.FullRowSelect = true; // 행 전체 선택 가능

            // 데이터 로드
            using (MySqlConnection connection = new MySqlConnection(_connectionAddress))
            {
                try
                {
                    connection.Open();
                    string query = "SELECT RequestId, UserId, Password, Name, PhoneNumber, CardNumber FROM SignupRequests WHERE Status = 'PENDING'";
                    MySqlCommand command = new MySqlCommand(query, connection);
                    MySqlDataReader reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        // 각 행 데이터를 추가
                        ListViewItem item = new ListViewItem(reader["RequestId"].ToString()); // 첫 번째 열
                        item.SubItems.Add(reader["UserId"].ToString());    // 두 번째 열
                        item.SubItems.Add(reader["Password"].ToString()); // 세 번째 열 (Password 추가)
                        item.SubItems.Add(reader["Name"].ToString());      // 네 번째 열
                        item.SubItems.Add(reader["PhoneNumber"].ToString()); // 다섯 번째 열
                        item.SubItems.Add(reader["CardNumber"].ToString());  // 여섯 번째 열
                        listView1.Items.Add(item); // ListView에 추가
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"데이터 로드 중 오류 발생: {ex.Message}");
                }
            }

            // 열 폭 자동 조정
            foreach (ColumnHeader column in listView1.Columns)
            {
                column.Width = -2; // 내용에 맞게 열 폭 조정
            }
        }

    }
}
