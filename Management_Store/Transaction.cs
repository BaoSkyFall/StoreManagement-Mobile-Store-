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
    public partial class Transaction : UserControl
    {
        public Transaction()
        {
            InitializeComponent();
        }
        public int loaded_Record = 0;
        public int page_number = 1;
        public int number_record = 15;
        public List<PRODUCT> db_excel = new List<PRODUCT>();
        void Loading()
        {
            using (DataStoreManagementDataContext db = new DataStoreManagementDataContext())
            {
                bunifuCustomDataGrid1.DataSource = db.PRODUCTs.ToList();
            }
        }
        public List<PRODUCT> Loaded_Record(int page, int recordNum)
        {
            List<PRODUCT> resulf = new List<PRODUCT>();
            using (DataStoreManagementDataContext db = new DataStoreManagementDataContext())
            {
                resulf = db.PRODUCTs.Skip((page - 1) * recordNum).Take(recordNum).ToList();
            }
            return resulf;
        }
        private void bunifuCustomDataGrid1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int index = bunifuCustomDataGrid1.CurrentRow.Index;
            txt_id.Text = bunifuCustomDataGrid1.Rows[index].Cells[0].Value.ToString();
            txt_name.Text = bunifuCustomDataGrid1.Rows[index].Cells[1].Value.ToString();
            txt_category.Text = bunifuCustomDataGrid1.Rows[index].Cells[2].Value.ToString();
            txt_price.Text = bunifuCustomDataGrid1.Rows[index].Cells[5].Value.ToString();
            num_amout.Maximum = int.Parse(bunifuCustomDataGrid1.Rows[index].Cells[6].Value.ToString());

            txt_total.Text = txt_price.Text;
        }

        private void Transaction_Load(object sender, EventArgs e)
        {
            lbl_date.Text = DateTime.Now.ToString("dd - MM - yyyy");
            try
            {
                Loading();
                bunifuCustomDataGrid1.DataSource = Loaded_Record(page_number, number_record);


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
                totalrecord = db.PRODUCTs.Count();

            }
            num.Maximum = totalrecord / number_record + 1;
            page_number = (int)num.Value;
            bunifuCustomDataGrid1.DataSource = Loaded_Record(page_number, number_record);
        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void bunifuMaterialTextbox3_OnValueChanged(object sender, EventArgs e)
        {
            int result = int.Parse(txt_price.Text) * Convert.ToInt32(num_amout.Value) - int.Parse(txt_advance.Text);
            txt_total.Text = result.ToString();
        }

        private void bunifuDropdown1_onItemSelected(object sender, EventArgs e)
        {
            if(bunifuDropdown1.selectedIndex != 0)
            {
                txt_advance.Text = "0";
                txt_advance.Enabled = false;
            }
            else
            {
                txt_advance.Text = "0";
                txt_advance.Enabled = true;

            }
        }

        private void txt_search_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {

                using (DataStoreManagementDataContext db = new DataStoreManagementDataContext())
                {
                    if (e.KeyChar == (char)13)
                    {
                        var rs = db.PRODUCTs.Where(q => q.NAME.Contains(txt_search.Text)).ToList();
                        bunifuCustomDataGrid1.DataSource = rs;

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
                    
                        var rs = db.PRODUCTs.Where(q => q.NAME.Contains(txt_search.Text)).ToList();
                        bunifuCustomDataGrid1.DataSource = rs;

                   
                }
            }
            catch
            {

            }
        }

        private void num_amout_ValueChanged(object sender, EventArgs e)
        {
            if(txt_advance.Text != "")
            {
                int result = int.Parse(txt_price.Text) * Convert.ToInt32(num_amout.Value) - int.Parse(txt_advance.Text);
                txt_total.Text = result.ToString();
            }
           
        }
        private void txt_advance_OnValueChanged(object sender, EventArgs e)
        {
            if (txt_advance.Text != "")
            {
                int result = int.Parse(txt_price.Text) * Convert.ToInt32(num_amout.Value) - int.Parse(txt_advance.Text);
                txt_total.Text = result.ToString();
            }
      
        }
        private void btn_printbill_Click(object sender, EventArgs e)
        {

        }

      
    }
}
