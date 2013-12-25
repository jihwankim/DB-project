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
        string HookRecord;
        bool LoginSuccess = false;
        static MySqlConnection connection;
        int interval = 500;
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

            return;
            // Hooker install
            actHook = new UserActivityHook(); // crate an instance with global hooks
            // hang on events
            actHook.OnMouseActivity += new MouseEventHandler(MouseMoved);
            actHook.KeyDown += new KeyEventHandler(MyKeyDown);
            actHook.KeyPress += new KeyPressEventHandler(MyKeyPress);
            actHook.KeyUp += new KeyEventHandler(MyKeyUp);

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
            InsertTimer.Start();
        }

        private void RecordingPause(object sender, EventArgs e)
        {
            InsertTimer.Stop();
        }

        private void ProcessBackGround(object sender, EventArgs e)
        {

        }


        // Hooker
        private static void InsertRecord(Object myObject, EventArgs myEventArgs)
        {
            InsertTimer.Stop();


            // Insert Application Name
            MySqlCommand insertCommand = new MySqlCommand();
            string name = GetActiveProcessFileName();
            insertCommand.Connection = connection;
            insertCommand.CommandText = "INSERT INTO application(name) VALUES(@name)";

            insertCommand.Parameters.Add("@name", MySqlDbType.VarChar, name.Length);
            insertCommand.Parameters[0].Value = name;

            try { insertCommand.ExecuteNonQuery(); }
            catch { }

            // Insert Date
            insertCommand = new MySqlCommand();
            insertCommand.Connection = connection;
            insertCommand.CommandText = "INSERT INTO date(YMD) VALUES(@YMD)";

            
            insertCommand.Parameters.Add("@YMD", MySqlDbType.Date, 10);
            insertCommand.Parameters[0].Value = DateTime.Today.ToString("yyyy-MM-dd");

            try { insertCommand.ExecuteNonQuery(); }
            catch { }

            // Get Focused Application's Name

            // Insert Record about now input


            // Displays a message box asking whether to continue running the timer.
//             if (MessageBox.Show("Continue running?", "Count is: " + GetActiveProcessFileName(),//alarmCounter,
//                MessageBoxButtons.YesNo) == DialogResult.Yes)
//             {
//                 // Restarts the timer and increments the counter.
//                 alarmCounter += 1;
//                 //InsertTimer.Enabled = true;
//             }
//             else
//             {
//                 // Stops the timer.
//                 //exitFlag = true;
//             }
        }
        public void MouseMoved(object sender, MouseEventArgs e)
        {
            //labelMousePosition.Text = String.Format("x={0}  y={1} wheel={2}", e.X, e.Y, e.Delta);
            //if (e.Clicks > 0) LogWrite("MouseButton 	- " + e.Button.ToString());
        }

        public void MyKeyDown(object sender, KeyEventArgs e)
        {
            //LogWrite("KeyDown 	- " + e.KeyData.ToString());
        }

        public void MyKeyPress(object sender, KeyPressEventArgs e)
        {
            //LogWrite("KeyPress 	- " + e.KeyChar);
        }

        public void MyKeyUp(object sender, KeyEventArgs e)
        {
            //LogWrite("KeyUp 		- " + e.KeyData.ToString());
        }

        private void LogWrite(string txt)
        {
            //textBox.AppendText(txt + Environment.NewLine);
            //textBox.SelectionStart = textBox.Text.Length;
        }
    }
}
