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
    public partial class Form10 : Form
    {
        public static Form10 instance;
        SqlConnection conn = new SqlConnection(@"Data Source=DESKTOP-J6UELL7;Initial Catalog=bloodBankSystem;Integrated Security=True");
        SqlDataAdapter sda;
        DataTable dtable;
        SqlDataAdapter sda1;
        DataTable dtable1;
        SqlDataAdapter sda2;
        DataTable dtable2;
        public Form10()
        {
            InitializeComponent();
            instance = this;
            conn.Open();
            sda = new SqlDataAdapter($"select * from Doner", conn);
            dtable = new DataTable();
            sda.Fill(dtable);
            dataGridView1.DataSource = dtable;

            sda1 = new SqlDataAdapter($"select * from donation", conn);
            dtable1 = new DataTable();
            sda1.Fill(dtable1);
            dataGridView2.DataSource = dtable1;

            sda2 = new SqlDataAdapter($"select * from hospital", conn);
            dtable2 = new DataTable();
            sda2.Fill(dtable2);
            dataGridView3.DataSource = dtable2;
            conn.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
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

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            Form7 z = new Form7();

            this.Hide();
            z.ShowDialog();
            this.Close();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            int selectedrow = dataGridView2.CurrentCell.RowIndex;
            dataGridView2.Rows.RemoveAt(selectedrow);
            SqlCommandBuilder scb1 = new SqlCommandBuilder(sda1);
            sda1.Update(dtable1);
        }

        private void button8_Click(object sender, EventArgs e)
        {
            SqlCommandBuilder scb = new SqlCommandBuilder(sda1);
            sda1.Update(dtable1);
        }

        private void button7_Click(object sender, EventArgs e)
        {
            int selectedrow = dataGridView3.CurrentCell.RowIndex;
            dataGridView3.Rows.RemoveAt(selectedrow);
            SqlCommandBuilder scb1 = new SqlCommandBuilder(sda2);
            sda2.Update(dtable2);
        }

        private void button6_Click(object sender, EventArgs e)
        {
            SqlCommandBuilder scb = new SqlCommandBuilder(sda2);
            sda2.Update(dtable2);
        }
    }
}
