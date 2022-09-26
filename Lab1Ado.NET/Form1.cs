using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab1Ado.NET
{
    public partial class Form1 : Form
    {
        private SqlDataAdapter operation_DB_adapter;
        private SqlDataAdapter recreation_zone_DB_adapter;
        private SqlDataAdapter bracelet_DB_adapter;

        private SqlCommandBuilder commandBuilder_for_operations;

        private DataSet dataset = new DataSet();
        string ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["DbConnection"].ConnectionString;
        public Form1()
        {
            InitializeComponent();
            string sql_query = "SELECT operation_id as 'ID', bracelet_id as 'ID браслета', recreation_area_id as 'Зона отдыха', operation.sum as'Сумма' FROM operation";
            operation_DB_adapter = new SqlDataAdapter(sql_query, ConnectionString);
            sql_query = "SELECT * FROM recreation_area";
            recreation_zone_DB_adapter = new SqlDataAdapter(sql_query, ConnectionString);
            sql_query = "SELECT * FROM bracelet";
            bracelet_DB_adapter = new SqlDataAdapter(sql_query, ConnectionString);

            commandBuilder_for_operations = new SqlCommandBuilder(operation_DB_adapter);

            recreation_zone_DB_adapter.Fill(dataset, "recreation_area");
            operation_DB_adapter.Fill(dataset, "operation");
            bracelet_DB_adapter.Fill(dataset, "bracelet");

            dataGridView1.DataSource = dataset.Tables["operation"];
            
            fill_combo_box_recreation_zone(((DataGridViewComboBoxColumn)dataGridView1.Columns["ID_recreation_zone"]));
            fill_combo_box_bracelete_id(((DataGridViewComboBoxColumn)dataGridView1.Columns["ID_bracelet"]));
            fill_combobox_report(comboBox1);

        }
        void fill_combobox_report(ComboBox column)
        {
            column.DataSource =
                dataset.Tables["recreation_area"];
            column.ValueMember =
                "recreation_area_id";
            column.DisplayMember =
                "Name";
        }
        void fill_combo_box_recreation_zone(DataGridViewComboBoxColumn column)
        {
            column.DataSource =
                dataset.Tables["recreation_area"];
            column.ValueMember =
                "recreation_area_id";
            column.DisplayMember =
                "Name";
        }
        void fill_combo_box_bracelete_id(DataGridViewComboBoxColumn column)
        {
            column.DataSource =
                dataset.Tables["bracelet"];
            column.ValueMember =
                "Bracelet_id";
            column.DisplayMember =
                "Bracelet_id";
        }
        private void button2_Click(object sender, EventArgs e)
        {
            operation_DB_adapter.Update(dataset.Tables["operation"]);
        }
        private void button3_Click(object sender, EventArgs e)
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                connection.Open();
                string sqluery = "select * from operation o\r\njoin recreation_area r on r.recreation_area_id = o.recreation_area_id\r\nwhere o.recreation_area_id = " + comboBox1.SelectedValue;
                SqlCommand sqlCommand = new SqlCommand(sqluery, connection);
                SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                DataTable dataTable = new DataTable("report1");
                dataTable.Columns.Add("operation_id");
                dataTable.Columns.Add("bracelet_id");
                dataTable.Columns.Add("sum");
                while (sqlDataReader.Read())
                {
                    DataRow row = dataTable.NewRow();
                    row["operation_id"] = sqlDataReader["operation_id"];
                    row["sum"] = sqlDataReader["sum"];
                    row["bracelet_id"] = sqlDataReader["bracelet_id"];
                    dataTable.Rows.Add(row);
                }
                sqlDataReader.Close();
                dataGridView2.DataSource = dataTable;
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                SqlDataAdapter sqlAdapter = new SqlDataAdapter("operations_between", connection);
                sqlAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;
                sqlAdapter.SelectCommand.Parameters.Add(new SqlParameter("@low_sum", numericUpDown1.Value));
                sqlAdapter.SelectCommand.Parameters.Add(new SqlParameter("@upper_sum", numericUpDown2.Value));
                DataSet dataSet = new DataSet();
                sqlAdapter.Fill(dataSet, "report2");
                dataGridView3.DataSource = dataSet.Tables["report2"];
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            string ID_deleting = numericUpDown3.Value.ToString();
            foreach(DataRow row in dataset.Tables["operation"].Rows)
                if (row[0].ToString() == ID_deleting)
                {
                    row.Delete();
                    break;
                }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            DataRow row = dataset.Tables["operation"].NewRow();
            row["ID"] = ((int)(dataset.Tables["operation"].Rows[dataset.Tables["operation"].Rows.Count - 1]["ID"]) + 1);
            dataset.Tables["operation"].Rows.Add(row);
        }
    }
}
