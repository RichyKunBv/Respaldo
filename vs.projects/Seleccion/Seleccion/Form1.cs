using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Seleccion
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            if (this.rbdColorBlue.Checked)
            {
                this.txtResponse.Text = this.rbdColorBlue.Text;
            }
            else
            {
                this.txtResponse.Text = string.Empty;
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void rdbColorGreen_CheckedChanged(object sender, EventArgs e)
        {
            if (this.rdbColorGreen.Checked)
            {
                this.txtResponse.Text = this.rdbColorGreen.Text;
            }
            else
            {
                this.txtResponse.Text = string.Empty;
            }
        }

        private void rbdColorRed_CheckedChanged(object sender, EventArgs e)
        {
            if (this.rbdColorRed.Checked)
            {
                this.txtResponse.Text = this.rbdColorRed.Text;
            }
            else
            {
                this.txtResponse.Text = string.Empty;
            }
        }

        private void chkColorBlue_CheckedChanged(object sender, EventArgs e)
        {
            if (this.chkColorBlue.Checked)
            {
                this.txtCheckColor.Text += this.chkColorBlue.Text;
            }
            else
            {
                this.txtCheckColor.Text = this.txtCheckColor.Text.Replace(this.chkColorBlue.Text, string.Empty);
            }
        }


        private void ChkColorGreen_CheckedChanged(object sender, EventArgs e)
        {
            if (this.chkColorGreen.Checked)
            {
                this.txtCheckColor.Text += this.chkColorGreen.Text;
            }
            else
            {
                this.txtCheckColor.Text = this.txtCheckColor.Text.Replace(this.chkColorGreen.Text, string.Empty);
            }
        }



        private void chkColorRed_CheckedChanged(object sender, EventArgs e)
        {
            if (this.chkColorRed.Checked)
            {
                this.txtCheckColor.Text += this.chkColorRed.Text;
            }
            else
            {
                this.txtCheckColor.Text = this.txtCheckColor.Text.Replace(this.chkColorRed.Text, string.Empty);
            }
        }

    }
}
