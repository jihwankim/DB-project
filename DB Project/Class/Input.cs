using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DB_Project
{
    public class Input
    {
        public Input()
        {
            InputType = "";
            Type = "";
            Record1 = "";
            Record2 = "";
            appName = "";
            datetime = "";
        }
        public Input(string iInputType, string iType, string iRecord1, string iRecord2, string iAppName, string iDatetime)
        {
            InputType = iInputType;
            Type = iType;
            Record1 = iRecord1;
            Record2 = iRecord2;
            appName = iAppName;
            datetime = iDatetime;
        }
        public string InputType { get; set; }
        public string Type { get; set; }
        public string Record1 { get; set; }
        public string Record2 { get; set; }
        public string appName { get; set; }
        public string datetime { get; set; }
    }
}
