﻿using System;
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
    public partial class frmCWID : Form
    {
        public frmCWID()
        {
            InitializeComponent();
        }
        //Cl0se button method
        private void BtnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        //Wires ok button
        private void BtnOK_Click(object sender, EventArgs e)
        {
            this.Hide();
            frmMain myForm = new frmMain(txtCWID.Text);
            if (myForm.ShowDialog() == DialogResult.OK)
            {

            }
            else
            {
                this.Close();
            }
        }
    }
}
