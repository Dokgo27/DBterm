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

    public partial class memberManageForm : Form
    {
        string _server = "localhost"; //DB 서버 주소, 로컬일 경우 localhost
        int _port = 3308; //DB 서버 포트
        string _database = "termdb"; //DB 이름
        string _id = "root"; //계정 아이디
        string _pw = "1234"; //계정 비밀번호
        string _connectionAddress = "";

        public memberManageForm()
        {
            InitializeComponent();
            _connectionAddress = string.Format("Server={0};Port={1};Database={2};Uid={3};Pwd={4}", _server, _port, _database, _id, _pw);
        }

        private void memberManageForm_Load(object sender, EventArgs e)
        {
            InitializeListView();

            // 등급 콤보박스 초기화
            findComboBox.Items.AddRange(new string[] { "전체", "VIP", "GOLD", "SILVER" });
            findComboBox.SelectedIndex = 0;

            // 속성 콤보박스 초기화
            findattrComboBox.Items.AddRange(new string[] { "아이디", "이름" });
            findattrComboBox.SelectedIndex = 0;

            // 수정할 등급 콤보박스 초기화
            levelComboBox.Items.AddRange(new string[] { "VIP", "GOLD", "SILVER" });
            levelComboBox.SelectedIndex = 0;
        }

        private void findUserButton_Click(object sender, EventArgs e)
        {
            string levelFilter = findComboBox.SelectedItem?.ToString() ?? "전체";
            string attributeFilter = findattrComboBox.SelectedItem?.ToString() ?? "아이디";
            string searchText = finduserTextBox.Text.Trim();

            // SQL 조건 설정
            string levelCondition = levelFilter != "전체" ? $"UserLevel = '{levelFilter}'" : "1=1"; // "전체" 선택 시 조건 없음
            string attributeCondition = !string.IsNullOrEmpty(searchText)
                ? $"{(attributeFilter == "아이디" ? "UserId" : "Name")} LIKE '%{searchText}%'"
                : "1=1"; // 검색 텍스트가 없으면 조건 없음

            string query = $"SELECT UserId, Name, PhoneNumber, CardNumber, UserLevel FROM Users WHERE {levelCondition} AND {attributeCondition}";

            // 리스트뷰 초기화
            findUserListView.Items.Clear();

            using (MySqlConnection connection = new MySqlConnection(_connectionAddress))
            {
                try
                {
                    connection.Open();
                    MySqlCommand command = new MySqlCommand(query, connection);
                    MySqlDataReader reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        ListViewItem item = new ListViewItem(reader["UserId"].ToString()); // 첫 번째 열
                        item.SubItems.Add(reader["Name"].ToString());                    // 두 번째 열
                        item.SubItems.Add(reader["PhoneNumber"].ToString());             // 세 번째 열
                        item.SubItems.Add(reader["CardNumber"].ToString());              // 네 번째 열
                        item.SubItems.Add(reader["UserLevel"].ToString());               // 다섯 번째 열
                        findUserListView.Items.Add(item);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"회원 조회 중 오류 발생: {ex.Message}");
                }
            }
        }
        private void changeLevelButton_Click(object sender, EventArgs e)
        {
            if (findUserListView.SelectedItems.Count == 0)
            {
                MessageBox.Show("수정할 회원을 선택하세요.");
                return;
            }

            if (levelComboBox.SelectedItem == null)
            {
                MessageBox.Show("수정할 등급을 선택하세요.");
                return;
            }

            string userId = findUserListView.SelectedItems[0].SubItems[0].Text; // 선택된 UserId
            string newLevel = levelComboBox.SelectedItem.ToString();

            using (MySqlConnection connection = new MySqlConnection(_connectionAddress))
            {
                try
                {
                    connection.Open();
                    string query = "UPDATE Users SET UserLevel = @UserLevel WHERE UserId = @UserId";
                    MySqlCommand command = new MySqlCommand(query, connection);
                    command.Parameters.AddWithValue("@UserLevel", newLevel);
                    command.Parameters.AddWithValue("@UserId", userId);
                    command.ExecuteNonQuery();

                    MessageBox.Show("회원 등급이 성공적으로 수정되었습니다.");
                    findUserButton_Click(sender, e); // 리스트 갱신
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"회원 등급 수정 중 오류 발생: {ex.Message}");
                }
            }
        }


        private void deleteUserButton_Click(object sender, EventArgs e)
        {
            if (findUserListView.SelectedItems.Count == 0)
            {
                MessageBox.Show("삭제할 회원을 선택하세요.");
                return;
            }

            string userId = findUserListView.SelectedItems[0].SubItems[0].Text; // 선택된 UserId

            DialogResult result = MessageBox.Show("정말로 삭제하시겠습니까?", "회원 삭제", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (result == DialogResult.Yes)
            {
                using (MySqlConnection connection = new MySqlConnection(_connectionAddress))
                {
                    try
                    {
                        connection.Open();
                        string query = "DELETE FROM Users WHERE UserId = @UserId";
                        MySqlCommand command = new MySqlCommand(query, connection);
                        command.Parameters.AddWithValue("@UserId", userId);
                        command.ExecuteNonQuery();

                        MessageBox.Show("회원이 성공적으로 삭제되었습니다.");
                        findUserButton_Click(sender, e); // 리스트 갱신
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"회원 삭제 중 오류 발생: {ex.Message}");
                    }
                }
            }
        }

        private void InitializeListView()
        {
            findUserListView.View = View.Details; // 세부 보기 설정
            findUserListView.FullRowSelect = true; // 전체 행 선택 가능
            findUserListView.Columns.Clear(); // 기존 열 초기화

            // 열 추가
            findUserListView.Columns.Add("UserId", 100, HorizontalAlignment.Left); // 첫 번째 열: UserId
            findUserListView.Columns.Add("Name", 100, HorizontalAlignment.Left);  // 두 번째 열: 이름
            findUserListView.Columns.Add("PhoneNumber", 120, HorizontalAlignment.Left); // 세 번째 열: 전화번호
            findUserListView.Columns.Add("CardNumber", 120, HorizontalAlignment.Left);  // 네 번째 열: 카드번호
            findUserListView.Columns.Add("UserLevel", 80, HorizontalAlignment.Left);    // 다섯 번째 열: 등급
        }

    }
}
