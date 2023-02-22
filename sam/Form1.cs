using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Data.Sql;

namespace sam
{
    public partial class Form1 : Form
    {
        SqlConnection con;
        SqlDataAdapter da;
        DataSet ds;
        SqlCommand cmd;
        public Form1()
        {
            InitializeComponent();
        }



        private void Form1_Load(object sender, EventArgs e)
        {
            con = new SqlConnection(@"Data Source=.\sqlexpress;Initial Catalog=sam;Integrated Security=True");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                con.Open();
                cmd = new SqlCommand("insert into sam_table2 values('" + textBox1.Text.ToString() + "','" + textBox2.Text.ToString() + "','" + textBox3.Text.ToString() + "')", con);
                cmd.ExecuteNonQuery();

                MessageBox.Show("INSTERED");
            }

            catch (Exception error)
            {

                MessageBox.Show("FAILURE" + error.Message);
            }
            con.Close();
            con.Open();
            da = new SqlDataAdapter("select * from sam_table2", con);
            ds = new DataSet();
            da.Fill(ds);
            dataGridView1.DataSource = ds.Tables[0];
            con.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            con.Open();
            cmd = new SqlCommand("delete from sam_table2 where id='" + textBox1.Text.ToString() + "'", con);
            if (cmd.ExecuteNonQuery() != 0)
            {
                MessageBox.Show("DELETED");
            }
            else
            {
                MessageBox.Show("FAILURE");
            }
            con.Close();
            con.Open();
            da = new SqlDataAdapter("select * from sam_table2", con);
            ds = new DataSet();
            da.Fill(ds);
            dataGridView1.DataSource = ds.Tables[0];
            con.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            con.Open();
            cmd = new SqlCommand("update sam_table2 set name='" + textBox2.Text.ToString() + "' where id='" + textBox1.Text + "'", con);
            if (cmd.ExecuteNonQuery() != 0)
            {
                MessageBox.Show("UPDATED");
            }
            else
            {
                MessageBox.Show("FAILURE");
            }
            con.Close();
            con.Open();
            da = new SqlDataAdapter("select * from sam_table2", con);
            ds = new DataSet();
            da.Fill(ds);
            dataGridView1.DataSource = ds.Tables[0];
            con.Close();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            con.Open();
            da = new SqlDataAdapter("select * from sam_table2 where id='" + textBox1.Text.ToString() + "'", con);
            ds = new DataSet();
            da.Fill(ds);
            if (ds.Tables[0].Rows.Count != 0)
            {
                textBox2.Text = ds.Tables[0].Rows[0].ItemArray[1].ToString();
                textBox3.Text = ds.Tables[0].Rows[0].ItemArray[2].ToString();
            }
            else
            {
                MessageBox.Show("NOT FOUND");
            }
            con.Close();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            textBox2.Clear();
            textBox3.Clear();
        }

    }
}

     

