using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace ClipMenu
{
    public partial class AppComponent : Component
    {
        private const string ITEM_LIST_FILENAME = "ClipMenuItems.txt";
        private const string ITEM_LIST_BACKUP_FILENAME = "ClipMenuItems.bak";

        private SavedItemList itemList = new SavedItemList(ITEM_LIST_FILENAME);
        
        public AppComponent()
        {
            InitializeComponent();
            Initialize();
        }

        public AppComponent(IContainer container)
        {
            container.Add(this);
            InitializeComponent();
            Initialize();
        }

        private void Initialize()
        {
            miAddItem.Click += miAddItem_Click;
            miRemoveItems.Click += miRemoveItems_Click;
            miExit.Click += miExit_Click;
            miFileMgmtEdit.Click += miFileMgmtEdit_Click;
            miFileMgmtReload.Click += miFileMgmtReload_Click;
            miFileMgmtBackup.Click += miFileMgmtBackup_Click;
            miFileMgmtRestore.Click += miFileMgmtRestore_Click;

            BuildMenu(itemList);
        }

        void miFileMgmtRestore_Click(object sender, EventArgs e)
        {
            if (File.Exists(ITEM_LIST_BACKUP_FILENAME)) {
                string msg = "Are you sure you want to restore from your backup?\r\nYou will lose any changes you have made since then.";
                if (MessageBox.Show(msg, "Restore", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button2) == DialogResult.Yes) {
                    File.Delete(ITEM_LIST_FILENAME);
                    File.Copy(ITEM_LIST_BACKUP_FILENAME, ITEM_LIST_FILENAME);
                    itemList.Reload();
                    BuildMenu(itemList);
                }
            } else {
                string msg = "Backup does not exist. Select File Management->Backup to create one.";
                MessageBox.Show(msg, "Restore", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        void miFileMgmtBackup_Click(object sender, EventArgs e)
        {
            if (File.Exists(ITEM_LIST_BACKUP_FILENAME)) File.Delete(ITEM_LIST_BACKUP_FILENAME);
            File.Copy(ITEM_LIST_FILENAME, ITEM_LIST_BACKUP_FILENAME);
        }

        void miFileMgmtReload_Click(object sender, EventArgs e)
        {
            itemList.Reload();
            BuildMenu(itemList);
        }

        void miFileMgmtEdit_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start(ITEM_LIST_FILENAME);
        }

        void miExit_Click(object sender, EventArgs e)
        {
            string msg = "Are you sure you want to exit?\r\nThis will stop the tray icon from being shown.";
            if (MessageBox.Show(msg, "ClipMenu", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2) == DialogResult.Yes) {
                tray.Visible = false; // To avoid that problem where the tray icon remains until you put the mouse over it.
                Application.Exit();
            }
        }

        void miRemoveItems_Click(object sender, EventArgs e)
        {
            RemoveItemsForm.ShowDialog(itemList);
            BuildMenu(itemList);
        }

        void miAddItem_Click(object sender, EventArgs e)
        {
            itemList.Add(AddItemForm.AskForText());
            BuildMenu(itemList);
        }

        private void CopyItemText(object sender, EventArgs e)
        {
            Clipboard.SetText(((ToolStripMenuItem)sender).Text);
        }

        private void BuildMenu(IEnumerable<string> list)
        {
            // First, remove all the menu items before the "(empty)" item.
            while (trayMenu.Items[0] != miEmpty) {
                trayMenu.Items.RemoveAt(0);
            }

            // Then, create a new menu item for each saved string.
            bool empty = true;
            int i = 0;
            foreach (string s in list) {
                empty = false;
                ToolStripMenuItem item = new ToolStripMenuItem(s);
                item.Image = Properties.Resources.page_copy;
                item.Click += new EventHandler(CopyItemText);
                trayMenu.Items.Insert(i, item);
                i++;
            }

            miEmpty.Visible = empty;
            miRemoveItems.Enabled = !empty;
        }

        private void tray_Click(object sender, EventArgs e)
        {
            tray.ContextMenuStrip.Show(Cursor.Position);
        }
    }
}
