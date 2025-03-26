using System;
using System.Windows.Forms;

namespace Validar
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btninput_Click(object sender, EventArgs e)
        {
            string input = txtValue.Text.Trim();

            if (string.IsNullOrEmpty(input))
            {
                MessageBox.Show(this,
                                "Por favor, ingrese un número.",
                                "Campo vacío",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Warning);
                return;
            }

            if (IsValidNumber(input))
            {
                lblTextRecibe.Text = input;
            }
            else
            {
                MessageBox.Show(this,
                                "El número ingresado no es válido. Solo se permiten números positivos o negativos con un punto decimal (opcional).",
                                "Error de validación",
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

        private bool IsValidNumber(string input)
        {
            bool hasDecimalPoint = false; 
            bool hasDigits = false;       

            for (int i = 0; i < input.Length; i++)
            {
                char c = input[i];

                if (c == '-')
                {
                    if (i != 0) return false; 
                    continue;
                }

                if (c == '.')
                {
                    if (hasDecimalPoint) return false;
                    hasDecimalPoint = true;
                    continue;
                }

                if (char.IsDigit(c))
                {
                    hasDigits = true;
                    continue;
                }

                return false;
            }

            return hasDigits;
        }
    }
}