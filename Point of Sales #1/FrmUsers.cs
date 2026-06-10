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
    public partial class FrmUsers : Form
    {
        public FrmUsers()
        {
            InitializeComponent();
        }

        MyDatabase db = new MyDatabase();

        private void FrmUsers_Load(object sender, EventArgs e)
        {
            string query = "SELECT tbluserinformation.userID, tbllogincredentials.LoginID, tbluserinformation.firstname, " +
                "tbluserinformation.middlename, tbluserinformation.lastname, tbluserinformation.emailAddress," +
                " tbluserinformation.homeAddress, tbluserinformation.birthDate, tbllogincredentials.user_username as 'Username'," +
                " tbllogincredentials.user_password as 'Password' FROM tbllogincredentials INNER JOIN tbluserinformation" +
                " ON tbllogincredentials.userID = tbluserinformation.userID;";

            dgvUsers.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            dgvUsers.DataSource = db.ExecuteReturnQuery(query);
            dgvUsers.Columns[0].Visible = false;
            dgvUsers.Columns[1].Visible = false;
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btsSave_Click(object sender, EventArgs e)
        {
            string query = "INSERT INTO tbluserinformation (Firstname, Middlename, Lastname, EmailAddress, HomeAddress, BirthDate)" +
               " VALUES (@fname, @mname, @lname, @email, @hadd, @bDate);" +
               "SET @newUserID = LAST_INSERT_ID();" +
               "INSERT INTO tbllogincredentials (userID, user_username, user_password) VALUES (@newUserID, @username, @password);";

            int affectedRowCount = db.ExecuteNoReturnQuery(query,
                new MySqlParameter("@fname", tbFname.Text),
                new MySqlParameter("@mname", tbMname.Text),
                new MySqlParameter("@lname", tbLname.Text),
                new MySqlParameter("@email", tbEmailAdd.Text),
                new MySqlParameter("@hadd", tbHomeAdd.Text),
                new MySqlParameter("@bDate", dtpBirthDate.Value),
                new MySqlParameter("@username", tbUsername.Text),
                new MySqlParameter("@password", tbPassword.Text)
                );

            if (affectedRowCount > 0)
            {
                MessageBox.Show("Data Inserted!");
                FrmUsers_Load(null, null);
            }

        }

        private void btnDeactivate_Click(object sender, EventArgs e)
        {
            if (dgvUsers.SelectedRows.Count > 0)
            {

                DialogResult result = MessageBox.Show("Are you sure you want to deactivate this account?", "Account Deactivation", MessageBoxButtons.YesNo);
                if (result == DialogResult.Yes)
                {

                    int id = Convert.ToInt32(dgvUsers.SelectedRows[0].Cells[1].Value);
                    string query = "UPDATE tbllogincredentials SET is_active = 0 where LoginID = @id";

                    int affectedRows = db.ExecuteNoReturnQuery(query,
                        new MySqlParameter("@id", id));
                    if (affectedRows > 0)
                    {
                        MessageBox.Show("Account is deactivated!");
                    }

                }
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (dgvUsers.SelectedRows.Count > 0)
            {
                DialogResult result = MessageBox.Show("Are you sure you want to update this account?", "Update Account", MessageBoxButtons.YesNo);
                if (result == DialogResult.Yes)
                {

                    int idUserInfo = Convert.ToInt32(dgvUsers.SelectedRows[0].Cells[0].Value);
                    int idLoginCredentials = Convert.ToInt32(dgvUsers.SelectedRows[0].Cells[1].Value);
                    tbFname.Text = dgvUsers.SelectedRows[0].Cells[2].Value.ToString();

                    //continue
                }
            }
        }

        private void dgvUsers_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void tbUsername_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
