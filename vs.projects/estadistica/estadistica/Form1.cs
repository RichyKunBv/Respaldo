using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Estadistica
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

        private void btnexit_Click(object sender, EventArgs e)
        {
            DialogResult option = MessageBox.Show(this,
                                           "Desea cerrar la aplicacion?",
                                           "Salir",
                                           MessageBoxButtons.YesNo,
                                           MessageBoxIcon.Question);
            if (option == DialogResult.Yes)
            {
                this.Close();
            }
        }

        private void btnTextClear_Click(object sender, EventArgs e)
        {
            this.lstWarehouse.Items.Clear();
            this.lblCountingItems.Text = "Totsl de elementos: 0";
        }

        private void btninput_Click(object sender, EventArgs e)
        {
            string data = this.txtAddValue.Text;

            if (data == string.Empty)
            {
                MessageBox.Show(this,
                    "no ha ingresado un valor a la aplicacion",
                    "Valor no ingresado",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                return;
            }

            string counting = "Total de elementos";
            try
            {
                double value = Convert.ToDouble(data);
                if (value >= 0)
                {
                    this.lstWarehouse.Items.Add(value);
                    counting += this.lstWarehouse.Items.Count;
                    this.lblCountingItems.Text = counting;
                }
                else
                {
                    MessageBox.Show(this,
                        "Ela valor ingresado no puede ser menor a cero",
                        "Valor Fuera de rango",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(this,
                    ex.Message,
                    "VAlor incorrecto",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
            this.txtAddValue.Text = string.Empty;
            this.txtAddValue.Focus();
        }

        private void lstWarehouse_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void lblCountingItems_Click(object sender, EventArgs e)
        {

        }

        private void txtValue_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnCalculate_Click(object sender, EventArgs e)
        {
            IEnumerator items = lstWarehouse.Items.GetEnumerator();
            string list = string.Empty;
            while (items.MoveNext())
            {
                list += items.Current.ToString() + "\n";
            }
            MessageBox.Show(list);
        }

        private void btninput_KeyUp(object sender, KeyEventArgs e)
        {

        }
    }
}
