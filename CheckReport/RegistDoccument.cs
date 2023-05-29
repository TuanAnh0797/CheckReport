using MySql.Data.MySqlClient;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace CheckReport
{
    public partial class RegistDoccument : Form
    {
        string filepath;
        string filename;
        string Ipserver;
        bool findline;

        public RegistDoccument()
        {
            InitializeComponent();
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
            using (MySqlConnection conn = new MySqlConnection($"server={Ipserver};uid=root;" + "pwd=6006;database=test"))
            {
                conn.Open();
                MySqlDataAdapter adap = new MySqlDataAdapter($"SELECT Name_Line FROM checkmachine.managermaindoccument Group by Name_Line", conn);
                DataTable dt = new DataTable();
                adap.Fill(dt);
                var mydata = from DataRow p in dt.Rows
                             select (string)p["Name_Line"];
                cmb_namelinedoc.DataSource = mydata.ToList();
                conn.Close();
            }
            cmb_namelinedoc.SelectedIndex = -1;
            cmb_Idmaindoc.SelectedIndex = -1;
        }

      

        private void btn_chossefile_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "(*.xlsx)|*.xlsx";
            if(ofd.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    filepath = ofd.FileName;
                    filename = ofd.FileName.Split('\\').Last().Split('.')[0];
                    txb_Iddoc.Text = filename.Split('_')[0];
                    txb_namedoc.Text = filename.Split('_')[1];
                    if (cmb_namelinedoc.FindString(filename.Split('_')[0].Split('-')[0].Trim()) < 0)
                    {
                        cmb_namelinedoc.SelectedIndex = -1;
                        cmb_Idmaindoc.SelectedIndex = -1;
                    }
                    else
                    {
                        cmb_namelinedoc.SelectedIndex = cmb_namelinedoc.FindString(filename.Split('_')[0].Split('-')[0].Trim());
                    }
                }
                catch (Exception)
                {

                    MessageBox.Show("Tên tài liệu không đúng định dạng", "Lỗi");
                }
                   
            }

        }

        private void btn_adddoc_Click(object sender, EventArgs e)
        {
            if(txb_Iddoc.Text!=""&& txb_namedoc.Text != "" && cmb_namelinedoc.SelectedItem.ToString() != "" && cmb_Idmaindoc.Text != "")
            {
                try
                {
                    DialogResult dr = MessageBox.Show("Bạn chắc chắn muốn thêm báo cáo này?", "Thông báo", MessageBoxButtons.YesNo);
                    if (dr == DialogResult.Yes)
                    {
                        if (txb_Iddoc.Text.ToLower().Contains("tài liệu"))
                        {
                            using (MySqlConnection conn = new MySqlConnection($"server={Ipserver};uid=root;" + "pwd=6006;database=test"))
                            {
                                string desfile = $"\\\\myip\\Baocao2$\\Doccument\\{cmb_namelinedoc.SelectedValue}\\TOV\\{filename}.xlsx";
                                string desfile1 = $"\\\\{Ipserver}\\Baocao2$\\Doccument\\{cmb_namelinedoc.SelectedValue}\\TOV\\{filename}.xlsx";
                                if (!Directory.Exists($"\\\\{Ipserver}\\Baocao2$\\Doccument\\{cmb_namelinedoc.SelectedValue}\\TOV"))
                                {
                                    Directory.CreateDirectory($"\\\\{Ipserver}\\Baocao2$\\Doccument\\{cmb_namelinedoc.SelectedValue}\\TOV");
                                }
                                if ( !checkexist())
                                {
                                    MessageBox.Show("Báo cáo đã tồn tại");
                                    return;
                                }
                                else
                                {
                                    File.Copy(filepath, desfile1,true);
                                    conn.Open();
                                    MySqlCommand cmd = new MySqlCommand($"INSERT INTO `checkmachine`.`managerdoccument` (`Id_Doccument`, `Name_Doccument`, `Type_Of_Doccument`, `Id_Main_Doccument`, `File_Path_save`, `Time_Update`) VALUES ('{txb_Iddoc.Text}', '{txb_namedoc.Text}', 'TOV', '{cmb_Idmaindoc.SelectedItem.ToString()}', '{desfile.Replace("\\", "/")}', '{DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")}');", conn);
                                    cmd.ExecuteNonQuery();
                                    conn.Close();
                                }
                            }
                        }
                        else
                        {
                            using (MySqlConnection conn = new MySqlConnection($"server={Ipserver};uid=root;" + "pwd=6006;database=test"))
                            {
                                string desfile = $"\\\\myip\\Baocao2$\\Doccument\\{cmb_namelinedoc.SelectedValue}\\JP\\{filename}.xlsx";
                                string desfile1 = $"\\\\{Ipserver}\\Baocao2$\\Doccument\\{cmb_namelinedoc.SelectedValue}\\JP\\{filename}.xlsx";
                                if (!Directory.Exists($"\\\\{Ipserver}\\Baocao2$\\Doccument\\{cmb_namelinedoc.SelectedValue}\\JP"))
                                {
                                    Directory.CreateDirectory($"\\\\{Ipserver}\\Baocao2$\\Doccument\\{cmb_namelinedoc.SelectedValue}\\JP");
                                }
                                if (!checkexist())
                                {
                                    MessageBox.Show("Báo cáo đã tồn tại");
                                    return;
                                }
                                else
                                {
                                    File.Copy(filepath, desfile1,true);
                                    conn.Open();
                                    MySqlCommand cmd = new MySqlCommand($"INSERT INTO `checkmachine`.`managerdoccument` (`Id_Doccument`, `Name_Doccument`, `Type_Of_Doccument`, `Id_Main_Doccument`, `File_Path_save`, `Time_Update`) VALUES ('{txb_Iddoc.Text}', '{txb_namedoc.Text}', 'JP', '{cmb_Idmaindoc.SelectedItem.ToString()}', '{desfile.Replace("\\", "/")}', '{DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")}');", conn);
                                    cmd.ExecuteNonQuery();
                                    conn.Close();
                                }
                            }
                        }
                        MessageBox.Show("Thêm thành công", "Thông báo");
                    }
                }
                catch (Exception ex)
                {

                    MessageBox.Show(ex.Message);
                }
               
                
               
            }
        }
        public bool checkexist()
        {
            using (MySqlConnection conn = new MySqlConnection($"server={Ipserver};uid=root;" + "pwd=6006;database=test"))
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand($"SELECT * FROM checkmachine.managerdoccument Where Id_Doccument = '{txb_Iddoc.Text}'", conn);
                if( cmd.ExecuteScalar() != null )
                {
                    return false;
                }
                conn.Close();
            }
            return true;
        }

      
        private void cmb_namelinedoc_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboBox cmb = (ComboBox)sender;
            int myselectedIndex = cmb.SelectedIndex;
            string myselectedValue = (string)cmb.SelectedValue;
            if (myselectedIndex >= 0)
            {
                using (MySqlConnection conn = new MySqlConnection($"server={Ipserver};uid=root;" + "pwd=6006;database=test"))
                {
                    conn.Open();
                    MySqlDataAdapter adap = new MySqlDataAdapter($"SELECT Id_Doccument FROM checkmachine.managermaindoccument Where Name_Line = '{myselectedValue}'", conn);
                    DataTable dt = new DataTable();
                    adap.Fill(dt);
                    var mydata = from DataRow p in dt.Rows
                                 select (string)p["Id_Doccument"];
                    cmb_Idmaindoc.DataSource = mydata.ToList();
                    conn.Close();
                }
            }
           
        }
    }
}
