using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CheckReport
{
    public class MainDoc
    {
        private int sTT;
        private string name_Doccument;
        private string quantity;

        public int STT { get => sTT; set => sTT = value; }
        public string Name_Doccument { get => name_Doccument; set => name_Doccument = value; }
        public string Quantity { get => quantity; set => quantity = value; }
    }
}
