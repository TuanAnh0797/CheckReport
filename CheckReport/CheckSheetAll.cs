using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CheckReport
{
    public class CheckSheetAll
    {
        private int sTT;
        private string nameLine;
        private List<string> nameCheckSheet;
        private int finishCheckSheet;
        private int totalCheckSheet;

        public int STT { get => sTT; set => sTT = value; }
        public string NameLine { get => nameLine; set => nameLine = value; }
        public List<string> NameCheckSheet { get => nameCheckSheet; set => nameCheckSheet = value; }
        public int FinishCheckSheet { get => finishCheckSheet; set => finishCheckSheet = value; }
        public int TotalCheckSheet { get => totalCheckSheet; set => totalCheckSheet = value; }


    }
}
