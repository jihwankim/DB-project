using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using MySql.Data.MySqlClient;

using System.Runtime.InteropServices;
using System.Diagnostics;

using gma.System.Windows;

namespace DB_Project
{
    public partial class Main
    {
        // MANAGING DATABASE ///////////////////////////////////////////////
        static List<Input> inputLog = new List<Input>();
        static Point lastMouseMove = new Point();
        static bool isMouseMoved = false;
        int interval = 10;//10;

        private Dictionary<string, bool> ApplicationList;

        // Record Update
        private DataTable data;
        private MySqlDataAdapter da;
        private MySqlCommandBuilder cb;


        private void DatabaseInit()
        {
            // Load Tables
            MySqlDataReader reader = null;

            MySqlCommand cmd = new MySqlCommand("SHOW TABLES", CGlobalVariable.Instance.connection);
            try
            {
                reader = cmd.ExecuteReader();
                TableList.Items.Clear();
                while (reader.Read())
                    TableList.Items.Add(reader.GetString(0));
            }
            catch (MySqlException ex)
            {
                MessageBox.Show("Failed to populate table list: " + ex.Message);
            }
            finally
            {
                if (reader != null)
                    reader.Close();
            }

            // Read Application List
            cmd = new MySqlCommand("SELECT name FROM Application", CGlobalVariable.Instance.connection);
            try
            {
                reader = cmd.ExecuteReader();
                while (reader.Read())
                    ApplicationList[reader.GetString(0)] = true;
            }
            catch { }
            finally
            {
                if (reader != null)
                    reader.Close();
            }
        }
        private void TableChange(object sender, EventArgs e)
        {
            data = new DataTable();

            da = new MySqlDataAdapter("SELECT * FROM " + TableList.SelectedItem.ToString(), CGlobalVariable.Instance.connection);
            cb = new MySqlCommandBuilder(da);

            da.Fill(data);

            DataList.DataSource = data;
        }

        private void RecordingStart(object sender, EventArgs e)
        {
            actHook.Start();
            InsertTimer.Start();
        }

        private void RecordingPause(object sender, EventArgs e)
        {
            actHook.Stop();
            InsertTimer.Stop();
            count = 0;
        }

        private void ProcessBackGround(object sender, EventArgs e)
        {
            Delay(1000, (o, b) => MessageBox.Show("Test"));
        }

        private void InsertRecord(Object myObject, EventArgs myEventArgs)
        {
            InsertTimer.Stop();

            using (MySqlCommand command = new MySqlCommand("", CGlobalVariable.Instance.connection))
            {
                for (int i = 0; i < inputLog.Count; ++i)
                {
                    int eventID = insertEventLog(command, inputLog[i]);

                    // Mouse Event
                    if (inputLog[i].InputType == "Mouse")
                    {
                        command.CommandText = String.Format(@"INSERT INTO MouseEvent(ID, Type, X, Y) VALUES('{0}', '{1}', '{2}', '{3}')", eventID, inputLog[i].Type, inputLog[i].Record1, inputLog[i].Record2);
                    }
                    // Key Event
                    else if (inputLog[i].InputType == "Keyboard")
                        command.CommandText = String.Format(@"INSERT INTO KeyEvent(ID, Type, Value) VALUES('{0}', '{1}', '{2}')", eventID, inputLog[i].Type, inputLog[i].Record1);

                    command.ExecuteNonQuery();
                }
            }

            inputLog.Clear();
            InsertTimer.Enabled = true;
        }

        public int insertEventLog(MySqlCommand command, Input data)
        {
            string result;

            // Update Application Used Log
            UpdateApplicationTable(command, data.appName, data.datetime);

            // Insert New Event Log
            command.CommandText = String.Format(@"INSERT INTO EventLog(time, User_name, Application_name) VALUES('{0}', '{1}', '{2}')", data.datetime, CGlobalVariable.Instance.DBuser, data.appName);
            command.ExecuteNonQuery();

            // Get Log's ID
            command.CommandText = String.Format(@"SELECT ID FROM EventLog WHERE time='{0}' AND User_name='{1}' AND Application_name = '{2}'", data.datetime, CGlobalVariable.Instance.DBuser, data.appName);
            command.ExecuteNonQuery();

            using (MySqlDataReader reader = command.ExecuteReader())
            {
                while (reader.Read()) ;
                result = reader[0].ToString();
            }

            return Convert.ToInt32(result);
        }

        public void UpdateApplicationTable(MySqlCommand command, string appName, string datetime)
        {
            command.CommandText = String.Format(@"SELECT COUNT(name) FROM Application WHERE name = '{0}'", appName);

            if(Convert.ToInt32(command.ExecuteScalar()) == 0)
                // new Application Info Insert
                command.CommandText = String.Format("INSERT INTO Application(name, Latest_Use_date, Latest_User_name) VALUES('{0}', '{1}', '{2}')", appName, datetime, CGlobalVariable.Instance.DBuser);
            else 
                // Update Application Log
                command.CommandText = String.Format("UPDATE Application SET Latest_Use_date='{0}', Latest_User_name='{1}' WHERE name='{2}'", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"), CGlobalVariable.Instance.DBuser, appName);

            command.ExecuteNonQuery();
        }
    }
}
