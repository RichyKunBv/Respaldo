namespace Conectividad
{
    partial class Form1
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.lblTextInstruction = new System.Windows.Forms.Label();
            this.txtValue = new System.Windows.Forms.TextBox();
            this.btninput = new System.Windows.Forms.Button();
            this.lblTextRecibe = new System.Windows.Forms.Label();
            this.btnTextClear = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblTextInstruction
            // 
            this.lblTextInstruction.AutoSize = true;
            this.lblTextInstruction.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTextInstruction.Location = new System.Drawing.Point(13, 13);
            this.lblTextInstruction.Name = "lblTextInstruction";
            this.lblTextInstruction.Size = new System.Drawing.Size(190, 18);
            this.lblTextInstruction.TabIndex = 0;
            this.lblTextInstruction.Text = "Ingresar un texto de prueba:";
            // 
            // txtValue
            // 
            this.txtValue.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtValue.Location = new System.Drawing.Point(210, 10);
            this.txtValue.MaxLength = 45;
            this.txtValue.Name = "txtValue";
            this.txtValue.Size = new System.Drawing.Size(250, 24);
            this.txtValue.TabIndex = 1;
            // 
            // btninput
            // 
            this.btninput.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btninput.Location = new System.Drawing.Point(381, 51);
            this.btninput.Name = "btninput";
            this.btninput.Size = new System.Drawing.Size(79, 28);
            this.btninput.TabIndex = 2;
            this.btninput.Text = "Agregar";
            this.btninput.UseVisualStyleBackColor = true;
            this.btninput.Click += new System.EventHandler(this.btninput_Click);
            // 
            // lblTextRecibe
            // 
            this.lblTextRecibe.AutoSize = true;
            this.lblTextRecibe.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTextRecibe.ForeColor = System.Drawing.Color.IndianRed;
            this.lblTextRecibe.Location = new System.Drawing.Point(29, 104);
            this.lblTextRecibe.Name = "lblTextRecibe";
            this.lblTextRecibe.Size = new System.Drawing.Size(0, 18);
            this.lblTextRecibe.TabIndex = 3;
            // 
            // btnTextClear
            // 
            this.btnTextClear.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTextClear.Location = new System.Drawing.Point(273, 51);
            this.btnTextClear.Name = "btnTextClear";
            this.btnTextClear.Size = new System.Drawing.Size(79, 28);
            this.btnTextClear.TabIndex = 4;
            this.btnTextClear.Text = "Limpiar";
            this.btnTextClear.UseVisualStyleBackColor = true;
            this.btnTextClear.Click += new System.EventHandler(this.btnTextClear_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(464, 321);
            this.Controls.Add(this.btnTextClear);
            this.Controls.Add(this.lblTextRecibe);
            this.Controls.Add(this.btninput);
            this.Controls.Add(this.txtValue);
            this.Controls.Add(this.lblTextInstruction);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Conectividad";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblTextInstruction;
        private System.Windows.Forms.TextBox txtValue;
        private System.Windows.Forms.Button btninput;
        private System.Windows.Forms.Label lblTextRecibe;
        private System.Windows.Forms.Button btnTextClear;
    }
}

