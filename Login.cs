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
    public partial class Login : Form
    {
        SqlConnection con = new SqlConnection(ConnectSQL.connectString);
        public Login()
        {
            InitializeComponent();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtUsername_MouseEnter(object sender, EventArgs e)
        {
            if(txtUsername.Text == "Username")
            {
                txtUsername.Clear();
            }
        }

        private void txtUsername_MouseClick(object sender, MouseEventArgs e)
        {
            if (txtUsername.Text == "Username")
            {
                txtUsername.Clear();
            }
        }

        private void txtPassword_MouseClick(object sender, MouseEventArgs e)
        {
            if (txtPassword.Text == "Password")
            {
                txtPassword.Clear();
                txtPassword.PasswordChar = '*';
            }
        }

        private void pictureBoxTwitter_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("https://www.facebook.com/profile.php?id=100005504982219");
        }

        private void pictureBoxFacebook_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("https://www.facebook.com/nguyeenxnhaan/");
        }

        private void pictureBoxInstagram_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("https://www.facebook.com/mytrinh.ha.9");
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;

            cmd.CommandText = "select * from loginTable where username ='"+txtUsername.Text+"' and pass ='"+txtPassword.Text+"'";
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds);

            if(ds.Tables[0].Rows.Count != 0)
            {
                this.Hide();
                Dashboard dsa = new Dashboard();
                dsa.Show();
            }
            else
            {
                MessageBox.Show("Wrong username or password!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
