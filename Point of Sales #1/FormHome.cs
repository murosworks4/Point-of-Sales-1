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
    public partial class FormHome : Form
    {
        public FormHome()
        {
            InitializeComponent();
        }

        private void FormHome_Load(object sender, EventArgs e)
        {

        }

        private void FormHome_Closing(object sender, EventArgs e)
        {
            Form1 frm = new Form1();
            frm.Show();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            FrmUsers frm = new FrmUsers();
            this.Hide();
            frm.ShowDialog();
            this.Show();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            FrmUsers frm = new FrmUsers();
            this.Hide();
            frm.ShowDialog();
            this.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            FrmRegister frm = new FrmRegister();
            this.Hide();
            frm.ShowDialog();
            this.Show();
        }
    }
}
