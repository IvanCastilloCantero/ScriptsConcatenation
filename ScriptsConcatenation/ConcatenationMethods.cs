using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace ScriptsConcatenation
{
    public class ConcatenationMethods
    {
        //private Dictionary<string, string> _scripts = new Dictionary<string, string>();
        public static void ConcatScripts()
        {
            Script scriptConcated = new Script();
            StringBuilder sb = new StringBuilder();
            foreach (Script script in Data.scripts)
            {
                sb.Append("--");
                sb.Append(script.ScriptName);
                sb.Append("/n");
                sb.Append(script.ScriptContent);
                sb.Append("/n");
                sb.Append("GO");
                sb.Append("/n");
            }
            Data.ScriptConcated = scriptConcated;
        }

        public static void DeleteSelectedItemsFromScriptList(Script script)
        {
            for (int i = 0; i < Data.scripts.Count; i++)
            {
                if (script.ScriptName == Data.scripts[i].ScriptName)
                {
                    Data.scripts.RemoveAt(i);
                }
            }
        }

        public void AddScript(string[] urls)
        {
            foreach (string url in urls)
            {
                var scriptName = GetName(url);
                var stream = File.OpenRead(url);
                StreamReader reader = new StreamReader(stream);
                string scriptContent = reader.ReadToEnd();
                Script script = new Script(scriptContent, scriptName);
                Data.scripts.Add(script);
            }
        }

        private string GetName(string url)
        {
            var splittedUrl = url.Split('\\');
            return splittedUrl[splittedUrl.Length - 1];
        }

        public static void SplitScriptName(string[] scripts)
        {
            foreach (string scriptName in scripts)
            {
                string[] scriptSplitedArray = scriptName.Split('.');
                AddScriptsNameSplitedToList(scriptSplitedArray);
            }
        }

        internal static void AddScriptsNameSplitedToList(string[] scriptSplitedArray)
        {
            if (scriptSplitedArray.Length == 2)
            {
                ScriptNameSplit scriptSplited = new ScriptNameSplit(scriptSplitedArray[0], scriptSplitedArray[1]);
                Data.scriptsSplited.Add(scriptSplited);
            }
            else
            {
                ScriptNameSplit scriptSplited = new ScriptNameSplit(scriptSplitedArray[0], scriptSplitedArray[1], scriptSplitedArray[2]);
                Data.scriptsSplited.Add(scriptSplited);
            }
        }
    }
}
