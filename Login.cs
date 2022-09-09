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
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }
        bool label2 = true;
        private void textBox1_TextChanged(object sender, EventArgs e)
        {
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            if(textBox2.Text.Length == 1)
            {
                if (label2)
                {
                    textBox1.PasswordChar = '*';
                    textBox1.Text = "";
                    label2 = false;
                }
                
            }
            if (label2)
            {
                textBox2.Text = "";
                textBox1.PasswordChar = '*';
                textBox1.Text = "";
                label2 = false;
            }
        }
        SqlConnection cnn = null;
        string connectionstring = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\samson\source\repos\MyFamilyFormsApp\MyFamilyFormsApp\Users.mdf;Integrated Security=True";
        private void btnLogIn_Click(object sender, EventArgs e)
        {
            cnn = new SqlConnection(connectionstring);
            SqlDataAdapter adapter = new SqlDataAdapter();
            cnn.Open();
            string sql = "SELECT Email, Password, Name, Id, Parent, FamilyId FROM UserLogin";
            SqlCommand cmd = new SqlCommand(sql, cnn);
            SqlDataReader dr = cmd.ExecuteReader();
            bool email = false;
            bool pass = false;
            string name = string.Empty;
            int id = 0;
            bool parent = false;
            string familyId = string.Empty;
            while (dr.Read())
            {
                if(dr.GetValue(0).ToString().ToLower() == textBox2.Text.Trim().ToLower())
                {
                    email = true;
                }
                if (dr.GetValue(1).ToString() == textBox1.Text.Trim())
                {
                    pass = true;
                }
                if(pass && email == true)
                {
                    MessageBox.Show("LOGIN");
                    name = dr.GetValue(2).ToString();
                    id = int.Parse(dr.GetValue(3).ToString());
                    parent = bool.Parse(dr.GetValue(4).ToString());
                    
                    familyId = (dr.GetValue(5).ToString());
                    break;
                }
                email = false;
                pass = false;
            }

            dr.Close();
            cmd.Dispose();
            cnn.Close();
            if(pass && email == true)
            {
                MainForm frm = new MainForm(name, id, parent, familyId);
                frm.Location = this.Location;
                this.Hide();
                frm.Show();
                frm.Focus();
                this.Close();
            }
            else
            {
                MessageBox.Show("Incorrect Username / Password");
            }
            
            
        }

        private void Login_Load(object sender, EventArgs e)
        {

        }
    }
}
