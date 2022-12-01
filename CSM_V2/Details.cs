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
            try
            {
                BindData();
            }
            catch(Exception ex)
            {
                MessageBox.Show("Error/n" + ex.Message, "error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void BindData()
        {
            _objdt = new DataTable();
            DataTable _objtotalRecord = new DataTable();
            string querystring = "SELECT ID, QC, QC_ORIGINAL, DMC_1, DMC_2, DMC_3, PRODUCT, DIRECTORY, WAREHOUSE, BOX, FOLDER_CREATION_DATE, SCRAP, PART_NUMBER, USER_NAME FROM LAB_WARRANTY_CSM";
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

        private void MData_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                for (int item = 0; item <= MData.Rows.Count - 1; item++)
                {

                    string qry = "UPDATE LAB_WARRANTY_CSM SET QC = :QC, QC_ORIGINAL = :QC_ORIGINAL, DMC_1 = :DMC_1, DMC_2 = :DMC_2, DMC_3 = :DMC_3, PRODUCT = :PRODUCT,DIRECTORY = :DIRECTORY, WAREHOUSE = :WAREHOUSE, BOX = :BOX, FOLDER_CREATION_DATE = :FOLDER_CREATION_DATE, SCRAP = :SCRAP, PART_NUMBER = :PART_NUMBER, USER_NAME = :USER_NAME WHERE ID = :ID";

                    OracleConnection conex = new OracleConnection(connectionstring);//aqui
                    OracleCommand cmd = new OracleCommand(qry, conex);

                    cmd.Parameters.AddWithValue(":QC", MData.Rows[item].Cells[1].Value);
                    cmd.Parameters.AddWithValue(":QC_ORIGINAL", MData.Rows[item].Cells[2].Value);
                    cmd.Parameters.AddWithValue(":DMC_1", MData.Rows[item].Cells[3].Value);
                    cmd.Parameters.AddWithValue(":DMC_2", MData.Rows[item].Cells[4].Value);
                    cmd.Parameters.AddWithValue(":DMC_3", MData.Rows[item].Cells[5].Value);
                    cmd.Parameters.AddWithValue(":PRODUCT", MData.Rows[item].Cells[6].Value);
                    cmd.Parameters.AddWithValue(":DIRECTORY", MData.Rows[item].Cells[7].Value);
                    cmd.Parameters.AddWithValue(":WAREHOUSE", MData.Rows[item].Cells[8].Value);
                    cmd.Parameters.AddWithValue(":BOX", MData.Rows[item].Cells[9].Value);
                    cmd.Parameters.AddWithValue(":FOLDER_CREATION_DATE", MData.Rows[item].Cells[10].Value);
                    cmd.Parameters.AddWithValue(":SCRAP", MData.Rows[item].Cells[11].Value);
                    cmd.Parameters.AddWithValue(":PART_NUMBER", MData.Rows[item].Cells[12].Value);
                    cmd.Parameters.AddWithValue(":USER_NAME", MData.Rows[item].Cells[13].Value);
                    cmd.Parameters.AddWithValue(":ID", MData.Rows[item].Cells[0].Value);

                    conex.Open();
                    conex.Close();
                    conex.Dispose();
                }
                MessageBox.Show("Information updated", "Update", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error/n" + ex.Message, "error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
