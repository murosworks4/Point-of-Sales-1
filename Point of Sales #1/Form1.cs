using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Point_of_Sales__1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        MyDatabase db = new MyDatabase();

        string[,] userCredentials =
        {
            {"admin", "admin", "admin1" },
            {"admin", "password", "admin1" }
        };

        private void Form1_Load(object sender, EventArgs e)
        {
            if (db.TestConnection() == true)
            {
                MessageBox.Show("Database is Connected");
            }
            else
            {
                MessageBox.Show("DataBase Connection Failed!");
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void tbUsername_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnLogin_Click(object sender, EventArgs e)
        {

            if (tbUsername.Text == "")
            {
                MessageBox.Show("Please enter username!!", "Validation");
                tbUsername.Focus();
            }
            else if (tbPassword.Text == "")
            {
                MessageBox.Show("Please enter password", "Validation");
                tbPassword.Focus();
            }
            else
            {
                DataTable dt = db.ExecuteReturnQuery("SELECT * from tblLoginCredentials WHERE user_username = @uname and user_password = @pword and is_active = 1;",
                    new MySqlParameter("@uname", tbUsername.Text),
                    new MySqlParameter("@pword", tbPassword.Text));

                if (dt.Rows.Count == 1)
                {
                    FormHome frm = new FormHome();
                    this.Hide();
                    frm.ShowDialog();
                    this.Show();
                }
                else
                {
                    MessageBox.Show("Invalid Username or Password");
                }

            }
           
        }
    }
}
