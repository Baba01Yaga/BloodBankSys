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
    public partial class Form2 : Form
    {
        SqlConnection conn = new SqlConnection(@"Data Source=DESKTOP-J6UELL7;Initial Catalog=bloodBankSystem;Integrated Security=True");
        
        public Form2()
        {
            

            InitializeComponent();
            groupBox2.Hide();
            groupBox1.Hide();
            button1.Show();
            button2.Show();
            button3.Hide();
            button4.Hide();
            button6.Hide();
            button7.Hide();
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            groupBox2.Show();
            groupBox1.Hide();
            button1.Hide();
            button2.Hide();
            button3.Hide();
            button4.Hide();
            button6.Show();
            button7.Show();
            
        }

        private void button3_Click(object sender, EventArgs e)
        {
            groupBox2.Hide();
            groupBox1.Hide();
            button1.Show();
            button2.Show();
            button3.Hide();
            button4.Hide();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            groupBox2.Hide();
            groupBox1.Show();
            button1.Hide();
            button2.Hide();
            button3.Show();
            button4.Show();
            button6.Hide();
            button7.Hide();
        }

        private void button5_Click(object sender, EventArgs e)
        { 

            Form1 a = new Form1();

            this.Hide();
            a.ShowDialog();
            this.Close();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            
            int chars = textBox9.Text.Length;
            try
            {
                if (!(textBox6.Text == "" || textBox7.Text == "" || textBox8.Text == "" || textBox9.Text == ""))
                {
                    
                    SqlDataAdapter sda = new SqlDataAdapter($"select name from Hospital where name='{textBox6.Text}'", conn);
                    DataTable dt = new DataTable();
                    sda.Fill(dt);
                    if (dt.Rows.Count >= 1)
                    {
                        MessageBox.Show("Name is already taken");
                    }
                    else
                    {
                        if (chars < 8)
                        {
                            MessageBox.Show("password must have a least 8 characters");
                        }
                        else
                        {
                            string querry = "insert into Hospital (name,address,phone,password) values " +
                                "( '" + textBox6.Text + "' ,'" + textBox7.Text + "' ,'" + textBox8.Text + "' ,'" + textBox9.Text + "' )";
                            conn.Open();
                            SqlCommand cmd = new SqlCommand(querry, conn);
                            cmd.ExecuteNonQuery();
                            MessageBox.Show("Successfuly Inserted!");
                            Form1 second = new Form1();
                            second.Show();
                            this.Hide();
                        }
                    }

                    
                    
                }
                else
                {
                    MessageBox.Show("invalid details");
                    textBox6.Focus();
                }



            }
            catch
            {
                MessageBox.Show("Error");
                textBox6.Focus();

            }
            finally
            {
                
              
                conn.Close();
            }


        }

        private void button6_Click(object sender, EventArgs e)
        {
            groupBox2.Hide();
            groupBox1.Hide();
            button1.Show();
            button2.Show();
            button6.Hide();
            button7.Hide();

        }

        private void button4_Click(object sender, EventArgs e)
        {
            int chars = textBox5.Text.Length;
            try
            {
                if (!(textBox1.Text == "" || textBox2.Text == "" || textBox3.Text == "" || textBox4.Text == "" || textBox5.Text == "" || comboBox1.SelectedItem == "" || comboBox2.SelectedItem == "" || comboBox3.SelectedItem == ""))
                {
                    SqlDataAdapter sda = new SqlDataAdapter($"select username from Doner where username='{textBox4.Text}'", conn);
                    DataTable dt = new DataTable();
                    sda.Fill(dt);
                    if (dt.Rows.Count >= 1)
                    {
                        MessageBox.Show("Username is already taken");
                    }
                    else
                    {
                        if (chars < 8)
                        {
                            MessageBox.Show("password must have a least 8 characters");
                        }
                        else
                        {
                            var date = $"'{comboBox3.SelectedItem}/{comboBox2.SelectedItem}/{comboBox1.SelectedItem}'";
                            string querry = "insert into Doner (name,address,phone,birthdate,username,password,bloodtype_id) " +
                                $"values ( '{textBox1.Text}' ,'{ textBox2.Text }' ,'{ textBox3.Text }' ,{date}" +
                                " ,'" + textBox4.Text + "' ,'" + textBox5.Text + "',@bloodty )";
                            conn.Open();

                            SqlCommand cmd = new SqlCommand(querry, conn);
                            cmd.Parameters.AddWithValue("bloodty", bloodTypeBox.SelectedIndex > -1 ? bloodTypeBox.SelectedIndex + 1 : (object)DBNull.Value);
                            cmd.ExecuteNonQuery();
                            MessageBox.Show("Successfuly Inserted!");
                            Form1 second = new Form1();
                            second.Show();
                            this.Hide();
                        }
                    }

                    
                    
                }


                else
                {
                    MessageBox.Show("invalid details");
                    textBox1.Focus();
                }

                

            }
            catch(Exception d)
            {
                MessageBox.Show(d.ToString());
                textBox1.Focus();

            }
            finally
            {
              
                conn.Close();
            }

        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }
    }
}
