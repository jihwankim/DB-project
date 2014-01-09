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
        static Option OptionForm = null;

        //
        public Main()
        {
            InitializeComponent();

            LoginModule = new CLoginModule();
            FunctionPanel.Enabled = false;
            LogForm.Show();
        }

        private void ShowSettingForm(object sender, EventArgs e)
        {
            if (OptionForm != null)
                OptionForm.Dispose();

            OptionForm = new Option();
            OptionForm.Show();
        }
    }
}
