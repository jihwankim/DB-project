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

namespace DB_Project
{
    public partial class Form1 : Form
    {
        // Value
        bool LoginSuccess = false;
        MySqlConnection connection; 

        //
        public Form1()
        {
             InitializeComponent();
        }



        // LOGIN PANEL ///////////////////////////////////////////////
        private void LoginRequest(object sender, EventArgs e)
        {
            string ID = LoginPanel_ID.Text;
            string password = LoginPanel_Password.Text;

            LoginSuccess = TryLogin(ID, password);

            if (LoginSuccess == true)
                LoginPanel.Enabled = false;
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
            }finally
            {
                if(connection != null)
                    connection.Close();
            }

            return result;
        }
    }
}
