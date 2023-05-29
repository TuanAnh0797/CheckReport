using MySql.Data.MySqlClient;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
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
    public partial class Form1 : Form
    {
        BindingList<CheckSheet> Listchecksheet;
        BindingList<CheckSheetAll> Listchecksheetall;
        BindingList<datachecksheet> listdatachecksheet;
        BindingList<MyDoccument> ListDoccument;
        BindingList<MainDoc> ListMainDoc;
        string Ipserver;
        public Form1()
        {
            Listchecksheet = new BindingList<CheckSheet>();
            Listchecksheetall = new BindingList<CheckSheetAll>();
            listdatachecksheet = new BindingList<datachecksheet>();
            ListDoccument = new BindingList<MyDoccument>();
            ListMainDoc = new BindingList<MainDoc>();
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
            if(Ipserver == "")
            {
                    MessageBox.Show("Không thể kết nối với máy chủ\n Hãy kiểm tra lại địa chỉ IP", "Lỗi");
                    Environment.Exit(0);
            }

            CultureInfo myculture = new CultureInfo("en-US");
            myculture.DateTimeFormat.ShortDatePattern = "dd/MM/yyyy";
            myculture.DateTimeFormat.LongDatePattern = "dd/MM/yyyy HH:mm:ss";
            Thread.CurrentThread.CurrentCulture = myculture;
            InitializeComponent();
            //loaddatafromdatabase();
            try
            {
                LoadNameLineFromDataBase();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Lỗi kết nối");
                Environment.Exit(0);
            }
           
            dtg_tab1.DataSource = Listchecksheet;
            dtg_tab1.Columns[0].HeaderText = "STT";
            dtg_tab1.Columns[1].HeaderText = "Mã bản kiểm tra máy";
            dtg_tab1.Columns[2].HeaderText = "Tên bản kiểm tra máy";
            dtg_tab1.Columns[3].HeaderText = "Tên Line";
            dtg_tab1.Columns[4].HeaderText = "Thời gian cập nhật";
            dtg_tab1.Columns[5].HeaderText = "Trạng thái nộp";
            //
            dtg_tab1_2.DataSource = Listchecksheetall;
            dtg_tab1_2.Columns[0].HeaderText = "STT";
            dtg_tab1_2.Columns[1].HeaderText = "Tên Line";
            dtg_tab1_2.Columns[2].HeaderText = "Số lượng đã nộp";
            dtg_tab1_2.Columns[3].HeaderText = "Tổng số lượng";
            //
            dtg_tab2.DataSource = listdatachecksheet;
            dtg_tab2.Columns[0].HeaderText = "STT";
            dtg_tab2.Columns[1].HeaderText = "Mã bản kiểm tra máy";
            dtg_tab2.Columns[2].HeaderText = "Tên bản kiểm tra máy";
            dtg_tab2.Columns[3].HeaderText = "Tên Line";
            dtg_tab2.Columns[4].HeaderText = "Thời gian cập nhật";
            //

            dtg_tab3.DataSource = ListDoccument;
            dtg_tab3.Columns[0].HeaderText = "STT";
            dtg_tab3.Columns[1].HeaderText = "Mã tài liệu";
            dtg_tab3.Columns[2].HeaderText = "Tên tài liệu";
            dtg_tab3.Columns[3].HeaderText = "Loại tài liệu";
            dtg_tab3.Columns[4].HeaderText = "Mã tài liệu gốc";
            dtg_tab3.Columns[5].HeaderText = "Đường dẫn";
            dtg_tab3.Columns[5].Visible = false;
            dtg_tab3.Columns[6].HeaderText = "Thời gian cập nhật";


            loaddatadoccument($"SELECT * FROM checkmachine.managerdoccument;");
            loadnamelinetab3();
            //
            dtg_tab3_2.DataSource = ListMainDoc;
            dtg_tab3_2.Columns[0].HeaderText = "STT";
            dtg_tab3_2.Columns[1].HeaderText = "Mã Tài liệu";
            dtg_tab3_2.Columns[2].HeaderText = "Số lượng tài liệu đính kèm";
            try
            {
                loaddatafromdatabasefortab2($"SELECT * FROM checkmachine.machecksheet");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Lỗi kết nối" );
                Environment.Exit( 0 );
            }
            dtg_tab3_2.Visible = false;

            DataGridViewButtonColumn DownloadButtonColumn = new DataGridViewButtonColumn();
            DownloadButtonColumn.Name = "Download_columns";
            DownloadButtonColumn.Text = "Download";
            if (dtg_tab3.Columns["Download_columns"] == null)
            {
                dtg_tab3.Columns.Insert(7, DownloadButtonColumn);
            }
            DataGridViewButtonColumn DeleteButtonColumn = new DataGridViewButtonColumn();
            DeleteButtonColumn.Name = "Delete_columns";
            DeleteButtonColumn.Text = "Delele";
            if (dtg_tab3.Columns["Delete_columns"] == null)
            {
                dtg_tab3.Columns.Insert(8, DeleteButtonColumn);
            }
            dtg_tab3.Columns[7].HeaderText = "Tải tài liệu";
            dtg_tab3.Columns[8].HeaderText = "xóa tài liệu";
            dtg_tab3.Columns[7].Width = 30;
            dtg_tab3.Columns[1].Width = 30;
            dtg_tab3.Columns[2].Width = 100;
            dtg_tab3.Columns[5].Width = 60;
            dtg_tab3.Columns[6].Width = 190;
            dtg_tab3.Columns[4].Width = 300;



        }
        public void loadnamedoctab3(string query)
        {
            using (MySqlConnection conn = new MySqlConnection($"server={Ipserver};uid=root;" + "pwd=6006;database=test"))
            {
                conn.Open();
                MySqlDataAdapter adap = new MySqlDataAdapter(query, conn);
                DataTable dt = new DataTable();
                adap.Fill(dt);
                var mydata = from DataRow p in dt.Rows
                             select (string)p["Id_Doccument"];
                cmb_NameDoc_tab3.DataSource = mydata.ToList();

                conn.Close();
            }
            //
           
        }
        public void loadnamelinetab3()
        {
           
            using (MySqlConnection conn = new MySqlConnection($"server={Ipserver};uid=root;" + "pwd=6006;database=test"))
            {
                conn.Open();
                MySqlDataAdapter adap = new MySqlDataAdapter($"SELECT Name_Line FROM checkmachine.managermaindoccument group by Name_Line;", conn);
                DataTable dt = new DataTable();
                adap.Fill(dt);
                var mydata = from DataRow p in dt.Rows
                             select (string)p["Name_Line"];
                cmb_Nameline_tab3.DataSource = mydata.ToList();

                conn.Close();
            }
        }
        public void loaddatadoccument(string query)
        {
            ListDoccument.Clear();
            using (MySqlConnection conn = new MySqlConnection($"server={Ipserver};uid=root;" + "pwd=6006;database=test"))
            {
                conn.Open();
                MySqlDataAdapter adap = new MySqlDataAdapter(query, conn);
                DataTable dt = new DataTable();
                adap.Fill(dt);
                var mydata = from DataRow p in dt.Rows
                             select p;
                int id = 1;
                foreach (DataRow item in mydata)
                {
                    ListDoccument.Add(new MyDoccument() { STT = id, Id_Doccument = (string)item["Id_Doccument"], Name_Doccument = (string)item["Name_Doccument"], Type_Doccument = (string)item["Type_Of_Doccument"],Id_Main_Doccument = item["Id_Main_Doccument"].ToString(), Path_Doccument = item["File_Path_save"].ToString(), Time_Update = item["Time_Update"] == null ? "": item["Time_Update"].ToString() });
                    id++;
                }


                conn.Close();
            }
        }
        public void loaddatafromdatabase()
        {
            Listchecksheet.Clear();
            using (MySqlConnection conn = new MySqlConnection($"server={Ipserver};uid=root;" + "pwd=6006;database=test"))
            {
                conn.Open();
                MySqlDataAdapter adap = new MySqlDataAdapter($"SELECT * FROM checkmachine.machecksheet Where NameLine = '{cmb_tab1.SelectedValue}'", conn);
                DataTable dt = new DataTable();
                adap.Fill(dt);
                var mydata = from DataRow p in dt.Rows
                             select p;
                int id = 1;
                foreach (DataRow item in mydata)
                {
                    Listchecksheet.Add(new CheckSheet() {STT = id, ID_CheckSheet = (string)item["IdCheckSheet"], Name_CheckSheet = (string)item["NameCheckSheet"],Name_Line = (string)item["NameLine"], TimeUpdate = item["TimeUpdate"]!= null?"": (string)item["TimeUpdate"], StatusUpdate = "Chưa nộp"});
                    id++;
                }
                
                conn.Close();
            }
        }
        public void LoadNameLineFromDataBase()
        {
            using (MySqlConnection conn = new MySqlConnection($"server={Ipserver};uid=root;" + "pwd=6006;database=test"))
            {
                conn.Open();
                MySqlDataAdapter adap = new MySqlDataAdapter("SELECT * FROM checkmachine.machecksheet group by NameLine", conn);
                DataTable dt = new DataTable();
                adap.Fill(dt);
                var mydata = from DataRow p in dt.Rows
                             select (string)p["NameLine"];
                cmb_tab1.DataSource = mydata.ToList();
                cmb_tab2.DataSource = mydata.ToList();
                conn.Close();
            }
        }

        private void btn_Check_Click(object sender, EventArgs e)
        {
            try
            {
                dtg_tab1_2.Visible = false;
                dtg_tab1.Visible = true;
                dtg_tab1.Columns[0].Width = 50;
                loaddatafromdatabase();
                string YearUpload = Dtime_tab1.Value.Year.ToString();
                string MonthUpload = Dtime_tab1.Value.Month.ToString();
                checkfinish($"\\\\{Ipserver}\\Baocao2$\\{YearUpload}\\{MonthUpload}\\{cmb_tab1.SelectedItem.ToString()}");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Lỗi kết nối");
            }
           
          
           // dtg_tab1.Refresh();
            
        }
        public void checkfinish(string path)
        {
            DirectoryInfo df = new DirectoryInfo(path);
            try
            {
                FileInfo[] fi = df.GetFiles("*.png");
                fi.ToList().ForEach((p) =>
                {
                    Listchecksheet.ToList().ForEach((p2) =>
                    {
                        if(p2.ID_CheckSheet == p.Name.Split('.')[0])
                        {
                            p2.StatusUpdate = "Đã nộp";
                            p2.TimeUpdate = p.LastWriteTime.ToString("HH:mm:ss dd/MM/yyyy");
                        }
                    });
                });
            }
            catch (Exception)
            {

                return;
            }
        }

        private void dtg_tab1_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            
            if(e.Value != null)
            {
                var cell1 = dtg_tab1.Rows[e.RowIndex].Cells[5];
                if(cell1.Value != null && cell1.Value.ToString()=="Đã nộp")
                {
                    e.CellStyle.BackColor = Color.LightGreen;
                }
                else
                {
                    e.CellStyle.BackColor = Color.OrangeRed;
                }
                
            }
        }

        private void dtg_tab1_SelectionChanged(object sender, EventArgs e)
        {
            if(dtg_tab1.SelectedRows.Count > 0)
            {
                var dataselect = dtg_tab1.SelectedRows[0];
                string nameimage = dataselect.Cells[1].Value.ToString();
                string StatusUpdate = dataselect.Cells[5].Value.ToString();
                string YearUpload = Dtime_tab1.Value.Year.ToString();
                string MonthUpload = Dtime_tab1.Value.Month.ToString();
                if(StatusUpdate == "Đã nộp")
                {
                    MyImage f = new MyImage($"\\\\{Ipserver}\\Baocao2$\\{YearUpload}\\{MonthUpload}\\{cmb_tab1.SelectedItem.ToString()}\\{nameimage}.png");
                    f.Show();
                }
            }
        }
        public void loadalldatafromdatabase()
        {
            Listchecksheetall.Clear();
            using (MySqlConnection conn = new MySqlConnection($"server={Ipserver};uid=root;" + "pwd=6006;database=test"))
            {
                int mystt = 1;
                conn.Open();
                MySqlDataAdapter adap = new MySqlDataAdapter($"SELECT * FROM checkmachine.machecksheet Group by NameLine", conn);
                DataTable dt = new DataTable();
                adap.Fill(dt);
                var datanameline = from DataRow p in dt.Rows
                             select p;
                foreach (DataRow item in datanameline)
                {
                    Listchecksheetall.Add(new CheckSheetAll() { STT = mystt, NameLine = (string)item["NameLine"].ToString(), NameCheckSheet = new List<string>(),FinishCheckSheet = 0, TotalCheckSheet = 0});
                    mystt++;
                }
                conn.Close();
            }
            using (MySqlConnection conn = new MySqlConnection($"server={Ipserver};uid=root;" + "pwd=6006;database=test"))
            {
                conn.Open();
                MySqlDataAdapter adap = new MySqlDataAdapter($"SELECT * FROM checkmachine.machecksheet", conn);
                DataTable dt = new DataTable();
                adap.Fill(dt);
                var datanamechecksheet = from DataRow p in dt.Rows
                             select p;
                foreach (DataRow item in datanamechecksheet)
                {
                    Listchecksheetall.ToList().ForEach((p) =>
                    {
                        if(p.NameLine == (string)item["NameLine"].ToString())
                        {
                            p.NameCheckSheet.Add((string)item["IdCheckSheet"].ToString());
                        }
                    });
                }
                conn.Close();
            }

        }
        public void checkfinishall(string filepath)
        {
            DirectoryInfo df = new DirectoryInfo(filepath);
            try
            {
                FileInfo[] fi = df.GetFiles("*.png", SearchOption.AllDirectories);
                fi.ToList().ForEach((p) =>
                {
                    Listchecksheetall.ToList().ForEach((p2) =>
                    {
                        p2.NameCheckSheet.ForEach((p3) =>
                        {
                            if(p3 == p.Name.Split('.')[0])
                            {
                                p2.FinishCheckSheet++;
                            }
                        });
                    });
                });
            }
            catch (Exception)
            {

                return;
            }
        }

        private void btn_checkall_Click(object sender, EventArgs e)
        {
            dtg_tab1.Visible = false;
            dtg_tab1_2.Visible = true;

            try
            {
                dtg_tab1_2.Columns[0].Width = 50;

                loadalldatafromdatabase();
                Listchecksheetall.ToList().ForEach((p) =>
                {
                    p.TotalCheckSheet = p.NameCheckSheet.Count;
                });
                string YearUpload = Dtime_tab1.Value.Year.ToString();
                string MonthUpload = Dtime_tab1.Value.Month.ToString();
                checkfinishall($"\\\\{Ipserver}\\Baocao2$\\{YearUpload}\\{MonthUpload}");
                //dtg_tab1.Refresh();
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message, "Lỗi kết nối");
            }
           
        }

        private void dtg_tab1_2_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.Value != null)
            {
                var total = dtg_tab1_2.Rows[e.RowIndex].Cells[3];
                var request = dtg_tab1_2.Rows[e.RowIndex].Cells[2];
                if (request.Value != null && request.Value.ToString() == total.Value.ToString())
                {
                    e.CellStyle.BackColor = Color.LightGreen;
                }
                else
                {
                    e.CellStyle.BackColor = Color.OrangeRed;
                }

            }
        }
        public void loaddatafromdatabasefortab2(string query)
        {
            listdatachecksheet.Clear();
            using (MySqlConnection conn = new MySqlConnection($"server={Ipserver};uid=root;" + "pwd=6006;database=test"))
            {
                conn.Open();
                MySqlDataAdapter adap = new MySqlDataAdapter(query, conn);
                DataTable dt = new DataTable();
                adap.Fill(dt);
                var mydata = from DataRow p in dt.Rows
                             select p;
                int id = 1;
                foreach (DataRow item in mydata)
                {
                    listdatachecksheet.Add(new datachecksheet() { STT = id, IdCheckSheet = (string)item["IdCheckSheet"], NameCheckSheet = item["NameCheckSheet"] == null ? "" : (string)item["NameCheckSheet"], NameLine = (string)item["NameLine"], TimeUpdate = item["TimeUpdate"] == null ? "" : item["TimeUpdate"].ToString() });
                    id++;
                }

                conn.Close();
            }

        }
        public void Insertdatatodatabase()
        {
            if(!Checkdataisexist() && txt_idchecksheet.Text.Contains('_'))
            {
                using (MySqlConnection conn = new MySqlConnection($"server={Ipserver};uid=root;" + "pwd=6006;database=test"))
                {
                    conn.Open();
                    MySqlCommand cmd = new MySqlCommand($"INSERT INTO `checkmachine`.`machecksheet` (`IdCheckSheet`, `NameCheckSheet`, `NameLine`,`TimeUpdate`) VALUES ('{txt_idchecksheet.Text}', '{txt_namechecksheet.Text}', '{txt_idchecksheet.Text.Split('_')[0]}','{DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")}')", conn);
                    cmd.ExecuteNonQuery();
                    conn.Close();
                }
            }
            else if (Checkdataisexist())
            {
                MessageBox.Show("Mã đã tồn tại");
            }
            else if (!txt_idchecksheet.Text.Contains('_'))
            {
                MessageBox.Show("Định dạng mã chưa đúng");
            }
            else
            {
                MessageBox.Show("Lỗi");
            }
        }
        public bool Checkdataisexist()
        {
            
            using (MySqlConnection conn = new MySqlConnection($"server={Ipserver};uid=root;" + "pwd=6006;database=test"))
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand($"SELECT * FROM checkmachine.machecksheet where IdCheckSheet ='{txt_idchecksheet.Text}'", conn);
                if(cmd.ExecuteScalar() != null)
                {
                    return true;
                }
                else
                {
                    return false;
                }
                conn.Close();
            }
        }
        public void Deletedatatodatabase()
        {
            
            using (MySqlConnection conn = new MySqlConnection($"server={Ipserver};uid=root;" + "pwd=6006;database=test"))
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand($"DELETE FROM `checkmachine`.`machecksheet` WHERE (IdCheckSheet = '{txt_idchecksheet.Text}')", conn);
                cmd.ExecuteNonQuery();
                conn.Close();
            }
        }

        private void btn_add_Click(object sender, EventArgs e)
        {
            try
            {
                Insertdatatodatabase();
                loaddatafromdatabasefortab2($"SELECT * FROM checkmachine.machecksheet");
                LoadNameLineFromDataBase();

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message, "Lỗi kết nối");
            }
            

        }

        private void btn_delete_Click(object sender, EventArgs e)
        {
            try
            {
                if (txt_idchecksheet.Text != "")
                {
                    DialogResult diag = MessageBox.Show($"Bạn chắc chắn muốn xóa mã : {txt_idchecksheet.Text}?", "Cảnh báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (diag == DialogResult.Yes)
                    {
                        if (Checkdataisexist())
                        {
                            Deletedatatodatabase();
                            loaddatafromdatabasefortab2($"SELECT * FROM checkmachine.machecksheet");
                            LoadNameLineFromDataBase();

                        }
                        else
                        {
                            MessageBox.Show("Không tìm thấy dữ liệu mà bạn cần xóa", "Thông báo");
                        }

                    }
                }
                else
                {
                    MessageBox.Show("Hãy nhập mã cần xóa", "Thông báo");
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message, "Lỗi kết nối");
            }
           
          
        }

        private void btn_filter_Click(object sender, EventArgs e)
        {
            try
            {
                loaddatafromdatabasefortab2($"SELECT * FROM checkmachine.machecksheet where NameLine = '{cmb_tab2.SelectedItem.ToString()}'");

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message, "Lỗi kết nối");
            }

        }

        private void dtg_tab2_DataMemberChanged(object sender, EventArgs e)
        {
            
        }

        private void btn_reload_Click(object sender, EventArgs e)
        {
            try
            {
                loaddatafromdatabasefortab2($"SELECT * FROM checkmachine.machecksheet");

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message, "Lỗi kết nối");
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //dtg_tab2.Columns[0].Width = 50;

        }

        private void button1_Click(object sender, EventArgs e)
        {
            RegistDoccument f = new RegistDoccument();
            this.Hide();
            f.ShowDialog();
            this.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            dtg_tab3_2.Visible = false;
            dtg_tab3.Visible = true;
            loaddatadoccument($"SELECT * FROM checkmachine.managerdoccument;");
            loadnamelinetab3();

        }

        private void btn_filter_tab3_Click(object sender, EventArgs e)
        {
            dtg_tab3_2.Visible = false;
            dtg_tab3.Visible = true;
            if(cmb_NameDoc_tab3.SelectedItem != null && cmb_Nameline_tab3.SelectedItem == null)
            {
                loaddatadoccument($"SELECT * FROM checkmachine.managerdoccument Where Id_Main_Doccument = '{cmb_NameDoc_tab3.SelectedItem.ToString()}' ");
            }
            else if (cmb_NameDoc_tab3.SelectedItem == null && cmb_Nameline_tab3.SelectedItem != null)
            {
                loaddatadoccument($"SELECT managerdoccument.Id_Doccument,managerdoccument.Name_Doccument,managerdoccument.Type_Of_Doccument,managerdoccument.Id_Main_Doccument,managerdoccument.File_Path_save,managerdoccument.Time_Update FROM checkmachine.managerdoccument INNER JOIN checkmachine.managermaindoccument ON managerdoccument.Id_Main_Doccument = managermaindoccument.Id_Doccument Where managermaindoccument.Name_Line = '{cmb_Nameline_tab3.SelectedItem.ToString()}'");
            }
            else if (cmb_NameDoc_tab3.SelectedItem != null && cmb_Nameline_tab3.SelectedItem != null)
            {
                loaddatadoccument($"SELECT managerdoccument.Id_Doccument,managerdoccument.Name_Doccument,managerdoccument.Type_Of_Doccument,managerdoccument.Id_Main_Doccument,managerdoccument.File_Path_save,managerdoccument.Time_Update FROM checkmachine.managerdoccument INNER JOIN checkmachine.managermaindoccument ON managerdoccument.Id_Main_Doccument = managermaindoccument.Id_Doccument Where managermaindoccument.Name_Line = '{cmb_Nameline_tab3.SelectedItem.ToString()}' and managerdoccument.Id_Main_Doccument = '{cmb_NameDoc_tab3.SelectedItem.ToString()}'");
            }
            else
            {
                loaddatadoccument($"SELECT * FROM checkmachine.managerdoccument;");
                loadnamelinetab3();
            }



        }

        private void cmb_Nameline_tab3_SelectedValueChanged(object sender, EventArgs e)
        {
            loadnamedoctab3($"SELECT Id_Doccument FROM checkmachine.managermaindoccument Where Name_Line = '{cmb_Nameline_tab3.SelectedItem.ToString()}';");
        }

        private void btn_maindoc_tab3_Click(object sender, EventArgs e)
        {
            dtg_tab3.Visible = false;
            dtg_tab3_2.Visible = true;
            dtg_tab3_2.Columns[0].Width = 50;
            ListMainDoc.Clear();
            using (MySqlConnection conn = new MySqlConnection($"server={Ipserver};uid=root;" + "pwd=6006;database=test"))
            {
                conn.Open();
                MySqlDataAdapter adap = new MySqlDataAdapter("SELECT Id_Main_Doccument, count(*) as quantity FROM checkmachine.managerdoccument group by Id_Main_Doccument", conn);
                DataTable dt = new DataTable();
                adap.Fill(dt);
                var mydata = from DataRow p in dt.Rows
                             select p;
                int id = 1;
                foreach (DataRow item in mydata)
                {
                    ListMainDoc.Add(new MainDoc() { STT = id,  Name_Doccument = item["Id_Main_Doccument"].ToString(),Quantity = item["quantity"].ToString() });
                    id++;
                }
                conn.Close();
            }

        }

        private void dtg_tab3_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == dtg_tab3.Columns["Download_columns"].Index)
            {
                FolderBrowserDialog fbd = new FolderBrowserDialog();
                if( fbd.ShowDialog() == DialogResult.OK)
                {
                    string a = dtg_tab3.Rows[e.RowIndex].Cells[7].Value.ToString().Replace("/", "\\").Replace("myip", Ipserver);
                    string b = fbd.SelectedPath +"\\"+ dtg_tab3.Rows[e.RowIndex].Cells[7].Value.ToString().Split('/').Last();
                    try
                    {
                        File.Copy(a, b,true);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                        
                    }
                    Process.Start(b);
                }
            }
            else if (e.ColumnIndex == dtg_tab3.Columns["Delete_columns"].Index)
            {
                if (MessageBox.Show("Bạn chắc chắn muốn xóa tài liệu", "Thông báo", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    string c = dtg_tab3.Rows[e.RowIndex].Cells[3].Value.ToString();
                    using (MySqlConnection conn = new MySqlConnection($"server={Ipserver};uid=root;" + "pwd=6006;database=test"))
                    {
                        conn.Open();
                        MySqlCommand cmd = new MySqlCommand($"DELETE FROM `checkmachine`.`managerdoccument` WHERE (`Id_Doccument` = '{dtg_tab3.Rows[e.RowIndex].Cells[3].Value.ToString()}')", conn);
                        cmd.ExecuteNonQuery();
                        conn.Close();
                    }
                    File.Delete(dtg_tab3.Rows[e.RowIndex].Cells[7].Value.ToString().Replace("/", "\\").Replace("myip", Ipserver));
                    loaddatadoccument($"SELECT * FROM checkmachine.managerdoccument;");
                    loadnamelinetab3();
                }
            }
        }

        private void btn_addmaindoc_Click(object sender, EventArgs e)
        {
            addmaindoc f = new addmaindoc();
            this.Hide();
            f.ShowDialog();
            this.Show();
        }

        private void btn_filtermain_Click(object sender, EventArgs e)
        {
            //if (dtg_tab3_2.Visible == true)
            //{
            try
            {
                dtg_tab3.Visible = false;
                dtg_tab3_2.Visible = true;
                dtg_tab3_2.Columns[0].Width = 50;
                ListMainDoc.Clear();
                using (MySqlConnection conn = new MySqlConnection($"server={Ipserver};uid=root;" + "pwd=6006;database=test"))
                {
                    conn.Open();
                    MySqlDataAdapter adap = new MySqlDataAdapter($"SELECT Id_Main_Doccument, count(*) as quantity FROM checkmachine.managerdoccument LEFT JOIN checkmachine.managermaindoccument ON managerdoccument.Id_Main_Doccument = managermaindoccument.Id_Doccument  Where managermaindoccument.Name_Line = '{cmb_Nameline_tab3.SelectedValue.ToString()}' group by Id_Main_Doccument", conn);
                    DataTable dt = new DataTable();
                    adap.Fill(dt);
                    var mydata = from DataRow p in dt.Rows
                                 select p;
                    int id = 1;
                    foreach (DataRow item in mydata)
                    {
                        ListMainDoc.Add(new MainDoc() { STT = id, Name_Doccument = item["Id_Main_Doccument"].ToString(), Quantity = item["quantity"].ToString() });
                        id++;
                    }
                    conn.Close();
                }

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
               
            //}
        }
    }
}
