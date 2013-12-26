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
        static Point lastMouseMove = new Point();
        static bool isMouseMoved = false;
        //static string HookType = "";
        //static string HookRecord = "";
        bool LoginSuccess = false;

        static MySqlConnection connection;

        static Log LogForm = new Log();

        int interval = 10;
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
            LogForm.Show();
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
            count = 0;
        }

        private void ProcessBackGround(object sender, EventArgs e)
        {
            Delay(1000, (o, b) => MessageBox.Show("Test"));
        }


        // Hooker
        //[STAThread]
        static void Delay(int ms, EventHandler action)
        {
            var tmp = new Timer { Interval = ms };
            tmp.Tick += new EventHandler((o, e) => tmp.Enabled = false);
            tmp.Tick += action;
            tmp.Enabled = true;
        }
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
        static int count = 0;

        private bool FindElement(string query, string item)
        {
            using(MySqlCommand command = new MySqlCommand())
            {
                command.Connection = connection;

                // Insert Application Name
                command.CommandText = query; 
                command.ExecuteNonQuery();

                using(MySqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read() == true)
                    {
                        if (reader[0].ToString() == item)
                            return true;
                    }
                }
            }
            return false;
        }
        private void InsertRecord(Object myObject, EventArgs myEventArgs)
        {
            InsertTimer.Stop();

            //MySqlCommand insertCommand = new MySqlCommand();
            //insertCommand.Connection = connection;

            
            label4.Text = String.Format("{0} sec", (float)(count++)/(1000/interval));

            if(isMouseMoved == true)
                WriteLog("Mouse", String.Format("Move x={0},y={1}", lastMouseMove.X, lastMouseMove.Y));
            isMouseMoved = false;

            using (MySqlCommand insertCommand = new MySqlCommand())
            {
                insertCommand.Connection = connection;
                for(int i=0; i<inputLog.Count; ++i)
                {
                        // Insert Application Name
                        if (FindElement( "SELECT name FROM application", inputLog[i].appName) == false)
                        {
                            //insertCommand.CommandText = "INSERT INTO application(name) VALUES(@name)";
                            //insertCommand.Parameters.AddWithValue("@name", inputLog[i].appName);
                            insertCommand.CommandText = String.Format(@"INSERT INTO application(name) VALUES('{0}')", inputLog[i].appName);
                            insertCommand.ExecuteNonQuery();
                        }
                    
                        // Insert Date
                        if (FindElement( "SELECT DATE_FORMAT(STR_TO_DATE(YMD, '%Y-%m-%d'), '%Y%m%d') FROM date", inputLog[i].date ) == false)
                        {
                            //insertCommand.CommandText = "INSERT INTO date(YMD) VALUES(@YMD)";
                            insertCommand.CommandText = String.Format(@"INSERT INTO date(YMD) VALUES('{0}')", inputLog[i].date);
                            //insertCommand.Parameters.AddWithValue("@YMD", inputLog[i].date);

                            insertCommand.ExecuteNonQuery();
                        }

                        //Insert Input Data
                        //insertCommand.CommandText = String.Format("INSERT INTO input(Type, Value, time, Date_YMD, Application_name) VALUES(@Type, @Value, @time, @Date_YMD, @Application_name)";
                        insertCommand.CommandText = String.Format(@"INSERT INTO input(Type, Value, time, Date_YMD, Application_name) VALUES('{0}', '{1}', '{2}', '{3}', '{4}')",inputLog[i].Type, inputLog[i].Record, inputLog[i].time, inputLog[i].date, inputLog[i].appName);

                       // insertCommand.Parameters.AddWithValue("@Type", inputLog[i].Type);
    //                     insertCommand.Parameters.AddWithValue("@Value", inputLog[i].Record);
    //                     insertCommand.Parameters.AddWithValue("@time", inputLog[i].time);
    //                     insertCommand.Parameters.AddWithValue("@Date_YMD", inputLog[i].date);
    //                     insertCommand.Parameters.AddWithValue("@Application_name", inputLog[i].appName);

                        insertCommand.ExecuteNonQuery();
                    }
                }

            inputLog.Clear();
            InsertTimer.Enabled = true;
        }
        public void MouseMoved(object sender, MouseEventArgs e)
        {
            if (e.Clicks > 0) WriteLog("Mouse", "Click " + e.Button.ToString() + String.Format(" x={0},y={1}", e.X, e.Y));
            else if (e.Delta != 0) WriteLog("Mouse", "Wheel " + (e.Delta > 0 ? "UP" : "DOWN"));
            else 
            {
                if((abs(lastMouseMove.X - e.X) > 50) || (abs(lastMouseMove.Y - e.Y) > 50))
                {
                    isMouseMoved = true;
                    lastMouseMove.X = e.X;
                    lastMouseMove.Y = e.Y;
                }
                
            }
        }

        public void MyKeyDown(object sender, KeyEventArgs e)
        {
            WriteLog("Keyboard", String.Format("KeyDown {0}", e.KeyData.ToString()));
        }

        public void MyKeyPress(object sender, KeyPressEventArgs e)
        {
            WriteLog("Keyboard", String.Format("KeyPress {0}", e.KeyChar.ToString()));
        }

        public void MyKeyUp(object sender, KeyEventArgs e)
        {
            WriteLog("Keyboard", String.Format("KeyUp {0}", e.KeyData.ToString()));
        }
        public static void WriteLog(string type, string record)
        {
            inputLog.Add(new Input(type, record, GetActiveProcessFileName(), DateTime.Today.ToString("yyyyMMdd"), DateTime.Now.ToString("HH:mm:ss")));

            LogForm.LogBox.AppendText(String.Format("[{0}] {1}{2}   - {3}{4}", DateTime.Now.ToString("HH:mm:ss"), record, Environment.NewLine, GetActiveProcessFileName(), Environment.NewLine));
            LogForm.LogBox.SelectionStart = LogForm.LogBox.Text.Length;
        }

        public int abs(int x) { return x > 0 ? x : -x; }
    }
    public class Input
    {
        public Input()
        {
            Type = "";
            Record = "";
            appName = "";
            date = "";
            time = "";
        }
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
