using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;




namespace WindowsFormsApp3
{
    public partial class Form8 : Form
    {
        public static Form8 instance;
        SqlConnection conn = new SqlConnection(@"Data Source=DESKTOP-J6UELL7;Initial Catalog=bloodBankSystem;Integrated Security=True");
        string us = Form1.instance.tb1.Text;
        string pw = Form1.instance.tb2.Text;
        SqlDataAdapter sda;
        DataTable dtable;
        public Form8()
        {
            InitializeComponent();
            instance = this;
            conn.Open();
            sda = new SqlDataAdapter("select * from orders", conn);
            dtable = new DataTable();
            sda.Fill(dtable);
            dataGridView1.DataSource = dtable;




            conn.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            /*dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.MultiSelect = true;
            DataGridViewSelectedRowCollection DataGridView = selected
            dataGridView1.Rows.RemoveAt();
            dataGridView1.s*/
            int selectedrow = dataGridView1.CurrentCell.RowIndex;
            dataGridView1.Rows.RemoveAt(selectedrow);
            SqlCommandBuilder scb1 = new SqlCommandBuilder(sda);
            sda.Update(dtable);
        }


        private void button2_Click(object sender, EventArgs e)
        {
            SqlCommandBuilder scb = new SqlCommandBuilder(sda);
            sda.Update(dtable);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Form7 z = new Form7();

            this.Hide();
            z.ShowDialog();
            this.Close();
        }
    }
}
