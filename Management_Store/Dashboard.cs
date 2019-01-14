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
    public partial class Dashboard : Form
    {
        public Dashboard()
        {
            InitializeComponent();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            System.Environment.Exit(1);

        }

        private void bunifuImageButton2_Click(object sender, EventArgs e)
        {
            if(panel_sidemenu.Width == 80)
            {
                panel_sidemenu.Width = 230;
                panel_sidemenu.Visible = false;
                Panel_Animator.ShowSync(panel_sidemenu);
                panel_temp.Location = new Point(225, 61);
                panel_temp.Size = new Size(746, 478);
                Logo_Animator.Show(panel_logo);

            }
            else
            {
                panel_logo.Visible = false;
                panel_sidemenu.Width = 80;
                panel_sidemenu.Visible = false;
                panel_temp.Location = new Point(65, 61);
                panel_temp.Size = new Size(906, 478);
                Panel_Animator.ShowSync(panel_sidemenu);
                
            }
        }

        private void bunifuFlatButton4_Click(object sender, EventArgs e)
        {
            panel_tick.Location = new Point(1, bunifuFlatButton4.Location.Y);
            uC_Product1.Visible = true;
            uC_Product1.BringToFront();



        }

        private void bunifuFlatButton1_Click(object sender, EventArgs e)
        {
            panel_tick.Location = new Point(1, bunifuFlatButton1.Location.Y);
            uC_Dashboard1.Visible = true;
            uC_Dashboard1.BringToFront();
        }

        private void bunifuFlatButton2_Click(object sender, EventArgs e)
        {
            panel_tick.Location = new Point(1, bunifuFlatButton2.Location.Y);
            transaction1.Visible = true;
            transaction1.BringToFront();
        }

        private void Dashboard_Load(object sender, EventArgs e)
        {

        }
    }
}
