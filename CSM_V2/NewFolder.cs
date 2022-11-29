using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CSM_V2
{
    public partial class NewFolder : Form
    {
        private string qc_c;
        public NewFolder(string qc)
        {
            InitializeComponent();
            this.qc_c = qc;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void NewFolder_Load(object sender, EventArgs e)
        {
            textBox1.Text = qc_c;
        }

        private void NewFolder_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
            }
        }
    }
}
