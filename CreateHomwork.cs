using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MyFamilyFormsApp
{
    public partial class CreateHomwork : Form
    {
        public List<string[]> famids = new List<string[]>();
        public string HomeworkName = string.Empty;
        public DateTime datetime = new DateTime();
        public CreateHomwork(List<string[]> famids1)
        {
            InitializeComponent();
            famids.AddRange(famids1);
            this.Shown += CreateButtonDelegate;
        }

        private void CreateHomwork_Load(object sender, EventArgs e)
        {
            btnLogIn.Visible = false;
            textBox1.Visible = false;
            dateTimePicker1.Visible = false;
        }
        private void CreateButtonDelegate(object sender, EventArgs e)
        {
            for(int i = 0; i < famids.Count; i++)
            {
                Button btn = new Button();
                btn.Text = famids[i][1];
                btn.Name = famids[i][0];
                btn.Location = new Point(0, Form.ActiveForm.Size.Height / famids.Count * i);
                btn.Size = new Size(Form.ActiveForm.Size.Width - 20, Form.ActiveForm.Size.Height / famids.Count);
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
        {
            Button btn = (Button)sender;
            famids.Clear();
            famids.Add(new string[2] { btn.Name, btn.Text });
            foreach(Button butn in this.Controls.OfType<Button>())
            {
                butn.Hide();
            }
            createSecondView();

            //
        }
        void createSecondView()
        {
            btnLogIn.Visible = true;
            textBox1.Visible = true;
            dateTimePicker1.Visible = true;

        }
        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void btnLogIn_Click(object sender, EventArgs e)
        {
            HomeworkName = textBox1.Text.Trim();
            datetime = dateTimePicker1.Value;
            this.DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}
