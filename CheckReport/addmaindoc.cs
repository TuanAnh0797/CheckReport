using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace CheckReport
{
    public partial class addmaindoc : Form
    {
        string Ipserver;
        BindingList<Maindocadd> listdata;
        public addmaindoc()
        {
            InitializeComponent();
            listdata = new BindingList<Maindocadd>();
            CultureInfo myculture = new CultureInfo("en-US");
            myculture.DateTimeFormat.ShortDatePattern = "dd/MM/yyyy";
            myculture.DateTimeFormat.LongDatePattern = "dd/MM/yyyy HH:mm:ss";
            Thread.CurrentThread.CurrentCulture = myculture;

            IPAddress[] listip = Dns.GetHostAddresses(Dns.GetHostName());
            listip.ToList().ForEach(ip =>
            {
                string a = ip.ToString();
                if (ip.ToString().Contains("10.27.4"))
                {
                    Ipserver = "10.27.4.218";

                }
                else if (ip.ToString().Contains("192.168.2"))
                {
                    Ipserver = "192.168.2.159";
                }

            });
            if (Ipserver == "")
            {
                MessageBox.Show("Không thể kết nối với máy chủ\n Hãy kiểm tra lại địa chỉ IP", "Lỗi");
                Environment.Exit(0);
            }
            
            dtg_data.DataSource = listdata;
            dtg_data.Columns[0].HeaderText = "STT";
            dtg_data.Columns[1].HeaderText = "Mã tài liệu";
            dtg_data.Columns[2].HeaderText = "Tên Line";
            dtg_data.Columns[3].HeaderText = "Thời gian cập nhật";
            loaddata();
        }
        public void loaddata()
        {
            listdata.Clear();
            using (MySqlConnection conn = new MySqlConnection($"server={Ipserver};uid=root;" + "pwd=6006;database=test"))
            {
                conn.Open();
                MySqlDataAdapter adap = new MySqlDataAdapter($"SELECT Id_Doccument,Name_Line,Time_Update FROM checkmachine.managermaindoccument;", conn);
                DataTable dt = new DataTable();
                adap.Fill(dt);
                var mydata = from DataRow p in dt.Rows
                             select p;
                int s = 1;
                foreach (var item in mydata)
                {
                    listdata.Add(new Maindocadd() { STT = s, Name_Doc = item["Id_Doccument"].ToString(),Name_Line = item["Name_Line"].ToString(), Time_Update = item["Time_Update"] == null ? "" : item["Time_Update"].ToString() });
                    s++;
                }
                
                conn.Close();
            }
            using (MySqlConnection conn = new MySqlConnection($"server={Ipserver};uid=root;" + "pwd=6006;database=test"))
            {
                conn.Open();
                MySqlDataAdapter adap = new MySqlDataAdapter($"SELECT Id_Doccument,Name_Line,Time_Update FROM checkmachine.managermaindoccument Group by Name_Line ;", conn);
                DataTable dt = new DataTable();
                adap.Fill(dt);
                var mydata = from DataRow p in dt.Rows
                             select (string)p["Name_Line"];
                int s = 1;
                cmb_nameline.DataSource = mydata.ToList();
                conn.Close();
            }
        }

        private void btn_addmaindoc_Click(object sender, EventArgs e)
        {
            if (txb_NameLineMain.Text != "" && txb_IdDocMain.Text != "")
            {
                try
                {
                    using (MySqlConnection conn = new MySqlConnection($"server={Ipserver};uid=root;" + "pwd=6006;database=test"))
                    {
                        conn.Open();
                        MySqlCommand cmd = new MySqlCommand($"INSERT INTO `checkmachine`.`managermaindoccument` (`Id_Doccument`, `Name_Doccument`, `Name_Line`, `Time_Update`) VALUES ('{txb_IdDocMain.Text}', '', '{txb_NameLineMain.Text}', '{DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")}');", conn);
                        cmd.ExecuteNonQuery();
                        conn.Close();
                    }
                    txb_NameLineMain.Text = "";
                    txb_IdDocMain.Text = "";
                    MessageBox.Show("Thêm thành công");
                    loaddata();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }

            }
            else
            {
                MessageBox.Show("Chưa điền đủ thông tin");
            }
        }

        private void btn_delmaindoc_Click(object sender, EventArgs e)
        {
            if (txb_IdDocMain.Text != "")
            {
                if( MessageBox.Show($"Bạn chắc chắn muốn xóa mã {txb_IdDocMain.Text}", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    try
                    {
                        using (MySqlConnection conn = new MySqlConnection($"server={Ipserver};uid=root;" + "pwd=6006;database=test"))
                        {
                            conn.Open();
                            MySqlCommand cmd = new MySqlCommand($"DELETE FROM `checkmachine`.`managermaindoccument` WHERE (`Id_Doccument` = '{txb_IdDocMain.Text}');", conn);
                            cmd.ExecuteNonQuery();
                            conn.Close();
                        }
                        txb_NameLineMain.Text = "";
                        txb_IdDocMain.Text = "";
                        MessageBox.Show("Xóa thành công");
                        loaddata();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }

            }
        }

        private void btn_filter_Click(object sender, EventArgs e)
        {
            dtg_data.Columns[0].Width = 50;
            listdata.Clear();
            using (MySqlConnection conn = new MySqlConnection($"server={Ipserver};uid=root;" + "pwd=6006;database=test"))
            {
                conn.Open();
                MySqlDataAdapter adap = new MySqlDataAdapter($"SELECT Id_Doccument,Name_Line,Time_Update FROM checkmachine.managermaindoccument Where Name_Line = '{cmb_nameline.SelectedValue.ToString()}'", conn);
                DataTable dt = new DataTable();
                adap.Fill(dt);
                var mydata = from DataRow p in dt.Rows
                             select p;
                int s = 1;
                foreach (var item in mydata)
                {
                    listdata.Add(new Maindocadd() { STT = s, Name_Doc = item["Id_Doccument"].ToString(), Name_Line = item["Name_Line"].ToString(), Time_Update = item["Time_Update"] == null ? "" : item["Time_Update"].ToString() });
                    s++;
                }

                conn.Close();
            }
        }

        private void btn_loadall_Click(object sender, EventArgs e)
        {
            dtg_data.Columns[0].Width = 50;
            loaddata();
        }
    }
}
