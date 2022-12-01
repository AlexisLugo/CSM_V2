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
    public partial class Administrator : Form
    {
        string connectionstring = "Data Source=IFACTJUP;Persist Security Info=True;User ID=JUP1QMM;Password=elcaro$QMM";
        DataTable _objdt;
        OracleDataAdapter _objda;
        int minValue = 0;
        int maxValue = 10;
        string gID = null;
        string gColumnName = null;
        string gValue = null;
        public Administrator()//Constructor
        {
            InitializeComponent();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Administrator_Load(object sender, EventArgs e)
        {
            BindData();
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
            MasterData.DataSource = _objdt;
        }

        private void button7_Click(object sender, EventArgs e)
        {
            int nextCount = (minValue - (_objdt.Rows.Count + maxValue)) < maxValue ? 0 : (minValue - (_objdt.Rows.Count + maxValue));
            _objdt = new DataTable();
            _objda.Fill(nextCount, maxValue, _objdt);
            MasterData.DataSource = _objdt;
            minValue = nextCount;
            //Enable disable button
            if (minValue == 0)
            {
                Prev_btn.Enabled = false;
                Next_btn.Enabled = true;
            }
            else
            {
                Prev_btn.Enabled = true;
                Next_btn.Enabled = true;
            }
        }

        private void Next_btn_Click(object sender, EventArgs e)
        {
            int nextCount = minValue + _objdt.Rows.Count;
            _objdt = new DataTable();
            _objda.Fill(nextCount, maxValue, _objdt);
            MasterData.DataSource = _objdt;
            minValue = nextCount;
            //Enable disable button
            if (_objdt.Rows.Count == maxValue)
            {
                Prev_btn.Enabled = true;
                Next_btn.Enabled = true;
            }
            else
            {
                Prev_btn.Enabled = true;
                Next_btn.Enabled = false;
                minValue = nextCount + _objdt.Rows.Count;
            }
        }

        private void BinDataScr()
        {
            _objdt = new DataTable();
            DataTable _objtotalRecord = new DataTable();
            string querystring = "SELECT ID, QC, QC_ORIGINAL, PART_NUMBER, MISC, PRICE_, DATE_, USER_ FROM LAB_WARRANTY_CSM_SCRAP";
            OracleConnection _objcon = new OracleConnection(connectionstring);
            _objda = new OracleDataAdapter(querystring, _objcon);
            _objcon.Open();
            //for filling the grid
            _objda.Fill(minValue, maxValue, _objdt);
            MasterData.DataSource = _objdt;
        }

        private void BinDataUsr()
        {
            _objdt = new DataTable();
            DataTable _objtotalRecord = new DataTable();
            string querystring = "SELECT ID, USERS_, LEVEL_ FROM LAB_WARRANTY_CSM_USERS";
            OracleConnection _objcon = new OracleConnection(connectionstring);
            _objda = new OracleDataAdapter(querystring, _objcon);
            _objcon.Open();
            //for filling the grid
            _objda.Fill(minValue, maxValue, _objdt);
            MasterData.DataSource = _objdt;
        }

        private void user_btn_Click(object sender, EventArgs e)
        {
            BinDataUsr();//user            
        }

        private void scrap_btn_Click(object sender, EventArgs e)
        {
            BinDataScr();
        }

        private void csm_btn_Click(object sender, EventArgs e)
        {
            BindData();//normal
        }
        private void Administrator_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
            }
        }                

        private void MasterData_KeyDown(object sender, KeyEventArgs e)
        {
            
        }

        private void MasterData_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                gID = MasterData.Rows[e.RowIndex].Cells[0].Value.ToString();
                gColumnName = MasterData.Columns[e.ColumnIndex].Name;
                gValue = MasterData.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString();

                backgroundWorker1.RunWorkerAsync();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            
            

            /*
            for (int item = 0; item <= MasterData.Rows.Count - 1; item++)
            {
          
                string qry = "UPDATE LAB_WARRANTY_CSM SET QC = :QC, QC_ORIGINAL = :QC_ORIGINAL, DMC_1 = :DMC_1, DMC_2 = :DMC_2, DMC_3 = :DMC_3, PRODUCT = :PRODUCT,DIRECTORY = :DIRECTORY, WAREHOUSE = :WAREHOUSE, BOX = :BOX, FOLDER_CREATION_DATE = :FOLDER_CREATION_DATE, SCRAP = :SCRAP, PART_NUMBER = :PART_NUMBER, USER_NAME = :USER_NAME WHERE ID = :ID";
          
                OracleConnection conex = new OracleConnection(connectionstring);//aqui
                OracleCommand cmd = new OracleCommand(qry, conex);

                cmd.Parameters.AddWithValue(":QC", MasterData.Rows[item].Cells[1].Value);
                cmd.Parameters.AddWithValue(":QC_ORIGINAL", MasterData.Rows[item].Cells[2].Value);
                cmd.Parameters.AddWithValue(":DMC_1", MasterData.Rows[item].Cells[3].Value);
                cmd.Parameters.AddWithValue(":DMC_2", MasterData.Rows[item].Cells[4].Value);
                cmd.Parameters.AddWithValue(":DMC_3", MasterData.Rows[item].Cells[5].Value);
                cmd.Parameters.AddWithValue(":PRODUCT", MasterData.Rows[item].Cells[6].Value);
                cmd.Parameters.AddWithValue(":DIRECTORY", MasterData.Rows[item].Cells[7].Value);
                cmd.Parameters.AddWithValue(":WAREHOUSE", MasterData.Rows[item].Cells[8].Value);
                cmd.Parameters.AddWithValue(":BOX", MasterData.Rows[item].Cells[9].Value);
                cmd.Parameters.AddWithValue(":FOLDER_CREATION_DATE", MasterData.Rows[item].Cells[10].Value);
                cmd.Parameters.AddWithValue(":SCRAP", MasterData.Rows[item].Cells[11].Value);
                cmd.Parameters.AddWithValue(":PART_NUMBER", MasterData.Rows[item].Cells[12].Value);
                cmd.Parameters.AddWithValue(":USER_NAME", MasterData.Rows[item].Cells[13].Value);
                cmd.Parameters.AddWithValue(":ID", MasterData.Rows[item].Cells[0].Value);

                conex.Open();
                conex.Close();
                conex.Dispose();
            }
            MessageBox.Show("Information updated", "Update", MessageBoxButtons.OK, MessageBoxIcon.Information);
            */
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            try
            {
                string qry = $"UPDATE LAB_WARRANTY_CSM SET {gColumnName} = '{gValue}' WHERE ID = {gID}";
                Console.WriteLine(qry);

                OracleConnection conex = new OracleConnection(connectionstring);//aqui

                conex.Open();
                OracleCommand cmd = new OracleCommand(qry, conex);
                cmd.Connection = conex;
                cmd.CommandText = qry;
                cmd.CommandType = CommandType.Text;
                int xx = cmd.ExecuteNonQuery();
                cmd.Dispose();
                conex.Dispose();
                conex.Close();
                
                Console.WriteLine("Execute BackgroundWorker!!");
                MessageBox.Show("Information updated", "Update", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }catch(Exception ex)
            {
                MessageBox.Show("Error/n" + ex.Message, "error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void backgroundWorker2_DoWork(object sender, DoWorkEventArgs e)
        {

        }
    }
}
