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
    public partial class txtform : Form
    {
        public txtform()
        {
            InitializeComponent();
        }
        public string stringReturn { get; set; }
        private void button1_Click(object sender, EventArgs e)
        {
            if(textBox1.Text.Trim().Length == 20)
            {
                stringReturn = textBox1.Text.Trim();
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            else
            {
                this.DialogResult = DialogResult.No;
                MessageBox.Show("Incorrect Length");
            }
            
        }

        private void txtform_Load(object sender, EventArgs e)
        {

        }
    }
}
