using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace DB_Project
{
    public class CGlobalVariable
    {
        private static CGlobalVariable pInstance = null;

        private CGlobalVariable() { }

        public static CGlobalVariable Instance
        {
            get
            {
                if (pInstance == null)
                    pInstance = new CGlobalVariable();
                return pInstance;
            }
        }

        public string DBserver = "localhost";//"ihlnext.vps.phps.kr";
        public string DBname = "mydb";//"jihwanDB";
        public string DBuser = "";
        public MySqlConnection connection;
        public bool LoginSuccess = false;



    }
}