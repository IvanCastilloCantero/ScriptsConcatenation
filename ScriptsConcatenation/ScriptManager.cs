using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace ScriptsConcatenation
{
    public class ScriptManager
    {
        public List<Script> Scripts = new List<Script>();
        public Script ScriptConcated;
        public List<ScriptNameSplit> ScriptsSplited = new List<ScriptNameSplit>();

        public ScriptManager()
        {
            Scripts = new List<Script>();
            ScriptConcated = new Script();
            ScriptsSplited = new List<ScriptNameSplit>();

        }

        public void ConcatScripts()
        {
            StringBuilder sb = new StringBuilder();
            foreach (Script script in Scripts)
            {
                sb.Append("--");
                sb.Append(script.ScriptName);
                sb.Append("/n");
                sb.Append(script.ScriptContent);
                sb.Append("/n");
                sb.Append("GO");
                sb.Append("/n");
            }
            ScriptConcated.ScriptContent = sb.ToString();
            ScriptConcated.ScriptName = "generatedScript.sql";
        }

        public void DeleteSelectedItemsFromScriptList(Script script)
        {
            for (int i = 0; i < Scripts.Count; i++)
            {
                if (script.ScriptName == Scripts[i].ScriptName)
                {
                    Scripts.RemoveAt(i);
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
                Console.WriteLine(script.ScriptName);
                Scripts.Add(script);
            }
        }

        private string GetName(string url)
        {
            var splittedUrl = url.Split('\\');
            return splittedUrl[splittedUrl.Length - 1];
        }

        public void SplitScriptName(string[] scripts)
        {
            foreach (string scriptName in scripts)
            {
                string[] scriptSplitedArray = scriptName.Split('.');
                AddScriptsNameSplitedToList(scriptSplitedArray);
            }
        }

        internal void AddScriptsNameSplitedToList(string[] scriptSplitedArray)
        {
            if (scriptSplitedArray.Length == 2)
            {
                ScriptNameSplit scriptSplited = new ScriptNameSplit(scriptSplitedArray[0], scriptSplitedArray[1]);
                ScriptsSplited.Add(scriptSplited);
            }
            else
            {
                ScriptNameSplit scriptSplited = new ScriptNameSplit(scriptSplitedArray[0], scriptSplitedArray[1], scriptSplitedArray[2]);
                ScriptsSplited.Add(scriptSplited);
            }
        }
    }
}
