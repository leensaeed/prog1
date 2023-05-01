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

namespace prog1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            LoadData();
        }
        tccEntities db;
        Exam add;
        int id1;

        //public string constring = " metadata=res://*/Model1.csdl|res://*/Model1.ssdl|res://*/Model1.msl;provider=System.Data.SqlClient;provider connection string=data source=AYA_HAMMODA\\SQLEXPRESS01;initial catalog=tcc;integrated security=True;MultipleActiveResultSets=True;App=EntityFramework";
        // SqlConnection con = new SqlConnection(@"Data Source=AYA_HAMMODA\SQLEXPRESS01;Initial Catalog=tcc;Integrated Security=True");
        private void label1_Click(object sender, EventArgs e)
        {

        }
        private void label2_Click(object sender, EventArgs e)
        {

        }
        private void label2_Click_1(object sender, EventArgs e)
        {

        }
        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
        //    SqlConnection con = new SqlConnection();
        //    con.ConnectionString = @" Data Source=AYA_HAMMODA\SQLEXPRESS01;Initial Catalog=tcc;Integrated Security=True";
        //    con.Open();
        //    MessageBox.Show(con.State.ToString());
        //    con.Close();
        //    MessageBox.Show(con.State.ToString());
            //if (con.State == System.Data.ConnectionState.Open)
            //{
            //    string q = " insert into Test (id,name)values('" + txtid.Text.ToString() + "','"
            //         + txtDate.Text.ToString() + "','" + txtSubjectId.Text.ToString() + "','"
            //         + txtTerm.Text.ToString() + "')";
            //    SqlCommand cm = new SqlCommand(q, con);
            //    cm.ExecuteNonQuery();
            //    MessageBox.Show("conniction made successfuly..!");
        }

    
        private void button3_Click(object sender, EventArgs e)
       {
            try
            {
                db = new tccEntities();
                add = new Exam();
                add.id = id1;
                db.Entry(add).State = System.Data.Entity.EntityState.Deleted;
                db.SaveChanges();
                LoadData();
                MessageBox.Show("successfully Delet");
            }
            catch
            {
                MessageBox.Show("can not add delet");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                db = new tccEntities();
                add = new Exam();
                add.subjectid = int.Parse(txtSubjectId.Text);
                add.term =Convert.ToInt16(txtTerm.Text);
                DateTime d =  new DateTime(int.Parse( txtDate.Text));
                add.date = d;
                add.id = int.Parse(txtid.Text);
                db.Entry(add).State=System.Data.Entity.EntityState.Added;
                db.SaveChanges();
                LoadData();
                MessageBox.Show("successfully Add");
            }
            catch
            {
                MessageBox.Show("can not add data");
            }
            //string sql = " insert into Exams values(@id,@subjectid,@date,@term)";
            //con.Open();
            //SqlCommand cmd = new SqlCommand(sql, con);
            //cmd.Parameters.AddWithValue("@id", txtid.Text.ToString());
            //cmd.Parameters.AddWithValue("@date", txtDate.Text.ToString());
            //cmd.Parameters.AddWithValue("@subjectid", txtSubjectId.Text.ToString());
            //cmd.Parameters.AddWithValue("@term", txtTerm.Text.ToString());

            //cmd.ExecuteNonQuery();
            //con.Close();
            //MessageBox.Show("conniction made successfuly..!");
        }

        private void button4_Click(object sender, EventArgs e)
        {

            try
            {
                db = new tccEntities();
                add = new Exam();
                add.id = id1;
                add.subjectid = int.Parse(txtSubjectId.Text);
                add.term = Convert.ToInt16(txtTerm.Text);
                DateTime d = new DateTime(int.Parse(txtDate.Text));
                add.date = d;
                add.id = int.Parse(txtid.Text);
                db.Entry(add).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
                LoadData();
                MessageBox.Show("successfully Edit");
            }
            catch
            {
                MessageBox.Show("can not add data");
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
        }
        private void LoadData()
        {
            try
            {
                db = new tccEntities();
                dataGridView1.DataSource = db.Exams.ToList();
            }
            catch
            {

            }
           
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                id1 = Convert.ToInt16(dataGridView1.CurrentRow.Cells[0].Value);
                txtDate.Text = Convert.ToString(dataGridView1.CurrentRow.Cells[1].Value);
                txtid.Text = Convert.ToString(dataGridView1.CurrentRow.Cells[2].Value);
                txtSubjectId.Text = Convert.ToString(dataGridView1.CurrentRow.Cells[3].Value);
                txtTerm.Text = Convert.ToString(dataGridView1.CurrentRow.Cells[4].Value);
            }
            catch
            {

            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {

            try
            {
                id1 = Convert.ToInt16(dataGridView1.CurrentRow.Cells[0].Value);
            }
            catch { }
           
        }
    }
    }
