namespace DBterm
{
    partial class applyForm
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
            this.listView1 = new System.Windows.Forms.ListView();
            this.RequestID = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.UserID = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Password = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.UserName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.PhoneNumber = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.CardNumber = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.apply_ok_Button = new System.Windows.Forms.Button();
            this.apply_no_Button = new System.Windows.Forms.Button();
            this.comboBoxUserLevel = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // listView1
            // 
            this.listView1.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.RequestID,
            this.UserID,
            this.Password,
            this.UserName,
            this.PhoneNumber,
            this.CardNumber});
            this.listView1.HideSelection = false;
            this.listView1.Location = new System.Drawing.Point(32, 62);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(611, 187);
            this.listView1.TabIndex = 0;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.SelectedIndexChanged += new System.EventHandler(this.listView1_SelectedIndexChanged);
            // 
            // RequestID
            // 
            this.RequestID.Text = "RequestID";
            // 
            // UserID
            // 
            this.UserID.Text = "UserID";
            // 
            // Password
            // 
            this.Password.Text = "Password";
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
            // apply_ok_Button
            // 
            this.apply_ok_Button.Location = new System.Drawing.Point(413, 282);
            this.apply_ok_Button.Name = "apply_ok_Button";
            this.apply_ok_Button.Size = new System.Drawing.Size(105, 57);
            this.apply_ok_Button.TabIndex = 1;
            this.apply_ok_Button.Text = "계정 승인";
            this.apply_ok_Button.UseVisualStyleBackColor = true;
            this.apply_ok_Button.Click += new System.EventHandler(this.apply_ok_Button_Click);
            // 
            // apply_no_Button
            // 
            this.apply_no_Button.Location = new System.Drawing.Point(538, 282);
            this.apply_no_Button.Name = "apply_no_Button";
            this.apply_no_Button.Size = new System.Drawing.Size(105, 57);
            this.apply_no_Button.TabIndex = 2;
            this.apply_no_Button.Text = "계정 거부";
            this.apply_no_Button.UseVisualStyleBackColor = true;
            this.apply_no_Button.Click += new System.EventHandler(this.apply_no_Button_Click);
            // 
            // comboBoxUserLevel
            // 
            this.comboBoxUserLevel.FormattingEnabled = true;
            this.comboBoxUserLevel.Items.AddRange(new object[] {
            "VIP",
            "GOLD",
            "SILVER"});
            this.comboBoxUserLevel.Location = new System.Drawing.Point(135, 282);
            this.comboBoxUserLevel.Name = "comboBoxUserLevel";
            this.comboBoxUserLevel.Size = new System.Drawing.Size(165, 20);
            this.comboBoxUserLevel.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("굴림", 20F);
            this.label1.Location = new System.Drawing.Point(244, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(192, 27);
            this.label1.TabIndex = 4;
            this.label1.Text = "가입 요청 목록";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("굴림", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label2.Location = new System.Drawing.Point(33, 286);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(93, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "회원 등급 설정";
            // 
            // applyForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(681, 368);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.comboBoxUserLevel);
            this.Controls.Add(this.apply_no_Button);
            this.Controls.Add(this.apply_ok_Button);
            this.Controls.Add(this.listView1);
            this.Name = "applyForm";
            this.Text = "applyForm";
            this.Load += new System.EventHandler(this.applyForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.Button apply_ok_Button;
        private System.Windows.Forms.Button apply_no_Button;
        private System.Windows.Forms.ColumnHeader RequestID;
        private System.Windows.Forms.ColumnHeader UserID;
        private System.Windows.Forms.ColumnHeader UserName;
        private System.Windows.Forms.ColumnHeader PhoneNumber;
        private System.Windows.Forms.ColumnHeader CardNumber;
        private System.Windows.Forms.ColumnHeader Password;
        private System.Windows.Forms.ComboBox comboBoxUserLevel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
    }
}