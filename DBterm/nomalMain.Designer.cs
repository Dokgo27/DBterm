namespace DBterm
{
    partial class nomalMain
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
            this.panel6 = new System.Windows.Forms.Panel();
            this.panel7 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.accountLabel = new System.Windows.Forms.Label();
            this.reservationInfoLabel = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.movieListBox = new System.Windows.Forms.ListBox();
            this.roomListBox = new System.Windows.Forms.ListBox();
            this.label3 = new System.Windows.Forms.Label();
            this.timeListBox = new System.Windows.Forms.ListBox();
            this.label4 = new System.Windows.Forms.Label();
            this.datePicker = new System.Windows.Forms.DateTimePicker();
            this.selectedMovieTextBox = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.selectedRoomTextBox = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.selectedDateTextBox = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.selectedTimeTextBox = new System.Windows.Forms.TextBox();
            this.reserveButton = new System.Windows.Forms.Button();
            this.movieInfoButton = new System.Windows.Forms.Button();
            this.label9 = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.panel6.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel6
            // 
            this.panel6.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.panel6.Controls.Add(this.panel7);
            this.panel6.Location = new System.Drawing.Point(37, 69);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(976, 1);
            this.panel6.TabIndex = 26;
            // 
            // panel7
            // 
            this.panel7.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.panel7.Location = new System.Drawing.Point(0, -101);
            this.panel7.Name = "panel7";
            this.panel7.Size = new System.Drawing.Size(717, 10);
            this.panel7.TabIndex = 23;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("굴림", 20F);
            this.label1.Location = new System.Drawing.Point(32, 30);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(246, 27);
            this.label1.TabIndex = 25;
            this.label1.Text = "김민재 영화 서비스";
            // 
            // accountLabel
            // 
            this.accountLabel.AutoSize = true;
            this.accountLabel.Font = new System.Drawing.Font("굴림", 10F);
            this.accountLabel.Location = new System.Drawing.Point(805, 42);
            this.accountLabel.Name = "accountLabel";
            this.accountLabel.Size = new System.Drawing.Size(54, 14);
            this.accountLabel.TabIndex = 27;
            this.accountLabel.Text = "내 계정";
            this.accountLabel.Click += new System.EventHandler(this.accountLabel_Click);
            // 
            // reservationInfoLabel
            // 
            this.reservationInfoLabel.AutoSize = true;
            this.reservationInfoLabel.Font = new System.Drawing.Font("굴림", 10F);
            this.reservationInfoLabel.Location = new System.Drawing.Point(896, 41);
            this.reservationInfoLabel.Name = "reservationInfoLabel";
            this.reservationInfoLabel.Size = new System.Drawing.Size(101, 14);
            this.reservationInfoLabel.TabIndex = 28;
            this.reservationInfoLabel.Text = "예약 정보 조회";
            this.reservationInfoLabel.Click += new System.EventHandler(this.reservationInfoLabel_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Location = new System.Drawing.Point(876, 37);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1, 22);
            this.panel1.TabIndex = 29;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.panel2.Location = new System.Drawing.Point(0, -101);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(717, 10);
            this.panel2.TabIndex = 23;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("굴림", 10F);
            this.label2.Location = new System.Drawing.Point(34, 99);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(35, 14);
            this.label2.TabIndex = 30;
            this.label2.Text = "영화";
            // 
            // movieListBox
            // 
            this.movieListBox.FormattingEnabled = true;
            this.movieListBox.ItemHeight = 12;
            this.movieListBox.Location = new System.Drawing.Point(37, 131);
            this.movieListBox.Name = "movieListBox";
            this.movieListBox.Size = new System.Drawing.Size(200, 220);
            this.movieListBox.TabIndex = 33;
            this.movieListBox.SelectedIndexChanged += new System.EventHandler(this.movieListBox_SelectedIndexChanged);
            // 
            // roomListBox
            // 
            this.roomListBox.FormattingEnabled = true;
            this.roomListBox.ItemHeight = 12;
            this.roomListBox.Location = new System.Drawing.Point(269, 132);
            this.roomListBox.Name = "roomListBox";
            this.roomListBox.Size = new System.Drawing.Size(200, 256);
            this.roomListBox.TabIndex = 35;
            this.roomListBox.SelectedIndexChanged += new System.EventHandler(this.roomListBox_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("굴림", 10F);
            this.label3.Location = new System.Drawing.Point(266, 99);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(35, 14);
            this.label3.TabIndex = 34;
            this.label3.Text = "극장";
            // 
            // timeListBox
            // 
            this.timeListBox.FormattingEnabled = true;
            this.timeListBox.ItemHeight = 12;
            this.timeListBox.Location = new System.Drawing.Point(496, 192);
            this.timeListBox.Name = "timeListBox";
            this.timeListBox.Size = new System.Drawing.Size(200, 196);
            this.timeListBox.TabIndex = 37;
            this.timeListBox.SelectedIndexChanged += new System.EventHandler(this.timeListBox_SelectedIndexChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("굴림", 10F);
            this.label4.Location = new System.Drawing.Point(493, 100);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(68, 14);
            this.label4.TabIndex = 36;
            this.label4.Text = "날짜 선택";
            // 
            // datePicker
            // 
            this.datePicker.Location = new System.Drawing.Point(496, 131);
            this.datePicker.Name = "datePicker";
            this.datePicker.Size = new System.Drawing.Size(200, 21);
            this.datePicker.TabIndex = 38;
            this.datePicker.ValueChanged += new System.EventHandler(this.datePicker_ValueChanged);
            // 
            // selectedMovieTextBox
            // 
            this.selectedMovieTextBox.Location = new System.Drawing.Point(808, 131);
            this.selectedMovieTextBox.Name = "selectedMovieTextBox";
            this.selectedMovieTextBox.Size = new System.Drawing.Size(183, 21);
            this.selectedMovieTextBox.TabIndex = 39;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("굴림", 10F);
            this.label5.Location = new System.Drawing.Point(751, 133);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(35, 14);
            this.label5.TabIndex = 40;
            this.label5.Text = "영화";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("굴림", 10F);
            this.label6.Location = new System.Drawing.Point(751, 164);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(35, 14);
            this.label6.TabIndex = 42;
            this.label6.Text = "극장";
            // 
            // selectedRoomTextBox
            // 
            this.selectedRoomTextBox.Location = new System.Drawing.Point(808, 162);
            this.selectedRoomTextBox.Name = "selectedRoomTextBox";
            this.selectedRoomTextBox.Size = new System.Drawing.Size(183, 21);
            this.selectedRoomTextBox.TabIndex = 41;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("굴림", 10F);
            this.label7.Location = new System.Drawing.Point(751, 194);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(35, 14);
            this.label7.TabIndex = 44;
            this.label7.Text = "날짜";
            // 
            // selectedDateTextBox
            // 
            this.selectedDateTextBox.Location = new System.Drawing.Point(808, 192);
            this.selectedDateTextBox.Name = "selectedDateTextBox";
            this.selectedDateTextBox.Size = new System.Drawing.Size(183, 21);
            this.selectedDateTextBox.TabIndex = 43;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("굴림", 10F);
            this.label8.Location = new System.Drawing.Point(751, 224);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(35, 14);
            this.label8.TabIndex = 46;
            this.label8.Text = "시간";
            // 
            // selectedTimeTextBox
            // 
            this.selectedTimeTextBox.Location = new System.Drawing.Point(808, 222);
            this.selectedTimeTextBox.Name = "selectedTimeTextBox";
            this.selectedTimeTextBox.Size = new System.Drawing.Size(183, 21);
            this.selectedTimeTextBox.TabIndex = 45;
            // 
            // reserveButton
            // 
            this.reserveButton.Location = new System.Drawing.Point(888, 267);
            this.reserveButton.Name = "reserveButton";
            this.reserveButton.Size = new System.Drawing.Size(103, 64);
            this.reserveButton.TabIndex = 47;
            this.reserveButton.Text = "예매";
            this.reserveButton.UseVisualStyleBackColor = true;
            this.reserveButton.Click += new System.EventHandler(this.reserveButton_Click);
            // 
            // movieInfoButton
            // 
            this.movieInfoButton.Location = new System.Drawing.Point(37, 359);
            this.movieInfoButton.Name = "movieInfoButton";
            this.movieInfoButton.Size = new System.Drawing.Size(200, 29);
            this.movieInfoButton.TabIndex = 48;
            this.movieInfoButton.Text = "영화 정보 보기";
            this.movieInfoButton.UseVisualStyleBackColor = true;
            this.movieInfoButton.Click += new System.EventHandler(this.movieInfoButton_Click);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("굴림", 10F);
            this.label9.Location = new System.Drawing.Point(493, 168);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(68, 14);
            this.label9.TabIndex = 49;
            this.label9.Text = "가능 시간";
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.panel3.Controls.Add(this.panel4);
            this.panel3.Location = new System.Drawing.Point(725, 93);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(1, 295);
            this.panel3.TabIndex = 30;
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.panel4.Location = new System.Drawing.Point(0, -101);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(717, 10);
            this.panel4.TabIndex = 23;
            // 
            // nomalMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1049, 432);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.movieInfoButton);
            this.Controls.Add(this.reserveButton);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.selectedTimeTextBox);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.selectedDateTextBox);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.selectedRoomTextBox);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.selectedMovieTextBox);
            this.Controls.Add(this.datePicker);
            this.Controls.Add(this.timeListBox);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.roomListBox);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.movieListBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.reservationInfoLabel);
            this.Controls.Add(this.accountLabel);
            this.Controls.Add(this.panel6);
            this.Controls.Add(this.label1);
            this.Name = "nomalMain";
            this.Text = "nomalMain";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.nomalMain_FormClosed);
            this.Load += new System.EventHandler(this.nomalMain_Load);
            this.panel6.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.Panel panel7;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label accountLabel;
        private System.Windows.Forms.Label reservationInfoLabel;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ListBox movieListBox;
        private System.Windows.Forms.ListBox roomListBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ListBox timeListBox;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DateTimePicker datePicker;
        private System.Windows.Forms.TextBox selectedMovieTextBox;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox selectedRoomTextBox;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox selectedDateTextBox;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox selectedTimeTextBox;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Button reserveButton;
        private System.Windows.Forms.Button movieInfoButton;
        private System.Windows.Forms.Label label9;
    }
}