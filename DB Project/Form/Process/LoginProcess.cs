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
        // LOGIN PANEL ///////////////////////////////////////////////

        private void TryLogin()
        {
            string ID = LoginPanel_ID.Text;
            string password = LoginPanel_Password.Text;

            CGlobalVariable.Instance.LoginSuccess = LoginModule.Login(ref CGlobalVariable.Instance.connection, ID, password);

            if (CGlobalVariable.Instance.LoginSuccess == true)
                LoginInit();
            else
                LoginPanel_Password.Text = "";
        }

        private void LoginRequest(object sender, EventArgs e)
        {
            TryLogin();
        }
        private void LoginKeyProcess(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Enter))
                TryLogin();
        }

        private void LoginInit()
        {
            LoginPanel.Enabled = false;
            FunctionPanel.Enabled = true;

            DatabaseInit();
            HookerInit();
        }
    }
}
