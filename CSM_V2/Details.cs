using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OracleClient;

namespace CSM_V2
{
    public partial class Details : Form
    {
        public string connectionstring = "Data Source=IFACTJUP;Persist Security Info=True;User ID=JUP1QMM;Password=elcaro$QMM";
        DataTable _objdt;
        OracleDataAdapter _objda;
        int minValue = 0;
        int maxValue = 10;
        public Details()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Details_Load(object sender, EventArgs e)
        {
            BindData();
        }

        public void BindData()
        {
            _objdt = new DataTable();
            DataTable _objtotalRecord = new DataTable();
            string querystring = "select id, qc, dmc_1, dmc_2, dmc_3, product, directory, warehouse, box, folder_creation_date, scrap, part_number, user_name from lab_warranty_csm";
            OracleConnection _objcon = new OracleConnection(connectionstring);
            _objda = new OracleDataAdapter(querystring, _objcon);
            _objcon.Open();
            //for filling the grid
            _objda.Fill(minValue, maxValue, _objdt);
            MData.DataSource = _objdt;
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            int nextCount = (minValue - (_objdt.Rows.Count + maxValue)) < maxValue ? 0 : (minValue - (_objdt.Rows.Count + maxValue));
            _objdt = new DataTable();
            _objda.Fill(nextCount, maxValue, _objdt);
            MData.DataSource = _objdt;
            minValue = nextCount;
            //Enable disable button
            if (minValue == 0)
            {
                Prev_btn.Enabled = false;
                nex_btn.Enabled = true;
            }
            else
            {
                Prev_btn.Enabled = true;
                nex_btn.Enabled = true;
            }
        }

        private void nex_btn_Click(object sender, EventArgs e)
        {
            int nextCount = minValue + _objdt.Rows.Count;
            _objdt = new DataTable();
            _objda.Fill(nextCount, maxValue, _objdt);
            MData.DataSource = _objdt;
            minValue = nextCount;
            //Enable disable button
            if (_objdt.Rows.Count == maxValue)
            {
                Prev_btn.Enabled = true;//boton 1 = anterior
                nex_btn.Enabled = true;
            }
            else
            {
                Prev_btn.Enabled = true;
                nex_btn.Enabled = false;
                minValue = nextCount + _objdt.Rows.Count;
            }
        }

        private void Details_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
            }
        }
    }
}
