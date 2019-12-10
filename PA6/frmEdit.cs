using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PA6
{
    public partial class frmEdit : Form
    {
        //Class variables
        private BookClass myBook;
        private string cwid;
        private string mode; 
        //Method for the form edit design
        public frmEdit(Object tempBook, string tempMode, string tempCwid)
        {
            //Variables for the form edit design box
            myBook = (BookClass)tempBook;
            cwid = tempCwid;
            mode = tempMode;
            InitializeComponent();
            pbCover.SizeMode = PictureBoxSizeMode.StretchImage;
        }

        //Loads the form edit box
        private void FrmEdit_Load(object sender, EventArgs e)
        {
            if (mode == "edit")
            {
                txtTitleData.Text = myBook.title;
                txtAuthorData.Text = myBook.author;
                txtGenreData.Text = myBook.genre;
                txtCopiesAvbl.Text = myBook.copies.ToString();
                txtISPNData.Text = myBook.isbn;
                txtCoverData.Text = myBook.cover;
                txtLengthData.Text = myBook.length.ToString();


                pbCover.Load(myBook.cover);

            }
        }
        //Close button
        private void BtnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        //Wires the save button
        private void BtnSave_Click(object sender, EventArgs e)
        {
            myBook.title = txtTitleData.Text;
            myBook.author = txtAuthorData.Text;
            myBook.genre = txtGenreData.Text;
            myBook.copies = int.Parse(txtCopiesAvbl.Text);
            myBook.isbn = txtISPNData.Text;
            myBook.cover = txtCoverData.Text;
            myBook.length = int.Parse(txtLengthData.Text);
            myBook.cwid = cwid;

            BookFile.SaveBook(myBook, cwid, mode);

            MessageBox.Show("Content was saved. ", "Saved", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.Close();
        }
    }
}
