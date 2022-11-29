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
            string querystring = "select id, qc, dmc_1, dmc_2, dmc_3, product, directory, warehouse, box, folder_creation_date, scrap, part_number, user_name from lab_warranty_csm";
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
            string querystring = "select id, qc, qc_original, part_number, misc, price_, date_, user_ from lab_warranty_csm_scrap";
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
            string querystring = "select id, users_, level_ from lab_warranty_csm_users";
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

        private void MasterData_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            for (int item = 0; item <= MasterData.Columns.Count ; item++)
            {
                string qry = ("update lab_warranty_csm set qc=:qc,qc_original=:qc_original, dmc_1=:dmc__1, dmc_2=:dmc_2, dmc_3=:dmc_3, product=:product, directory=:directory, warehouse=:warehouse, box=:box, folder_creation_date=:folder_creation_date, scrap=:scrap, part_number=:part_number, user_name=:user_name where id=:id");
                OracleCommand cmd = new OracleCommand(qry, connectionstring);

                cmd.Parameters.AddWithValue(":qc", MasterData.Rows[item].Cells[1].Value);
                cmd.Parameters.AddWithValue(":qc_original", MasterData.Rows[item].Cells[2].Value);
                cmd.Parameters.AddWithValue(":dmc_1", MasterData.Rows[item].Cells[3].Value);
                cmd.Parameters.AddWithValue(":dmc_2", MasterData.Rows[item].Cells[4].Value);
                cmd.Parameters.AddWithValue(":dmc_3", MasterData.Rows[item].Cells[5].Value);
                cmd.Parameters.AddWithValue(":product", MasterData.Rows[item].Cells[6].Value);
                cmd.Parameters.AddWithValue(":directory", MasterData.Rows[item].Cells[7].Value);
                cmd.Parameters.AddWithValue(":warehouse", MasterData.Rows[item].Cells[8].Value);
                cmd.Parameters.AddWithValue(":box", MasterData.Rows[item].Cells[9].Value);
                cmd.Parameters.AddWithValue(":folder_creation_date", MasterData.Rows[item].Cells[10].Value);
                cmd.Parameters.AddWithValue(":scrap", MasterData.Rows[item].Cells[11].Value);
                cmd.Parameters.AddWithValue(":part_number", MasterData.Rows[item].Cells[12].Value);
                cmd.Parameters.AddWithValue(":user_name", MasterData.Rows[item].Cells[13].Value);
                cmd.Parameters.AddWithValue(":id", MasterData.Rows[item].Cells[0].Value);

                connectionstring.Open();
                cmd.ExecuteNonQuery();
                connectionstring.Close();
            }

            MessageBox.Show("Save lastest updates");
            //UpdateBalance();

        }


    }
}
