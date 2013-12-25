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
    public partial class Form1 : Form
    {
        // Value
        static List<Input> inputLog = new List<Input>();
        //static string HookType = "";
        //static string HookRecord = "";
        bool LoginSuccess = false;
        static MySqlConnection connection;
        int interval = 1000;
        UserActivityHook actHook;
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

        // LOGIN PANEL ///////////////////////////////////////////////
        private void Login()
        {
            LoginPanel.Enabled = false;
            FunctionPanel.Enabled = true;

            InsertTimer.Tick += new EventHandler(InsertRecord);
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

            HookerInit();
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

        // Record Update
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
            actHook.Start();
            InsertTimer.Start();
        }

        private void RecordingPause(object sender, EventArgs e)
        {
            actHook.Stop();
            InsertTimer.Stop();
        }

        private void ProcessBackGround(object sender, EventArgs e)
        {

        }


        // Hooker
        //[STAThread]
        void HookerInit()
        {
            // Hooker install
            actHook = new UserActivityHook(); // crate an instance with global hooks
            actHook.Stop();
            // hang on events
            actHook.OnMouseActivity += new MouseEventHandler(MouseMoved);
            actHook.KeyDown += new KeyEventHandler(MyKeyDown);
            actHook.KeyPress += new KeyPressEventHandler(MyKeyPress);
            actHook.KeyUp += new KeyEventHandler(MyKeyUp);
        }
        private static void InsertRecord(Object myObject, EventArgs myEventArgs)
        {
            InsertTimer.Stop();

            for(int i=0; false && i<inputLog.Count; ++i)
            {
                // Insert Application Name
                MySqlCommand insertCommand = new MySqlCommand();
                //applicationName = GetActiveProcessFileName();
                insertCommand.Connection = connection;
                insertCommand.CommandText = "INSERT INTO application(name) VALUES(@name)";

                insertCommand.Parameters.AddWithValue("@name", inputLog[i].appName);

                try { insertCommand.ExecuteNonQuery(); }
                catch { }

                // Insert Date
                insertCommand.CommandText = "INSERT INTO date(YMD) VALUES(@YMD)";

                insertCommand.Parameters.AddWithValue("@YMD", inputLog[i].date);

                try { insertCommand.ExecuteNonQuery(); }
                catch { }

                //Insert Input Data
                insertCommand.CommandText = "INSERT INTO input(Type, Value, time, Date_YMD, Application_name) VALUES(@Type, @Value, @time, @Date_YMD, @Application_name)";

                insertCommand.Parameters.AddWithValue("@Type", inputLog[i].Type);
                insertCommand.Parameters.AddWithValue("@Value", inputLog[i].Record);
                insertCommand.Parameters.AddWithValue("@time", inputLog[i].time);
                insertCommand.Parameters.AddWithValue("@Date_YMD", inputLog[i].date);
                insertCommand.Parameters.AddWithValue("@Application_name", inputLog[i].appName);

                try { insertCommand.ExecuteNonQuery(); }
                catch { }
            }

            inputLog.Clear();
            InsertTimer.Enabled = true;
        }
        public void MouseMoved(object sender, MouseEventArgs e)
        {
            WriteLog("Mouse", String.Format("x={0},y={1},wheel={2}", e.X, e.Y, e.Delta));
        }

        public void MyKeyDown(object sender, KeyEventArgs e)
        {
            WriteLog("Keyboard", String.Format("KeyDown {0}", e.KeyData.ToString()));
        }

        public void MyKeyPress(object sender, KeyPressEventArgs e)
        {
            WriteLog("Keyboard", String.Format("KeyPress {0}", e.ToString()));
        }

        public void MyKeyUp(object sender, KeyEventArgs e)
        {
            WriteLog("Keyboard", String.Format("KeyUp {0}", e.KeyData.ToString()));
        }
        public void WriteLog(string type, string record)
        {
            inputLog.Add(new Input(type, record, GetActiveProcessFileName(), DateTime.Today.ToString("yyyyMMdd"), DateTime.Now.ToString("HH:mm:ss")));
        }
    }
    public class Input
    {
        public Input(string iType, string iRecord, string iAppName, string iDate, string iTime)
        {
            Type = iType;
            Record = iRecord;
            appName = iAppName;
            date = iDate;
            time = iTime;
        }
        public string Type { get; set; }
        public string Record { get; set; }
        public string appName { get; set; }
        public string date { get; set; }
        public string time { get; set; }
    }
}
