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
    public partial class UC_Dashboard : UserControl
    {
        public UC_Dashboard()
        {
            InitializeComponent();
        }
        public List<BILL> bil_temp = new List<BILL>();
        private void bunifuDatepicker1_onValueChanged(object sender, EventArgs e)
        {

        }

        private void bunifuDatepicker1_onValueChanged_1(object sender, EventArgs e)
        {
            txt_start.Text = bunifuDatepicker1.Value.ToString("dd - MM - yy");
        }

        private void bunifuDatepicker3_onValueChanged(object sender, EventArgs e)
        {
            txt_from.Text = bunifuDatepicker3.Value.ToString("dd - MM - yy");

        }

        private void bunifuDatepicker2_onValueChanged(object sender, EventArgs e)
        {
            txt_to.Text = bunifuDatepicker2.Value.ToString("dd - MM - yy");

        }

        private void btn_loadChart_Click(object sender, EventArgs e)
        {
            //Clear Biểu đồ
            foreach (var series in chart1.Series)
            {
                series.Points.Clear();
            }
            //Xử lý đọc doanh số từ NSX
            if (radiobtn_producer.Checked)
            {
                if (radiobtn_time.Checked)
                {
                    if (dropdown_type.selectedValue == "Day")
                    {
                        
                            using (DataStoreManagementDataContext db = new DataStoreManagementDataContext())
                            {

                                var temp = db.GETPRODUCERBYDAY(bunifuDatepicker1.Value.Date).ToList();
                                foreach (var i in temp)
                                {
                                    chart1.Series["Value"].Points.AddXY(i.PRODUCER, i.Total);
                                }

                            }

                      
                      
                    }
                    else if (dropdown_type.selectedValue == "Month")
                    {
                        
                            using (DataStoreManagementDataContext db = new DataStoreManagementDataContext())
                            {

                                var temp = db.GETPRODUCERBYMONTH(bunifuDatepicker1.Value.Date.Month.ToString(), bunifuDatepicker1.Value.Date.Year.ToString()).ToList();
                                foreach (var i in temp)
                                {
                                    chart1.Series["Value"].Points.AddXY(i.PRODUCER, i.Total);
                                }

                            }

                        
                    }
                    else
                    {
                        using (DataStoreManagementDataContext db = new DataStoreManagementDataContext())
                        {

                            var temp = db.GETPRODUCERBYYEAR(bunifuDatepicker1.Value.Date.Year.ToString()).ToList();
                            foreach (var i in temp)
                            {
                                chart1.Series["Value"].Points.AddXY(i.PRODUCER, i.Total);
                            }

                        }
                    }

                }
                else
                {
                    using (DataStoreManagementDataContext db = new DataStoreManagementDataContext())
                    {

                        var temp = db.GETPRODUCERBY2DAYS(bunifuDatepicker3.Value.Date, bunifuDatepicker2.Value.Date).ToList();
                        foreach (var i in temp)
                        {
                            chart1.Series["Value"].Points.AddXY(i.PRODUCER, i.Total);
                        }

                    }
                }
            }
            //Xử lý đọc sản phẩm từ NSX
            else
            {
                if (radiobtn_time.Checked)
                {
                    if (dropdown_type.selectedValue == "Day")
                    {
                        
                            using (DataStoreManagementDataContext db = new DataStoreManagementDataContext())
                            {

                                var temp = db.GETPRODUCTBYDAY(bunifuDatepicker1.Value.Date,dropdown_producer.selectedValue).ToList();
                                foreach (var i in temp)
                                {
                                    chart1.Series["Value"].Points.AddXY(i.NAME_PRODUCT, i.Total);
                                }

                            }
                        
                     
                    }
                    else if (dropdown_type.selectedValue == "Month")
                    {
                        
                            using (DataStoreManagementDataContext db = new DataStoreManagementDataContext())
                            {

                                var temp = db.GETPRODUCTBYMONTH(bunifuDatepicker1.Value.Date.Month.ToString(), bunifuDatepicker1.Value.Date.Year.ToString(),dropdown_producer.selectedValue).ToList();
                                foreach (var i in temp)
                                {
                                    chart1.Series["Value"].Points.AddXY(i.NAME_PRODUCT, i.Total);
                                }

                            }

                     
                    }
                    else
                    {
                        using (DataStoreManagementDataContext db = new DataStoreManagementDataContext())
                        {

                            var temp = db.GETPRODUCTBYYEAR(bunifuDatepicker1.Value.Date.Year.ToString(), dropdown_producer.selectedValue).ToList();
                            foreach (var i in temp)
                            {
                                chart1.Series["Value"].Points.AddXY(i.NAME_PRODUCT, i.Total);
                            }

                        }
                    }

                }
                else
                {
                    using (DataStoreManagementDataContext db = new DataStoreManagementDataContext())
                    {

                        var temp = db.GETPRODUCTBY2DAYS(bunifuDatepicker3.Value.Date, bunifuDatepicker2.Value.Date,dropdown_producer.selectedValue).ToList();
                        foreach (var i in temp)
                        {
                            chart1.Series["Value"].Points.AddXY(i.NAME_PRODUCT, i.Total);
                        }

                    }
                }
            }
            
        }

        private void radiobtn_product_CheckedChanged(object sender, EventArgs e)
        {
            dropdown_producer.Enabled = true;
            using (DataStoreManagementDataContext db = new DataStoreManagementDataContext())
            {
                dropdown_producer.Clear();
                var temp = db.GETPRODUCER().ToList();
                foreach (var i in temp)
                {
                    dropdown_producer.AddItem(i.PRODUCER);
                }

            }
        }

        private void radiobtn_producer_CheckedChanged(object sender, EventArgs e)
        {
            dropdown_producer.Enabled = false;
        }

        public void UC_Dashboard_Load(object sender, EventArgs e)
        {
            using (DataStoreManagementDataContext db = new DataStoreManagementDataContext())
            {
                lbl_product.Text = db.PRODUCTs.Count().ToString();
                lbl_producer.Text = db.GETPRODUCER().Count().ToString();
                lbl_invoice.Text = db.BILLs.Count().ToString();
            }
        }
    }
}
