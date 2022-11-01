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
    public partial class Form3 : Form

    {
        public static Form3 instance;
        public Button b1;
        SqlConnection conn = new SqlConnection(@"Data Source=DESKTOP-J6UELL7;Initial Catalog=bloodBankSystem;Integrated Security=True");
        string us = Form1.instance.tb1.Text;
        string pw = Form1.instance.tb2.Text;

        public Form3()
        {
            
            InitializeComponent();
            instance = this;
            string querry = "select name,address,phone from Doner where username='" + us + "' and password ='" + pw + "'";
            conn.Open();
            SqlCommand cmd = new SqlCommand(querry, conn);
            cmd.ExecuteNonQuery();

            using (SqlDataReader reader = cmd.ExecuteReader())
            {
                if (reader.Read())
                {
                    label2.Text = "Name : " + reader["name"].ToString();
                    label5.Text = "Address : " + reader["address"].ToString();
                    label6.Text = "Phone Number : " + reader["phone"].ToString();

                }
            }
            string querry1 = $"SELECT dbo.GetAge(Birthdate) as age from Doner where username='" + us + "' and password='" + pw + "'";
            SqlCommand cmd1 = new SqlCommand(querry1, conn);
            cmd1.ExecuteNonQuery();
            using (SqlDataReader reader1 = cmd1.ExecuteReader())
            {
                if (reader1.Read())
                {
                    label3.Text = "Age : " + reader1["age"];

                }

            }
            string querry2 = "select b.bloodTypeName from bloodType as b inner join Doner as d on b.id =d.bloodType_id " +
                "where d.username='" + us + "' and d.password='" + pw + "'";
            SqlCommand cmd2 = new SqlCommand(querry2, conn);
            cmd2.ExecuteNonQuery();
            using (SqlDataReader reader2 = cmd2.ExecuteReader())
            {
                if (reader2.Read())
                {
                    label7.Text = reader2["bloodTypeName"].ToString();
                }

            }
            SqlDataAdapter sda = new SqlDataAdapter($"select id,doner_id,bloodType_id,donationDate from donation " +
                $"where doner_id= dbo.doner_id('{us}','{pw}')", conn);
            DataTable dtable = new DataTable();
            sda.Fill(dtable);
            dataGridView1.DataSource = dtable;


            conn.Close();
        }

        private void label3_Click(object sender, EventArgs e)
        {
           
           
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {

            Form1 second = new Form1();
            second.Show();
            this.Hide();
        }
        
        private void button1_Click(object sender, EventArgs e)
        {
            conn.Open();
            string querry1 = $"insert into reservation (doner_id) values(dbo.doner_id('{us}','{pw}'))";
            SqlCommand cmd1 = new SqlCommand(querry1, conn);
            cmd1.ExecuteNonQuery();
            b1 = button1;
            Form4 second = new Form4();
            second.Owner= this;
            second.Show();
            conn.Close();
        }

        private void label1_Click(object sender, EventArgs e)
        {
           
            
        }
    }
}
