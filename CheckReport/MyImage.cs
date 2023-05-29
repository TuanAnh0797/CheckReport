using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Windows.Forms;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace CheckReport
{
    public partial class MyImage : Form
    {
        public MyImage(string filepath)
        {
            InitializeComponent();
            WebRequest request = WebRequest.Create(filepath);

            using (WebResponse response = request.GetResponse())
            {
                using (Stream stream = response.GetResponseStream())
                {
                    Bitmap bitmap = new Bitmap(stream);

                    pictureBox1.Image = bitmap;
                }
            }
        }
    }
}
