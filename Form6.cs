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
    public partial class Form6 : Form
    {
        public static Form6 instance;
        SqlConnection conn = new SqlConnection(@"Data Source=DESKTOP-J6UELL7;Initial Catalog=bloodBankSystem;Integrated Security=True");

        public Form6()
        {
            InitializeComponent();
            instance = this;
            string us = Form1.instance.tb1.Text;
            string pw = Form1.instance.tb2.Text;
            string qu = Form5.instance.quantity.Text;
            string querry = $"select name,address,phone from hospital where name = '{us}' and password = '{pw}'";
            conn.Open();
            SqlCommand cmd = new SqlCommand(querry, conn);
            cmd.ExecuteNonQuery();

            using (SqlDataReader reader = cmd.ExecuteReader())
            {
                if (reader.Read())
                {
                    label2.Text = "Hospital Name : " + reader["name"].ToString();
                    label3.Text = "Address : " + reader["address"].ToString();
                    label4.Text = "Phone Number : " + reader["phone"].ToString();

                }
            }
            label5.Text = "Quantity : " + qu;
            label6.Text = "Blood Type : " + Form5.selection;
        }

        private void Form6_Load(object sender, EventArgs e)
        {
            
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();

        }
    }
}
