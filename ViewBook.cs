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
    public partial class ViewBook : Form
    {
        SqlConnection con = new SqlConnection(ConnectSQL.connectString);
        public ViewBook()
        {
            InitializeComponent();
        }


        private void ViewBook_Load(object sender, EventArgs e)
        {
            panel2.Visible = false;
            //SqlConnection con = new SqlConnection();
            //con.ConnectionString = "data source = DESKTOP-OF65B88\\NGUYENNHAN; database = liberaryManagement; integrated security=True";
            //con.ConnectionString = "data source = LAPTOP-SDBRN09Q; database = LibraryDB; integrated security = True";
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;

            cmd.CommandText = "select * from NewBook";
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds);

            dataGridView1.DataSource = ds.Tables[0];
        }
        int bid;
        Int64 rowid;
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if(dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value != null)
            {
               bid =  int.Parse(dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString());
                //MessageBox.Show(dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString());
            }
            panel2.Visible = true;
            //SqlConnection con = new SqlConnection();
            //con.ConnectionString = "data source = DESKTOP-OF65B88\\NGUYENNHAN; database = liberaryManagement; integrated security=True";
            //con.ConnectionString = "data source = LAPTOP-SDBRN09Q; database = LibraryDB; integrated security = True";
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;

            cmd.CommandText = "select * from NewBook where bid="+bid+"";
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds);

            rowid = Int64.Parse(ds.Tables[0].Rows[0][0].ToString());

            txtBName.Text = ds.Tables[0].Rows[0][1].ToString();
            txtCategory.Text = ds.Tables[0].Rows[0][2].ToString();
            txtAuthorName.Text= ds.Tables[0].Rows[0][3].ToString();
            txtPubYear.Text = ds.Tables[0].Rows[0][4].ToString();
            txtPublication.Text = ds.Tables[0].Rows[0][5].ToString();
            txtPDate.Text = ds.Tables[0].Rows[0][6].ToString();
            txtPrice.Text = ds.Tables[0].Rows[0][7].ToString();
            txtQuantity.Text = ds.Tables[0].Rows[0][8].ToString();

        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            panel2.Visible = false;
        }

        private void txtBookName_TextChanged(object sender, EventArgs e)
        {
            //if(txtBookName.Text != "")
            //{
            //    SqlConnection con = new SqlConnection();
            //    con.ConnectionString = "data source = DESKTOP-OF65B88\\NGUYENNHAN; database = liberaryManagement; integrated security=True";
            //    SqlCommand cmd = new SqlCommand();
            //    cmd.Connection = con;

            //    cmd.CommandText = "select * from NewBook where bName LIKE'"+txtBookName.Text+"%'";
            //    SqlDataAdapter da = new SqlDataAdapter(cmd);
            //    DataSet ds = new DataSet();
            //    da.Fill(ds);

            //    dataGridView1.DataSource = ds.Tables[0];
            //}
            //else
            //{
            //    SqlConnection con = new SqlConnection();
            //    con.ConnectionString = "data source = DESKTOP-OF65B88\\NGUYENNHAN; database = liberaryManagement; integrated security=True";
            //    SqlCommand cmd = new SqlCommand();
            //    cmd.Connection = con;

            //    cmd.CommandText = "select * from NewBook";
            //    SqlDataAdapter da = new SqlDataAdapter(cmd);
            //    DataSet ds = new DataSet();
            //    da.Fill(ds);

            //    dataGridView1.DataSource = ds.Tables[0];
            //}
            searchData(txtBookName.Text);
        }

        /*Search data voi dieu kien nhieu cot match*/
        //SqlConnection con = new SqlConnection("data source = LAPTOP-SDBRN09Q; database = LibraryDB; integrated security = True");
        public void searchData(string valueToFind)
        {
            string searchQuery = "select * from NewBook where CONCAT(bName, bCategory, bAuthor, bQuan) LIKE'%" + valueToFind + "%'";
            SqlDataAdapter adapter = new SqlDataAdapter(searchQuery, con);
            DataTable table = new DataTable();
            adapter.Fill(table);
            dataGridView1.DataSource = table;
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            txtBookName.Clear();
            panel2.Visible = false;
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Data will be updated.Confirm?", "Success!", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {
                String bname = txtBName.Text;
                String bcategory = txtCategory.Text;
                String bauthor = txtAuthorName.Text;
                String pubyear = txtPubYear.Text;
                String publication = txtPublication.Text;
                String pdate = txtPDate.Text;
                Int64 price = Int64.Parse(txtPrice.Text);
                Int64 quan = Int64.Parse(txtQuantity.Text);

                //SqlConnection con = new SqlConnection();
                //con.ConnectionString = "data source = DESKTOP-OF65B88\\NGUYENNHAN; database = liberaryManagement; integrated security=True";
                //con.ConnectionString = "data source = LAPTOP-SDBRN09Q; database = LibraryDB; integrated security = True";
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;

                cmd.CommandText = "update NewBook set bName = '" + bname + "', bCategory = '" + bcategory + "' ,bAuthor = '" + bauthor + "', bPubYear = '" + pubyear + "' ,bPubl = '" + publication + "', bPDate = '" + pdate + "', bPrice = " + price + ", bQuan=" + quan + " where bid = " + rowid + " ";
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                da.Fill(ds);
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Data will be deleted.Confirm?", "Success!", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.OK)
            {
                //SqlConnection con = new SqlConnection();
                //con.ConnectionString = "data source = DESKTOP-OF65B88\\NGUYENNHAN; database = liberaryManagement; integrated security=True";
                //con.ConnectionString = "data source = LAPTOP-SDBRN09Q; database = LibraryDB; integrated security = True";
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;

                cmd.CommandText = "delete from NewBook where bid = "+rowid+"";
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                da.Fill(ds);
            }
        }
    }
}
