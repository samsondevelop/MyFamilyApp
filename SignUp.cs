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
    public partial class SignUp : Form
    {
        public SignUp()
        {
            InitializeComponent();
        }
        bool labelone = true;
        bool labeltwo = true;
        bool parent = false;
        SqlConnection cnn = null;
        string connectionstring = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\samson\source\repos\MyFamilyFormsApp\MyFamilyFormsApp\Users.mdf;Integrated Security=True";
        private void Login_Load(object sender, EventArgs e)
        {

        }
       
        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            if (labelone && textBox3.Text.Length == 0)
            {
                
                labelone = false;
            }
                if (labelone)
            {
                
                textBox3.Text = "";
                labelone = false;
            }
        }
        

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            if(labeltwo && textBox2.Text.Length == 0)
            {
                labeltwo = false;
                textBox1.PasswordChar = '*';
                textBox1.Text = "";
            }
            if (labeltwo)
            {
                textBox2.Text = "";
                labeltwo = false;
                textBox1.Text = "";
                textBox1.PasswordChar = '*';
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void btnLogIn_Click(object sender, EventArgs e)
        {
         
            
            
        }

        private void btnLogIn_Click_1(object sender, EventArgs e)
        {
            cnn = new SqlConnection(connectionstring);
            SqlDataAdapter adapter = new SqlDataAdapter();
            cnn.Open();
            string sql = "SELECT Email FROM UserLogin";
            SqlCommand cmd = new SqlCommand(sql, cnn);
            SqlDataReader dr = cmd.ExecuteReader();
            bool unique = true;
            int count = 0;
            while (dr.Read())
            {
                if (dr.GetValue(0)!="")
                {
                    count++;
                }
                if (dr.GetValue(0).ToString()== textBox2.Text){
                    unique = false;
                    MessageBox.Show("Email Already Exists");
                }
            }
            dr.Close();
            if(textBox2.Text.Contains('@') && textBox2.Text.Length > 0 && textBox1.Text.Length > 0 && textBox3.Text.Length > 0 && textBox3.Text != "Name" && textBox1.Text != "Password")
            {
                if (unique)
                {
                    sql = @"INSERT INTO [dbo].[UserLogin] ([Id], [Name], [Email], [Password], [Parent], [FamilyId]) VALUES (" + count.ToString().Trim() + ", N'" + textBox3.Text.Trim() + "', N'" + textBox2.Text.Trim() + "', N'" + textBox1.Text.Trim() + "', N'" + parent.ToString() + "', N'0')";
                    cmd = new SqlCommand(sql, cnn);
                    adapter.InsertCommand = cmd;
                    adapter.InsertCommand.ExecuteNonQuery();
                    MainForm frm = new MainForm(textBox3.Text.Trim(), count, parent, "");
                    frm.Location = this.Location;
                    this.Hide();
                    frm.Show();
                    frm.Focus();
                    this.Close();
                }
            }
            else
            {
                MessageBox.Show("Invalid Data");
            }
           
            cmd.Dispose();
            cnn.Close();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void parentbutton_Click(object sender, EventArgs e)
        {
            parent = !parent;
            switch (parent)
            {
                case true:
                    parentbutton.BackColor = Color.Green;
                    break;
                    case false:
                    parentbutton.BackColor = Color.Red;
                    break;
            }
        }
    }
}
