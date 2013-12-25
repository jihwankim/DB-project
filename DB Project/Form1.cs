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

namespace DB_Project
{
    public partial class Form1 : Form
    {
        // Value
        bool LoginSuccess = false;
        MySqlConnection connection;
        int interval = 500;
        static System.Windows.Forms.Timer InsertTimer = new System.Windows.Forms.Timer();

        // DLL LOAD
        [DllImport("user32.dll")]
        public static extern IntPtr GetWindowThreadProcessId(IntPtr hWnd, out uint ProcessId);

        [DllImport("user32.dll")]
        private static extern IntPtr GetForegroundWindow();

        public static string GetActiveProcessFileName()
        {
            IntPtr hwnd = GetForegroundWindow();
            uint pid;
            GetWindowThreadProcessId(hwnd, out pid);
            Process p = Process.GetProcessById((int)pid);
            return p.MainModule.ModuleName;
        }
        //
        public Form1()
        {
            InitializeComponent();
            FunctionPanel.Enabled = false;
        }

        static int alarmCounter = 1;
        private static void TimerEventProcessor(Object myObject,
                                            EventArgs myEventArgs)
        {
            InsertTimer.Stop();

            // Displays a message box asking whether to continue running the timer.
            if (MessageBox.Show("Continue running?", "Count is: " + GetActiveProcessFileName(),//alarmCounter,
               MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                // Restarts the timer and increments the counter.
                alarmCounter += 1;
                //InsertTimer.Enabled = true;
            }
            else
            {
                // Stops the timer.
                //exitFlag = true;
            }
        }

        // LOGIN PANEL ///////////////////////////////////////////////
        private void Login()
        {
            LoginPanel.Enabled = false;
            FunctionPanel.Enabled = true;

            InsertTimer.Tick += new EventHandler(TimerEventProcessor);
            InsertTimer.Interval = interval;

            // Load Tables
            MySqlDataReader reader = null;
            connection.ChangeDatabase("mydb");

            MySqlCommand cmd = new MySqlCommand("SHOW TABLES", connection);
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

        }
        private void LoginRequest(object sender, EventArgs e)
        {
            string ID = LoginPanel_ID.Text;
            string password = LoginPanel_Password.Text;

            LoginSuccess = TryLogin(ID, password);

            if (LoginSuccess == true)
                Login();
            else
                LoginPanel_Password.Text = "";
        }
        private void LoginKeyProcess(object sender, KeyPressEventArgs e)
        {
            if(e.KeyChar == Convert.ToChar(Keys.Enter))
                LoginRequest(null, null);
        }

        // LOGIN Request
        private bool TryLogin(string ID, string Password)
        {
            bool result = true;
            string strConn = @"Data Source=localhost;Database=mydb;User ID=" + ID + ";Password=" + Password + ";";

            connection = new MySqlConnection(strConn);
            try 
            {
                connection.Open();
                MessageBox.Show("Login Success!");
            }catch
            {
                MessageBox.Show("Login Failed!");
                result = false;
            }

            return result;
        }

        private DataTable data;
        private MySqlDataAdapter da;
        private MySqlCommandBuilder cb;

        private void TableChange(object sender, EventArgs e)
        {
            data = new DataTable();

            da = new MySqlDataAdapter("SELECT * FROM " + TableList.SelectedItem.ToString(), connection);
            cb = new MySqlCommandBuilder(da);

            da.Fill(data);

            DataList.DataSource = data;
        }

        private void RecordingStart(object sender, EventArgs e)
        {
            InsertTimer.Start();
        }

        private void RecordingPause(object sender, EventArgs e)
        {
            InsertTimer.Stop();
        }

        private void ProcessBackGround(object sender, EventArgs e)
        {

        }
    }
}
