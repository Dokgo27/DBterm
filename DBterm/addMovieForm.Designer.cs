namespace DBterm
{
    partial class addMovieForm
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.logolabel = new System.Windows.Forms.Label();
            this.posterPictureBox = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.titleTextBox = new System.Windows.Forms.TextBox();
            this.directorTextBox = new System.Windows.Forms.TextBox();
            this.actorsTextBox = new System.Windows.Forms.TextBox();
            this.uploadImageButton = new System.Windows.Forms.Button();
            this.addMovieButton = new System.Windows.Forms.Button();
            this.cancelButton = new System.Windows.Forms.Button();
            this.genreComboBox = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.posterPictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.panel1.Location = new System.Drawing.Point(37, 71);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(642, 1);
            this.panel1.TabIndex = 23;
            // 
            // logolabel
            // 
            this.logolabel.AutoSize = true;
            this.logolabel.Font = new System.Drawing.Font("굴림", 20F);
            this.logolabel.Location = new System.Drawing.Point(300, 24);
            this.logolabel.Name = "logolabel";
            this.logolabel.Size = new System.Drawing.Size(129, 27);
            this.logolabel.TabIndex = 22;
            this.logolabel.Text = "영화 추가";
            // 
            // posterPictureBox
            // 
            this.posterPictureBox.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.posterPictureBox.Location = new System.Drawing.Point(73, 106);
            this.posterPictureBox.Name = "posterPictureBox";
            this.posterPictureBox.Size = new System.Drawing.Size(213, 307);
            this.posterPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.posterPictureBox.TabIndex = 24;
            this.posterPictureBox.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("굴림", 10F);
            this.label1.Location = new System.Drawing.Point(360, 111);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(68, 14);
            this.label1.TabIndex = 25;
            this.label1.Text = "영화 제목";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("굴림", 10F);
            this.label2.Location = new System.Drawing.Point(393, 154);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(35, 14);
            this.label2.TabIndex = 26;
            this.label2.Text = "장르";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("굴림", 10F);
            this.label3.Location = new System.Drawing.Point(393, 198);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(35, 14);
            this.label3.TabIndex = 27;
            this.label3.Text = "감독";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("굴림", 10F);
            this.label4.Location = new System.Drawing.Point(360, 241);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(68, 14);
            this.label4.TabIndex = 28;
            this.label4.Text = "주연 배우";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("굴림", 10F);
            this.label5.Location = new System.Drawing.Point(379, 287);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(49, 14);
            this.label5.TabIndex = 29;
            this.label5.Text = "포스터";
            // 
            // titleTextBox
            // 
            this.titleTextBox.Location = new System.Drawing.Point(445, 106);
            this.titleTextBox.Name = "titleTextBox";
            this.titleTextBox.Size = new System.Drawing.Size(233, 21);
            this.titleTextBox.TabIndex = 30;
            // 
            // directorTextBox
            // 
            this.directorTextBox.Location = new System.Drawing.Point(445, 195);
            this.directorTextBox.Name = "directorTextBox";
            this.directorTextBox.Size = new System.Drawing.Size(233, 21);
            this.directorTextBox.TabIndex = 32;
            // 
            // actorsTextBox
            // 
            this.actorsTextBox.Location = new System.Drawing.Point(445, 239);
            this.actorsTextBox.Name = "actorsTextBox";
            this.actorsTextBox.Size = new System.Drawing.Size(233, 21);
            this.actorsTextBox.TabIndex = 33;
            // 
            // uploadImageButton
            // 
            this.uploadImageButton.Location = new System.Drawing.Point(445, 283);
            this.uploadImageButton.Name = "uploadImageButton";
            this.uploadImageButton.Size = new System.Drawing.Size(233, 23);
            this.uploadImageButton.TabIndex = 34;
            this.uploadImageButton.Text = "이미지 업로드";
            this.uploadImageButton.UseVisualStyleBackColor = true;
            this.uploadImageButton.Click += new System.EventHandler(this.UploadImageButton_Click);
            // 
            // addMovieButton
            // 
            this.addMovieButton.Location = new System.Drawing.Point(445, 349);
            this.addMovieButton.Name = "addMovieButton";
            this.addMovieButton.Size = new System.Drawing.Size(111, 64);
            this.addMovieButton.TabIndex = 35;
            this.addMovieButton.Text = "등록";
            this.addMovieButton.UseVisualStyleBackColor = true;
            this.addMovieButton.Click += new System.EventHandler(this.addMovieButton_Click);
            // 
            // cancelButton
            // 
            this.cancelButton.Location = new System.Drawing.Point(569, 349);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(110, 64);
            this.cancelButton.TabIndex = 36;
            this.cancelButton.Text = "취소";
            this.cancelButton.UseVisualStyleBackColor = true;
            this.cancelButton.Click += new System.EventHandler(this.cancelButton_Click);
            // 
            // genreComboBox
            // 
            this.genreComboBox.FormattingEnabled = true;
            this.genreComboBox.Items.AddRange(new object[] {
            "액션",
            "드라마",
            "코미디",
            "스릴러",
            "SF",
            "판타지",
            "로맨스",
            "공포",
            "어드벤처",
            "범죄",
            "뮤지컬",
            "미스터리",
            "다큐멘터리",
            "가족",
            "애니메이션",
            "전쟁",
            "서부극",
            "역사",
            "전기",
            "스포츠"});
            this.genreComboBox.Location = new System.Drawing.Point(445, 152);
            this.genreComboBox.Name = "genreComboBox";
            this.genreComboBox.Size = new System.Drawing.Size(121, 20);
            this.genreComboBox.TabIndex = 37;
            // 
            // addMovieForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(731, 450);
            this.Controls.Add(this.genreComboBox);
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.addMovieButton);
            this.Controls.Add(this.uploadImageButton);
            this.Controls.Add(this.actorsTextBox);
            this.Controls.Add(this.directorTextBox);
            this.Controls.Add(this.titleTextBox);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.posterPictureBox);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.logolabel);
            this.Name = "addMovieForm";
            this.Text = "addMovieForm";
            ((System.ComponentModel.ISupportInitialize)(this.posterPictureBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label logolabel;
        private System.Windows.Forms.PictureBox posterPictureBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox titleTextBox;
        private System.Windows.Forms.TextBox directorTextBox;
        private System.Windows.Forms.TextBox actorsTextBox;
        private System.Windows.Forms.Button uploadImageButton;
        private System.Windows.Forms.Button addMovieButton;
        private System.Windows.Forms.Button cancelButton;
        private System.Windows.Forms.ComboBox genreComboBox;
    }
}