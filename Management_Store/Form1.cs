using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Management_Store
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            //timeball.Tick += new EventHandler(rocketup);
            //timeball.Interval = 20;
            //timeball.Start();
        }
        
        Timer time_rocket = new Timer();
        Timer time_slide = new Timer();

        public bool rocket_slide = false;

        private void bunifuImageButton1_Click(object sender, EventArgs e)
        {
            this.Close();
        }



        private void btn_login_Click_1(object sender, EventArgs e)
        {
            time_slide.Tick += new EventHandler(panel_left_move);
            time_slide.Interval = 10;
            time_slide.Start();

            pic_rocket.Image.RotateFlip(RotateFlipType.Rotate90FlipY);
            bunifuTransition2.HideSync(panel_title);
            pic_rocket.Visible = false;
            bunifuTransition1.ShowSync(pic_rocket);
      
        
            time_rocket.Tick += new EventHandler(rocketup);
            time_rocket.Interval = 20;
            time_rocket.Start();


          





        }
   
        int move = 5;
        int rockright = 5;

        public void panel_left_move(object sender, EventArgs e)
        {
            if(panel_left.Size.Width < 1050)
            {
                panel_left.Size = new Size(427 + move, 464);
                move += 15;
            }
            else
            {
                rocket_slide = true;
                time_slide.Stop();
            }
          
        }

        public void rocketup(object sender,EventArgs e)
        {
            if(pic_rocket.Location.X < 838)
            {
                pic_rocket.Location = new Point(105 + rockright, 172);
                rockright += 10;
            }
            else
            {
                time_rocket.Stop();
                Dashboard dbrd = new Dashboard();
                this.Hide();
                dbrd.Show();

            }


        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Form1_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btn_login_Click_1(sender, e);
            }
        }
    }
}
