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
    public partial class Form_search : Form
    {
        public string s_IS;

        public Form_search()
        {
            InitializeComponent();
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            
            
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void comboBox2_SelectedIndexChanged_1(object sender, EventArgs e)
        {

        }



        private void button2_Click(object sender, EventArgs e)
        {
            bool a = comboBox3.Text.Trim() == "greater than or equal to";
            bool b = comboBox3.Text.Trim() == "less than or equal to";


            string sConnectionString = "data source=cypress.csil.sfu.ca;" + "initial catalog=hga13354;" + "Trusted_Connection=yes;";
            SqlConnection objConn = new SqlConnection(sConnectionString);
            objConn.Open();
           
            String sql = "select * from dbo.Course where c_department= '" + comboBox1.Text + "'  and c_number= '" + textBox1.Text + "' ";

            if (a){
                sql = "select * from dbo.Course where c_department= '" + comboBox1.Text + "'  and c_number >= '" + Convert.ToInt32(textBox1.Text) + "' ";
            }

            if (b) {
                sql = "select * from dbo.Course where c_department= '" + comboBox1.Text + "'  and c_number <= '" + Convert.ToInt32(textBox1.Text) + "' ";
            }

            SqlCommand cmd = new SqlCommand(sql, objConn);
            SqlDataReader sdr = cmd.ExecuteReader();
            
            this.listView1.Clear();
            this.listView1.View = System.Windows.Forms.View.Details;
            listView1.FullRowSelect = true;
            listView1.Scrollable = true;

            this.listView1.Columns.Clear();
            this.listView1.Columns.Add("ID", 30, HorizontalAlignment.Left);
            this.listView1.Columns.Add("Course Name", 100, HorizontalAlignment.Left);
            this.listView1.Columns.Add("Credit", 80, HorizontalAlignment.Left);
            this.listView1.Columns.Add("Capacity", 120, HorizontalAlignment.Left);


            if (!sdr.HasRows){
                MessageBox.Show("No such courses");
                    
             }
            while (sdr.Read())
            {
                ListViewItem Item = new ListViewItem();
                Item.SubItems.Clear();
                Item.SubItems[0].Text = sdr["c_ID"].ToString();
                Item.SubItems.Add(sdr["c_name"].ToString());
                Item.SubItems.Add(sdr["c_credit"].ToString());
                Item.SubItems.Add(sdr["c_capacity"].ToString());
                listView1.Items.Add(Item);
            }
            sdr.Close();
            objConn.Close();
            objConn.Dispose();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            comboBox2.Text = null;
            comboBox1.Text = null;
            comboBox3.Text = null;
            textBox1.Text = null; 
        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void button3_Click(object sender, EventArgs e)
        { 
               try
               {

                    string sConnectionString = "data source=cypress.csil.sfu.ca;" + "initial catalog=hga13354;" + "Trusted_Connection=yes;";
                    SqlConnection objConn = new SqlConnection(sConnectionString);
                    objConn.Open();

                    String sql2 = "select * from hga13354.dbo.Student where s_ID = '" +  s_IS + "' ";
                    SqlCommand cmd2 = new SqlCommand(sql2, objConn);
                    SqlDataReader sdr2 = cmd2.ExecuteReader();
                    sdr2.Read();

                    bool c = Convert.ToDouble(sdr2["s_gpa"].ToString()) <= 2.25;

                    if (c)
                    {
                        MessageBox.Show("Your GPA is below 2.25, please contact advisor!");
                        objConn.Close();
                        objConn.Dispose();
                    }
                    else
                    {
                        sdr2.Close();
                        String sql = "Insert into dbo.Taken_course values (1, '" + Convert.ToInt32(listView1.SelectedItems[0].SubItems[0].Text.ToString()) + "' ) ";
                        SqlCommand cmd = new SqlCommand(sql, objConn);
                        cmd.ExecuteNonQuery();

                        MessageBox.Show("Successful");
                        objConn.Close();
                        objConn.Dispose();
                   }
                    sdr2.Close();
                    objConn.Close();
                    objConn.Dispose();
               }

               catch { MessageBox.Show("You already enrolled in this course, please search for other courses!"); }   
        }

        private void button4_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Are you sure?");
            Form_report f3 = new Form_report();
            f3.s_IA = s_IS;
            this.Hide();
            f3.Show();
        }
    }
}
