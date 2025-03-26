using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Opciones
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void mnFileExit_Click(object sender, EventArgs e)
        {
            this.ExitProgram();
        }

        private void ExitProgram()
        {
            DialogResult option = MessageBox.Show(this,
                                                   "Desea cerrar la aplicacion?",
                                                   "Salir",
                                                   MessageBoxButtons.YesNo,
                                                   MessageBoxIcon.Question,
                                                   MessageBoxDefaultButton.Button2);
            if (option == DialogResult.Yes)
            {
                this.Dispose();
            }
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.ExitProgram();
            e.Cancel = true;
        }
    }
}
