using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
namespace MyFamilyFormsApp
{
    public partial class MyFamilyMain : Form
    {
        public MyFamilyMain()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void btnSignUp_Click(object sender, EventArgs e)
        {
            SignUp frm = new SignUp();
            frm.Show();
            frm.Focus();
        }

        private void btnLogIn_Click(object sender, EventArgs e)
        {
            /*using (SqlConnection connection = new SqlConnection(GetConnectionString()))
            {
                connection.Open();

                MessageBox.Show("State: {0}", connection.State.ToString());
                MessageBox.Show("ConnectionString: {0}",
                    connection.ConnectionString);
            }*/

            Login frm = new Login();
            frm.Location = this.Location;
            frm.Show();
            frm.Focus();
        }
        static private string GetConnectionString()
        {
            return "Data Source=(local);Initial Catalog=AdventureWorks;"
                + "Integrated Security=SSPI;";
        }
    }
}
