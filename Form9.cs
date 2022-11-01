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
    public partial class Form9 : Form
    {
        public static Form9 instance;
        SqlConnection conn = new SqlConnection(@"Data Source=DESKTOP-J6UELL7;Initial Catalog=bloodBankSystem;Integrated Security=True");
        SqlDataAdapter sda;
        string querry2;
       
        DataTable dtable;
        string us = Form1.instance.tb1.Text;
        string pw = Form1.instance.tb2.Text;

        public Form9()
        {
            InitializeComponent();
            instance = this;
            conn.Open();
            sda = new SqlDataAdapter($"select * from reservation", conn);
            dtable = new DataTable();
            sda.Fill(dtable);
            dataGridView1.DataSource = dtable;
            conn.Close();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            Form7 z = new Form7();

            this.Hide();
            z.ShowDialog();
            this.Close();
        }

        private void Form9_Load(object sender, EventArgs e)
        {

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
            conn.Open();
            string querry1 = $"select doner_id from reservation";
            SqlCommand cmd1 = new SqlCommand(querry1, conn);
            using (SqlDataReader reader1 = cmd1.ExecuteReader())
            {

                if (reader1.Read())
                {

                    
                    querry2 = $"insert into donation (doner_id,donationDate,is_avalible) values " +
              $"({reader1["doner_id"]},'{comboBox3.SelectedItem}/{comboBox2.SelectedItem}/{comboBox1.SelectedItem}',1)";

                }


            }

            
            SqlCommand cmd2 = new SqlCommand(querry2, conn);
            cmd2.ExecuteNonQuery();

            int selectedrow = dataGridView1.CurrentCell.RowIndex;
           dataGridView1.Rows.RemoveAt(selectedrow);
           SqlCommandBuilder scb1 = new SqlCommandBuilder(sda);
           sda.Update(dtable);
           conn.Close();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
