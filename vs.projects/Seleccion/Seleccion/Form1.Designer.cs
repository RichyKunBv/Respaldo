namespace Seleccion
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
            this.lblColorChange = new System.Windows.Forms.Label();
            this.rbdColorBlue = new System.Windows.Forms.RadioButton();
            this.rdbColorGreen = new System.Windows.Forms.RadioButton();
            this.rbdColorRed = new System.Windows.Forms.RadioButton();
            this.txtResponse = new System.Windows.Forms.TextBox();
            this.chkColorBlue = new System.Windows.Forms.CheckBox();
            this.chkColorGreen = new System.Windows.Forms.CheckBox();
            this.chkColorRed = new System.Windows.Forms.CheckBox();
            this.txtCheckColor = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // lblColorChange
            // 
            this.lblColorChange.AutoSize = true;
            this.lblColorChange.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblColorChange.Location = new System.Drawing.Point(13, 13);
            this.lblColorChange.Name = "lblColorChange";
            this.lblColorChange.Size = new System.Drawing.Size(65, 18);
            this.lblColorChange.TabIndex = 0;
            this.lblColorChange.Text = "Colores:";
            this.lblColorChange.Click += new System.EventHandler(this.label1_Click);
            // 
            // rbdColorBlue
            // 
            this.rbdColorBlue.AutoSize = true;
            this.rbdColorBlue.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbdColorBlue.Location = new System.Drawing.Point(84, 34);
            this.rbdColorBlue.Name = "rbdColorBlue";
            this.rbdColorBlue.Size = new System.Drawing.Size(54, 22);
            this.rbdColorBlue.TabIndex = 1;
            this.rbdColorBlue.TabStop = true;
            this.rbdColorBlue.Text = "Azul";
            this.rbdColorBlue.UseVisualStyleBackColor = true;
            this.rbdColorBlue.CheckedChanged += new System.EventHandler(this.radioButton1_CheckedChanged);
            // 
            // rdbColorGreen
            // 
            this.rdbColorGreen.AutoSize = true;
            this.rdbColorGreen.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rdbColorGreen.Location = new System.Drawing.Point(84, 62);
            this.rdbColorGreen.Name = "rdbColorGreen";
            this.rdbColorGreen.Size = new System.Drawing.Size(64, 22);
            this.rdbColorGreen.TabIndex = 2;
            this.rdbColorGreen.TabStop = true;
            this.rdbColorGreen.Text = "Verde";
            this.rdbColorGreen.UseVisualStyleBackColor = true;
            this.rdbColorGreen.CheckedChanged += new System.EventHandler(this.rdbColorGreen_CheckedChanged);
            // 
            // rbdColorRed
            // 
            this.rbdColorRed.AutoSize = true;
            this.rbdColorRed.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbdColorRed.Location = new System.Drawing.Point(84, 90);
            this.rbdColorRed.Name = "rbdColorRed";
            this.rbdColorRed.Size = new System.Drawing.Size(58, 22);
            this.rbdColorRed.TabIndex = 3;
            this.rbdColorRed.TabStop = true;
            this.rbdColorRed.Text = "Rojo";
            this.rbdColorRed.UseVisualStyleBackColor = true;
            this.rbdColorRed.CheckedChanged += new System.EventHandler(this.rbdColorRed_CheckedChanged);
            // 
            // txtResponse
            // 
            this.txtResponse.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtResponse.Location = new System.Drawing.Point(84, 118);
            this.txtResponse.Name = "txtResponse";
            this.txtResponse.Size = new System.Drawing.Size(100, 24);
            this.txtResponse.TabIndex = 4;
            // 
            // chkColorBlue
            // 
            this.chkColorBlue.AutoSize = true;
            this.chkColorBlue.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkColorBlue.Location = new System.Drawing.Point(253, 34);
            this.chkColorBlue.Name = "chkColorBlue";
            this.chkColorBlue.Size = new System.Drawing.Size(55, 22);
            this.chkColorBlue.TabIndex = 5;
            this.chkColorBlue.Text = "Azul";
            this.chkColorBlue.UseVisualStyleBackColor = true;
            this.chkColorBlue.CheckedChanged += new System.EventHandler(this.chkColorBlue_CheckedChanged);
            // 
            // chkColorGreen
            // 
            this.chkColorGreen.AutoSize = true;
            this.chkColorGreen.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkColorGreen.Location = new System.Drawing.Point(253, 62);
            this.chkColorGreen.Name = "chkColorGreen";
            this.chkColorGreen.Size = new System.Drawing.Size(65, 22);
            this.chkColorGreen.TabIndex = 6;
            this.chkColorGreen.Text = "Verde";
            this.chkColorGreen.UseVisualStyleBackColor = true;
            this.chkColorGreen.CheckedChanged += new System.EventHandler(this.ChkColorGreen_CheckedChanged);
            // 
            // chkColorRed
            // 
            this.chkColorRed.AutoSize = true;
            this.chkColorRed.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkColorRed.Location = new System.Drawing.Point(253, 90);
            this.chkColorRed.Name = "chkColorRed";
            this.chkColorRed.Size = new System.Drawing.Size(59, 22);
            this.chkColorRed.TabIndex = 7;
            this.chkColorRed.Text = "Rojo";
            this.chkColorRed.UseVisualStyleBackColor = true;
            this.chkColorRed.CheckedChanged += new System.EventHandler(this.chkColorRed_CheckedChanged);
            // 
            // txtCheckColor
            // 
            this.txtCheckColor.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCheckColor.Location = new System.Drawing.Point(253, 118);
            this.txtCheckColor.Name = "txtCheckColor";
            this.txtCheckColor.Size = new System.Drawing.Size(144, 24);
            this.txtCheckColor.TabIndex = 8;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(560, 321);
            this.Controls.Add(this.txtCheckColor);
            this.Controls.Add(this.chkColorRed);
            this.Controls.Add(this.chkColorGreen);
            this.Controls.Add(this.chkColorBlue);
            this.Controls.Add(this.txtResponse);
            this.Controls.Add(this.rbdColorRed);
            this.Controls.Add(this.rdbColorGreen);
            this.Controls.Add(this.rbdColorBlue);
            this.Controls.Add(this.lblColorChange);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.Text = "Seleccion";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblColorChange;
        private System.Windows.Forms.RadioButton rbdColorBlue;
        private System.Windows.Forms.RadioButton rdbColorGreen;
        private System.Windows.Forms.RadioButton rbdColorRed;
        private System.Windows.Forms.TextBox txtResponse;
        private System.Windows.Forms.CheckBox chkColorBlue;
        private System.Windows.Forms.CheckBox chkColorGreen;
        private System.Windows.Forms.CheckBox chkColorRed;
        private System.Windows.Forms.TextBox txtCheckColor;
    }
}

