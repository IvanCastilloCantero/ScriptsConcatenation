using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScriptsConcatenation
{
    public class Script
    {
        public string ScriptContent;
        public string ScriptName;

        public Script()
        {

        }

        public Script(string scripContent, String scriptName)
        {
            ScriptContent = scripContent;
            ScriptName = scriptName;
        }
    }
}
