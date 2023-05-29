using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CheckReport
{
    public class datachecksheet
    {
        private int sTT;
        private string idCheckSheet;
        private string nameCheckSheet;
        private string nameLine;
        private string timeUpdate;

        public int STT { get => sTT; set => sTT = value; }
        public string IdCheckSheet { get => idCheckSheet; set => idCheckSheet = value; }
        public string NameCheckSheet { get => nameCheckSheet; set => nameCheckSheet = value; }
        public string NameLine { get => nameLine; set => nameLine = value; }
        public string TimeUpdate { get => timeUpdate; set => timeUpdate = value; }
    }
}
