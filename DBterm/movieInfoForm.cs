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
    public partial class movieInfoForm : Form
    {
        public movieInfoForm()
        {
            InitializeComponent();
        }

        private void posterPictureBox_Click(object sender, EventArgs e)
        {

        }

        // 폼에 접근하기 위한 setter 설정
        public string MovieTitle
        {
            set => titleLabel.Text = value; // titleLabel은 private이지만 속성을 통해 값을 설정
        }

        public string MovieGenre
        {
            set => genreLabel.Text = value;
        }

        public string MovieDirector
        {
            set => directorLabel.Text = value;
        }

        public string LeadActors
        {
            set => leadActorLabel.Text = value;
        }

        public Image PosterImage
        {
            set => posterPictureBox.Image = value;
        }
    }
}
