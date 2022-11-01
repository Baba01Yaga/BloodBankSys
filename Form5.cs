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
    public partial class Form5 : Form
    {
        public static Form5 instance;
        SqlConnection conn = new SqlConnection(@"Data Source=DESKTOP-J6UELL7;Initial Catalog=bloodBankSystem;Integrated Security=True");
        string us = Form1.instance.tb1.Text;
        string pw = Form1.instance.tb2.Text;
        public static string selection = "";
        public TextBox quantity;
        
        public Form5()
        {
            InitializeComponent();
            instance = this;
            quantity = textBox1;
            
            
            string querry = "select name,address,phone from Hospital where name='" + us + "' and password ='" + pw + "'";
            conn.Open();
            SqlCommand cmd = new SqlCommand(querry, conn);
            cmd.ExecuteNonQuery();
            using (SqlDataReader reader = cmd.ExecuteReader())
            {
                if (reader.Read())
                {
                    label2.Text = "Name : " + reader["name"].ToString();
                    label3.Text = "Address : " + reader["address"].ToString();
                    label4.Text = "Phone Number : " + reader["phone"].ToString();
                }
            }
            SqlDataAdapter sda = new SqlDataAdapter($"select * from orders where hospital_id= dbo.hospital_id('{us}','{pw}')", conn);
            DataTable dtable = new DataTable();
            sda.Fill(dtable);
            dataGridView1.DataSource = dtable;
            conn.Close();
        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void Form5_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form1 a = new Form1();

            this.Hide();
            a.ShowDialog();
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            instance = this;
            string querry = $"insert into orders (hospital_id,quantity,bloodType_id,orderState_id) values" +
                $"(dbo.hospital_id('{us}','{pw}'),{textBox1.Text},@bloodty,2)";

            conn.Open();
            SqlCommand cmd = new SqlCommand(querry, conn);
            cmd.Parameters.AddWithValue("bloodty",comboBox1.SelectedIndex > -1 ? comboBox1.SelectedIndex + 1 : (object)DBNull.Value);

            cmd.ExecuteNonQuery();
            //MessageBox.Show("Your Order Has Been Requested. ");
            Form6 second = new Form6();
            second.Owner = this;
            second.Show();
            conn.Close();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            selection = comboBox1.SelectedItem.ToString();
        }
    }
}
