using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Management_Store
{
    public partial class ManageInvoice : UserControl
    {
        public ManageInvoice()
        {
            InitializeComponent();
        }
        public int loaded_Record = 0;
        public int page_number = 1;
        public int number_record = 15;
        public string path = "";
        public List<PRODUCT> db_excel = new List<PRODUCT>();
        void Loading()
        {
            using (DataStoreManagementDataContext db = new DataStoreManagementDataContext())
            {
                data_grid.DataSource = db.PRODUCTs.ToList();
            }
        }
        public List<BILL> Loaded_Record(int page, int recordNum)
        {
            List<BILL> resulf = new List<BILL>();
            using (DataStoreManagementDataContext db = new DataStoreManagementDataContext())
            {
                resulf = db.BILLs.Skip((page - 1) * recordNum).Take(recordNum).ToList();
            }
            return resulf;
        }
        private void UC_Product_Load(object sender, EventArgs e)
        {
            try
            {
                Loading();
                data_grid.DataSource = Loaded_Record(page_number, number_record);


            }
            catch
            {
                MessageBox.Show("Cannot Find Database!");
            }
        }
        public void ManageInvoice_Load(object sender, EventArgs e)
        {
            try
            {
                Loading();
                data_grid.DataSource = Loaded_Record(page_number, number_record);


            }
            catch
            {
                MessageBox.Show("Cannot Find Database!");
            }
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            NumericUpDown num = sender as NumericUpDown;
            int totalrecord = 0;
            using (DataStoreManagementDataContext db = new DataStoreManagementDataContext())
            {
                totalrecord = db.BILLs.Count();

            }
            num.Maximum = totalrecord / number_record + 1;
            page_number = (int)num.Value;
            data_grid.DataSource = Loaded_Record(page_number, number_record);
        }

        private void data_grid_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

            int index = data_grid.CurrentRow.Index;
            txt_bill.Text = data_grid.Rows[index].Cells[0].Value.ToString();
            txt_id.Text = data_grid.Rows[index].Cells[1].Value.ToString();
            txt_name.Text = data_grid.Rows[index].Cells[3].Value.ToString();
            txt_namecustomer.Text = data_grid.Rows[index].Cells[2].Value.ToString();
            txt_category.Text = data_grid.Rows[index].Cells[4].Value.ToString();
            txt_price.Text = data_grid.Rows[index].Cells[5].Value.ToString();
            lbl_date.Text = data_grid.Rows[index].Cells[6].Value.ToString();
            num_amout.Maximum = int.Parse(data_grid.Rows[index].Cells[7].Value.ToString());
            num_amout.Value = decimal.Parse(data_grid.Rows[index].Cells[7].Value.ToString());
            txt_advance.Text = data_grid.Rows[index].Cells[8].Value.ToString();
            txt_payment.Text = data_grid.Rows[index].Cells[9].Value.ToString();
            txt_total.Text = data_grid.Rows[index].Cells[10].Value.ToString();
            cb_paid.Checked = (bool)data_grid.Rows[index].Cells[11].Value;

        }

        private void bunifuFlatButton2_Click(object sender, EventArgs e)
        {
            Loading();
            data_grid.DataSource = Loaded_Record(page_number, number_record);

        }

        private void txt_search_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {

                using (DataStoreManagementDataContext db = new DataStoreManagementDataContext())
                {
                    if (e.KeyChar == (char)13)
                    {
                        var rs = db.BILLs.Where(q => q.NAME_PRODUCT.Contains(txt_search.Text)).ToList();
                        data_grid.DataSource = rs;

                    }
                }
            }
            catch
            {

            }
        }

        private void bunifuFlatButton4_Click(object sender, EventArgs e)
        {
            try
            {

                using (DataStoreManagementDataContext db = new DataStoreManagementDataContext())
                {
                     var rs = db.BILLs.Where(q => q.NAME_PRODUCT.Contains(txt_search.Text)).ToList();
                        data_grid.DataSource = rs;

                  
                }
            }
            catch
            {

            }
        }
    }
}
