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

using DB_Project.Class;

namespace DB_Project
{
    public partial class Main : Form
    {
        // Class
        CLoginModule LoginModule;
        static Log LogForm = new Log();

        //
        public Main()
        {
            InitializeComponent();

            LoginModule = new CLoginModule();
            FunctionPanel.Enabled = false;
            LogForm.Show();
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
        

        public int abs(int x) { return x > 0 ? x : -x; }
    }
}
