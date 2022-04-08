using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace ScriptsConcatenation
{
    public partial class ScriptsConcatenationFrm : Form
    {

        private ScriptManager _scriptManager;

        public ScriptsConcatenationFrm() 
        {
            InitializeComponent();
            _scriptManager = new ScriptManager();
        }

        private void BtnBrowse_Click(object sender, EventArgs e)
        {
            if (ScriptsBrowser.ShowDialog(this) == DialogResult.OK)
            {
                AddScriptsToListView();
            }
            EnableButtons();
        }


        private void EnableButtons()
        {
            this.BtnDelete.Enabled = true;
            this.BtnConcat.Enabled = true;
        }

        private void AddScriptsToListView()
        {
            _scriptManager.AddScript(this.ScriptsBrowser.FileNames);
            foreach (string scriptName in ScriptsBrowser.SafeFileNames)
            {
                ScriptsList.Items.Add(scriptName);
            }
        }

        private void BtnDelete_Click(object sender, EventArgs e)
        {
            if (ScriptsList.SelectedItems.Count > 0)
            {
                DeleteSelectedElements();
            } 
            else
            {
                MessageBox.Show("Select at least one item in the list to delete it");
            }
            DisableDeleteConcatButtonWhenListDontHaveElements();
        }

        private void DisableDeleteConcatButtonWhenListDontHaveElements()
        {
            if (ScriptsList.Items.Count == 0)
            {
                BtnDelete.Enabled = false;
                BtnConcat.Enabled = false;
            }
        }

        private void DeleteSelectedElements()
        {
            foreach (ListViewItem listViewItem in ScriptsList.SelectedItems)
            {
                Script script = new Script
                {
                    ScriptName = listViewItem.Text
                };
                listViewItem.Remove();
                _scriptManager.DeleteSelectedItemsFromScriptList(script);
                
            }
        }

        private void BtnConcat_Click(object sender, EventArgs e)
        {
            _scriptManager.ConcatScripts();
            BtnDownload.Enabled = true;
            MessageBox.Show("Scripts concated succesfully");
        }

        private void BtnDownload_Click(object sender, EventArgs e)
        {
            if (FolderBrowser.ShowDialog() == DialogResult.OK)
            {
                DownloadScript();
            } 
            else
            {
                MessageBox.Show("You must choose a folder");
            }
        }

        private void DownloadScript()
        {
            File.WriteAllText(FolderBrowser.SelectedPath, _scriptManager.ScriptConcated.ScriptContent);
        }
    }
}
