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

using DB_Project;

namespace DB_Project
{
    public partial class Main
    {
        // HOOKING ///////////////////////////////////////////////
        
        UserActivityHook actHook;
        static System.Windows.Forms.Timer InsertTimer = new System.Windows.Forms.Timer();

        // DLL LOAD
        [DllImport("user32.dll")]
        public static extern IntPtr GetWindowThreadProcessId(IntPtr hWnd, out uint ProcessId);

        [DllImport("user32.dll")]
        private static extern IntPtr GetForegroundWindow();

        public static string GetActiveProcessName()
        {
            IntPtr hwnd = GetForegroundWindow();
            uint pid;
            GetWindowThreadProcessId(hwnd, out pid);
            Process p = Process.GetProcessById((int)pid);
            //return p.MainModule.ModuleName;
            return p.ProcessName;
        }

        void HookerInit()
        {
            InsertTimer.Tick += new EventHandler(InsertRecord);
            InsertTimer.Interval = interval;

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

        
        public void MouseMoved(object sender, MouseEventArgs e)
        {
            if (e.Clicks > 0) WriteLog("Mouse", "Click " + e.Button.ToString().Substring(0, 1), e.X.ToString(), e.Y.ToString());
            else if (e.Delta != 0) WriteLog("Mouse", "Wheel " + (e.Delta > 0 ? "UP" : "DOWN"), e.X.ToString(), e.Y.ToString());
            else
            {
                if ((abs(lastMouseMove.X - e.X) > 50) || (abs(lastMouseMove.Y - e.Y) > 50))
                {
                    isMouseMoved = true;
                    lastMouseMove.X = e.X;
                    lastMouseMove.Y = e.Y;
                }

            }
        }

        public void MyKeyDown(object sender, KeyEventArgs e)
        {
            WriteLog("Keyboard", "KeyDown", e.KeyData.ToString(), "");
        }

        public void MyKeyPress(object sender, KeyPressEventArgs e)
        {
            WriteLog("Keyboard", "KeyPress", e.KeyChar.ToString(), "");
        }

        public void MyKeyUp(object sender, KeyEventArgs e)
        {
            WriteLog("Keyboard", "KeyUp", e.KeyData.ToString(), "");
        }
        public static void WriteLog(string InputType, string Type, string record1, string record2)
        {
            inputLog.Add(new Input(InputType, Type, record1, record2, GetActiveProcessName(), DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")));

            LogForm.LogBox.AppendText(String.Format("[{0}] {1}{2}{3}{4}   - {5}{6}", DateTime.Now.ToString("HH:mm:ss"), Type, record1, record2, Environment.NewLine, GetActiveProcessName(), Environment.NewLine));
            LogForm.LogBox.SelectionStart = LogForm.LogBox.Text.Length;
        }
    }
}
