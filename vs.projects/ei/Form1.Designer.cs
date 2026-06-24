namespace ei
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
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            mnMain = new MenuStrip();
            mnMainFile = new ToolStripMenuItem();
            mnFileNew = new ToolStripMenuItem();
            mnFileOpen = new ToolStripMenuItem();
            mnFileSave = new ToolStripMenuItem();
            mnFileClose = new ToolStripMenuItem();
            toolStripSeparator1 = new ToolStripSeparator();
            mnFilePrint = new ToolStripMenuItem();
            mnFileExit = new ToolStripMenuItem();
            mnMainEdit = new ToolStripMenuItem();
            mnEditCopy = new ToolStripMenuItem();
            mnEditPaste = new ToolStripMenuItem();
            mnEditCut = new ToolStripMenuItem();
            toolStripSeparator3 = new ToolStripSeparator();
            mnEditSelectAll = new ToolStripMenuItem();
            mnMainView = new ToolStripMenuItem();
            mnViewAumentar = new ToolStripMenuItem();
            mnViewDisminuir = new ToolStripMenuItem();
            toolStripSeparator2 = new ToolStripSeparator();
            mnViewZoom = new ToolStripMenuItem();
            mnMainHelp = new ToolStripMenuItem();
            mnHelpManual = new ToolStripMenuItem();
            mnHelpAcercaDe = new ToolStripMenuItem();
            toolMain = new ToolStrip();
            tmFileNew = new ToolStripButton();
            tmFileOpen = new ToolStripButton();
            tmFileSave = new ToolStripButton();
            tmFilePrint = new ToolStripButton();
            tmEditCopy = new ToolStripButton();
            tmFilePaste = new ToolStripButton();
            tmFileCut = new ToolStripButton();
            tmViewAumentar = new ToolStripButton();
            tmViewDisminuir = new ToolStripButton();
            tmViewZoom = new ToolStripButton();
            tmDeshacer = new ToolStripButton();
            tmRehacer = new ToolStripButton();
            statusMain = new StatusStrip();
            RichTextBox = new RichTextBox();
            saveFile = new SaveFileDialog();
            toolTip1 = new ToolTip(components);
            mnMain.SuspendLayout();
            toolMain.SuspendLayout();
            SuspendLayout();
            // 
            // mnMain
            // 
            mnMain.ImageScalingSize = new Size(32, 32);
            mnMain.Items.AddRange(new ToolStripItem[] { mnMainFile, mnMainEdit, mnMainView, mnMainHelp });
            mnMain.Location = new Point(0, 0);
            mnMain.Name = "mnMain";
            mnMain.Padding = new Padding(5, 3, 0, 3);
            mnMain.Size = new Size(759, 30);
            mnMain.TabIndex = 1;
            mnMain.Text = "menuStrip1";
            // 
            // mnMainFile
            // 
            mnMainFile.DropDownItems.AddRange(new ToolStripItem[] { mnFileNew, mnFileOpen, mnFileSave, mnFileClose, toolStripSeparator1, mnFilePrint, mnFileExit });
            mnMainFile.Name = "mnMainFile";
            mnMainFile.Size = new Size(73, 24);
            mnMainFile.Text = "Archivo";
            // 
            // mnFileNew
            // 
            mnFileNew.Image = (Image)resources.GetObject("mnFileNew.Image");
            mnFileNew.Name = "mnFileNew";
            mnFileNew.ShortcutKeys = Keys.Control | Keys.N;
            mnFileNew.Size = new Size(195, 26);
            mnFileNew.Text = "Nuevo";
            mnFileNew.Click += mnFileNew_Click;
            // 
            // mnFileOpen
            // 
            mnFileOpen.Image = (Image)resources.GetObject("mnFileOpen.Image");
            mnFileOpen.Name = "mnFileOpen";
            mnFileOpen.ShortcutKeys = Keys.Control | Keys.O;
            mnFileOpen.Size = new Size(195, 26);
            mnFileOpen.Text = "Abrir";
            mnFileOpen.Click += mnFileOpen_Click;
            // 
            // mnFileSave
            // 
            mnFileSave.Image = (Image)resources.GetObject("mnFileSave.Image");
            mnFileSave.Name = "mnFileSave";
            mnFileSave.ShortcutKeys = Keys.Control | Keys.S;
            mnFileSave.Size = new Size(195, 26);
            mnFileSave.Text = "Guardar";
            mnFileSave.Click += mnFileSave_Click;
            // 
            // mnFileClose
            // 
            mnFileClose.Image = (Image)resources.GetObject("mnFileClose.Image");
            mnFileClose.Name = "mnFileClose";
            mnFileClose.ShortcutKeys = Keys.Control | Keys.W;
            mnFileClose.Size = new Size(195, 26);
            mnFileClose.Text = "Cerrar";
            // 
            // toolStripSeparator1
            // 
            toolStripSeparator1.Name = "toolStripSeparator1";
            toolStripSeparator1.Size = new Size(192, 6);
            // 
            // mnFilePrint
            // 
            mnFilePrint.Image = (Image)resources.GetObject("mnFilePrint.Image");
            mnFilePrint.Name = "mnFilePrint";
            mnFilePrint.ShortcutKeys = Keys.Control | Keys.P;
            mnFilePrint.Size = new Size(195, 26);
            mnFilePrint.Text = "Inprimir";
            mnFilePrint.Click += mnFilePrint_Click;
            // 
            // mnFileExit
            // 
            mnFileExit.Image = (Image)resources.GetObject("mnFileExit.Image");
            mnFileExit.Name = "mnFileExit";
            mnFileExit.ShortcutKeys = Keys.Control | Keys.Q;
            mnFileExit.Size = new Size(195, 26);
            mnFileExit.Text = "Salir";
            mnFileExit.Click += mnFileExit_Click;
            // 
            // mnMainEdit
            // 
            mnMainEdit.DropDownItems.AddRange(new ToolStripItem[] { mnEditCopy, mnEditPaste, mnEditCut, toolStripSeparator3, mnEditSelectAll });
            mnMainEdit.Name = "mnMainEdit";
            mnMainEdit.Size = new Size(62, 24);
            mnMainEdit.Text = "Editar";
            // 
            // mnEditCopy
            // 
            mnEditCopy.Image = (Image)resources.GetObject("mnEditCopy.Image");
            mnEditCopy.Name = "mnEditCopy";
            mnEditCopy.ShortcutKeys = Keys.Control | Keys.C;
            mnEditCopy.Size = new Size(256, 26);
            mnEditCopy.Text = "Copiar";
            mnEditCopy.Click += mnEditCopy_Click;
            // 
            // mnEditPaste
            // 
            mnEditPaste.Image = (Image)resources.GetObject("mnEditPaste.Image");
            mnEditPaste.Name = "mnEditPaste";
            mnEditPaste.ShortcutKeys = Keys.Control | Keys.V;
            mnEditPaste.Size = new Size(256, 26);
            mnEditPaste.Text = "Pegar";
            mnEditPaste.Click += mnEditPaste_Click;
            // 
            // mnEditCut
            // 
            mnEditCut.Image = (Image)resources.GetObject("mnEditCut.Image");
            mnEditCut.Name = "mnEditCut";
            mnEditCut.ShortcutKeys = Keys.Control | Keys.X;
            mnEditCut.Size = new Size(256, 26);
            mnEditCut.Text = "Cortar";
            mnEditCut.Click += mnEditCut_Click;
            // 
            // toolStripSeparator3
            // 
            toolStripSeparator3.Name = "toolStripSeparator3";
            toolStripSeparator3.Size = new Size(253, 6);
            // 
            // mnEditSelectAll
            // 
            mnEditSelectAll.Image = (Image)resources.GetObject("mnEditSelectAll.Image");
            mnEditSelectAll.Name = "mnEditSelectAll";
            mnEditSelectAll.ShortcutKeys = Keys.Control | Keys.A;
            mnEditSelectAll.Size = new Size(256, 26);
            mnEditSelectAll.Text = "Seleccionar todo";
            mnEditSelectAll.Click += mnEditSelectAll_Click;
            // 
            // mnMainView
            // 
            mnMainView.DropDownItems.AddRange(new ToolStripItem[] { mnViewAumentar, mnViewDisminuir, toolStripSeparator2, mnViewZoom });
            mnMainView.Name = "mnMainView";
            mnMainView.Size = new Size(44, 24);
            mnMainView.Text = "Ver";
            // 
            // mnViewAumentar
            // 
            mnViewAumentar.Image = (Image)resources.GetObject("mnViewAumentar.Image");
            mnViewAumentar.Name = "mnViewAumentar";
            mnViewAumentar.ShortcutKeys = Keys.Control | Keys.Oemplus;
            mnViewAumentar.Size = new Size(268, 26);
            mnViewAumentar.Text = "Aumentar";
            mnViewAumentar.Click += mnViewAumentar_Click;
            // 
            // mnViewDisminuir
            // 
            mnViewDisminuir.Image = (Image)resources.GetObject("mnViewDisminuir.Image");
            mnViewDisminuir.Name = "mnViewDisminuir";
            mnViewDisminuir.ShortcutKeys = Keys.Control | Keys.OemMinus;
            mnViewDisminuir.Size = new Size(268, 26);
            mnViewDisminuir.Text = "Disminuir";
            mnViewDisminuir.Click += mnViewDisminuir_Click;
            // 
            // toolStripSeparator2
            // 
            toolStripSeparator2.Name = "toolStripSeparator2";
            toolStripSeparator2.Size = new Size(265, 6);
            // 
            // mnViewZoom
            // 
            mnViewZoom.Image = (Image)resources.GetObject("mnViewZoom.Image");
            mnViewZoom.Name = "mnViewZoom";
            mnViewZoom.Size = new Size(268, 26);
            mnViewZoom.Text = "Zoom";
            // 
            // mnMainHelp
            // 
            mnMainHelp.DropDownItems.AddRange(new ToolStripItem[] { mnHelpManual, mnHelpAcercaDe });
            mnMainHelp.Name = "mnMainHelp";
            mnMainHelp.Size = new Size(65, 24);
            mnMainHelp.Text = "Ayuda";
            // 
            // mnHelpManual
            // 
            mnHelpManual.Image = (Image)resources.GetObject("mnHelpManual.Image");
            mnHelpManual.Name = "mnHelpManual";
            mnHelpManual.ShortcutKeys = Keys.Control | Keys.F1;
            mnHelpManual.Size = new Size(236, 38);
            mnHelpManual.Text = "Manual";
            mnHelpManual.Click += mnHelpManual_Click;
            // 
            // mnHelpAcercaDe
            // 
            mnHelpAcercaDe.Image = (Image)resources.GetObject("mnHelpAcercaDe.Image");
            mnHelpAcercaDe.Name = "mnHelpAcercaDe";
            mnHelpAcercaDe.Size = new Size(236, 38);
            mnHelpAcercaDe.Text = "Acerca de...";
            mnHelpAcercaDe.Click += mnHelpAcercaDe_Click;
            // 
            // toolMain
            // 
            toolMain.BackColor = SystemColors.ActiveBorder;
            toolMain.ImageScalingSize = new Size(32, 32);
            toolMain.Items.AddRange(new ToolStripItem[] { tmFileNew, tmFileOpen, tmFileSave, tmFilePrint, tmEditCopy, tmFilePaste, tmFileCut, tmViewAumentar, tmViewDisminuir, tmViewZoom, tmDeshacer, tmRehacer });
            toolMain.Location = new Point(0, 30);
            toolMain.Name = "toolMain";
            toolMain.Padding = new Padding(0, 0, 3, 0);
            toolMain.Size = new Size(759, 39);
            toolMain.TabIndex = 2;
            toolMain.Text = "toolStrip1";
            // 
            // tmFileNew
            // 
            tmFileNew.DisplayStyle = ToolStripItemDisplayStyle.Image;
            tmFileNew.Image = (Image)resources.GetObject("tmFileNew.Image");
            tmFileNew.ImageTransparentColor = Color.Magenta;
            tmFileNew.Name = "tmFileNew";
            tmFileNew.Size = new Size(36, 36);
            tmFileNew.Text = "Nuevo";
            tmFileNew.ToolTipText = "Crear un nuevo documento";
            tmFileNew.Click += tmFileNew_Click;
            // 
            // tmFileOpen
            // 
            tmFileOpen.DisplayStyle = ToolStripItemDisplayStyle.Image;
            tmFileOpen.Image = (Image)resources.GetObject("tmFileOpen.Image");
            tmFileOpen.ImageTransparentColor = Color.Magenta;
            tmFileOpen.Name = "tmFileOpen";
            tmFileOpen.Size = new Size(36, 36);
            tmFileOpen.Text = "Abrir";
            tmFileOpen.Click += tmFileOpen_Click;
            // 
            // tmFileSave
            // 
            tmFileSave.DisplayStyle = ToolStripItemDisplayStyle.Image;
            tmFileSave.Image = (Image)resources.GetObject("tmFileSave.Image");
            tmFileSave.ImageTransparentColor = Color.Magenta;
            tmFileSave.Name = "tmFileSave";
            tmFileSave.Size = new Size(36, 36);
            tmFileSave.Text = "Guardar";
            tmFileSave.Click += tmFileSave_Click;
            // 
            // tmFilePrint
            // 
            tmFilePrint.DisplayStyle = ToolStripItemDisplayStyle.Image;
            tmFilePrint.Image = (Image)resources.GetObject("tmFilePrint.Image");
            tmFilePrint.ImageTransparentColor = Color.Magenta;
            tmFilePrint.Name = "tmFilePrint";
            tmFilePrint.Size = new Size(36, 36);
            tmFilePrint.Text = "Imprimir";
            tmFilePrint.Click += tmFilePrint_Click;
            // 
            // tmEditCopy
            // 
            tmEditCopy.DisplayStyle = ToolStripItemDisplayStyle.Image;
            tmEditCopy.Image = (Image)resources.GetObject("tmEditCopy.Image");
            tmEditCopy.ImageTransparentColor = Color.Magenta;
            tmEditCopy.Name = "tmEditCopy";
            tmEditCopy.Size = new Size(36, 36);
            tmEditCopy.Text = "Copiar";
            tmEditCopy.Click += tmEditCopy_Click;
            // 
            // tmFilePaste
            // 
            tmFilePaste.DisplayStyle = ToolStripItemDisplayStyle.Image;
            tmFilePaste.Image = (Image)resources.GetObject("tmFilePaste.Image");
            tmFilePaste.ImageTransparentColor = Color.Magenta;
            tmFilePaste.Name = "tmFilePaste";
            tmFilePaste.Size = new Size(36, 36);
            tmFilePaste.Text = "Pegar";
            tmFilePaste.Click += tmFilePaste_Click;
            // 
            // tmFileCut
            // 
            tmFileCut.DisplayStyle = ToolStripItemDisplayStyle.Image;
            tmFileCut.Image = (Image)resources.GetObject("tmFileCut.Image");
            tmFileCut.ImageTransparentColor = Color.Magenta;
            tmFileCut.Name = "tmFileCut";
            tmFileCut.Size = new Size(36, 36);
            tmFileCut.Text = "Cortar";
            tmFileCut.Click += tmFileCut_Click;
            // 
            // tmViewAumentar
            // 
            tmViewAumentar.DisplayStyle = ToolStripItemDisplayStyle.Image;
            tmViewAumentar.Image = (Image)resources.GetObject("tmViewAumentar.Image");
            tmViewAumentar.ImageTransparentColor = Color.Magenta;
            tmViewAumentar.Name = "tmViewAumentar";
            tmViewAumentar.Size = new Size(36, 36);
            tmViewAumentar.Text = "Aumentar";
            tmViewAumentar.Click += tmViewAumentar_Click;
            // 
            // tmViewDisminuir
            // 
            tmViewDisminuir.DisplayStyle = ToolStripItemDisplayStyle.Image;
            tmViewDisminuir.Image = (Image)resources.GetObject("tmViewDisminuir.Image");
            tmViewDisminuir.ImageTransparentColor = Color.Magenta;
            tmViewDisminuir.Name = "tmViewDisminuir";
            tmViewDisminuir.Size = new Size(36, 36);
            tmViewDisminuir.Text = "Disminuir";
            tmViewDisminuir.Click += tmViewDisminuir_Click;
            // 
            // tmViewZoom
            // 
            tmViewZoom.DisplayStyle = ToolStripItemDisplayStyle.Image;
            tmViewZoom.Image = (Image)resources.GetObject("tmViewZoom.Image");
            tmViewZoom.ImageTransparentColor = Color.Magenta;
            tmViewZoom.Name = "tmViewZoom";
            tmViewZoom.Size = new Size(36, 36);
            tmViewZoom.Text = "toolStripButton1";
            // 
            // tmDeshacer
            // 
            tmDeshacer.DisplayStyle = ToolStripItemDisplayStyle.Image;
            tmDeshacer.Image = (Image)resources.GetObject("tmDeshacer.Image");
            tmDeshacer.ImageTransparentColor = Color.Magenta;
            tmDeshacer.Name = "tmDeshacer";
            tmDeshacer.Size = new Size(36, 36);
            tmDeshacer.Text = "Deshacer";
            // 
            // tmRehacer
            // 
            tmRehacer.DisplayStyle = ToolStripItemDisplayStyle.Image;
            tmRehacer.Image = (Image)resources.GetObject("tmRehacer.Image");
            tmRehacer.ImageTransparentColor = Color.Magenta;
            tmRehacer.Name = "tmRehacer";
            tmRehacer.Size = new Size(36, 36);
            tmRehacer.Text = "Rehacer";
            // 
            // statusMain
            // 
            statusMain.BackColor = SystemColors.ActiveBorder;
            statusMain.ImageScalingSize = new Size(32, 32);
            statusMain.Location = new Point(0, 445);
            statusMain.Name = "statusMain";
            statusMain.Padding = new Padding(1, 0, 19, 0);
            statusMain.Size = new Size(759, 22);
            statusMain.TabIndex = 3;
            statusMain.Text = "statusStrip1";
            // 
            // RichTextBox
            // 
            RichTextBox.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            RichTextBox.BackColor = SystemColors.HighlightText;
            RichTextBox.ForeColor = SystemColors.WindowText;
            RichTextBox.Location = new Point(0, 89);
            RichTextBox.Margin = new Padding(5, 5, 5, 5);
            RichTextBox.Name = "RichTextBox";
            RichTextBox.Size = new Size(759, 363);
            RichTextBox.TabIndex = 4;
            RichTextBox.Text = "";
            // 
            // saveFile
            // 
            saveFile.DefaultExt = "*.rtf";
            saveFile.Title = "Guardar documento";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(759, 467);
            Controls.Add(RichTextBox);
            Controls.Add(statusMain);
            Controls.Add(toolMain);
            Controls.Add(mnMain);
            Icon = (Icon)resources.GetObject("$this.Icon");
            MainMenuStrip = mnMain;
            Margin = new Padding(5, 5, 5, 5);
            Name = "Form1";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "ei";
            FormClosing += Form1_FormClosing;
            mnMain.ResumeLayout(false);
            mnMain.PerformLayout();
            toolMain.ResumeLayout(false);
            toolMain.PerformLayout();
            ResumeLayout(false);
            PerformLayout();

        }

        #endregion
        private System.Windows.Forms.MenuStrip mnMain;
        private System.Windows.Forms.ToolStripMenuItem mnMainFile;
        private System.Windows.Forms.ToolStripMenuItem mnMainEdit;
        private System.Windows.Forms.ToolStripMenuItem mnMainView;
        private System.Windows.Forms.ToolStripMenuItem mnMainHelp;
        private System.Windows.Forms.ToolStripMenuItem mnFileExit;
        private System.Windows.Forms.ToolStripMenuItem mnFileOpen;
        private System.Windows.Forms.ToolStripMenuItem mnFileSave;
        private System.Windows.Forms.ToolStripMenuItem mnFileClose;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem mnEditCopy;
        private System.Windows.Forms.ToolStripMenuItem mnEditPaste;
        private System.Windows.Forms.ToolStripMenuItem mnEditCut;
        private System.Windows.Forms.ToolStripMenuItem mnEditSelectAll;
        private System.Windows.Forms.ToolStripMenuItem mnHelpManual;
        private System.Windows.Forms.ToolStripMenuItem mnHelpAcercaDe;
        private System.Windows.Forms.ToolStripMenuItem mnViewAumentar;
        private System.Windows.Forms.ToolStripMenuItem mnViewDisminuir;
        private System.Windows.Forms.ToolStripMenuItem mnViewZoom;
        private System.Windows.Forms.ToolStrip toolMain;
        private System.Windows.Forms.ToolStripMenuItem mnFileNew;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.StatusStrip statusMain;
        private System.Windows.Forms.RichTextBox RichTextBox;
        private System.Windows.Forms.ToolStripButton tmFileNew;
        private System.Windows.Forms.ToolStripButton tmFileOpen;
        private System.Windows.Forms.ToolStripButton tmFileSave;
        private System.Windows.Forms.ToolStripButton tmEditCopy;
        private System.Windows.Forms.ToolStripButton tmFilePaste;
        private System.Windows.Forms.ToolStripButton tmFileCut;
        private System.Windows.Forms.ToolStripButton tmViewAumentar;
        private System.Windows.Forms.ToolStripButton tmViewDisminuir;
        private System.Windows.Forms.ToolStripButton tmViewZoom;
        private System.Windows.Forms.ToolStripButton tmDeshacer;
        private System.Windows.Forms.ToolStripButton tmRehacer;
        private System.Windows.Forms.SaveFileDialog saveFile;
        private System.Windows.Forms.ToolTip toolTip1;
        private ToolStripMenuItem mnFilePrint;
        private ToolStripButton tmFilePrint;
    }
}

