using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace vnsidjvnsdjnclksdmncklsnclksdnclkdsnklndcjkvnwsklndsk
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            lblCountingItems.Text = "Total de elementos: 0";
        }

        private void lblCountingItems_Click(object sender, EventArgs e)
        {
        }

        private void btnAddValue_Click(object sender, EventArgs e)
        {
            string data = txtAddValue.Text;

            if (string.IsNullOrWhiteSpace(data))
            {
                MessageBox.Show(this,
                    "No ha ingresado un valor a la aplicación.",
                    "Valor no ingresado.",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                return;
            }

            if (!double.TryParse(data, out double value))
            {
                MessageBox.Show(this,
                    "El valor ingresado no es un número válido.",
                    "Valor incorrecto",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                return;
            }

            if (value < 0)
            {
                MessageBox.Show(this,
                    "El valor ingresado no puede ser menor a cero.",
                    "Valor fuera de rango",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                return;
            }

            lstWarehouse.Items.Add(value);
            lblCountingItems.Text = $"Total de elementos: {lstWarehouse.Items.Count}";

            txtAddValue.Text = string.Empty;
            txtAddValue.Focus();
        }

        private void btnClearList_Click(object sender, EventArgs e)
        {
            lstWarehouse.Items.Clear();
            lblCountingItems.Text = "Total de elementos: 0";
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            DialogResult option = MessageBox.Show(this,
                "¿Desea cerrar la aplicación?",
                "Salir",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (option == DialogResult.Yes)
            {
                Close();
            }
        }

        private void btnCalculate_Click(object sender, EventArgs e)
        {
            if (lstWarehouse.Items.Count == 0)
            {
                MessageBox.Show("No hay elementos en la lista para calcular estadísticas.",
                    "Lista vacía", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            List<double> numbers = lstWarehouse.Items.Cast<double>().ToList();

            double average = numbers.Average();
            double median = GetMedian(numbers);
            double range = numbers.Max() - numbers.Min();
            double variance = GetVariance(numbers, average);
            double stdDeviation = Math.Sqrt(variance);

            string result = $"Promedio: {average:F2}\n" +
                            $"Mediana: {median:F2}\n" +
                            $"Rango: {range:F2}\n" +
                            $"Varianza: {variance:F2}\n" +
                            $"Desviación estándar: {stdDeviation:F2}";

            MessageBox.Show(result, "Estadísticas", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private double GetMedian(List<double> numbers)
        {
            numbers.Sort();
            int count = numbers.Count;
            return count % 2 == 0
                ? (numbers[count / 2 - 1] + numbers[count / 2]) / 2.0
                : numbers[count / 2];
        }

        private double GetVariance(List<double> numbers, double mean)
        {
            return numbers.Sum(num => Math.Pow(num - mean, 2)) / numbers.Count;
        }

        private void lstWarehouse_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

        private void label1_Click(object sender, EventArgs e)
        {
        }

        private void lblDescriptiveText_Click(object sender, EventArgs e)
        {
        }

        private void lblInputText_Click(object sender, EventArgs e)
        {
        }
    }
}
