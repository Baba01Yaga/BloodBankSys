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
    public partial class Form7 : Form
    {
        public static Form7 instance;
        SqlConnection conn = new SqlConnection(@"Data Source=DESKTOP-J6UELL7;Initial Catalog=bloodBankSystem;Integrated Security=True");

        public Form7()
        {
            InitializeComponent();
            instance = this;
            conn.Open();
            string querry1 = $"select count(is_avalible) as stock from donation where bloodType_id=1 and is_avalible=1";
            SqlCommand cmd1 = new SqlCommand(querry1, conn);
            cmd1.ExecuteNonQuery();
            using (SqlDataReader reader1 = cmd1.ExecuteReader())
            {
                if (reader1.Read())
                {
                    label2.Text = " " + reader1["stock"];

                }

            }
            
            string querry2 = $"select count(is_avalible) as stock from donation where bloodType_id=2 and is_avalible=1";
            SqlCommand cmd2 = new SqlCommand(querry2, conn);
            cmd2.ExecuteNonQuery();
            using (SqlDataReader reader2 = cmd2.ExecuteReader())
            {
                if (reader2.Read())
                {
                    label4.Text = " " + reader2["stock"];

                }

            }
            string querry3 = $"select count(is_avalible) as stock from donation where bloodType_id=3 and is_avalible=1";
            SqlCommand cmd3 = new SqlCommand(querry3, conn);
            cmd3.ExecuteNonQuery();
            using (SqlDataReader reader3 = cmd3.ExecuteReader())
            {
                if (reader3.Read())
                {
                    label6.Text = " " + reader3["stock"];

                }

            }
            string querry4 = $"select count(is_avalible) as stock from donation where bloodType_id=4 and is_avalible=1";
            SqlCommand cmd4 = new SqlCommand(querry4, conn);
            cmd4.ExecuteNonQuery();
            using (SqlDataReader reader4 = cmd4.ExecuteReader())
            {
                if (reader4.Read())
                {
                    label8.Text = " " + reader4["stock"];

                }

            }
            string querry5 = $"select count(is_avalible) as stock from donation where bloodType_id=5 and is_avalible=1";
            SqlCommand cmd5 = new SqlCommand(querry5, conn);
            cmd5.ExecuteNonQuery();
            using (SqlDataReader reader5 = cmd5.ExecuteReader())
            {
                if (reader5.Read())
                {
                    label10.Text = " " + reader5["stock"];

                }

            }
            string querry6 = $"select count(is_avalible) as stock from donation where bloodType_id=6 and is_avalible=1";
            SqlCommand cmd6 = new SqlCommand(querry6, conn);
            cmd6.ExecuteNonQuery();
            using (SqlDataReader reader6 = cmd6.ExecuteReader())
            {
                if (reader6.Read())
                {
                    label12.Text = " " + reader6["stock"];

                }

            }
            string querry7 = $"select count(is_avalible) as stock from donation where bloodType_id=7 and is_avalible=1";
            SqlCommand cmd7 = new SqlCommand(querry7, conn);
            cmd7.ExecuteNonQuery();
            using (SqlDataReader reader7 = cmd7.ExecuteReader())
            {
                if (reader7.Read())
                {
                    label14.Text = " " + reader7["stock"];

                }

            }
            string querry8 = $"select count(is_avalible) as stock from donation where bloodType_id=8 and is_avalible=1";
            SqlCommand cmd8 = new SqlCommand(querry8, conn);
            cmd8.ExecuteNonQuery();
            using (SqlDataReader reader8 = cmd8.ExecuteReader())
            {
                if (reader8.Read())
                {
                    label16.Text = " " + reader8["stock"];

                }

            }
            conn.Close();
        }

        private void label12_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void label13_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form9 second = new Form9();
            second.Show();
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form8 second = new Form8();
            second.Show();
            this.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Form10 second = new Form10();
            second.Show();
            this.Hide();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            Form1 second = new Form1();
            second.Show();
            this.Hide();

        }
    }
}
