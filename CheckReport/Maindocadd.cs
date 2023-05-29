using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CheckReport
{
    public class Maindocadd
    {
        private int sTT;
        private string name_Doc;
        private string name_Line;
        private string time_Update;

        public int STT { get => sTT; set => sTT = value; }
        public string Name_Doc { get => name_Doc; set => name_Doc = value; }
        public string Name_Line { get => name_Line; set => name_Line = value; }
        public string Time_Update { get => time_Update; set => time_Update = value; }
    }
}
