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
    public partial class Form4 : Form
    {
        public static Form4 instance;
        SqlConnection conn = new SqlConnection(@"Data Source=DESKTOP-J6UELL7;Initial Catalog=bloodBankSystem;Integrated Security=True");
        public Form4()
        {
            string us = Form1.instance.tb1.Text;
            string pw = Form1.instance.tb2.Text;
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
                    label3.Text = "Address : " + reader["address"].ToString();
                    label5.Text = "Phone Number : " + reader["phone"].ToString();

                }
            }
            string querry1 = $"SELECT dbo.GetAge(Birthdate) as age from Doner " +
                $"where username='" + us + "' and password='" + pw + "'";
            SqlCommand cmd1 = new SqlCommand(querry1, conn);
            cmd1.ExecuteNonQuery();
            using (SqlDataReader reader1 = cmd1.ExecuteReader())
            {
                if (reader1.Read())
                {
                    label4.Text = "Age : " + reader1["age"];

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


            conn.Close();
        }

        private void Form4_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            //object f3b1 =Form3.instance.b1;

            (this.Owner as Form3).b1.Enabled = false;
            this.Hide();
            
        }
    }
}
