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
    public partial class Form1 : Form
    {
        public static Form1 instance;
        public TextBox tb1,tb2;
        public Form1()
        {
            InitializeComponent();
            instance = this;
            tb1 = textBox1;
            tb2 = textBox2;

        }
        SqlConnection conn = new SqlConnection(@"Data Source=DESKTOP-J6UELL7;Initial Catalog=bloodBankSystem;Integrated Security=True");


        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Form11 second = new Form11();
            second.Show();
            this.Hide();

        }


        private void button2_Click_1(object sender, EventArgs e)
        {
            Form2 second = new Form2();
            second.Show();
            this.Hide();

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string Username, Password;
            Username = textBox1.Text;
            Password = textBox2.Text;
            if (radioButton2.Checked)
            {


                try
                {
                    string querry = "select * from Hospital WHERE name = '" + textBox1.Text + "' AND password ='" + textBox2.Text + "'";
                    SqlDataAdapter sda = new SqlDataAdapter(querry, conn);
                    DataTable dtable = new DataTable();
                    sda.Fill(dtable);
                    if (dtable.Rows.Count > 0)
                    {
                        Username = textBox1.Text;
                        Password = textBox2.Text;

                        Form5 second = new Form5();
                        second.Show();
                        this.Hide();

                    }
                    else
                    {
                        MessageBox.Show("invalid details");
                        textBox1.Focus();
                    }
                }
                catch
                {
                    MessageBox.Show("Error");
                }
                finally
                {
                    conn.Close();
                }

            }
            else if (radioButton1.Checked)
            {
                try
                {
                    string querry = "select * from Doner WHERE username = '" + textBox1.Text + "' AND password ='" + textBox2.Text + "'";
                    SqlDataAdapter sda = new SqlDataAdapter(querry, conn);
                    DataTable dtable = new DataTable();
                    sda.Fill(dtable);
                    if (dtable.Rows.Count > 0)
                    {
                        Username = textBox1.Text;
                        Password = textBox2.Text;

                        Form3 second = new Form3();
                        second.Show();
                        this.Hide();

                    }
                    else
                    {
                        MessageBox.Show("invalid details");
                        textBox1.Focus();
                    }
                }
                catch
                {
                    MessageBox.Show("Error");
                }
                finally
                {
                    conn.Close();
                }
            }
            else
            {
                MessageBox.Show("Type of user needed");
            }
            conn.Close();

        }
    }
}
