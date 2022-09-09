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
    public partial class Chores : Form
    {
        SqlConnection cnn = null;
        string familyid = string.Empty;
        string connectionstring = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\samson\source\repos\MyFamilyFormsApp\MyFamilyFormsApp\Users.mdf;Integrated Security=True";
        public Chores(int id1, bool parent1, string familyid1)
        {
            InitializeComponent();
            familyid = familyid1;
            cnn = new SqlConnection(connectionstring);
            SqlDataAdapter adapter = new SqlDataAdapter();
            cnn.Open();
            string sql = "SELECT ";
            SqlCommand cmd = new SqlCommand(sql, cnn);
            SqlDataReader dr = cmd.ExecuteReader();
            bool email = false;
            bool pass = false;
            string name = string.Empty;
            int id = 0;
            while (dr.Read())
            {

            }

        }

        List<Chore> ChoreList = new List<Chore>();
        private void btnLogIn_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form form1 = Application.OpenForms["MainForm"];
            form1.Show();
            this.Close();
        }

        private void Chores_Load(object sender, EventArgs e)
        {

        }
    }
}
