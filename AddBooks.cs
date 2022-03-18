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
    public partial class AddBooks : Form
    {
        SqlConnection con = new SqlConnection(ConnectSQL.connectString);
        public AddBooks()
        {
            InitializeComponent();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (txtBookName.Text != "" && txtCategory.Text != "" && txtAuthorName.Text != "" && txtPubYear.Text != "" && txtPublication.Text != "" && txtPrice.Text != "" && txtQuantity.Text != "")
            {

                String bname = txtBookName.Text;
                String category = txtCategory.Text;
                String bauthor = txtAuthorName.Text;
                String pubyear = txtPubYear.Text;
                String publication = txtPublication.Text;
                String pdate = dateTimePicker1.Text;
                Int64 price = Int64.Parse(txtPrice.Text);
                Int64 quan = Int64.Parse(txtQuantity.Text);
                
                SqlConnection con = new SqlConnection(ConnectSQL.connectString);
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;

                con.Open();
                /*Danh sach loai sach va doc gia*/
                SqlDataAdapter daCate = new SqlDataAdapter("select * from BookCategory where cateName ='" + txtCategory.Text + "'", con);
                DataTable dtCate = new DataTable();
                daCate.Fill(dtCate);

                SqlDataAdapter daAuthor = new SqlDataAdapter("select * from BookAuthor where authorName ='" + txtAuthorName.Text + "'", con);
                DataTable dtAuthor = new DataTable();
                daAuthor.Fill(dtAuthor);
                
                /*Nhan sach trong vong 8 nam*/
                String st = txtPubYear.Text;
                int PubYear = Convert.ToInt32(st);
                DateTime current = DateTime.Now;
                int currentYear = current.Year;
                int year = currentYear - PubYear;

                if (dtCate.Rows.Count == 0)
                {
                    MessageBox.Show("Invalid Category");
                }
                else if (dtAuthor.Rows.Count == 0)
                {
                    MessageBox.Show("Invalid Author");
                }
                else if (year > 8)
                {
                    MessageBox.Show("Only recieve books for 8 years");
                }
                else
                {
                    cmd.CommandText = "insert into NewBook (bName,bCategory,bAuthor,bPubYear,bPubl,bPDate,bPrice,bQuan) values ('" + bname + "','" + category + "','" + bauthor + "','" + pubyear + "', '" + publication + "','" + pdate + "','" + price + "','" + quan + "')";
                    cmd.ExecuteNonQuery();
                    con.Close();
                    MessageBox.Show("Data Saved!", "Success!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                txtBookName.Clear();
                txtCategory.Clear();
                txtAuthorName.Clear();
                txtPubYear.Clear();
                txtPublication.Clear();
                txtPrice.Clear();
                txtQuantity.Clear();
            }
            else
            {
                MessageBox.Show("Empty Field NOT Allowed", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            if(MessageBox.Show("This will DELETE your Unsaved Data.", "Are you sure?", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.OK)
            this.Close();
        }

        private void AddBooks_Load(object sender, EventArgs e)
        {
            con.Open();
            /*Load danh sach va tu dong dien*/
            SqlCommand cmdCate = new SqlCommand("select cateName from BookCategory", con);
            SqlDataReader drCate;
            drCate = cmdCate.ExecuteReader();
            AutoCompleteStringCollection collectCate = new AutoCompleteStringCollection();
            while (drCate.Read())
            {
                collectCate.Add(drCate["cateName"].ToString());
            }
            txtCategory.AutoCompleteMode = AutoCompleteMode.Suggest;
            txtCategory.AutoCompleteSource = AutoCompleteSource.CustomSource;
            txtCategory.AutoCompleteCustomSource = collectCate;
            drCate.Close();

            SqlCommand cmdAuthor = new SqlCommand("select authorName from BookAuthor", con);
            SqlDataReader drAuthor;
            drAuthor = cmdAuthor.ExecuteReader();
            AutoCompleteStringCollection collectAuthor = new AutoCompleteStringCollection();
            while (drAuthor.Read())
            {
                collectAuthor.Add(drAuthor["authorName"].ToString());
            }
            txtAuthorName.AutoCompleteMode = AutoCompleteMode.Suggest;
            txtAuthorName.AutoCompleteSource = AutoCompleteSource.CustomSource;
            txtAuthorName.AutoCompleteCustomSource = collectAuthor;
            drAuthor.Close();
        }
    }
}
