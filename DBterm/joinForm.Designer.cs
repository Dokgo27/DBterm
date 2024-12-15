namespace DBterm
{
    partial class joinForm
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
            this.joinLabel = new System.Windows.Forms.Label();
            this.Userid_label = new System.Windows.Forms.Label();
            this.Username_label = new System.Windows.Forms.Label();
            this.UseridTextbox = new System.Windows.Forms.TextBox();
            this.nameTextbox = new System.Windows.Forms.TextBox();
            this.Password_label = new System.Windows.Forms.Label();
            this.PasswordTextbox = new System.Windows.Forms.TextBox();
            this.PhoneNumber_label = new System.Windows.Forms.Label();
            this.PhoneNumberTextbox = new System.Windows.Forms.TextBox();
            this.CardNum_label = new System.Windows.Forms.Label();
            this.CardTextbox = new System.Windows.Forms.TextBox();
            this.JoinButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // joinLabel
            // 
            this.joinLabel.AutoSize = true;
            this.joinLabel.Font = new System.Drawing.Font("굴림", 30F);
            this.joinLabel.Location = new System.Drawing.Point(149, 61);
            this.joinLabel.Name = "joinLabel";
            this.joinLabel.Size = new System.Drawing.Size(94, 40);
            this.joinLabel.TabIndex = 2;
            this.joinLabel.Text = "Join";
            // 
            // Userid_label
            // 
            this.Userid_label.AutoSize = true;
            this.Userid_label.Location = new System.Drawing.Point(77, 181);
            this.Userid_label.Name = "Userid_label";
            this.Userid_label.Size = new System.Drawing.Size(41, 12);
            this.Userid_label.TabIndex = 8;
            this.Userid_label.Text = "Userid";
            this.Userid_label.Click += new System.EventHandler(this.Userid_label_Click);
            // 
            // Username_label
            // 
            this.Username_label.AutoSize = true;
            this.Username_label.Location = new System.Drawing.Point(75, 145);
            this.Username_label.Name = "Username_label";
            this.Username_label.Size = new System.Drawing.Size(63, 12);
            this.Username_label.TabIndex = 7;
            this.Username_label.Text = "Username";
            // 
            // UseridTextbox
            // 
            this.UseridTextbox.Location = new System.Drawing.Point(144, 178);
            this.UseridTextbox.Name = "UseridTextbox";
            this.UseridTextbox.Size = new System.Drawing.Size(168, 21);
            this.UseridTextbox.TabIndex = 6;
            this.UseridTextbox.TextChanged += new System.EventHandler(this.passwordTextbox_TextChanged);
            // 
            // nameTextbox
            // 
            this.nameTextbox.Location = new System.Drawing.Point(144, 142);
            this.nameTextbox.Name = "nameTextbox";
            this.nameTextbox.Size = new System.Drawing.Size(168, 21);
            this.nameTextbox.TabIndex = 5;
            // 
            // Password_label
            // 
            this.Password_label.AutoSize = true;
            this.Password_label.Location = new System.Drawing.Point(77, 217);
            this.Password_label.Name = "Password_label";
            this.Password_label.Size = new System.Drawing.Size(62, 12);
            this.Password_label.TabIndex = 10;
            this.Password_label.Text = "Password";
            // 
            // PasswordTextbox
            // 
            this.PasswordTextbox.Location = new System.Drawing.Point(144, 214);
            this.PasswordTextbox.Name = "PasswordTextbox";
            this.PasswordTextbox.PasswordChar = '*';
            this.PasswordTextbox.Size = new System.Drawing.Size(168, 21);
            this.PasswordTextbox.TabIndex = 9;
            // 
            // PhoneNumber_label
            // 
            this.PhoneNumber_label.AutoSize = true;
            this.PhoneNumber_label.Location = new System.Drawing.Point(77, 254);
            this.PhoneNumber_label.Name = "PhoneNumber_label";
            this.PhoneNumber_label.Size = new System.Drawing.Size(41, 12);
            this.PhoneNumber_label.TabIndex = 12;
            this.PhoneNumber_label.Text = "Phone";
            // 
            // PhoneNumberTextbox
            // 
            this.PhoneNumberTextbox.Location = new System.Drawing.Point(144, 251);
            this.PhoneNumberTextbox.Name = "PhoneNumberTextbox";
            this.PhoneNumberTextbox.Size = new System.Drawing.Size(168, 21);
            this.PhoneNumberTextbox.TabIndex = 11;
            // 
            // CardNum_label
            // 
            this.CardNum_label.AutoSize = true;
            this.CardNum_label.Location = new System.Drawing.Point(77, 290);
            this.CardNum_label.Name = "CardNum_label";
            this.CardNum_label.Size = new System.Drawing.Size(32, 12);
            this.CardNum_label.TabIndex = 14;
            this.CardNum_label.Text = "Card";
            // 
            // CardTextbox
            // 
            this.CardTextbox.Location = new System.Drawing.Point(144, 287);
            this.CardTextbox.Name = "CardTextbox";
            this.CardTextbox.Size = new System.Drawing.Size(168, 21);
            this.CardTextbox.TabIndex = 13;
            // 
            // JoinButton
            // 
            this.JoinButton.Location = new System.Drawing.Point(144, 331);
            this.JoinButton.Name = "JoinButton";
            this.JoinButton.Size = new System.Drawing.Size(114, 23);
            this.JoinButton.TabIndex = 15;
            this.JoinButton.Text = "확인";
            this.JoinButton.UseVisualStyleBackColor = true;
            this.JoinButton.Click += new System.EventHandler(this.JoinButton2_Click);
            // 
            // joinForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(388, 410);
            this.Controls.Add(this.JoinButton);
            this.Controls.Add(this.CardNum_label);
            this.Controls.Add(this.CardTextbox);
            this.Controls.Add(this.PhoneNumber_label);
            this.Controls.Add(this.PhoneNumberTextbox);
            this.Controls.Add(this.Password_label);
            this.Controls.Add(this.PasswordTextbox);
            this.Controls.Add(this.Userid_label);
            this.Controls.Add(this.Username_label);
            this.Controls.Add(this.UseridTextbox);
            this.Controls.Add(this.nameTextbox);
            this.Controls.Add(this.joinLabel);
            this.Name = "joinForm";
            this.Text = "joinForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label joinLabel;
        private System.Windows.Forms.Label Userid_label;
        private System.Windows.Forms.Label Username_label;
        private System.Windows.Forms.TextBox UseridTextbox;
        private System.Windows.Forms.TextBox nameTextbox;
        private System.Windows.Forms.Label Password_label;
        private System.Windows.Forms.TextBox PasswordTextbox;
        private System.Windows.Forms.Label PhoneNumber_label;
        private System.Windows.Forms.TextBox PhoneNumberTextbox;
        private System.Windows.Forms.Label CardNum_label;
        private System.Windows.Forms.TextBox CardTextbox;
        private System.Windows.Forms.Button JoinButton;
    }
}