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
    public partial class Homework : Form
    {
        int id = 0;
        bool parent = false;
        string familyid = "";
        public Homework(int id1, bool parent1, string familyid1)
        {
            InitializeComponent();
            id = id1;
            parent = parent1;
            this.familyid = familyid1;
        }
        void Create()
        {

        }
        private void monthCalendar1_DateChanged(object sender, DateRangeEventArgs e)
        {

        }
        SqlConnection cnn = null;
        string connectionstring = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\samson\source\repos\MyFamilyFormsApp\MyFamilyFormsApp\Users.mdf;Integrated Security=True";
        List<string> designated = new List<string>();
        private void Homework_Load(object sender, EventArgs e)
        {
            if (parent)
            {
                label2.Text = "Parent";

            }
            else
            {
                button2.Hide();
                button1.Hide();
                this.Shown += CreateButtonDelegate;
            }

            /*Button btn = new Button();
            btn.Text = "Created Button";
            btn.Location = new Point(0, 69);
            btn.Size = new Size(Form.ActiveForm.Size.Width - 20, 200);
            btn.Font = new Font("Microsoft YaHei", 26.25f, FontStyle.Bold);
            btn.ForeColor = Color.FromArgb(245, 241, 237);
            btn.BackColor = Color.FromArgb(112, 121, 140);
            btn.Visible = true;
            btn.BringToFront();
            
            this.Controls.Add(btn);*/
            

        }
        List<string[]> HomeworkTasks = new List<string[]>();
        private void CreateButtonDelegate(object sender, EventArgs e)
        {
            MessageBox.Show("Called");
            cnn = new SqlConnection(connectionstring);
            SqlDataAdapter adapter = new SqlDataAdapter();
            cnn.Open();
            string sql = "SELECT HomeworkId, Id, HomeworkName FROM HomeworkTable;";
            SqlCommand cmd = new SqlCommand(sql, cnn);
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                if (int.Parse(dr.GetValue(1).ToString()) == id)
                {
                    HomeworkTasks.Add(new string[3] { dr.GetValue(0).ToString(), dr.GetValue(1).ToString(), dr.GetValue(2).ToString()});
                    
                    
                }
            }
            dr.Close();
            MessageBox.Show(HomeworkTasks.Count.ToString());
            for(int i = 0; i < HomeworkTasks.Count; i++)
            {
                Button btn = new Button();
                btn.Text = dr.GetValue(2).ToString();
                btn.Name = dr.GetValue(0).ToString();
                btn.Location = new Point(0, Form.ActiveForm.Size.Height / HomeworkTasks.Count * i);
                btn.Size = new Size(Form.ActiveForm.Size.Width - 20, Form.ActiveForm.Size.Height / HomeworkTasks.Count);
                btn.Font = new Font("Microsoft YaHei", 26.25f, FontStyle.Bold);
                btn.ForeColor = Color.FromArgb(245, 241, 237);
                btn.BackColor = Color.FromArgb(112, 121, 140);
                btn.Visible = true;
                btn.BringToFront();
                btn.Click += DynamicButton_Click;

                this.Controls.Add(btn);
            }
                

            
        }
        private void DynamicButton_Click(object sender, EventArgs e)
        { }
            private void btnLogIn_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form form1 = Application.OpenForms["MainForm"];
            form1.Show();
            this.Close();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            cnn = new SqlConnection(connectionstring);
            SqlDataAdapter adapter = new SqlDataAdapter();
            cnn.Open();
            string sql = "SELECT Name, Id FROM UserLogin WHERE FamilyId = '" + familyid + "';";
            SqlCommand cmd = new SqlCommand(sql, cnn);
            SqlDataReader dr = cmd.ExecuteReader();
            List<string[]> famids = new List<string[]>();
            while (dr.Read()){
                if(int.Parse(dr.GetValue(1).ToString()) != id)
                {
                    famids.Add(new string[2] { dr.GetValue(1).ToString(), dr.GetValue(0).ToString() });
                }
            }
            
            dr.Close();
            sql = "SELECT HomeworkId FROM HomeworkTable;";
            cmd = new SqlCommand(sql, cnn);
            dr = cmd.ExecuteReader();
            int number = 0;
            while (dr.Read())
            {
                if(dr.GetValue(0).ToString().Length > 0)
                {
                    number++;
                }
            }
            dr.Close();
            if (famids.Count > 0)
            {
                using (var form = new CreateHomwork(famids))
                {
                    var result = form.ShowDialog();
                    if (result == DialogResult.OK)
                    {
                        designated.Add(form.famids[0][0]);
                        designated.Add(form.famids[0][1]);
                        designated.Add(form.HomeworkName);
                        designated.Add(form.datetime.ToString());
                        sql = @"INSERT INTO[dbo].[HomeworkTable]([Id], [HomeworkId], [HomeworkName], [DueDate], [HomeworkCompleted]) VALUES('" + id.ToString() + "',"+ number.ToString() +", '" + designated[2] + "', '" + designated[3] + "',0)";
                        cmd = new SqlCommand(sql, cnn);
                        adapter.InsertCommand = cmd;
                        adapter.InsertCommand.ExecuteNonQuery();
                        

                    }
                }
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }
    }
}
