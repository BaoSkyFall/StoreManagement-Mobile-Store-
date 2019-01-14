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
    public partial class UC_Product : UserControl
    {
        public UC_Product()
        {
            InitializeComponent();
        }
        public bool add = false;
        public int loaded_Record = 0;
        public int page_number = 1;
        public int number_record = 15;
        public string path = "";
        public List<PRODUCT> db_excel = new List<PRODUCT>();
        void Loading()
        {
            using (DataStoreManagementDataContext db = new DataStoreManagementDataContext())
            {
                bunifuCustomDataGrid1.DataSource = db.PRODUCTs.ToList();
            }
        }
        public List<PRODUCT> Loaded_Record(int page,int recordNum)
        {
            List<PRODUCT> resulf = new List<PRODUCT>();
            using (DataStoreManagementDataContext db = new DataStoreManagementDataContext())
            {
                resulf = db.PRODUCTs.Skip((page - 1) * recordNum).Take(recordNum).ToList();
            }
                return resulf;
        }
        private void UC_Product_Load(object sender, EventArgs e)
        {
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

        private void bunifuCustomDataGrid1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int index = bunifuCustomDataGrid1.CurrentRow.Index;
            txt_id.Text = bunifuCustomDataGrid1.Rows[index].Cells[0].Value.ToString();
            txt_name.Text = bunifuCustomDataGrid1.Rows[index].Cells[1].Value.ToString();
            txt_category.Text = bunifuCustomDataGrid1.Rows[index].Cells[2].Value.ToString();
            txt_producer.Text = bunifuCustomDataGrid1.Rows[index].Cells[3].Value.ToString();
            txt_purchase.Text = bunifuCustomDataGrid1.Rows[index].Cells[4].Value.ToString();
            txt_price.Text = bunifuCustomDataGrid1.Rows[index].Cells[5].Value.ToString();
            txt_inventory.Text = bunifuCustomDataGrid1.Rows[index].Cells[6].Value.ToString();
        }

        private void btn_add_Click(object sender, EventArgs e)
        {
            if(add)
            {
                using (DataStoreManagementDataContext db = new DataStoreManagementDataContext())
                {
                    try
                    {
                        PRODUCT prodct = new PRODUCT
                        {
                            ID = int.Parse(txt_id.Text),
                            NAME = txt_name.Text,
                            CATEGORY = txt_category.Text,
                            PRODUCER = txt_producer.Text,
                            PURCHASE_PRICE = int.Parse(txt_purchase.Text),
                            PRICE = int.Parse(txt_price.Text),
                            INVENTORY = int.Parse(txt_inventory.Text),
                        };
                        db.PRODUCTs.InsertOnSubmit(prodct);
                        db.SubmitChanges();
                        notifyIcon1.Visible = true;
                        notifyIcon1.Icon = SystemIcons.Exclamation;
                        notifyIcon1.BalloonTipTitle = "Add Successfull!";
                        notifyIcon1.BalloonTipText = "Your product is added in Database!";
                        notifyIcon1.BalloonTipIcon = ToolTipIcon.Info;
                        notifyIcon1.ShowBalloonTip(1000);
                 
                      

                    }
                    catch
                    {
                        notifyIcon1.Visible = true;
                        notifyIcon1.Icon = SystemIcons.Exclamation;
                        notifyIcon1.BalloonTipTitle = "Can't Add new Product to Database";
                        notifyIcon1.BalloonTipText = "Check your input is Valid!";
                        notifyIcon1.BalloonTipIcon = ToolTipIcon.Error;
                        notifyIcon1.ShowBalloonTip(1000);
                    }

                }
                Loading();
                bunifuCustomDataGrid1.DataSource = Loaded_Record(page_number, number_record);

            }

        }

        private void btn_delete_Click(object sender, EventArgs e)
        {
            if(!add)
            {
                using (DataStoreManagementDataContext db = new DataStoreManagementDataContext())
                {
                    try
                    {
                        int index = bunifuCustomDataGrid1.CurrentRow.Index;
                        index = int.Parse(bunifuCustomDataGrid1.Rows[index].Cells[0].Value.ToString());

                        PRODUCT prdct = db.PRODUCTs.SingleOrDefault(x => x.ID == index);
                        db.PRODUCTs.DeleteOnSubmit(prdct);
                        db.SubmitChanges();
                        notifyIcon1.Visible = true;
                        notifyIcon1.Icon = SystemIcons.Exclamation;
                        notifyIcon1.BalloonTipTitle = "Delete Successful";
                        notifyIcon1.BalloonTipText = "Your product has been deleted in Database!";
                        notifyIcon1.BalloonTipIcon = ToolTipIcon.Info;
                        notifyIcon1.ShowBalloonTip(1000);
                    }
                    catch
                    {
                        notifyIcon1.Visible = true;
                        notifyIcon1.Icon = SystemIcons.Exclamation;
                        notifyIcon1.BalloonTipTitle = "Can't Delete new Product to Database";
                        notifyIcon1.BalloonTipText = "Check your id is Valid!";
                        notifyIcon1.BalloonTipIcon = ToolTipIcon.Error;
                        notifyIcon1.ShowBalloonTip(1000);
                    }

                }
                Loading();
                bunifuCustomDataGrid1.DataSource = Loaded_Record(page_number, number_record);

            }

        }

        private void btn_update_Click(object sender, EventArgs e)
        {
            if(!add)
            {
                using (DataStoreManagementDataContext db = new DataStoreManagementDataContext())
                {
                    try
                    {
                        PRODUCT prodct = new PRODUCT
                        {
                            ID = int.Parse(txt_id.Text),
                            NAME = txt_name.Text,
                            CATEGORY = txt_category.Text,
                            PRODUCER = txt_producer.Text,
                            PURCHASE_PRICE = int.Parse(txt_purchase.Text),
                            PRICE = int.Parse(txt_price.Text),
                            INVENTORY = int.Parse(txt_inventory.Text),
                        };
                        PRODUCT temp = db.PRODUCTs.SingleOrDefault(x => x.ID == prodct.ID);
                        temp.ID = int.Parse(txt_id.Text);
                        temp.NAME = txt_name.Text;
                        temp.CATEGORY = txt_category.Text;
                        temp.PRODUCER = txt_producer.Text;
                        temp.PURCHASE_PRICE = int.Parse(txt_purchase.Text);
                        temp.PRICE = int.Parse(txt_price.Text);
                        temp.INVENTORY = int.Parse(txt_inventory.Text);

                        db.SubmitChanges();

                        notifyIcon1.Visible = true;
                        notifyIcon1.Icon = SystemIcons.Exclamation;
                        notifyIcon1.BalloonTipTitle = "Update Successful!";
                        notifyIcon1.BalloonTipText = "Your product has been updated in Database!";
                        notifyIcon1.BalloonTipIcon = ToolTipIcon.Info;
                        notifyIcon1.ShowBalloonTip(1000);
                    }
                    catch
                    {
                        notifyIcon1.Visible = true;
                        notifyIcon1.Icon = SystemIcons.Exclamation;
                        notifyIcon1.BalloonTipTitle = "Can't Delete new Product to Database";
                        notifyIcon1.BalloonTipText = "Check your id is Valid!";
                        notifyIcon1.BalloonTipIcon = ToolTipIcon.Error;
                        notifyIcon1.ShowBalloonTip(1000);

                    }

                }
                Loading();
                bunifuCustomDataGrid1.DataSource = Loaded_Record(page_number, number_record);

            }



        }


        private void bunifuFlatButton1_Click(object sender, EventArgs e)
        {
            if(!add)
            {
                btn_add.Visible = true;
                txt_id.Enabled = true;
                txt_id.Text = "";
                txt_name.Text = "";
                txt_category.Text = "";
                txt_producer.Text = "";
                txt_purchase.Text = "";
                txt_price.Text = "";
                txt_inventory.Text = "";
                add = true;
                bunifuFlatButton1.Text = "Click To Finish Your Adding";
                bunifuFlatButton1.Normalcolor = Color.FromArgb(52, 152, 219);
            }
            else
            {
                bunifuFlatButton1.Normalcolor = Color.FromArgb(39, 174, 96);
                bunifuFlatButton1.Text = "Add New Product";
                add = false;
                btn_add.Visible = false;
                txt_id.Enabled = false;
            }
     
        }

        private void bunifuFlatButton2_Click(object sender, EventArgs e)
        {
            if(db_excel == null)
            {
                Loading();
                bunifuCustomDataGrid1.DataSource = Loaded_Record(page_number, number_record);
            }
            else
            {
                try
                {
                    int totalrecord;
                    using (DataStoreManagementDataContext db = new DataStoreManagementDataContext())
                    {
                        totalrecord = db.PRODUCTs.Count();

                        int temp = db.PRODUCTs.OrderByDescending(x => x.ID).First().ID;
                        if (temp <= totalrecord)
                            temp = totalrecord;
                        for (int i = 0; i < db_excel.Count; i++)
                        {
                            db_excel[i].ID = db_excel[i].ID + temp;
                            totalrecord = db.PRODUCTs.Count();
                            db.PRODUCTs.InsertOnSubmit(db_excel[i]);
                            db.SubmitChanges();


                        }

                        
                        bunifuCustomDataGrid1.DataSource = Loaded_Record(page_number, number_record);
                    }
                }
                catch
                {
                    notifyIcon1.Visible = true;
                    notifyIcon1.Icon = SystemIcons.Exclamation;
                    notifyIcon1.BalloonTipTitle = "Can't Add new Product to Database";
                    notifyIcon1.BalloonTipText = "Check your input is Valid!";
                    notifyIcon1.BalloonTipIcon = ToolTipIcon.Error;
                    notifyIcon1.ShowBalloonTip(1000);
                }
                
            }
            txt_search.Text = "";

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

        private void bunifuFlatButton3_Click(object sender, EventArgs e)
        {
            Import_Excel excel = new Import_Excel();
            db_excel = excel.db_form;
            excel.Show();
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
    }
}
