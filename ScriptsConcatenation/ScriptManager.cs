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
            _scriptConcated = new Script();
            var sb = new StringBuilder();
            foreach (var script in Scripts)
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
            for (var i = 0; i < _scripts.Count; i++)
            {
                if (script.ScriptNameComplete.Equals(_scripts[i].ScriptNameComplete))
                {
                    _scripts.RemoveAt(i);
                }
            }
        }

        public void AddScript(string[] urls)
        {
            foreach (var url in urls)
            {
                var stream = File.OpenRead(url);
                var reader = new StreamReader(stream);
                var script = new Script()
                {
                    ScriptNameComplete = GetName(url),
                    ScriptContent = reader.ReadToEnd()
                };
                if (!ScriptsContains(script) && !ScriptsNameIncorrectContains(script.ScriptNameComplete))
                {
                    CheckScriptsVersion(script);
                }
            }
        }

        private bool ScriptsContains(Script script)
        {
            return _scripts.Where(x => x.ScriptNameComplete.Equals(script.ScriptNameComplete)).Any();
        }

        private void CheckScriptsVersion(Script script)
        {
            var scriptComplete = SplitScriptName(script);
            if (!ScriptsNameIncorrectContains(scriptComplete.ScriptNameComplete))
            {
                CheckScriptsVersionCorrectFormat(scriptComplete);
            }
        }

        private void CheckScriptsVersionCorrectFormat(Script scriptComplete)
        {
            var existsWithNumVersionHigher = false;
            for (int i = 0; i < _scripts.Count(); i++)
            {
                if (scriptComplete.ScriptName.Equals(_scripts[i].ScriptName) &&
                    scriptComplete.NumScript.Equals(_scripts[i].NumScript))
                {
                    existsWithNumVersionHigher = CheckScriptVersionHigher(scriptComplete, _scripts[i]);
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

        private bool ScriptsNameIncorrectContains(string scriptName)
        {
            return _scriptsNameIncorrect.Where(x => x.Equals(scriptName)).Any();
        }

        private bool CheckScriptVersionHigher(Script scriptComplete, Script scriptIterator)
        {
            var existsWithNumVersionHigher = false;
            if (Convert.ToInt32(scriptComplete.NumVersion) < Convert.ToInt32(scriptIterator.NumVersion) ||
                scriptComplete.ScriptNameComplete.Equals(scriptIterator.ScriptNameComplete))
            {
                existsWithNumVersionHigher = true;
            }
            else
            {
                ScriptVersionLower(scriptComplete, scriptIterator);
            }
            return existsWithNumVersionHigher;
        }

        private void ScriptVersionLower(Script scriptComplete, Script scriptIteratorComplete)
        {
            var versionDiference = Convert.ToInt32(scriptComplete.NumVersion) - Convert.ToInt32(scriptIteratorComplete.NumVersion);
            var scriptCompletePreviousVersion = new Script()
            {
                ScriptContent = scriptComplete.ScriptContent,
                NumScript = scriptIteratorComplete.NumScript,
                NumVersion = (Convert.ToInt32(scriptComplete.NumVersion) - versionDiference).ToString(),
                ScriptName = scriptIteratorComplete.ScriptName
            };
            scriptCompletePreviousVersion.ScriptNameComplete = scriptCompletePreviousVersion.NumScript + "." + scriptCompletePreviousVersion.NumVersion + "." + scriptCompletePreviousVersion.ScriptName + ".sql";
            ScriptVersionLowerDelete(scriptCompletePreviousVersion);
        }

        private void ScriptVersionLowerDelete(Script scriptCompletePreviousVersion)
        {
            for (int i = 0; i < _scripts.Count(); i++)
            {
                if (_scripts[i].ScriptNameComplete.Equals(scriptCompletePreviousVersion.ScriptNameComplete))
                {
                    _scripts.Remove(_scripts[i]);
                }
            };
        }

        private string GetName(string url)
        {
            var splittedUrl = url.Split('\\');
            return splittedUrl[splittedUrl.Length - 1];
        }

        public Script SplitScriptName(Script scriptIncomplete)
        {
            var scriptComplete = scriptIncomplete;
            var scriptSplitedArray = scriptComplete.ScriptNameComplete.Split('.');
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
            var scriptsIncorrectFormat = new StringBuilder();
            foreach (var scriptNameIncorrect in _scriptsNameIncorrect)
            {
                scriptsIncorrectFormat.Append("\n");
                scriptsIncorrectFormat.Append(scriptNameIncorrect);
            }
            return scriptsIncorrectFormat.ToString();
        }

        public void WriteScript(string Path)
        {
            using (var sw = File.CreateText(Path + "\\" + _scriptConcated.ScriptName))
            {
                sw.Write(_scriptConcated.ScriptContent);
            };
        }
    }
}
