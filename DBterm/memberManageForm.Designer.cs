namespace DBterm
{
    partial class memberManageForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.findUserListView = new System.Windows.Forms.ListView();
            this.UserId = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.UserName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.PhoneNumber = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.CardNumber = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.UserLevel = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.label2 = new System.Windows.Forms.Label();
            this.findComboBox = new System.Windows.Forms.ComboBox();
            this.finduserTextBox = new System.Windows.Forms.TextBox();
            this.levelComboBox = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.changeLevelButton = new System.Windows.Forms.Button();
            this.deleteUserButton = new System.Windows.Forms.Button();
            this.panel6 = new System.Windows.Forms.Panel();
            this.panel7 = new System.Windows.Forms.Panel();
            this.findUserButton = new System.Windows.Forms.Button();
            this.findattrComboBox = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.panel6.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("굴림", 20F);
            this.label1.Location = new System.Drawing.Point(256, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(129, 27);
            this.label1.TabIndex = 0;
            this.label1.Text = "회원 관리";
            // 
            // findUserListView
            // 
            this.findUserListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.UserId,
            this.UserName,
            this.PhoneNumber,
            this.CardNumber,
            this.UserLevel});
            this.findUserListView.HideSelection = false;
            this.findUserListView.Location = new System.Drawing.Point(30, 138);
            this.findUserListView.Name = "findUserListView";
            this.findUserListView.Size = new System.Drawing.Size(598, 226);
            this.findUserListView.TabIndex = 1;
            this.findUserListView.UseCompatibleStateImageBehavior = false;
            // 
            // UserId
            // 
            this.UserId.Text = "UserId";
            // 
            // UserName
            // 
            this.UserName.Text = "UserName";
            // 
            // PhoneNumber
            // 
            this.PhoneNumber.Text = "PhoneNumber";
            // 
            // CardNumber
            // 
            this.CardNumber.Text = "CardNumber";
            // 
            // UserLevel
            // 
            this.UserLevel.Text = "UserLevel";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("굴림", 10F);
            this.label2.Location = new System.Drawing.Point(317, 98);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(35, 14);
            this.label2.TabIndex = 2;
            this.label2.Text = "검색";
            // 
            // findComboBox
            // 
            this.findComboBox.FormattingEnabled = true;
            this.findComboBox.Location = new System.Drawing.Point(74, 94);
            this.findComboBox.Name = "findComboBox";
            this.findComboBox.Size = new System.Drawing.Size(86, 20);
            this.findComboBox.TabIndex = 3;
            // 
            // finduserTextBox
            // 
            this.finduserTextBox.Location = new System.Drawing.Point(356, 95);
            this.finduserTextBox.Name = "finduserTextBox";
            this.finduserTextBox.Size = new System.Drawing.Size(178, 21);
            this.finduserTextBox.TabIndex = 4;
            // 
            // levelComboBox
            // 
            this.levelComboBox.FormattingEnabled = true;
            this.levelComboBox.Location = new System.Drawing.Point(31, 427);
            this.levelComboBox.Name = "levelComboBox";
            this.levelComboBox.Size = new System.Drawing.Size(114, 20);
            this.levelComboBox.TabIndex = 6;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("굴림", 10F);
            this.label4.Location = new System.Drawing.Point(30, 402);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(115, 14);
            this.label4.TabIndex = 7;
            this.label4.Text = "수정할 등급 선택";
            // 
            // changeLevelButton
            // 
            this.changeLevelButton.Location = new System.Drawing.Point(164, 399);
            this.changeLevelButton.Name = "changeLevelButton";
            this.changeLevelButton.Size = new System.Drawing.Size(77, 50);
            this.changeLevelButton.TabIndex = 8;
            this.changeLevelButton.Text = "등급 수정";
            this.changeLevelButton.UseVisualStyleBackColor = true;
            this.changeLevelButton.Click += new System.EventHandler(this.changeLevelButton_Click);
            // 
            // deleteUserButton
            // 
            this.deleteUserButton.Location = new System.Drawing.Point(548, 399);
            this.deleteUserButton.Name = "deleteUserButton";
            this.deleteUserButton.Size = new System.Drawing.Size(80, 52);
            this.deleteUserButton.TabIndex = 9;
            this.deleteUserButton.Text = "회원 삭제";
            this.deleteUserButton.UseVisualStyleBackColor = true;
            this.deleteUserButton.Click += new System.EventHandler(this.deleteUserButton_Click);
            // 
            // panel6
            // 
            this.panel6.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.panel6.Controls.Add(this.panel7);
            this.panel6.Location = new System.Drawing.Point(27, 64);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(601, 1);
            this.panel6.TabIndex = 24;
            // 
            // panel7
            // 
            this.panel7.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.panel7.Location = new System.Drawing.Point(0, -101);
            this.panel7.Name = "panel7";
            this.panel7.Size = new System.Drawing.Size(717, 10);
            this.panel7.TabIndex = 23;
            // 
            // findUserButton
            // 
            this.findUserButton.Location = new System.Drawing.Point(550, 93);
            this.findUserButton.Name = "findUserButton";
            this.findUserButton.Size = new System.Drawing.Size(78, 25);
            this.findUserButton.TabIndex = 25;
            this.findUserButton.Text = "회원 조회";
            this.findUserButton.UseVisualStyleBackColor = true;
            this.findUserButton.Click += new System.EventHandler(this.findUserButton_Click);
            // 
            // findattrComboBox
            // 
            this.findattrComboBox.FormattingEnabled = true;
            this.findattrComboBox.Location = new System.Drawing.Point(214, 95);
            this.findattrComboBox.Name = "findattrComboBox";
            this.findattrComboBox.Size = new System.Drawing.Size(86, 20);
            this.findattrComboBox.TabIndex = 26;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("굴림", 10F);
            this.label5.Location = new System.Drawing.Point(33, 97);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(35, 14);
            this.label5.TabIndex = 27;
            this.label5.Text = "등급";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("굴림", 10F);
            this.label6.Location = new System.Drawing.Point(173, 97);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(35, 14);
            this.label6.TabIndex = 28;
            this.label6.Text = "속성";
            // 
            // memberManageForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(670, 475);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.findattrComboBox);
            this.Controls.Add(this.findUserButton);
            this.Controls.Add(this.panel6);
            this.Controls.Add(this.deleteUserButton);
            this.Controls.Add(this.changeLevelButton);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.levelComboBox);
            this.Controls.Add(this.finduserTextBox);
            this.Controls.Add(this.findComboBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.findUserListView);
            this.Controls.Add(this.label1);
            this.Name = "memberManageForm";
            this.Text = "memberManage";
            this.Load += new System.EventHandler(this.memberManageForm_Load);
            this.panel6.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ListView findUserListView;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox findComboBox;
        private System.Windows.Forms.TextBox finduserTextBox;
        private System.Windows.Forms.ComboBox levelComboBox;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button changeLevelButton;
        private System.Windows.Forms.Button deleteUserButton;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.Panel panel7;
        private System.Windows.Forms.Button findUserButton;
        private System.Windows.Forms.ComboBox findattrComboBox;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ColumnHeader UserId;
        private System.Windows.Forms.ColumnHeader UserName;
        private System.Windows.Forms.ColumnHeader PhoneNumber;
        private System.Windows.Forms.ColumnHeader CardNumber;
        private System.Windows.Forms.ColumnHeader UserLevel;
    }
}