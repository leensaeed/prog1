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
    public partial class Form6 : Form
    {
        public Form6()
        {
            InitializeComponent();
            LoadData();
        }
        tccEntities db;
        subject add;
        int id1;

        // SqlConnection con = new SqlConnection(@"Data Source=AYA_HAMMODA\SQLEXPRESS01;Initial Catalog=tcc;Integrated Security=True");
        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void Form6_Load(object sender, EventArgs e)
        {

            SqlConnection con = new SqlConnection();
            con.ConnectionString = @" Data Source=AYA_HAMMODA\SQLEXPRESS01;Initial Catalog=tcc;Integrated Security=True";
            con.Open();
            MessageBox.Show(con.State.ToString());
            con.Close();
            MessageBox.Show(con.State.ToString());
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                db = new tccEntities();
                add = new subject();
                add.Year = Convert.ToInt16(txtYear.Text);
                add.Name = txtName.Text;
                add.MinimumDegree = Convert.ToInt16(txtMinimumDegree.Text);
                add.Departmentid = int.Parse(txtDepartmentId.Text);
                add.id = int.Parse(txtid.Text);
                add.Term = Convert.ToInt16(txtTerm.Text);
                db.Entry(add).State = System.Data.Entity.EntityState.Added;
                db.SaveChanges();
                LoadData();
                MessageBox.Show("successfully Add");
            }
            catch
            {
                MessageBox.Show("can not add data");
            }
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

        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                db = new tccEntities();
                add = new subject();
                add.id = id1;
                add.Year = Convert.ToInt16(txtYear.Text);
                add.Name = txtName.Text;
                add.MinimumDegree = Convert.ToInt16(txtMinimumDegree.Text);
                add.Departmentid = int.Parse(txtDepartmentId.Text);
                add.id = int.Parse(txtid.Text);
                add.Term = Convert.ToInt16(txtTerm.Text);
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

        private void button3_Click(object sender, EventArgs e)
        {

            try
            {
                db = new tccEntities();
                add = new subject();
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

