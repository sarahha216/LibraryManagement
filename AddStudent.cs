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
    public partial class AddStudent : Form
    {
        SqlConnection con = new SqlConnection(ConnectSQL.connectString);
        public AddStudent()
        {
            InitializeComponent();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Confirm", "Alert", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.OK)
            {
                this.Close();
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            txtName.Clear();
            txtEnrollment.Clear();
            txtDepartment.Clear();
            txtAddress.Clear();
            txtBirth.Clear();
            //txtEmail.Clear();

            txtEmail.Text = "";
            
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (txtName.Text != "" && txtEnrollment.Text != "" && txtDepartment.Text != "" && txtAddress.Text != "" && txtBirth.Text != "" && txtEmail.Text != "")
            {
                String name = txtName.Text;
                String enroll = txtEnrollment.Text;
                String depart = txtDepartment.Text;
                String address = txtAddress.Text;
                String birth = txtBirth.Text;
                String email = txtEmail.Text;
                String card = dateTimePicker1.Text;

                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;

                con.Open();
                cmd.CommandText = "insert into NewStudent (stdname, enroll, department, dateOfBirth, address, email, createdDate) values ('" + name + "','" + enroll + "', '" + depart + "','" + birth + "','" + address + "','" + email + "','" + card + "')";
                cmd.ExecuteNonQuery();
                con.Close();
                MessageBox.Show("Data Saved", "Success!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Please fill empty fields", "Suggest", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}
