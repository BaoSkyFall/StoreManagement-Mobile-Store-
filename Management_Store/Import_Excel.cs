using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Excel = Microsoft.Office.Interop.Excel;
using System.Data.OleDb;
namespace Management_Store
{
    public partial class Import_Excel : Form
    {
        public Import_Excel()
        {
            InitializeComponent();
        }
        public List<PRODUCT> db_form = new List<PRODUCT>();
        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog fopen = new OpenFileDialog();
            fopen.Filter = "(Tất Cả các Tệp) |*.*| (Các tệp excel)| *.xlsx";
            fopen.ShowDialog();
            if(fopen.FileName != "")
            {
                txt_path.Text = fopen.FileName;
                

            }
            else
            {
                MessageBox.Show("Bạn không chọn tập tin nào!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if(txt_path.Text != "")
            {
                try
                {
                    string constr = "Provider = Microsoft.Jet.OLEDB.4.0; Data Source = " + txt_path.Text + "; Extended Properties =\"Excel 8.0; HDR = Yes;\";";
                    OleDbConnection con = new OleDbConnection(constr);
                    string str = "Sheet" + vl_sheet.Value.ToString();
                    OleDbDataAdapter sda = new OleDbDataAdapter("Select * From [" + str + "$]", con);
                    DataTable dt = new DataTable();
                    sda.Fill(dt);
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        PRODUCT prdct = new PRODUCT();
                        prdct.ID = Convert.ToInt32(dt.Rows[i]["ID"]);
                        prdct.NAME = dt.Rows[i]["NAME"].ToString();
                        prdct.CATEGORY = dt.Rows[i]["CATEGORY"].ToString();
                        prdct.PRODUCER = dt.Rows[i]["PRODUCER"].ToString();
                        prdct.PURCHASE_PRICE = Convert.ToInt32(dt.Rows[i]["PURCHASE_PRICE"]);
                        prdct.PRICE = Convert.ToInt32(dt.Rows[i]["PRICE"]);
                        prdct.INVENTORY = Convert.ToInt32(dt.Rows[i]["INVENTORY"]);
                        db_form.Add(prdct);
                        this.Close();

                    }
              

                }

                catch
                {
                    MessageBox.Show("Khong doc duoc file");
                }
                

            }
        }
    }
}
