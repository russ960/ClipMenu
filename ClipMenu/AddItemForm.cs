﻿using System;
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
    public partial class AddItemForm : Form
    {
        public AddItemForm()
        {
            InitializeComponent();
        }

        private void AddItemForm_Load(object sender, EventArgs e)
        {
            string clipboardText = Clipboard.GetText();
            if (!clipboardText.Contains('\n')) {
                itemText.Text = clipboardText;
                itemText.SelectAll();
            }
        }

        /// <summary>
        /// Displays a new AddItemForm to the user as a modal dialog box prompting for a string.
        /// </summary>
        /// <returns>The string the user entered, or null if the user pressed Cancel.</returns>
        public static Dictionary<string,string> AskForText()
        {
            AddItemForm form = new AddItemForm();
            if (form.ShowDialog() == DialogResult.OK)
            {
                Dictionary<string, string> formItem = new Dictionary<string, string>();
                formItem.Add(form.itemText.Text, form.itemName.Text);
                return formItem;

            }
            else
            {
                return null;
            }

            /* Code to be removed Start
            AddItemForm form = new AddItemForm();
            if (form.ShowDialog() == DialogResult.OK) {
                return form.itemText.Text;
            } else {
                return null;
            }
            Code to be removed End */
        }

        private void itemText_TextChanged(object sender, EventArgs e)
        {
            ok.Enabled = !itemText.Text.Equals("");
        }
    }
}
