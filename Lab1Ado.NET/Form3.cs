using BLL;
using BLL.Interfaces;
using BLL.Models;
using BLL.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab1Ado.NET
{
    public partial class Form3 : Form
    {
        IDbCrud db;
        IBraceletService service;
        public Form3(IDbCrud db, IBraceletService service)
        {
            InitializeComponent();
            this.service = service;
            this.db = db;
            comboBox1.DataSource = db.GetAllCustomer();
            comboBox1.ValueMember = "Id";
            comboBox1.DisplayMember = "Name";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            BraceletModel br = new BraceletModel();
            br.CustomerId = (int)comboBox1.SelectedValue;
            br.Id = (int)numericUpDown1.Value;
            br.Deposit = (int)numericUpDown2.Value;

            service.GiveBracelet(br);
            MessageBox.Show("Success");
        }
    }
}
