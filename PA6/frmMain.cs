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
    public partial class frmMain : Form
    {
        //Class variables and book list
        string cwid;
        List<BookClass> myBooks;
        public frmMain(string tempCwid)
        {
            this.cwid = tempCwid;
            InitializeComponent();
            pbCover.SizeMode = PictureBoxSizeMode.StretchImage;
        }
        //Loads the main form
        private void FrmMain_Load(object sender, EventArgs e)
        {
            LoadList();
        }
        //Loads the list
        private void LoadList()
        {
            myBooks = BookFile.GetAllBooks(cwid);
            lstBooks.DataSource = myBooks;
        }
        //Methods for labels and text boxes
        private void Label1_Click(object sender, EventArgs e)
        {

        }

        private void Label1_Click_1(object sender, EventArgs e)
        {

        }

        private void TextBox1_TextChanged(object sender, EventArgs e)
        {

        }
        //Close button
        private void BtnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        //Loads the book cover
        private void LstBooks_SelectedIndexChanged(object sender, EventArgs e)
        {
            BookClass myBook = (BookClass)lstBooks.SelectedItem;

            txtTitleData.Text = myBook.title;
            txtAuthorData.Text = myBook.author;
            txtGenreData.Text = myBook.genre;
            txtCopiesAvbl.Text = myBook.copies.ToString();
            txtLengthData.Text = myBook.length.ToString();
            txtISPNData.Text = myBook.isbn;

            try
            {
                pbCover.Load(myBook.cover);
            }
            catch
            {

            }
        }

        private void BtnRent_Click(object sender, EventArgs e)
        {
            BookClass myBook = (BookClass)lstBooks.SelectedItem;

            myBook.copies--;
            BookFile.SaveBook(myBook, cwid, "edit");
            LoadList();
        }

        private void BtnReturn_Click(object sender, EventArgs e)
        {
            BookClass myBook = (BookClass)lstBooks.SelectedItem;

            myBook.copies++;
            BookFile.SaveBook(myBook, cwid, "edit");
            LoadList();
        }

        private void BtnDelete_Click(object sender, EventArgs e)
        {
            BookClass myBook = (BookClass)lstBooks.SelectedItem;

            DialogResult dialogResult = MessageBox.Show("Are you sure you want to delete?", "Delete", MessageBoxButtons.YesNo);

            if (dialogResult == DialogResult.Yes)
            {
                BookFile.DeleteBook(myBook, cwid);
                LoadList();
            }
        }

        private void BtnEdit_Click(object sender, EventArgs e)
        {
            BookClass myBook = (BookClass)lstBooks.SelectedItem;
            frmEdit myForm = new frmEdit(myBook, "edit", cwid);

            if (myForm.ShowDialog() == DialogResult.OK)
            {

            }
            else
            {
                LoadList();
            }
        }

        private void BtnNew_Click(object sender, EventArgs e)
        {
            BookClass myBook = new BookClass();
            frmEdit myForm = new frmEdit(myBook, "new", cwid);

            if (myForm.ShowDialog() == DialogResult.OK)
            {

            }
            else
            {
                LoadList();
            }
        }
    }
}
