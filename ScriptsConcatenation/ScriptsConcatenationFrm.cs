using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ScriptsConcatenation
{
    public partial class ScriptsConcatenationFrm : Form
    {
        public ScriptsConcatenationFrm()
        {
            InitializeComponent();
        }

        private void btnBrowse_Click(object sender, EventArgs e)
        {
            if (ScriptsBrowser.ShowDialog(this) == DialogResult.OK)
            {
                string[] scripts = ScriptsBrowser.FileNames;
                foreach (string s in scripts)
                {
                    if (s == scripts[0])
                    {
                        ScriptsPath.AppendText(s);
                    } 
                    else
                    {
                        ScriptsPath.AppendText(" | " + s);
                    }
                    
                }
                
            }
        }
    }
}
