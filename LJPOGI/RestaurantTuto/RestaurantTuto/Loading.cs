using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RestaurantTuto
{
    public partial class Loading : Form
    {
        public Loading()
        {
            InitializeComponent();
        }
        int startpoint = 0;

        private void timer1_Tick_1(object sender, EventArgs e)
        {
            startpoint += 3;
            MyProgress.Value = startpoint;
            if (MyProgress.Value == 100)
            {
                MyProgress.Value = 0;
                timer1.Stop();
                Login log = new Login();
                log.Show();
                this.Hide();

            }
        }

        private void guna2CustomGradientPanel1_Paint(object sender, PaintEventArgs e)
        {
            timer1.Start();
        }
    }
}
