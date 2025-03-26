using System;
using System.Windows.Forms;

namespace vnsidjvnsdjnclksdmncklsnclksdnclkdsnklndcjkvnwsklndsk
{
    partial class Form1
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.btnAddValue = new System.Windows.Forms.Button();
            this.btnClearList = new System.Windows.Forms.Button();
            this.btnExit = new System.Windows.Forms.Button();
            this.btnCalculate = new System.Windows.Forms.Button();
            this.lstWarehouse = new System.Windows.Forms.ListBox();
            this.lblCountingItems = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtAddValue = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnAddValue
            // 
            this.btnAddValue.Location = new System.Drawing.Point(540, 115);
            this.btnAddValue.Name = "btnAddValue";
            this.btnAddValue.Size = new System.Drawing.Size(75, 23);
            this.btnAddValue.TabIndex = 0;
            this.btnAddValue.Text = "Agregar";
            this.btnAddValue.UseVisualStyleBackColor = true;
            this.btnAddValue.Click += new System.EventHandler(this.btnAddValue_Click);
            // 
            // btnClearList
            // 
            this.btnClearList.Location = new System.Drawing.Point(634, 115);
            this.btnClearList.Name = "btnClearList";
            this.btnClearList.Size = new System.Drawing.Size(75, 23);
            this.btnClearList.TabIndex = 1;
            this.btnClearList.Text = "Limpiar";
            this.btnClearList.UseVisualStyleBackColor = true;
            this.btnClearList.Click += new System.EventHandler(this.btnClearList_Click);
            // 
            // btnExit
            // 
            this.btnExit.Location = new System.Drawing.Point(373, 203);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(75, 23);
            this.btnExit.TabIndex = 2;
            this.btnExit.Text = "Salir";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // btnCalculate
            // 
            this.btnCalculate.Location = new System.Drawing.Point(578, 157);
            this.btnCalculate.Name = "btnCalculate";
            this.btnCalculate.Size = new System.Drawing.Size(75, 23);
            this.btnCalculate.TabIndex = 3;
            this.btnCalculate.Text = "Calcular";
            this.btnCalculate.UseVisualStyleBackColor = true;
            this.btnCalculate.Click += new System.EventHandler(this.btnCalculate_Click);
            // 
            // lstWarehouse
            // 
            this.lstWarehouse.Location = new System.Drawing.Point(361, 69);
            this.lstWarehouse.Name = "lstWarehouse";
            this.lstWarehouse.Size = new System.Drawing.Size(173, 121);
            this.lstWarehouse.TabIndex = 3;
            // 
            // lblCountingItems
            // 
            this.lblCountingItems.Location = new System.Drawing.Point(454, 203);
            this.lblCountingItems.Name = "lblCountingItems";
            this.lblCountingItems.Size = new System.Drawing.Size(100, 23);
            this.lblCountingItems.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(553, 203);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(100, 23);
            this.label1.TabIndex = 1;
            // 
            // txtAddValue
            // 
            this.txtAddValue.Location = new System.Drawing.Point(540, 89);
            this.txtAddValue.Name = "txtAddValue";
            this.txtAddValue.Size = new System.Drawing.Size(100, 20);
            this.txtAddValue.TabIndex = 0;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(540, 69);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(73, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Agregar valor:";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.ClientSize = new System.Drawing.Size(766, 427);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtAddValue);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lblCountingItems);
            this.Controls.Add(this.lstWarehouse);
            this.Controls.Add(this.btnCalculate);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.btnClearList);
            this.Controls.Add(this.btnAddValue);
            this.Name = "Form1";
            this.Text = "Gestión de Valores";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnAddValue;
        private System.Windows.Forms.Button btnClearList;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.Button btnCalculate;
        private System.Windows.Forms.ListBox lstWarehouse;
        private System.Windows.Forms.Label lblCountingItems;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtAddValue;
        private Label label2;
    }
}
