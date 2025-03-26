namespace Opciones
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.mnMain = new System.Windows.Forms.MenuStrip();
            this.mnMainFile = new System.Windows.Forms.ToolStripMenuItem();
            this.mnFileNew = new System.Windows.Forms.ToolStripMenuItem();
            this.mnFileOpen = new System.Windows.Forms.ToolStripMenuItem();
            this.mnFileSave = new System.Windows.Forms.ToolStripMenuItem();
            this.mnFileClose = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.mnFileExit = new System.Windows.Forms.ToolStripMenuItem();
            this.mnMainEdit = new System.Windows.Forms.ToolStripMenuItem();
            this.mnEditCopy = new System.Windows.Forms.ToolStripMenuItem();
            this.mnEditPaste = new System.Windows.Forms.ToolStripMenuItem();
            this.mnEditCut = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.mnEditSelectAll = new System.Windows.Forms.ToolStripMenuItem();
            this.mnMainView = new System.Windows.Forms.ToolStripMenuItem();
            this.mnViewAumentar = new System.Windows.Forms.ToolStripMenuItem();
            this.mnViewDisminuir = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.mnViewZoom = new System.Windows.Forms.ToolStripMenuItem();
            this.mnMainHelp = new System.Windows.Forms.ToolStripMenuItem();
            this.mnHelpManual = new System.Windows.Forms.ToolStripMenuItem();
            this.mnHelpAcercaDe = new System.Windows.Forms.ToolStripMenuItem();
            this.toolMain = new System.Windows.Forms.ToolStrip();
            this.tmFileNew = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton2 = new System.Windows.Forms.ToolStripButton();
            this.tmFileSave = new System.Windows.Forms.ToolStripButton();
            this.tmEditCopy = new System.Windows.Forms.ToolStripButton();
            this.tmFilePaste = new System.Windows.Forms.ToolStripButton();
            this.tmFileCut = new System.Windows.Forms.ToolStripButton();
            this.statusMain = new System.Windows.Forms.StatusStrip();
            this.tmFileOpen = new System.Windows.Forms.RichTextBox();
            this.tmViewAumentar = new System.Windows.Forms.ToolStripButton();
            this.tmViewDisminuir = new System.Windows.Forms.ToolStripButton();
            this.tmViewZoom = new System.Windows.Forms.ToolStripButton();
            this.tmDeshacer = new System.Windows.Forms.ToolStripButton();
            this.tmRehacer = new System.Windows.Forms.ToolStripButton();
            this.mnMain.SuspendLayout();
            this.toolMain.SuspendLayout();
            this.SuspendLayout();
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(61, 4);
            // 
            // mnMain
            // 
            this.mnMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnMainFile,
            this.mnMainEdit,
            this.mnMainView,
            this.mnMainHelp});
            this.mnMain.Location = new System.Drawing.Point(0, 0);
            this.mnMain.Name = "mnMain";
            this.mnMain.Size = new System.Drawing.Size(515, 24);
            this.mnMain.TabIndex = 1;
            this.mnMain.Text = "menuStrip1";
            // 
            // mnMainFile
            // 
            this.mnMainFile.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnFileNew,
            this.mnFileOpen,
            this.mnFileSave,
            this.mnFileClose,
            this.toolStripSeparator1,
            this.mnFileExit});
            this.mnMainFile.Name = "mnMainFile";
            this.mnMainFile.Size = new System.Drawing.Size(60, 20);
            this.mnMainFile.Text = "Archivo";
            // 
            // mnFileNew
            // 
            this.mnFileNew.Image = ((System.Drawing.Image)(resources.GetObject("mnFileNew.Image")));
            this.mnFileNew.Name = "mnFileNew";
            this.mnFileNew.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.N)));
            this.mnFileNew.Size = new System.Drawing.Size(156, 22);
            this.mnFileNew.Text = "Nuevo";
            // 
            // mnFileOpen
            // 
            this.mnFileOpen.Image = ((System.Drawing.Image)(resources.GetObject("mnFileOpen.Image")));
            this.mnFileOpen.Name = "mnFileOpen";
            this.mnFileOpen.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.O)));
            this.mnFileOpen.Size = new System.Drawing.Size(156, 22);
            this.mnFileOpen.Text = "Abrir";
            // 
            // mnFileSave
            // 
            this.mnFileSave.Image = ((System.Drawing.Image)(resources.GetObject("mnFileSave.Image")));
            this.mnFileSave.Name = "mnFileSave";
            this.mnFileSave.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.S)));
            this.mnFileSave.Size = new System.Drawing.Size(156, 22);
            this.mnFileSave.Text = "Guardar";
            // 
            // mnFileClose
            // 
            this.mnFileClose.Image = ((System.Drawing.Image)(resources.GetObject("mnFileClose.Image")));
            this.mnFileClose.Name = "mnFileClose";
            this.mnFileClose.Size = new System.Drawing.Size(156, 22);
            this.mnFileClose.Text = "Cerrar";
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(153, 6);
            // 
            // mnFileExit
            // 
            this.mnFileExit.Image = ((System.Drawing.Image)(resources.GetObject("mnFileExit.Image")));
            this.mnFileExit.Name = "mnFileExit";
            this.mnFileExit.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Q)));
            this.mnFileExit.Size = new System.Drawing.Size(156, 22);
            this.mnFileExit.Text = "Salir";
            this.mnFileExit.Click += new System.EventHandler(this.mnFileExit_Click);
            // 
            // mnMainEdit
            // 
            this.mnMainEdit.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnEditCopy,
            this.mnEditPaste,
            this.mnEditCut,
            this.toolStripSeparator3,
            this.mnEditSelectAll});
            this.mnMainEdit.Name = "mnMainEdit";
            this.mnMainEdit.Size = new System.Drawing.Size(49, 20);
            this.mnMainEdit.Text = "Editar";
            // 
            // mnEditCopy
            // 
            this.mnEditCopy.Image = ((System.Drawing.Image)(resources.GetObject("mnEditCopy.Image")));
            this.mnEditCopy.Name = "mnEditCopy";
            this.mnEditCopy.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.C)));
            this.mnEditCopy.Size = new System.Drawing.Size(204, 22);
            this.mnEditCopy.Text = "Copiar";
            // 
            // mnEditPaste
            // 
            this.mnEditPaste.Image = ((System.Drawing.Image)(resources.GetObject("mnEditPaste.Image")));
            this.mnEditPaste.Name = "mnEditPaste";
            this.mnEditPaste.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.V)));
            this.mnEditPaste.Size = new System.Drawing.Size(204, 22);
            this.mnEditPaste.Text = "Pegar";
            // 
            // mnEditCut
            // 
            this.mnEditCut.Image = ((System.Drawing.Image)(resources.GetObject("mnEditCut.Image")));
            this.mnEditCut.Name = "mnEditCut";
            this.mnEditCut.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.X)));
            this.mnEditCut.Size = new System.Drawing.Size(204, 22);
            this.mnEditCut.Text = "Cortar";
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(201, 6);
            // 
            // mnEditSelectAll
            // 
            this.mnEditSelectAll.Image = ((System.Drawing.Image)(resources.GetObject("mnEditSelectAll.Image")));
            this.mnEditSelectAll.Name = "mnEditSelectAll";
            this.mnEditSelectAll.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.A)));
            this.mnEditSelectAll.Size = new System.Drawing.Size(204, 22);
            this.mnEditSelectAll.Text = "Seleccionar todo";
            // 
            // mnMainView
            // 
            this.mnMainView.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnViewAumentar,
            this.mnViewDisminuir,
            this.toolStripSeparator2,
            this.mnViewZoom});
            this.mnMainView.Name = "mnMainView";
            this.mnMainView.Size = new System.Drawing.Size(35, 20);
            this.mnMainView.Text = "Ver";
            // 
            // mnViewAumentar
            // 
            this.mnViewAumentar.Image = ((System.Drawing.Image)(resources.GetObject("mnViewAumentar.Image")));
            this.mnViewAumentar.Name = "mnViewAumentar";
            this.mnViewAumentar.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Oemplus)));
            this.mnViewAumentar.Size = new System.Drawing.Size(218, 22);
            this.mnViewAumentar.Text = "Aumentar";
            // 
            // mnViewDisminuir
            // 
            this.mnViewDisminuir.Image = ((System.Drawing.Image)(resources.GetObject("mnViewDisminuir.Image")));
            this.mnViewDisminuir.Name = "mnViewDisminuir";
            this.mnViewDisminuir.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.OemMinus)));
            this.mnViewDisminuir.Size = new System.Drawing.Size(218, 22);
            this.mnViewDisminuir.Text = "Disminuir";
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(215, 6);
            // 
            // mnViewZoom
            // 
            this.mnViewZoom.Image = ((System.Drawing.Image)(resources.GetObject("mnViewZoom.Image")));
            this.mnViewZoom.Name = "mnViewZoom";
            this.mnViewZoom.Size = new System.Drawing.Size(218, 22);
            this.mnViewZoom.Text = "Zoom";
            // 
            // mnMainHelp
            // 
            this.mnMainHelp.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnHelpManual,
            this.mnHelpAcercaDe});
            this.mnMainHelp.Name = "mnMainHelp";
            this.mnMainHelp.Size = new System.Drawing.Size(53, 20);
            this.mnMainHelp.Text = "Ayuda";
            // 
            // mnHelpManual
            // 
            this.mnHelpManual.Image = ((System.Drawing.Image)(resources.GetObject("mnHelpManual.Image")));
            this.mnHelpManual.Name = "mnHelpManual";
            this.mnHelpManual.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.F1)));
            this.mnHelpManual.Size = new System.Drawing.Size(180, 22);
            this.mnHelpManual.Text = "Manual";
            // 
            // mnHelpAcercaDe
            // 
            this.mnHelpAcercaDe.Image = ((System.Drawing.Image)(resources.GetObject("mnHelpAcercaDe.Image")));
            this.mnHelpAcercaDe.Name = "mnHelpAcercaDe";
            this.mnHelpAcercaDe.Size = new System.Drawing.Size(180, 22);
            this.mnHelpAcercaDe.Text = "Acerca de...";
            // 
            // toolMain
            // 
            this.toolMain.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.toolMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tmFileNew,
            this.toolStripButton2,
            this.tmFileSave,
            this.tmEditCopy,
            this.tmFilePaste,
            this.tmFileCut,
            this.tmViewAumentar,
            this.tmViewDisminuir,
            this.tmViewZoom,
            this.tmDeshacer,
            this.tmRehacer});
            this.toolMain.Location = new System.Drawing.Point(0, 24);
            this.toolMain.Name = "toolMain";
            this.toolMain.Size = new System.Drawing.Size(515, 25);
            this.toolMain.TabIndex = 2;
            this.toolMain.Text = "toolStrip1";
            // 
            // tmFileNew
            // 
            this.tmFileNew.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tmFileNew.Image = ((System.Drawing.Image)(resources.GetObject("tmFileNew.Image")));
            this.tmFileNew.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tmFileNew.Name = "tmFileNew";
            this.tmFileNew.Size = new System.Drawing.Size(23, 22);
            this.tmFileNew.Text = "toolStripButton1";
            // 
            // toolStripButton2
            // 
            this.toolStripButton2.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton2.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton2.Image")));
            this.toolStripButton2.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton2.Name = "toolStripButton2";
            this.toolStripButton2.Size = new System.Drawing.Size(23, 22);
            this.toolStripButton2.Text = "toolStripButton2";
            // 
            // tmFileSave
            // 
            this.tmFileSave.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tmFileSave.Image = ((System.Drawing.Image)(resources.GetObject("tmFileSave.Image")));
            this.tmFileSave.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tmFileSave.Name = "tmFileSave";
            this.tmFileSave.Size = new System.Drawing.Size(23, 22);
            this.tmFileSave.Text = "toolStripButton3";
            // 
            // tmEditCopy
            // 
            this.tmEditCopy.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tmEditCopy.Image = ((System.Drawing.Image)(resources.GetObject("tmEditCopy.Image")));
            this.tmEditCopy.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tmEditCopy.Name = "tmEditCopy";
            this.tmEditCopy.Size = new System.Drawing.Size(23, 22);
            this.tmEditCopy.Text = "toolStripButton4";
            // 
            // tmFilePaste
            // 
            this.tmFilePaste.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tmFilePaste.Image = ((System.Drawing.Image)(resources.GetObject("tmFilePaste.Image")));
            this.tmFilePaste.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tmFilePaste.Name = "tmFilePaste";
            this.tmFilePaste.Size = new System.Drawing.Size(23, 22);
            this.tmFilePaste.Text = "toolStripButton5";
            // 
            // tmFileCut
            // 
            this.tmFileCut.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tmFileCut.Image = ((System.Drawing.Image)(resources.GetObject("tmFileCut.Image")));
            this.tmFileCut.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tmFileCut.Name = "tmFileCut";
            this.tmFileCut.Size = new System.Drawing.Size(23, 22);
            this.tmFileCut.Text = "toolStripButton6";
            // 
            // statusMain
            // 
            this.statusMain.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.statusMain.Location = new System.Drawing.Point(0, 255);
            this.statusMain.Name = "statusMain";
            this.statusMain.Size = new System.Drawing.Size(515, 22);
            this.statusMain.TabIndex = 3;
            this.statusMain.Text = "statusStrip1";
            // 
            // tmFileOpen
            // 
            this.tmFileOpen.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tmFileOpen.Location = new System.Drawing.Point(0, 52);
            this.tmFileOpen.Name = "tmFileOpen";
            this.tmFileOpen.Size = new System.Drawing.Size(515, 200);
            this.tmFileOpen.TabIndex = 4;
            this.tmFileOpen.Text = "";
            // 
            // tmViewAumentar
            // 
            this.tmViewAumentar.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tmViewAumentar.Image = ((System.Drawing.Image)(resources.GetObject("tmViewAumentar.Image")));
            this.tmViewAumentar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tmViewAumentar.Name = "tmViewAumentar";
            this.tmViewAumentar.Size = new System.Drawing.Size(23, 22);
            this.tmViewAumentar.Text = "toolStripButton1";
            // 
            // tmViewDisminuir
            // 
            this.tmViewDisminuir.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tmViewDisminuir.Image = ((System.Drawing.Image)(resources.GetObject("tmViewDisminuir.Image")));
            this.tmViewDisminuir.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tmViewDisminuir.Name = "tmViewDisminuir";
            this.tmViewDisminuir.Size = new System.Drawing.Size(23, 22);
            this.tmViewDisminuir.Text = "toolStripButton1";
            // 
            // tmViewZoom
            // 
            this.tmViewZoom.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tmViewZoom.Image = ((System.Drawing.Image)(resources.GetObject("tmViewZoom.Image")));
            this.tmViewZoom.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tmViewZoom.Name = "tmViewZoom";
            this.tmViewZoom.Size = new System.Drawing.Size(23, 22);
            this.tmViewZoom.Text = "toolStripButton1";
            // 
            // tmDeshacer
            // 
            this.tmDeshacer.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tmDeshacer.Image = ((System.Drawing.Image)(resources.GetObject("tmDeshacer.Image")));
            this.tmDeshacer.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tmDeshacer.Name = "tmDeshacer";
            this.tmDeshacer.Size = new System.Drawing.Size(23, 22);
            this.tmDeshacer.Text = "toolStripButton1";
            // 
            // tmRehacer
            // 
            this.tmRehacer.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tmRehacer.Image = ((System.Drawing.Image)(resources.GetObject("tmRehacer.Image")));
            this.tmRehacer.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tmRehacer.Name = "tmRehacer";
            this.tmRehacer.Size = new System.Drawing.Size(23, 22);
            this.tmRehacer.Text = "toolStripButton1";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(515, 277);
            this.Controls.Add(this.tmFileOpen);
            this.Controls.Add(this.statusMain);
            this.Controls.Add(this.toolMain);
            this.Controls.Add(this.mnMain);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.mnMain;
            this.Name = "Form1";
            this.Text = "Opciones";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.mnMain.ResumeLayout(false);
            this.mnMain.PerformLayout();
            this.toolMain.ResumeLayout(false);
            this.toolMain.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
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
        private System.Windows.Forms.RichTextBox tmFileOpen;
        private System.Windows.Forms.ToolStripButton tmFileNew;
        private System.Windows.Forms.ToolStripButton toolStripButton2;
        private System.Windows.Forms.ToolStripButton tmFileSave;
        private System.Windows.Forms.ToolStripButton tmEditCopy;
        private System.Windows.Forms.ToolStripButton tmFilePaste;
        private System.Windows.Forms.ToolStripButton tmFileCut;
        private System.Windows.Forms.ToolStripButton tmViewAumentar;
        private System.Windows.Forms.ToolStripButton tmViewDisminuir;
        private System.Windows.Forms.ToolStripButton tmViewZoom;
        private System.Windows.Forms.ToolStripButton tmDeshacer;
        private System.Windows.Forms.ToolStripButton tmRehacer;
    }
}

