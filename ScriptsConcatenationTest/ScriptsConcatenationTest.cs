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
        public void Add_Scripts_Test() 
        {
            string[] urls = new string[] { "C:\\Users\\Ivancc\\Documents\\scripts sql de prueba\\05.tipo_contrato_prestador.sql", "C:\\Users\\Ivancc\\Documents\\scripts sql de prueba\\10.guardar_vistas_tipo_contrato_prestador.sql" };

            ScriptManager scriptManager = new();
            scriptManager.AddScript(urls);

            scriptManager.Scripts[0].ScriptNameComplete.Should().Be("05.tipo_contrato_prestador.sql");
            scriptManager.Scripts[1].ScriptNameComplete.Should().Be("10.guardar_vistas_tipo_contrato_prestador.sql");
            
            
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
    }
}