using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;
using System.Drawing.Printing;

namespace ei
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
                DialogResult saveOption = MessageBox.Show(this,
                                                         "Desea guardar el documento antes de salir?",
                                                         "Guardar",
                                                         MessageBoxButtons.YesNo,
                                                         MessageBoxIcon.Question,
                                                         MessageBoxDefaultButton.Button1);

                if (saveOption == DialogResult.Yes)
                {
                    SaveFile();
                    this.Dispose();
                }
                else if (saveOption == DialogResult.No)
                {
                    this.Dispose();
                }
            }
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            ExitProgram();
            e.Cancel = true;
        }

        private void NewFile()
        {
            DialogResult opcion = MessageBox.Show(this,
                                                  "Desea guardar el documento?",
                                                  "Guardar",
                                                  MessageBoxButtons.YesNo,
                                                  MessageBoxIcon.Question,
                                                  MessageBoxDefaultButton.Button1);
            if (opcion == DialogResult.Yes)
            {
                SaveFile();
            }
        }

        private void mnFileNew_Click(object sender, EventArgs e)
        {
            this.NewFile();
        }

        private void tmFileNew_Click(object sender, EventArgs e)
        {
            this.NewFile();
        }

        private void SaveFile()
        {
            SaveFileDialog guardar = new SaveFileDialog();
            guardar.Filter = "Documento de texto|*.txt";
            guardar.Title = "Guadrar RichTextBox";
            guardar.FileName = "Sin titulo 1";
            var resultado = guardar.ShowDialog();
            if (resultado == DialogResult.OK)
            {
                StreamWriter escribir = new StreamWriter(guardar.FileName);
                foreach (object line in RichTextBox.Lines)
                {
                    escribir.WriteLine(line);
                }
                escribir.Close();
            }
        }

        private void tmFileSave_Click(object sender, EventArgs e)
        {
            this.SaveFile();
        }

        private void mnFileSave_Click(object sender, EventArgs e)
        {
            this.SaveFile();
        }

        private void OpenFile()
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Title = "Abrir archivo";
                openFileDialog.Filter = "Archivo (*.txt)|*.txt";
                openFileDialog.FilterIndex = 1;
                openFileDialog.RestoreDirectory = true;

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    string filePath = openFileDialog.FileName;

                    try
                    {
                        string fileContent = File.ReadAllText(filePath);
                        RichTextBox.Clear();
                        RichTextBox.Text = fileContent;
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error al abrir el archivo: " + ex.Message,
                                        "Error",
                                        MessageBoxButtons.OK,
                                        MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void mnFileOpen_Click(object sender, EventArgs e)
        {
            this.OpenFile();
        }

        private void tmFileOpen_Click(object sender, EventArgs e)
        {
            this.OpenFile();
        }

        private void Copy()
        {
            RichTextBox.Copy();
        }

        private void mnEditCopy_Click(object sender, EventArgs e)
        {
            this.Copy();
        }

        private void tmEditCopy_Click(object sender, EventArgs e)
        {
            this.Copy();
        }

        private void Paste()
        {
            RichTextBox.Paste();
        }

        private void tmFilePaste_Click(object sender, EventArgs e)
        {
            this.Paste();
        }

        private void mnEditPaste_Click(object sender, EventArgs e)
        {
            this.Paste();
        }
        private void Cut()
        {
            RichTextBox.Cut();
        }

        private void mnEditCut_Click(object sender, EventArgs e)
        {
            this.Cut();
        }

        private void tmFileCut_Click(object sender, EventArgs e)
        {
            this.Cut();
        }

        private void SA()
        {
            RichTextBox.SelectAll();
        }

        private void mnEditSelectAll_Click(object sender, EventArgs e)
        {
            this.SA();
        }
        private void ZoomIn()
        {
            if (RichTextBox.ZoomFactor < 5.0f) // Maximum zoom factor is 5.0
            {
                RichTextBox.ZoomFactor += 0.1f;
            }
        }

        private void mnViewAumentar_Click(object sender, EventArgs e)
        {
            this.ZoomIn();
        }

        private void tmViewAumentar_Click(object sender, EventArgs e)
        {
            this.ZoomIn();
        }
        private void ZoomOut()
        {
            if (RichTextBox.ZoomFactor > 0.1f) // Minimum zoom factor is 0.1
            {
                RichTextBox.ZoomFactor -= 0.1f;
            }
        }

        private void tmViewDisminuir_Click(object sender, EventArgs e)
        {
            this.ZoomOut();
        }

        private void mnViewDisminuir_Click(object sender, EventArgs e)
        {
            this.ZoomOut();
        }
        private void Print()
        {
            PrintDialog printDialog = new PrintDialog();
            PrintDocument printDocument = new PrintDocument();
            printDialog.Document = printDocument;

            printDocument.PrintPage += new PrintPageEventHandler(PrintPageHandler);

            if (printDialog.ShowDialog() == DialogResult.OK)
            {
                printDocument.Print();
            }
        }

        private void PrintPageHandler(object sender, PrintPageEventArgs e)
        {
            if (RichTextBox != null)
            {
                Font printFont = RichTextBox.Font;
                string textToPrint = RichTextBox.Text;
                e.Graphics.DrawString(textToPrint, printFont, Brushes.Black, new RectangleF(50, 50, e.PageBounds.Width - 100, e.PageBounds.Height - 100));
            }
        }

        private void mnFilePrint_Click(object sender, EventArgs e)
        {
            this.Print();
        }

        private void tmFilePrint_Click(object sender, EventArgs e)
        {
            this.Print();
        }
    }
}
