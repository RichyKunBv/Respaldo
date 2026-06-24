namespace Contenedores
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            gbxColors = new GroupBox();
            rdbGreen = new RadioButton();
            rdbRed = new RadioButton();
            rdbBlue = new RadioButton();
            gbxGender = new GroupBox();
            rdbGenderNone = new RadioButton();
            rdbGenderMale = new RadioButton();
            rdbGenderFemale = new RadioButton();
            gbxColors.SuspendLayout();
            gbxGender.SuspendLayout();
            SuspendLayout();
            // 
            // gbxColors
            // 
            gbxColors.Controls.Add(rdbGreen);
            gbxColors.Controls.Add(rdbRed);
            gbxColors.Controls.Add(rdbBlue);
            gbxColors.Location = new Point(12, 12);
            gbxColors.Name = "gbxColors";
            gbxColors.Size = new Size(200, 100);
            gbxColors.TabIndex = 0;
            gbxColors.TabStop = false;
            gbxColors.Text = "Colores";
            // 
            // rdbGreen
            // 
            rdbGreen.AutoSize = true;
            rdbGreen.Location = new Point(6, 72);
            rdbGreen.Name = "rdbGreen";
            rdbGreen.Size = new Size(54, 19);
            rdbGreen.TabIndex = 2;
            rdbGreen.TabStop = true;
            rdbGreen.Text = "Verde";
            rdbGreen.UseVisualStyleBackColor = true;
            // 
            // rdbRed
            // 
            rdbRed.AutoSize = true;
            rdbRed.Location = new Point(6, 47);
            rdbRed.Name = "rdbRed";
            rdbRed.Size = new Size(49, 19);
            rdbRed.TabIndex = 1;
            rdbRed.TabStop = true;
            rdbRed.Text = "Rojo";
            rdbRed.UseVisualStyleBackColor = true;
            // 
            // rdbBlue
            // 
            rdbBlue.AutoSize = true;
            rdbBlue.Location = new Point(6, 22);
            rdbBlue.Name = "rdbBlue";
            rdbBlue.Size = new Size(48, 19);
            rdbBlue.TabIndex = 0;
            rdbBlue.TabStop = true;
            rdbBlue.Text = "Azul";
            rdbBlue.UseVisualStyleBackColor = true;
            // 
            // gbxGender
            // 
            gbxGender.Controls.Add(rdbGenderNone);
            gbxGender.Controls.Add(rdbGenderMale);
            gbxGender.Controls.Add(rdbGenderFemale);
            gbxGender.Location = new Point(218, 12);
            gbxGender.Name = "gbxGender";
            gbxGender.Size = new Size(200, 100);
            gbxGender.TabIndex = 1;
            gbxGender.TabStop = false;
            gbxGender.Text = "Genero";
            // 
            // rdbGenderNone
            // 
            rdbGenderNone.AutoSize = true;
            rdbGenderNone.Location = new Point(6, 72);
            rdbGenderNone.Name = "rdbGenderNone";
            rdbGenderNone.Size = new Size(122, 19);
            rdbGenderNone.TabIndex = 2;
            rdbGenderNone.TabStop = true;
            rdbGenderNone.Text = "Prefiero no decirlo";
            rdbGenderNone.UseVisualStyleBackColor = true;
            // 
            // rdbGenderMale
            // 
            rdbGenderMale.AutoSize = true;
            rdbGenderMale.Location = new Point(6, 47);
            rdbGenderMale.Name = "rdbGenderMale";
            rdbGenderMale.Size = new Size(80, 19);
            rdbGenderMale.TabIndex = 1;
            rdbGenderMale.TabStop = true;
            rdbGenderMale.Text = "Masculino";
            rdbGenderMale.UseVisualStyleBackColor = true;
            // 
            // rdbGenderFemale
            // 
            rdbGenderFemale.AutoSize = true;
            rdbGenderFemale.Location = new Point(6, 22);
            rdbGenderFemale.Name = "rdbGenderFemale";
            rdbGenderFemale.Size = new Size(78, 19);
            rdbGenderFemale.TabIndex = 0;
            rdbGenderFemale.TabStop = true;
            rdbGenderFemale.Text = "Femenino";
            rdbGenderFemale.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(672, 356);
            Controls.Add(gbxGender);
            Controls.Add(gbxColors);
            Name = "Form1";
            Text = "Form1";
            gbxColors.ResumeLayout(false);
            gbxColors.PerformLayout();
            gbxGender.ResumeLayout(false);
            gbxGender.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private GroupBox gbxColors;
        private GroupBox gbxGender;
        private RadioButton rdbGreen;
        private RadioButton rdbRed;
        private RadioButton rdbBlue;
        private RadioButton rdbGenderNone;
        private RadioButton rdbGenderMale;
        private RadioButton rdbGenderFemale;
    }
}
