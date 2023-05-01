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
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
            LoadData();
        }
        tccEntities db;
        Department add;
        int id1;

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void txtid_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

            SqlConnection conn = new SqlConnection();
            conn.Open();
            if (conn.State == System.Data.ConnectionState.Open)
            {
                string d = " insert into Test (id,name)values('" + txtid.Text.ToString() + "','"
                     + txtName.Text.ToString() + "')";
                SqlCommand cmd = new SqlCommand(d, conn);
                cmd.ExecuteNonQuery();
                MessageBox.Show("conniction made successfuly..!");
            }
        }

        private void Form2_Load(object sender, EventArgs e)
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
                add = new Department();
                add.name = txtName.Text;
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
                add = new Department();
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
                add = new Department();
                add.id = id1;
                add.name = txtName.Text;
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
        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                id1 = Convert.ToInt16(dataGridView1.CurrentRow.Cells[0].Value);
                txtName.Text = Convert.ToString(dataGridView1.CurrentRow.Cells[1].Value);
               
            }
            catch
            {

            }
        }
    }
}
