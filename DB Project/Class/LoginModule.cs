using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using MySql.Data.MySqlClient;

namespace DB_Project.Class
{
    class CLoginModule
    {
        /// 
        public CLoginModule()
        {
        }

        // LOGIN PANEL ///////////////////////////////////////////////
        public bool Login(ref MySqlConnection connection, string ID, string password)
        {
            bool result = true;
            string strConn = String.Format(@"Data Source={0};Database={1};User ID={2};Password={3};", CGlobalVariable.Instance.DBserver, CGlobalVariable.Instance.DBname, ID, password);

            connection = new MySqlConnection(strConn);
            try
            {
                connection.Open();
                CGlobalVariable.Instance.DBuser = ID;
                MessageBox.Show("Login Success!");

                using( MySqlCommand command = new MySqlCommand(String.Format("SELECT count(name) FROM User WHERE name = '{0}'",CGlobalVariable.Instance.DBuser) ,connection) )
                {
                    
                    if( Convert.ToInt32(command.ExecuteScalar()) == 0 )
                        // 유저 정보가 없으면 정보를 Insert
                        command.CommandText = String.Format("INSERT INTO User(name, Latest_Login) VALUES('{0}', '{1}')", CGlobalVariable.Instance.DBuser, DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
                    else 
                        // 최근 로그인 시간 Update
                        command.CommandText = String.Format("UPDATE User SET Latest_Login='{0}' WHERE name='{1}'", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"), CGlobalVariable.Instance.DBuser);

                    command.ExecuteNonQuery();
                }
            }
            catch
            {
                MessageBox.Show("Login Failed!");
                result = false;
            }

            return result;
        }
    }
}
