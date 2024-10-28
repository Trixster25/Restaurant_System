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
    public partial class Items : Form
    {
        public Items()
        {
            InitializeComponent();
            Con = new Functions();
            ShowItems();
            GetCategories();
        }
        Functions Con;
        private void ShowItems()
        {
            try
            {
                string Query = "select * from ItemTbl";
                ItemsList.DataSource = Con.GetData(Query);
            }
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.Message);
            }

        }

        private void GetCategories()
        {
            string Query = "select * from CategoryTbl";
            CatCb.ValueMember = Con.GetData(Query).Columns["CatCode"].ToString();
            CatCb.DisplayMember = Con.GetData(Query).Columns["CatName"].ToString();
            CatCb.DataSource = Con.GetData(Query);
        }
       
        private void AddBtn_Click(object sender, EventArgs e)
        {
            if (NameTb.Text == "" || PriceTb.Text == "" || CatCb.SelectedIndex == -1)
            {
                MessageBox.Show("Missing Data!!!");
            }
            else
            {
                try
                {
                    string Name = NameTb.Text;
                    int Category = Convert.ToInt32(CatCb.SelectedValue.ToString());
                    int Price = Convert.ToInt32(PriceTb.Text);
                    string Query = "insert into ItemTbl values('{0}', {1}, {2})";
                    Query = string.Format(Query, Name, Category, Price);
                    Con.SetData(Query);
                    ShowItems();
                    MessageBox.Show("Item Added!!");
                }
                catch (Exception Ex)
                {
                    MessageBox.Show(Ex.Message);
                }
            }
        }
        int key = 0;
        private void ItemList_CellContentClick(Object sender, DataGridViewCellEventArgs e)
        {
            NameTb.Text = ItemsList.SelectedRows[0].Cells[1].Value.ToString();
            CatCb.Text = ItemsList.SelectedRows[0].Cells[2].Value.ToString();
            PriceTb.Text = ItemsList.SelectedRows[0].Cells[1].Value.ToString();
            if (NameTb.Text == "")
            {
                key = 0;
            }
            else
            {
                key = Convert.ToInt32(ItemsList.SelectedRows[0].Cells[0].Value.ToString());
            }
        }

        private void EditBtn_Click(object sender, EventArgs e)
        {
            if (NameTb.Text == "" || PriceTb.Text == "" || CatCb.SelectedIndex == -1)
            {
                MessageBox.Show("Missing Data!!!");
            }
            else
            {
                try
                {
                    string Name = NameTb.Text;
                    int Category = Convert.ToInt32(CatCb.SelectedValue.ToString());
                    int Price = Convert.ToInt32(PriceTb.Text);
                    string Query = "update ItemTbl set ItName = '{0}', ItPrice = {1}, ItCategory = {2} where ItNum = {3}";
                    Query = string.Format(Query, Name, Category, Price, key);
                    Con.SetData(Query);
                    ShowItems();
                    MessageBox.Show("Item Updated!!");
                }
                catch (Exception Ex)
                {
                    MessageBox.Show(Ex.Message);
                }
            }
        }

        private void DeleteBtn_Click(object sender, EventArgs e)
        {
            if (key == 0)
            {
                MessageBox.Show("Missing Data!!!");
            }
            else
            {
                try
                {
                    string Name = NameTb.Text;
                    int Category = Convert.ToInt32(CatCb.SelectedValue.ToString());
                    int Price = Convert.ToInt32(PriceTb.Text);
                    string Query = "delete from ItemTbl where ItNum = {0}";
                    Query = string.Format(Query, key);
                    Con.SetData(Query);
                    ShowItems();
                    MessageBox.Show("Item Deleted!!");
                }
                catch (Exception Ex)
                {
                    MessageBox.Show(Ex.Message);
                }
            }
        }

        private void ItemsList_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void UserLbl_Click(object sender, EventArgs e)
        {
            Users Obj = new Users();
            Obj.Show();
            this.Hide();
        }

        private void CatLbl_Click(object sender, EventArgs e)
        {
            Category Obj = new Category();
            Obj.Show();
            this.Hide();
        }

        private void label2_Click(object sender, EventArgs e)
        {
            Billing Obj = new Billing();
            Obj.Show();
            this.Hide();
        }

        private void pictureBox7_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void label4_Click(object sender, EventArgs e)
        {
            
        }

        private void label5_Click(object sender, EventArgs e)
        {
            Login Obj = new Login();
            Obj.Show();
            this.Hide();
        }
    }
}
