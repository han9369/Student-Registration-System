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
    public partial class Form_report : Form
    {
        public string s_IA;

        public Form_report()
        {
            InitializeComponent();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                string sConnectionString = "data source=cypress.csil.sfu.ca;" + "initial catalog=hga13354;" + "Trusted_Connection=yes;";
                SqlConnection objConn = new SqlConnection(sConnectionString);
                objConn.Open();

                String sql = "delete from dbo.Taken_course where c_ID='" + Convert.ToInt32(listView1.SelectedItems[0].SubItems[0].Text.ToString()) + "'  ";
                SqlCommand cmd = new SqlCommand(sql, objConn);

                cmd.ExecuteNonQuery();
                objConn.Close();
                MessageBox.Show("Successful");
                this.button3_Click(this.button3, e);
            }

            catch { MessageBox.Show("Please select a course"); }
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            
            
        }

        private void button3_Click(object sender, EventArgs e)
        {

            string sConnectionString = "data source=cypress.csil.sfu.ca;" + "initial catalog=hga13354;" + "Trusted_Connection=yes;";
            SqlConnection objConn = new SqlConnection(sConnectionString);
            objConn.Open();

            String sql = "select * from dbo.Course c, dbo.Taken_course t where c.c_ID = t.c_ID ";
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

        private void button4_Click(object sender, EventArgs e)
        {
            Form_search f2 = new Form_search();
            f2.s_IS = s_IA;
            this.Hide();
            f2.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            MessageBox.Show("GoodBye!");
            this.Hide();
        }
    }
}
