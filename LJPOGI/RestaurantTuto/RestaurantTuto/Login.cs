using Microsoft.VisualBasic.ApplicationServices;
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
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
            Con = new Functions();
        }
        Functions Con;
        int failedAttempts = 0;

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void CloseBtn_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void LoginBtn_Click(object sender, EventArgs e)
        {
            if (UNameTb.Text == "" || PasswordTb.Text == "")
            {
                MessageBox.Show("Wrong Username or Password!");
            }
            else if (UNameTb.Text == "Admin" && PasswordTb.Text == "Admin")
            {
                Users Obj = new Users();
                Obj.Show();
                this.Hide();
            }
            else
            {
                string Query = "select * from UsersTbl where UName = '{0}' and UPass = '{1}'";
                Query = string.Format(Query, UNameTb.Text, PasswordTb.Text);
                DataTable dt = Con.GetData(Query);
                if (dt.Rows.Count == 0)
                {
                    MessageBox.Show("Missing Data!!!");
                    failedAttempts++;

                    if (failedAttempts >= 3)
                    {
                        MessageBox.Show("Try Again in 20 Seconds");
                        Task.Delay(20000); // Wait for 20 seconds
                        Application.Exit();
                    }
                }
                else
                {
                    Billing Obj = new Billing();
                    Obj.Show();
                    this.Hide();
                }
            }
        }
    }
}
