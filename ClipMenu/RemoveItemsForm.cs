using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ClipMenu
{
    public partial class RemoveItemsForm : Form
    {
        public RemoveItemsForm()
        {
            InitializeComponent();
        }

        private void selectAll_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < checkList.Items.Count; i++) {
                checkList.SetItemChecked(i, true);
            }
        }

        private void selectNone_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < checkList.Items.Count; i++) {
                checkList.SetItemChecked(i, false);
            }
        }

        public static void ShowDialog(ICollection<string> itemList)
        {
            RemoveItemsForm form = new RemoveItemsForm();
            foreach (string s in itemList) {
                form.checkList.Items.Add(s);
            }

            if (form.ShowDialog() == DialogResult.OK) {
                for (int i = 0; i < form.checkList.Items.Count; i++) {
                    if (form.checkList.GetItemChecked(i)) {
                        itemList.Remove((string)form.checkList.Items[i]);
                    }
                }
            }
        }
    }
}
