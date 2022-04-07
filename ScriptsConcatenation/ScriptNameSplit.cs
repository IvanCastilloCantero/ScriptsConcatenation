using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScriptsConcatenation
{
    public class ScriptNameSplit
    {
        public string NScript { get; set; }
        public string NVersion { get; set; }
        public string ScriptName { get; set; }

        public ScriptNameSplit()
        {

        }

        public ScriptNameSplit(string nScript, string scriptName)
        {
            NScript = nScript;
            NVersion = null;
            ScriptName = scriptName;
        }

        public ScriptNameSplit(string nScript, string nVersion, string scriptName)
        {
            NScript = nScript;
            NVersion = nVersion;
            ScriptName = scriptName;
        }
        
    }
}
