using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CheckReport
{
    public class MyDoccument
    {
        private int sTT;
        private string id_Doccument;
        private string name_Doccument;
        private string type_Doccument;
        private string id_Main_Doccument;
        private string path_Doccument;
        private string time_Update;

        public int STT { get => sTT; set => sTT = value; }
        public string Id_Doccument { get => id_Doccument; set => id_Doccument = value; }
        public string Name_Doccument { get => name_Doccument; set => name_Doccument = value; }
        public string Type_Doccument { get => type_Doccument; set => type_Doccument = value; }
        public string Id_Main_Doccument { get => id_Main_Doccument; set => id_Main_Doccument = value; }
        public string Path_Doccument { get => path_Doccument; set => path_Doccument = value; }
        public string Time_Update { get => time_Update; set => time_Update = value; }
        
    }
}
