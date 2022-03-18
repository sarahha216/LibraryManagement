using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QLTV
{
    public partial class Dashboard : Form
    {
        public Dashboard()
        {
            InitializeComponent();
        }

        private void vToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ViewStudentInformation vsi = new ViewStudentInformation();
            vsi.Show();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
           if (MessageBox.Show("Are you sure want to exit?", "Confirm", MessageBoxButtons.YesNo,MessageBoxIcon.Warning)==DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        private void addNewBookToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AddBooks abs = new AddBooks();
            abs.Show();
        }

        private void viewBooksToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ViewBook vb = new ViewBook();
            vb.Show();
        }

        private void addStudentToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AddStudent ast = new AddStudent();
            ast.Show();
        }

        private void issueBooksToolStripMenuItem_Click(object sender, EventArgs e)
        {
            IssueBook ib = new IssueBook();
            ib.Show();
        }

        private void returnBooksToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ReturnBook rb = new ReturnBook();
            rb.Show();
        }

        private void completeBooksToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CompleteBookDetails cbd = new CompleteBookDetails();
            cbd.Show();
        }
    }
}
