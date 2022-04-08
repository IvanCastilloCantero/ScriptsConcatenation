using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace ScriptsConcatenation
{
    public class ScriptManager
    {
        private readonly List<Script> _scripts;
        private Script _scriptConcated;
        private readonly List<string> _scriptsNameIncorrect;

        public ScriptManager()
        {
            _scripts = new List<Script>();
            _scriptsNameIncorrect = new List<string>();
        }

        public List<Script> Scripts
        {
            get
            {
                return _scripts;
            }
        }

        public Script ScriptConcated
        {
            get
            {
                return _scriptConcated;
            }
        }

        public List<string> ScriptsNameIncorrect
        {
            get
            {
                return _scriptsNameIncorrect;
            }
        }

        public void ConcatScripts()
        {
            this._scriptConcated = new Script();
            StringBuilder sb = new StringBuilder();
            foreach (Script script in Scripts)
            {
                sb.Append("--");
                sb.Append(script.ScriptNameComplete);
                sb.Append("\n");
                sb.Append(script.ScriptContent);
                sb.Append("\n");
                sb.Append("GO");
                sb.Append("\n");
            }
            _scriptConcated.ScriptContent = sb.ToString();
            _scriptConcated.ScriptName = "generatedScript.sql";
        }

        public void DeleteSelectedItemsFromScriptList(Script script)
        {
            for (int i = 0; i < _scripts.Count; i++)
            {
                if (script.ScriptName == Scripts[i].ScriptName)
                {
                    _scripts.RemoveAt(i);
                }
            }
        }

        public void AddScript(string[] urls)
        {
            foreach (string url in urls)
            {
                var stream = File.OpenRead(url);
                StreamReader reader = new StreamReader(stream);
                Script script = new Script
                {
                    ScriptNameComplete = GetName(url),
                    ScriptContent = reader.ReadToEnd()
                };
                CheckScriptsVersion(script);
            }
        }

        private void CheckScriptsVersion(Script script)
        {
            Script scriptComplete = SplitScriptName(script);
            bool incorrectFormat = CheckIncorrectFormat(scriptComplete);
            if (!incorrectFormat)
            {
                CheckScriptsVersionCorrectFormat(scriptComplete);
            }
            
            
        }

        private void CheckScriptsVersionCorrectFormat(Script scriptComplete)
        {
            bool existsWithNumVersionHigher = false;
            foreach (Script scriptIterator in _scripts)
            {
                Script scriptIteratorComplete = SplitScriptName(scriptIterator);
                if (scriptComplete.ScriptName.Equals(scriptIteratorComplete.ScriptName) &&
                    scriptComplete.NumScript.Equals(scriptIteratorComplete.NumScript))
                {
                    existsWithNumVersionHigher = CheckScriptVersionHigher(scriptComplete, scriptIteratorComplete);
                }
            }
            CheckAddScript(scriptComplete, existsWithNumVersionHigher);
        }

        private void CheckAddScript(Script scriptComplete, bool existsWithNumVersionHigher)
        {
            if (!existsWithNumVersionHigher)
            {
                _scripts.Add(scriptComplete);
            }
        }

        private bool CheckIncorrectFormat(Script scriptComplete)
        {
            bool incorrectFormat = false;
            foreach (string scriptNameIncorrect in _scriptsNameIncorrect)
            {
                if (scriptComplete.ScriptNameComplete.Equals(scriptNameIncorrect))
                {
                    incorrectFormat = true;
                }
            }
            return incorrectFormat;
            
        }

        private bool CheckScriptVersionHigher(Script scriptComplete, Script scriptIteratorComplete)
        {
            bool existsWithNumVersionHigher = false;
            if (Convert.ToInt32(scriptComplete.NumVersion) < Convert.ToInt32(scriptIteratorComplete.NumVersion) ||
                scriptComplete.ScriptNameComplete.Equals(scriptIteratorComplete.ScriptNameComplete))
            {
                existsWithNumVersionHigher = true;
            }
            else
            {
                ScriptVersionLower(scriptComplete, scriptIteratorComplete);
            }
            return existsWithNumVersionHigher;
        }

        private void ScriptVersionLower(Script scriptComplete, Script scriptIteratorComplete)
        {
            Script scriptCompletePreviousVersion = new Script()
            {
                ScriptNameComplete = scriptIteratorComplete.ScriptNameComplete,
                ScriptContent = scriptComplete.ScriptContent,
                NumScript = scriptIteratorComplete.NumScript,
                NumVersion = (Convert.ToInt32(scriptComplete.NumVersion) - 1).ToString(),
                ScriptName = scriptIteratorComplete.ScriptName
            };
            _scripts.Remove(scriptCompletePreviousVersion);
        }

        private string GetName(string url)
        {
            var splittedUrl = url.Split('\\');
            return splittedUrl[splittedUrl.Length - 1];
        }

        public Script SplitScriptName(Script scriptIncomplete)
        {
            var scriptComplete = scriptIncomplete;
            string[] scriptSplitedArray = scriptComplete.ScriptNameComplete.Split('.');
            switch (scriptSplitedArray.Length)
            {
                case 3:
                    scriptComplete.NumScript = scriptSplitedArray[0];
                    scriptComplete.NumVersion = "0";
                    scriptComplete.ScriptName = scriptSplitedArray[1];
                    break;
                case 4:
                    scriptComplete.NumScript = scriptSplitedArray[0];
                    scriptComplete.NumVersion = scriptSplitedArray[1];
                    scriptComplete.ScriptName = scriptSplitedArray[2];
                    break;
                default:
                    _scriptsNameIncorrect.Add(scriptComplete.ScriptNameComplete);
                    break;
            }
            return scriptComplete;
        }

        public string ShowScriptsWithIncorrectFormat()
        {
            StringBuilder scriptsIncorrectFormat = new StringBuilder();
            foreach (string scriptNameIncorrect in _scriptsNameIncorrect)
            {
                scriptsIncorrectFormat.Append("\n");
                scriptsIncorrectFormat.Append(scriptNameIncorrect); 
            }
            return scriptsIncorrectFormat.ToString();
        }

        public void WriteScript(string Path)
        {
            using (StreamWriter sw = File.CreateText(Path + "\\" + _scriptConcated.ScriptName))
            {
                sw.Write(_scriptConcated.ScriptContent);
            };
        }
    }
}
