using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Media;
using System.Data.SqlClient;

namespace MyFamilyFormsApp
{
    public partial class MainForm : Form
    {
        string name = string.Empty;
        private static Random random = new Random();
        int id;
        bool parent = false;
        string familyId = string.Empty;
        public MainForm(string name1, int id1, bool parent1, string familyId1)
        {
            InitializeComponent();
            this.name = name1;
            id = id1;
            parent = parent1;
            familyId = familyId1;
        }

        private void btnHomework_Click(object sender, EventArgs e)
        {
            
            
            Homework hmf = new Homework(id, parent, familyId);
            hmf.Location = this.Location;
            this.Hide();
            hmf.Show();

        }

        private void btnChores_Click(object sender, EventArgs e)
        {

        }

        private void btnEvents_Click(object sender, EventArgs e)
        {

        }

        private void btnReflection_Click(object sender, EventArgs e)
        {

        }

        private void MainForm_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlConnection cnn = null;
            string connectionstring = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\samson\source\repos\MyFamilyFormsApp\MyFamilyFormsApp\Users.mdf;Integrated Security=True";
            cnn = new SqlConnection(connectionstring);
            SqlDataAdapter adapter = new SqlDataAdapter();
            cnn.Open();
            string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            string newid = string.Empty;
            for(int i = 0; i < 20; i++)
            {
                newid += chars[random.Next(chars.Length)];
            }
            MessageBox.Show(newid);
            string sql = @"UPDATE [dbo].[UserLogin] SET [FamilyId] = '" + newid.ToString() + "' WHERE [Id] = " + id.ToString();
            SqlCommand cmd = new SqlCommand(sql, cnn);
            adapter.UpdateCommand = cmd;
            adapter.UpdateCommand.ExecuteNonQuery();
            familyId = newid;
            Clipboard.SetText(newid);
            
        }
        

        private void button2_Click(object sender, EventArgs e)
        {
            using (var form = new txtform())
            {
                var result = form.ShowDialog();
                if (result == DialogResult.OK)
                {
                    string famid = form.stringReturn;
                    txtform hmf = new txtform();
                    SqlConnection cnn = null;
                    string connectionstring = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\samson\source\repos\MyFamilyFormsApp\MyFamilyFormsApp\Users.mdf;Integrated Security=True";
                    cnn = new SqlConnection(connectionstring);
                    SqlDataAdapter adapter = new SqlDataAdapter();
                    cnn.Open();
                    string sql = "SELECT FamilyId FROM UserLogin";
                    SqlCommand cmd = new SqlCommand(sql, cnn);
                    SqlDataReader dr = cmd.ExecuteReader();
                    bool validid = false;
                    while (dr.Read())
                    {
                        if (dr.GetValue(0).ToString() == famid)
                        {
                            validid = true;

                        }
                    }
                    dr.Close();
                    if (validid)
                    {
                        sql = @"UPDATE [dbo].[UserLogin] SET [FamilyId] = '" + famid.ToString() + "' WHERE [Id] = " + id.ToString();
                        cmd = new SqlCommand(sql, cnn);
                        adapter.UpdateCommand = cmd;
                        adapter.UpdateCommand.ExecuteNonQuery();
                        familyId = famid;
                        MessageBox.Show(famid);
                    }
                    else
                    {
                        MessageBox.Show("ID NOT FOUND");
                    }
                }
            }
            
            
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Clipboard.SetText(familyId);
        }
    }
}
