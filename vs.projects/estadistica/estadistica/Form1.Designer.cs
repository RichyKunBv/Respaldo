namespace Estadistica
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
            this.lblTextTitle = new System.Windows.Forms.Label();
            this.lblTextInstruction = new System.Windows.Forms.Label();
            this.txtAddValue = new System.Windows.Forms.TextBox();
            this.btnTextClear = new System.Windows.Forms.Button();
            this.btninput = new System.Windows.Forms.Button();
            this.btnexit = new System.Windows.Forms.Button();
            this.lstWarehouse = new System.Windows.Forms.ListBox();
            this.lblCountingItems = new System.Windows.Forms.Label();
            this.btnCalculate = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblTextTitle
            // 
            this.lblTextTitle.AutoSize = true;
            this.lblTextTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTextTitle.Location = new System.Drawing.Point(13, 13);
            this.lblTextTitle.Name = "lblTextTitle";
            this.lblTextTitle.Size = new System.Drawing.Size(310, 18);
            this.lblTextTitle.TabIndex = 0;
            this.lblTextTitle.Text = "Calculos basicos de la Estadistica Descriptiva";
            // 
            // lblTextInstruction
            // 
            this.lblTextInstruction.AutoSize = true;
            this.lblTextInstruction.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTextInstruction.Location = new System.Drawing.Point(16, 85);
            this.lblTextInstruction.Name = "lblTextInstruction";
            this.lblTextInstruction.Size = new System.Drawing.Size(46, 18);
            this.lblTextInstruction.TabIndex = 1;
            this.lblTextInstruction.Text = "Valor:";
            // 
            // txtAddValue
            // 
            this.txtAddValue.Location = new System.Drawing.Point(69, 82);
            this.txtAddValue.Name = "txtAddValue";
            this.txtAddValue.Size = new System.Drawing.Size(250, 20);
            this.txtAddValue.TabIndex = 2;
            this.txtAddValue.TextChanged += new System.EventHandler(this.txtValue_TextChanged);
            // 
            // btnTextClear
            // 
            this.btnTextClear.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F);
            this.btnTextClear.Location = new System.Drawing.Point(69, 142);
            this.btnTextClear.Name = "btnTextClear";
            this.btnTextClear.Size = new System.Drawing.Size(79, 28);
            this.btnTextClear.TabIndex = 4;
            this.btnTextClear.Text = "Limpiar";
            this.btnTextClear.UseVisualStyleBackColor = true;
            this.btnTextClear.Click += new System.EventHandler(this.btnTextClear_Click);
            // 
            // btninput
            // 
            this.btninput.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F);
            this.btninput.Location = new System.Drawing.Point(240, 142);
            this.btninput.Name = "btninput";
            this.btninput.Size = new System.Drawing.Size(79, 28);
            this.btninput.TabIndex = 5;
            this.btninput.Text = "Agregar";
            this.btninput.UseVisualStyleBackColor = true;
            this.btninput.Click += new System.EventHandler(this.btninput_Click);
            this.btninput.KeyUp += new System.Windows.Forms.KeyEventHandler(this.btninput_KeyUp);
            // 
            // btnexit
            // 
            this.btnexit.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnexit.Location = new System.Drawing.Point(473, 286);
            this.btnexit.Name = "btnexit";
            this.btnexit.Size = new System.Drawing.Size(75, 23);
            this.btnexit.TabIndex = 6;
            this.btnexit.Text = "Salir";
            this.btnexit.UseVisualStyleBackColor = true;
            this.btnexit.Click += new System.EventHandler(this.btnexit_Click);
            // 
            // lstWarehouse
            // 
            this.lstWarehouse.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lstWarehouse.FormattingEnabled = true;
            this.lstWarehouse.ItemHeight = 18;
            this.lstWarehouse.Location = new System.Drawing.Point(371, 40);
            this.lstWarehouse.Name = "lstWarehouse";
            this.lstWarehouse.Size = new System.Drawing.Size(120, 130);
            this.lstWarehouse.TabIndex = 7;
            this.lstWarehouse.SelectedIndexChanged += new System.EventHandler(this.lstWarehouse_SelectedIndexChanged);
            // 
            // lblCountingItems
            // 
            this.lblCountingItems.AutoSize = true;
            this.lblCountingItems.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCountingItems.Location = new System.Drawing.Point(368, 200);
            this.lblCountingItems.Name = "lblCountingItems";
            this.lblCountingItems.Size = new System.Drawing.Size(150, 18);
            this.lblCountingItems.TabIndex = 8;
            this.lblCountingItems.Text = "Total de elementos: 0";
            this.lblCountingItems.Click += new System.EventHandler(this.lblCountingItems_Click);
            // 
            // btnCalculate
            // 
            this.btnCalculate.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCalculate.Location = new System.Drawing.Point(69, 200);
            this.btnCalculate.Name = "btnCalculate";
            this.btnCalculate.Size = new System.Drawing.Size(79, 28);
            this.btnCalculate.TabIndex = 9;
            this.btnCalculate.Text = "Calcular";
            this.btnCalculate.UseVisualStyleBackColor = true;
            this.btnCalculate.Click += new System.EventHandler(this.btnCalculate_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(560, 321);
            this.Controls.Add(this.btnCalculate);
            this.Controls.Add(this.lblCountingItems);
            this.Controls.Add(this.lstWarehouse);
            this.Controls.Add(this.btnexit);
            this.Controls.Add(this.btninput);
            this.Controls.Add(this.btnTextClear);
            this.Controls.Add(this.txtAddValue);
            this.Controls.Add(this.lblTextInstruction);
            this.Controls.Add(this.lblTextTitle);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Estadistica";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblTextTitle;
        private System.Windows.Forms.Label lblTextInstruction;
        private System.Windows.Forms.TextBox txtAddValue;
        private System.Windows.Forms.Button btnTextClear;
        private System.Windows.Forms.Button btninput;
        private System.Windows.Forms.Button btnexit;
        private System.Windows.Forms.ListBox lstWarehouse;
        private System.Windows.Forms.Label lblCountingItems;
        private System.Windows.Forms.Button btnCalculate;
    }
}

