using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Conectividad
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btninput_Click(object sender, EventArgs e)
        {
            if (txtValue.Text.Length > 0)
            {
                lblTextRecibe.Text = txtValue.Text;
            }
            else
            {
                MessageBox.Show(this,
                                "Tienes que escribir algo subnormal.",
                                "Campo no vacio",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
            }
        }

        private void btnTextClear_Click(object sender, EventArgs e)
        {
            txtValue.Text = string.Empty;
            lblTextRecibe.Text = string.Empty;

            txtValue.Focus();
        }
    }
}
