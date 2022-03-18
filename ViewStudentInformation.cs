using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QLTV
{
    public partial class ViewStudentInformation : Form
    {
        SqlConnection con = new SqlConnection(ConnectSQL.connectString);
        public ViewStudentInformation()
        {
            InitializeComponent();
        }

        private void txtSearchEnrollement_TextChanged(object sender, EventArgs e)
        {
            if (txtSearchEnrollement.Text != "")
            {
                label1.Visible = false;
                Image image = Properties.Resources.search1;
                pictureBox1.Image = image;

                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;

                cmd.CommandText = "select * from NewStudent where enroll LIKE '"+txtSearchEnrollement.Text+"%' ";
                SqlDataAdapter DA = new SqlDataAdapter(cmd);
                DataSet DS = new DataSet();
                DA.Fill(DS);

                dataGridView1.DataSource = DS.Tables[0];
            }
            else
            {
                label1.Visible = true;
                Image image = Properties.Resources.search;
                pictureBox1.Image = image;
            }
        }

        private void ViewStudentInformation_Load(object sender, EventArgs e)
        {
            panel2.Visible = false;

            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;

            cmd.CommandText = "select * from NewStudent";
            SqlDataAdapter DA = new SqlDataAdapter(cmd);
            DataSet DS = new DataSet();
            DA.Fill(DS);

            dataGridView1.DataSource = DS.Tables[0];
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ViewStudentInformation_Load(this, null);
            txtSearchEnrollement.Clear();
            panel2.Visible = false;
        }

        int bid;
        Int64 rowid;
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value != null)
            {
                bid = int.Parse(dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString());
            }
            panel2.Visible = true;

            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;

            cmd.CommandText = "select * from NewStudent where stdid = "+bid+"";
            SqlDataAdapter DA = new SqlDataAdapter(cmd);
            DataSet DS = new DataSet();
            DA.Fill(DS);

            rowid = Int64.Parse(DS.Tables[0].Rows[0][0].ToString());


            txtSName.Text = DS.Tables[0].Rows[0][1].ToString();
            txtEnrollment.Text = DS.Tables[0].Rows[0][2].ToString();
            txtDepartment.Text = DS.Tables[0].Rows[0][3].ToString();
            txtBirth.Text = DS.Tables[0].Rows[0][4].ToString();
            txtAddress.Text = DS.Tables[0].Rows[0][5].ToString();
            txtEmail.Text = DS.Tables[0].Rows[0][6].ToString();
            txtCard.Text = DS.Tables[0].Rows[0][7].ToString();

            
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            String stdname = txtSName.Text;
            String enroll = txtEnrollment.Text;
            String depart = txtDepartment.Text;
            String birth = txtBirth.Text;
            String address = txtAddress.Text;
            String semail = txtEmail.Text;
            String card = txtCard.Text;

            if (MessageBox.Show("Data will be updated!", "Success!", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;

                cmd.CommandText = "update NewStudent set stdname='" + stdname + "', enroll='" + enroll + "', department='" + depart + "', dateOfBirth='" + birth + "', address='" + address + "', email='" + semail + "', createdDate='" +card +"' where stdid = " + rowid + " ";
                SqlDataAdapter DA = new SqlDataAdapter(cmd);
                DataSet DS = new DataSet();
                DA.Fill(DS);

                ViewStudentInformation_Load(this, null);
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Data will be deleted!", "Deleted!", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.OK)
            {
                SqlConnection con = new SqlConnection();
                con.ConnectionString = "data source = LAPTOP-SDBRN09Q; database = LibraryDB; integrated security = True";

                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;

                cmd.CommandText = "delete from NewStudent where stdid = "+rowid+"";
                SqlDataAdapter DA = new SqlDataAdapter(cmd);
                DataSet DS = new DataSet();
                DA.Fill(DS);

                ViewStudentInformation_Load(this, null);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Unsaved data will be lost!", "Are you sure?", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.OK)
            {
                this.Close();
            }
        }
    }
}
