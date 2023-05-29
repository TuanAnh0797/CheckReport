using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CheckReport
{
    public class CheckSheet
    {
        private int sTT;
        private string iD_CheckSheet;
        private string name_CheckSheet;
        private string name_Line;
        private string timeUpdate;
        private string statusUpdate;

        public int STT { get => sTT; set => sTT = value; }
        public string ID_CheckSheet { get => iD_CheckSheet; set => iD_CheckSheet = value; }
        public string Name_CheckSheet { get => name_CheckSheet; set => name_CheckSheet = value; }
        public string Name_Line { get => name_Line; set => name_Line = value; }
        public string TimeUpdate { get => timeUpdate; set => timeUpdate = value; }
        public string StatusUpdate { get => statusUpdate; set => statusUpdate = value; }
    }
}
