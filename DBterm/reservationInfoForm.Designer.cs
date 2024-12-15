namespace DBterm
{
    partial class reservationInfoForm
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
            this.reservationListView = new System.Windows.Forms.ListView();
            this.label2 = new System.Windows.Forms.Label();
            this.userIdLabel = new System.Windows.Forms.Label();
            this.reservationCancelButton = new System.Windows.Forms.Button();
            this.reservationInfoLabel = new System.Windows.Forms.Label();
            this.panel6.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel6
            // 
            this.panel6.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.panel6.Controls.Add(this.panel7);
            this.panel6.Location = new System.Drawing.Point(54, 90);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(592, 1);
            this.panel6.TabIndex = 28;
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
            this.label1.Location = new System.Drawing.Point(247, 38);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(192, 27);
            this.label1.TabIndex = 27;
            this.label1.Text = "나의 예약 정보";
            // 
            // reservationListView
            // 
            this.reservationListView.HideSelection = false;
            this.reservationListView.Location = new System.Drawing.Point(54, 148);
            this.reservationListView.Name = "reservationListView";
            this.reservationListView.Size = new System.Drawing.Size(592, 159);
            this.reservationListView.TabIndex = 29;
            this.reservationListView.UseCompatibleStateImageBehavior = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("굴림", 10F);
            this.label2.Location = new System.Drawing.Point(54, 115);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(49, 14);
            this.label2.TabIndex = 30;
            this.label2.Text = "아이디";
            // 
            // userIdLabel
            // 
            this.userIdLabel.AutoSize = true;
            this.userIdLabel.Font = new System.Drawing.Font("굴림", 10F);
            this.userIdLabel.Location = new System.Drawing.Point(128, 115);
            this.userIdLabel.Name = "userIdLabel";
            this.userIdLabel.Size = new System.Drawing.Size(81, 14);
            this.userIdLabel.TabIndex = 31;
            this.userIdLabel.Text = "userIdLabel";
            // 
            // reservationCancelButton
            // 
            this.reservationCancelButton.Location = new System.Drawing.Point(542, 331);
            this.reservationCancelButton.Name = "reservationCancelButton";
            this.reservationCancelButton.Size = new System.Drawing.Size(104, 51);
            this.reservationCancelButton.TabIndex = 32;
            this.reservationCancelButton.Text = "예약 취소";
            this.reservationCancelButton.UseVisualStyleBackColor = true;
            this.reservationCancelButton.Click += new System.EventHandler(this.reservationCancelButton_Click);
            // 
            // reservationInfoLabel
            // 
            this.reservationInfoLabel.AutoSize = true;
            this.reservationInfoLabel.Font = new System.Drawing.Font("굴림", 10F);
            this.reservationInfoLabel.Location = new System.Drawing.Point(54, 349);
            this.reservationInfoLabel.Name = "reservationInfoLabel";
            this.reservationInfoLabel.Size = new System.Drawing.Size(0, 14);
            this.reservationInfoLabel.TabIndex = 33;
            // 
            // reservationInfoForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(717, 450);
            this.Controls.Add(this.reservationInfoLabel);
            this.Controls.Add(this.reservationCancelButton);
            this.Controls.Add(this.userIdLabel);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.reservationListView);
            this.Controls.Add(this.panel6);
            this.Controls.Add(this.label1);
            this.Name = "reservationInfoForm";
            this.Text = "reservationInfoForm";
            this.Load += new System.EventHandler(this.reservationInfoForm_Load);
            this.panel6.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.Panel panel7;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ListView reservationListView;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label userIdLabel;
        private System.Windows.Forms.Button reservationCancelButton;
        private System.Windows.Forms.Label reservationInfoLabel;
    }
}