using System;
using System.Windows.Forms;

namespace ScriptsConcatenation
{
    public partial class ScriptsConcatenationFrm : Form
    {
        private readonly ScriptManager _scriptManager;

        public ScriptsConcatenationFrm()
        {
            InitializeComponent();
            _scriptManager = new ScriptManager();
        }

        private void BtnAdd_Click(object sender, EventArgs e)
        {
            if (ScriptsBrowser.ShowDialog(this) == DialogResult.OK)
            {
                AddScriptsToListView();
            }
            if (_scriptManager.ScriptsNameIncorrect.Count > 0)
            {
                MessageBox.Show("The following scripts aren't in the correct format:" + _scriptManager.ShowScriptsWithIncorrectFormat());
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
            ScriptsList.Items.Clear();
            _scriptManager.AddScript(this.ScriptsBrowser.FileNames);
            foreach (Script script in _scriptManager.Scripts)
            {
                ScriptsList.Items.Add(script.ScriptNameComplete);
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
                    ScriptNameComplete = listViewItem.Text
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
                _scriptManager.WriteScript(FolderBrowser.SelectedPath);
                MessageBox.Show("Script downloaded in " + FolderBrowser.SelectedPath + "\\" + _scriptManager.ScriptConcated.ScriptNameComplete);
            }
            else
            {
                MessageBox.Show("You must choose a folder");
            }
        }
    }
}