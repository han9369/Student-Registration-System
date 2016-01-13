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
using System.Data.OleDb;


namespace A3
{
    public partial class Form_login : Form
    {
        public Form_login()
        {
            InitializeComponent();
        }


        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                string sConnectionString = "data source=cypress.csil.sfu.ca;" + "initial catalog=hga13354;" + "Trusted_Connection=yes;";
                SqlConnection objConn = new SqlConnection(sConnectionString);
                objConn.Open();

                SqlCommand cmd = new SqlCommand("select s_ID, s_pw from dbo.Student where s_ID= '" + textBox1.Text + "'  and s_pw= '" + textBox2.Text + "' ", objConn);
                SqlDataReader sdr = cmd.ExecuteReader();
                sdr.Read();

                if (sdr.HasRows)
                { 
                    Form_search f2 = new Form_search();
                    f2.s_IS = textBox1.Text.ToString();
                    this.Hide();
                    f2.Show();
                    objConn.Close();
                    objConn.Dispose();
                }
                else
                {
                    MessageBox.Show("Incorrect Student ID or Password");
                    objConn.Close();
                    objConn.Dispose();
                }
                objConn.Close();
                objConn.Dispose();
            }
            catch (SqlException sqlEx) { MessageBox.Show("SQL Server Error Message:" + sqlEx.Message); }
           
        }
            
        
    
        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                string sConnectionString = "data source=cypress.csil.sfu.ca;" + "initial catalog=hga13354;" + "Trusted_Connection=yes;";
                SqlConnection objConn = new SqlConnection(sConnectionString);
                objConn.Open();

                SqlCommand cmd = new SqlCommand("select s_ID, s_pw from dbo.Student where s_ID= '" + textBox1.Text + "'  and s_pw= '" + textBox2.Text + "' ", objConn);
                SqlDataReader sdr = cmd.ExecuteReader();
                sdr.Read();

                if (sdr.HasRows)
                { 
                    Form_report f3 = new Form_report();
                    f3.s_IA = textBox1.Text.ToString();
                    this.Hide();
                    f3.Show();
                    objConn.Close();
                    objConn.Dispose();
                }
                else
                {
                    MessageBox.Show("Incorrect Student ID or Password");
                    objConn.Close();
                    objConn.Dispose();
                }
                objConn.Close();
                objConn.Dispose();
            }
            catch (SqlException sqlEx) { MessageBox.Show("SQL Server Error Message:" + sqlEx.Message); }
           
        }

        }
        
       
    }


