using Xunit;
using FluentAssertions;
using ScriptsConcatenation;

namespace ScriptsConcatenationTest
{
    public class ScriptsConcatenationTest
    {

        [Fact]
        public void Script_Name_Split_Test()
        {
            ScriptManager scriptManager = new ScriptManager();
            Script script = new Script()
            {
                ScriptNameComplete = "2.2.prueba.sql"
            };

            Script scriptComplete = scriptManager.SplitScriptName(script);

            scriptComplete.NumScript.Should().Be("2");
            scriptComplete.NumVersion.Should().Be("2");
            scriptComplete.ScriptName.Should().Be("prueba");
        }

        [Fact]
        public void Script_Name_Split_Test_Incorrect_Format()
        {
            ScriptManager scriptManager = new();
            Script script = new()
            {
                ScriptNameComplete = "prueba.sql"
            };

            Script scriptComplete = scriptManager.SplitScriptName(script);

            scriptManager.ScriptsNameIncorrect[0].Should().Be("prueba.sql");
        }

        [Fact]
        public void Add_Scripts_Test() 
        {
            string[] urls = new string[] { "C:\\Users\\Ivancc\\Documents\\scripts sql de prueba\\05.1.tipo_contrato_prestador.sql", "C:\\Users\\Ivancc\\Documents\\scripts sql de prueba\\05.2.tipo_contrato_prestador.sql", "C:\\Users\\Ivancc\\Documents\\scripts sql de prueba\\05.3.tipo_contrato_prestador.sql", "C:\\Users\\Ivancc\\Documents\\scripts sql de prueba\\05.tipo_contrato_prestador.sql", "C:\\Users\\Ivancc\\Documents\\scripts sql de prueba\\10.guardar_vistas_tipo_contrato_prestador.sql", "C:\\Users\\Ivancc\\Documents\\scripts sql de prueba\\pegar_servicio_farmacia.sql"};

            ScriptManager scriptManager = new();
            scriptManager.AddScript(urls);

            scriptManager.Scripts[0].ScriptNameComplete.Should().Be("05.3.tipo_contrato_prestador.sql");
            scriptManager.Scripts[1].ScriptNameComplete.Should().Be("10.guardar_vistas_tipo_contrato_prestador.sql");
            scriptManager.ScriptsNameIncorrect[0].Should().Be("pegar_servicio_farmacia.sql");
        }

        [Fact]
        public void Delete_Script_From_List_Test()
        {
            string[] urls = new string[] { "C:\\Users\\Ivancc\\Documents\\scripts sql de prueba\\05.tipo_contrato_prestador.sql", "C:\\Users\\Ivancc\\Documents\\scripts sql de prueba\\10.guardar_vistas_tipo_contrato_prestador.sql" };

            ScriptManager scriptManager = new();
            scriptManager.AddScript(urls);

            Script script = new()
            {
                ScriptNameComplete = "05.tipo_contrato_prestador.sql"
            };

            scriptManager.DeleteSelectedItemsFromScriptList(script);

            scriptManager.Scripts[0].ScriptNameComplete.Should().Be("10.guardar_vistas_tipo_contrato_prestador.sql");
        }

        [Fact]
        public void Concat_Scripts_Test()
        {
            string[] urls = new string[] { "C:\\Users\\Ivancc\\Documents\\scripts sql de prueba\\05.tipo_contrato_prestador.sql", "C:\\Users\\Ivancc\\Documents\\scripts sql de prueba\\10.guardar_vistas_tipo_contrato_prestador.sql" };

            ScriptManager scriptManager = new();
            scriptManager.AddScript(urls);

            scriptManager.ConcatScripts();

            scriptManager.ScriptConcated.ScriptName.Should().Be("generatedScript.sql");
        }

        [Fact]
        public void Show_Scripts_With_Incorrect_Format_Test()
        {
            ScriptManager scriptManager = new();
            Script script1 = new()
            {
                ScriptNameComplete = "prueba1.sql"
            };

            Script script2 = new()
            {
                ScriptNameComplete = "prueba2.sql"
            };

            Script scriptComplete1 = scriptManager.SplitScriptName(script1);
            Script scriptComplete2 = scriptManager.SplitScriptName(script2);

            string scriptsWithIncorrectFormat = scriptManager.ShowScriptsWithIncorrectFormat();

            scriptsWithIncorrectFormat.Should().Be("\nprueba1.sql\nprueba2.sql");
        }
    }
}