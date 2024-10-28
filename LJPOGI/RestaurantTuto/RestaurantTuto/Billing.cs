using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using iTextSharp.text;
using iTextSharp.text.pdf;
using System.IO;
using System.Drawing.Printing;

namespace RestaurantTuto
{
    public partial class Billing : Form
    {
        private PrintDocument printDocument;
        private PrintPreviewDialog printPreviewDialog;
       
        public Billing()
        {
            InitializeComponent();
            Con = new Functions();
            ShowItems();


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
        int n = 0;
        int GrdTotal = 0;

        private void AddBtn_Click(object sender, EventArgs e)
        {
            if(QtyTb.Text == "" || PriceTb.Text == "")
            {
                MessageBox.Show("Missing Data!!!");
            }
            else
            {
                int Qte = Convert.ToInt32(QtyTb.Text);
                int Total = Convert.ToInt32(PriceTb.Text) * Qte;
                DataGridViewRow newRow = new DataGridViewRow();
                newRow.CreateCells(BillDGV);
                newRow.Cells[0].Value = n + 1;
                newRow.Cells[1].Value = ItemTb.Text;
                newRow.Cells[2].Value = PriceTb.Text;
                newRow.Cells[3].Value = QtyTb.Text;
                newRow.Cells[4].Value = "Php " + Total;
                BillDGV.Rows.Add(newRow);
                n++;
                GrdTotal = GrdTotal + Total;
                GrdTotalLbl.Text = "Php " + GrdTotal;
            }
        }
        int key = 0;
        private void ItemsList_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            ItemTb.Text = ItemsList.SelectedRows[0].Cells[1].Value.ToString();
            //CatCb.Text = ItemsList.SelectedRows[0].Cells[2].Value.ToString();
            PriceTb.Text = ItemsList.SelectedRows[0].Cells[3].Value.ToString();
            if (ItemTb.Text == "")
            {
                key = 0;
            }
            else
            {
                key = Convert.ToInt32(ItemsList.SelectedRows[0].Cells[0].Value.ToString());
            }
        }

        private void UserLbl_Click(object sender, EventArgs e)
        {
            
        }

        private void ItemLbl_Click(object sender, EventArgs e)
        {
            
        }

        private void CatLbl_Click(object sender, EventArgs e)
        {
            
        }

        private void BillingLbl_Click(object sender, EventArgs e)
        {
            
        }

        private void CloseBtn_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void label5_Click(object sender, EventArgs e)
        {
            Login Obj = new Login();
            Obj.Show();
            this.Hide();
        }

        private void PrintBtn_Click(object sender, EventArgs e)
        {
            // Create a PDF document
            Document doc = new Document();
            try
            {
                string path = @"C:\Users\loren\Downloads\Receipt.pdf"; // Define the path for the PDF file

                PdfWriter.GetInstance(doc, new FileStream(path, FileMode.Create));

                doc.Open();

                // Create a PdfPTable with the same number of columns as your DataGridView
                PdfPTable pdfTable = new PdfPTable(BillDGV.Columns.Count);

                // Add headers from the DataGridView to the PDF table
                for (int i = 0; i < BillDGV.Columns.Count; i++)
                {
                    pdfTable.AddCell(new Phrase(BillDGV.Columns[i].HeaderText));
                }

                // Add rows from the DataGridView to the PDF table
                for (int j = 0; j < BillDGV.Rows.Count; j++)
                {
                    for (int k = 0; k < BillDGV.Columns.Count; k++)
                    {
                        if (BillDGV[k, j].Value != null)
                        {
                            pdfTable.AddCell(new Phrase(BillDGV[k, j].Value.ToString()));
                        }
                    }
                }

                // Add the PDF table to the document
                doc.Add(pdfTable);
                MessageBox.Show("PDF file created successfully at: " + path);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                // Close the document
                doc.Close();
            }
        }

        private void Billing_Load(object sender, EventArgs e)
        {

        }
    }
}
