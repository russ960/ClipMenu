namespace ClipMenu
{
    partial class AppComponent
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.tray = new System.Windows.Forms.NotifyIcon(this.components);
            this.trayMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.miEmpty = new System.Windows.Forms.ToolStripMenuItem();
            this.listEndSeparator = new System.Windows.Forms.ToolStripSeparator();
            this.miAddItem = new System.Windows.Forms.ToolStripMenuItem();
            this.miRemoveItems = new System.Windows.Forms.ToolStripMenuItem();
            this.miFileMgmt = new System.Windows.Forms.ToolStripMenuItem();
            //this.miFileMgmtEdit = new System.Windows.Forms.ToolStripMenuItem();
            //this.miFileMgmtReload = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.miFileMgmtBackup = new System.Windows.Forms.ToolStripMenuItem();
            this.miFileMgmtRestore = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.miExit = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.miCancel = new System.Windows.Forms.ToolStripMenuItem();
            this.trayMenu.SuspendLayout();
            // 
            // tray
            // 
            this.tray.ContextMenuStrip = this.trayMenu;
            this.tray.Icon = global::ClipMenu.Properties.Resources.TrayIcon;
            this.tray.Text = "ClipMenu";
            this.tray.Visible = true;
            this.tray.Click += new System.EventHandler(this.tray_Click);
            // 
            // trayMenu
            // 
            this.trayMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.miEmpty,
            this.listEndSeparator,
            this.miAddItem,
            this.miRemoveItems,
            this.miFileMgmt,
            this.toolStripSeparator1,
            this.miExit,
            this.toolStripSeparator2,
            this.miCancel});
            this.trayMenu.Name = "trayMenu";
            this.trayMenu.Size = new System.Drawing.Size(167, 154);
            // 
            // miEmpty
            // 
            this.miEmpty.Enabled = false;
            this.miEmpty.Name = "miEmpty";
            this.miEmpty.Size = new System.Drawing.Size(166, 22);
            this.miEmpty.Text = "(empty)";
            // 
            // listEndSeparator
            // 
            this.listEndSeparator.Name = "listEndSeparator";
            this.listEndSeparator.Size = new System.Drawing.Size(163, 6);
            // 
            // miAddItem
            // 
            this.miAddItem.Image = global::ClipMenu.Properties.Resources.add;
            this.miAddItem.Name = "miAddItem";
            this.miAddItem.Size = new System.Drawing.Size(166, 22);
            this.miAddItem.Text = "Add Item...";
            // 
            // miRemoveItems
            // 
            this.miRemoveItems.Image = global::ClipMenu.Properties.Resources.delete;
            this.miRemoveItems.Name = "miRemoveItems";
            this.miRemoveItems.Size = new System.Drawing.Size(166, 22);
            this.miRemoveItems.Text = "&Remove Items...";
            // 
            // miFileMgmt
            // 
            this.miFileMgmt.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            //this.miFileMgmtEdit,
            //this.miFileMgmtReload,
            this.toolStripSeparator3,
            this.miFileMgmtBackup,
            this.miFileMgmtRestore});
            this.miFileMgmt.Name = "miFileMgmt";
            this.miFileMgmt.Size = new System.Drawing.Size(166, 22);
            this.miFileMgmt.Text = "Database Management";
            // 
            // miFileMgmtEdit
            // 
            //this.miFileMgmtEdit.Image = global::ClipMenu.Properties.Resources.page_edit;
            //this.miFileMgmtEdit.Name = "miFileMgmtEdit";
            //this.miFileMgmtEdit.Size = new System.Drawing.Size(122, 22);
            //this.miFileMgmtEdit.Text = "&Edit";
            // 
            // miFileMgmtReload
            // 
            //this.miFileMgmtReload.Image = global::ClipMenu.Properties.Resources.page_refresh;
            //this.miFileMgmtReload.Name = "miFileMgmtReload";
            //this.miFileMgmtReload.Size = new System.Drawing.Size(122, 22);
            //this.miFileMgmtReload.Text = "Re&load";
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(119, 6);
            // 
            // miFileMgmtBackup
            // 
            this.miFileMgmtBackup.Image = global::ClipMenu.Properties.Resources.database_go;
            this.miFileMgmtBackup.Name = "miFileMgmtBackup";
            this.miFileMgmtBackup.Size = new System.Drawing.Size(122, 22);
            this.miFileMgmtBackup.Text = "&Backup";
            // 
            // miFileMgmtRestore
            // 
            this.miFileMgmtRestore.Image = global::ClipMenu.Properties.Resources.database_refresh;
            this.miFileMgmtRestore.Name = "miFileMgmtRestore";
            this.miFileMgmtRestore.Size = new System.Drawing.Size(122, 22);
            this.miFileMgmtRestore.Text = "&Restore...";
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(163, 6);
            // 
            // miExit
            // 
            this.miExit.Name = "miExit";
            this.miExit.Size = new System.Drawing.Size(166, 22);
            this.miExit.Text = "E&xit";
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(163, 6);
            // 
            // miCancel
            // 
            this.miCancel.Name = "miCancel";
            this.miCancel.Size = new System.Drawing.Size(166, 22);
            this.miCancel.Text = "- Cancel -";
            this.trayMenu.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.NotifyIcon tray;
        private System.Windows.Forms.ContextMenuStrip trayMenu;
        private System.Windows.Forms.ToolStripSeparator listEndSeparator;
        private System.Windows.Forms.ToolStripMenuItem miAddItem;
        private System.Windows.Forms.ToolStripMenuItem miRemoveItems;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem miExit;
        private System.Windows.Forms.ToolStripMenuItem miEmpty;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem miCancel;
        private System.Windows.Forms.ToolStripMenuItem miFileMgmt;
        //private System.Windows.Forms.ToolStripMenuItem miFileMgmtEdit;
        private System.Windows.Forms.ToolStripMenuItem miFileMgmtReload;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripMenuItem miFileMgmtBackup;
        private System.Windows.Forms.ToolStripMenuItem miFileMgmtRestore;
    }
}
