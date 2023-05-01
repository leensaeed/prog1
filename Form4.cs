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
    public partial class Form4 : Form
    {
        public Form4()
        {
            InitializeComponent();
            LoadData();
        }
        tccEntities db;
        student add;
        int id1;
        //  SqlConnection con = new SqlConnection(@"Data Source=AYA_HAMMODA\SQLEXPRESS01;Initial Catalog=tcc;Integrated Security=True");
        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void txtExamId_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtMark_TextChanged(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void Form4_Load(object sender, EventArgs e)
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
                add = new student();
                add.FiristName = txtFirstName.Text;
                add.Username = txtUsername.Text;
                add.lastName = txtLastName.Text;
                add.Email = txtEmail.Text;
                add.Phone = (txtPhone.Text);
                add.Departmentid = int.Parse(txtDepartmentId.Text); ;
                add.RegisterDate = int.Parse(txtRegisterDate.Text);
                add.id = int.Parse(txtid.Text);
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

        private void button3_Click(object sender, EventArgs e)
        {

            try
            {
                db = new tccEntities();
                add = new student();
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

        private void button4_Click(object sender, EventArgs e)
        {

            try
            {
                db = new tccEntities();
                add = new student();
                add.id = id1;
                add.FiristName = txtFirstName.Text;
                add.Username = txtUsername.Text;
                add.lastName = txtLastName.Text;
                add.Email = txtEmail.Text;
                add.Phone = (txtPhone.Text);
                add.Departmentid = int.Parse(txtDepartmentId.Text); ;
                add.RegisterDate = int.Parse(txtRegisterDate.Text);
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
