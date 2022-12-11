using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Common;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Runtime.Remoting.Contexts;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BLL;
using BLL.Interfaces;
using BLL.Models;
using BLL.Services;

namespace Lab1Ado.NET
{
    public partial class Form1 : Form
    {
        IDbCrud db;
        IReportService reportService;
        IBraceletService braceletService;
        public Form1(IDbCrud db, IReportService reportService, IBraceletService braceletService)
        {
            InitializeComponent();
            this.db = db;
            this.reportService = reportService;
            this.braceletService = braceletService;

            dataGridView1.DataSource = db.GetAllOperations();
            dataGridView4.DataSource = db.GetAllBracelet();

            fill_combo_box_recreation_zone(((DataGridViewComboBoxColumn)dataGridView1.Columns["recreationAreaIdDataGridViewTextBoxColumn2"]));
            fill_combo_box_bracelete_id(((DataGridViewComboBoxColumn)dataGridView1.Columns["braceletIdDataGridViewTextBoxColumn2"]));
            fill_combo_box_customer(((DataGridViewComboBoxColumn)dataGridView4.Columns["customerIdDataGridViewTextBoxColumn"]));
            fill_combobox_report(comboBox1);

        }
        void fill_combobox_report(ComboBox column)
        {
            column.DataSource =
                db.GetAllRecreationAres();
            column.ValueMember =
                "Id";
            column.DisplayMember =
                "Name";
        }
        void fill_combo_box_customer(DataGridViewComboBoxColumn column)
        {
            column.DataSource =
               db.GetAllCustomer();
            column.ValueMember =
                "Id";
            column.DisplayMember =
                "Name";
        }
        void fill_combo_box_recreation_zone(DataGridViewComboBoxColumn column)
        {
            column.DataSource =
                db.GetAllRecreationAres();
            column.ValueMember =
                "Id";
            column.DisplayMember =
                "Name";
        }
        void fill_combo_box_bracelete_id(DataGridViewComboBoxColumn column)
        {
            column.DataSource =
                db.GetAllBracelet();
            column.ValueMember = column.DisplayMember =
                "Id";
        }
        private void ButtonSave(object sender, EventArgs e)
        {
        }
        private void button3_Click(object sender, EventArgs e)
        {
            dataGridView2.DataSource = reportService.ReportOrdersByMonth((int)comboBox1.SelectedValue);
        }
        private void button1_Click(object sender, EventArgs e)
        {
            dataGridView3.DataSource = reportService.ExecuteSP((int)numericUpDown1.Value, (int)numericUpDown2.Value);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            int ID_deleting = (int)numericUpDown3.Value;
            db.DeleteOperation(ID_deleting);
            dataGridView1.DataSource = db.GetAllOperations();
            dataGridView1.Refresh();
        }
        private void button4_Click(object sender, EventArgs e)
        {
            Form2 d = new Form2() { Text = "Добавление операции" };

            d.comboBox1.DataSource = db.GetAllRecreationAres();
            d.comboBox1.ValueMember = "Id";
            d.comboBox1.DisplayMember = "Name";

            d.comboBox2.DataSource = db.GetAllBracelet();
            d.comboBox2.ValueMember = d.comboBox2.DisplayMember = "Id";

            DialogResult result = d.ShowDialog(this);

            if (result == DialogResult.Cancel)
                return;


            OperationModel op = new OperationModel();
            op.sum = (int)d.numericUpDown1.Value;
            op.BraceletId = (int)d.comboBox2.SelectedValue;
            op.RecreationAreaId = (int)d.comboBox1.SelectedValue;
            op.Id = (int)d.numericUpDown2.Value;
            op.time = d.dateTimePicker1.Value;
            db.CreateOperation(op);
            dataGridView1.DataSource = db.GetAllOperations();
            dataGridView1.Refresh();

            MessageBox.Show("Новый объект добавлен");

        }
        private int getSelectedRow(DataGridView dataGridView)
        {
            int index = -1;
            if (dataGridView.SelectedRows.Count > 0 || dataGridView.SelectedCells.Count == 1)
            {
                if (dataGridView.SelectedRows.Count > 0)
                    index = dataGridView.SelectedRows[0].Index;
                else index = dataGridView.SelectedCells[0].RowIndex;
            }
            return index;
        }
        private void button6_Click(object sender, EventArgs e)
        {

            int index = getSelectedRow(dataGridView1);
            if (index == -1)
                return;

            int id = 0;
            bool converted = Int32.TryParse(dataGridView1[0, index].Value.ToString(), out id);
            if (converted == false)
                return;

            Form2 d = new Form2() { Text = "Обновление операции" };
            OperationModel op = db.GetAllOperations().First(i => i.Id == id);
            d.comboBox1.DataSource = db.GetAllRecreationAres();
            d.comboBox1.ValueMember = "Id";
            d.comboBox1.DisplayMember = "Name";
            d.comboBox1.SelectedValue = op.RecreationAreaId;

            d.comboBox2.DataSource = db.GetAllBracelet();
            d.comboBox2.ValueMember = d.comboBox2.DisplayMember = "Id";
            d.comboBox2.SelectedValue = op.BraceletId;

            d.numericUpDown1.Value = op.sum;
            d.numericUpDown2.Value = op.Id;
            d.dateTimePicker1.Value = op.time;

            DialogResult result = d.ShowDialog(this);

            if (result == DialogResult.Cancel)
                return;


            op.sum = (int)d.numericUpDown1.Value;
            op.BraceletId = (int)d.comboBox2.SelectedValue;
            op.RecreationAreaId = (int)d.comboBox1.SelectedValue;
            op.Id = (int)d.numericUpDown2.Value;
            op.time = d.dateTimePicker1.Value;
            db.UpdateOperation(op);
            dataGridView1.DataSource = db.GetAllOperations();
            dataGridView1.Refresh();

            MessageBox.Show("Объект обновлен");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form3 f = new Form3(db, braceletService);
            DialogResult result = f.ShowDialog(this);
            if (result == DialogResult.OK)
            {
                //AllBracelets = db.GetBracelets();
                dataGridView4.DataSource = db.GetAllBracelet();
                dataGridView4.Refresh();
            }
        }
    }
}
