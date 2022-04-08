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
            string[] scripts = new string[] { "1.prueba", "1.2.prueba", "2.prueba2" };
            ScriptManager scriptManager = new();
            scriptManager.SplitScriptName(scripts);

            scriptManager.ScriptsSplited[0].Should().BeEquivalentTo(new ScriptNameSplit("1", "prueba"));
            scriptManager.ScriptsSplited[1].Should().BeEquivalentTo(new ScriptNameSplit("1", "2", "prueba"));
            scriptManager.ScriptsSplited[2].Should().BeEquivalentTo(new ScriptNameSplit("2", "prueba2"));
        }

        [Fact]
        public void Add_Scripts_Test() 
        {
            string[] urls = new string[] { "C:\\Users\\Ivancc\\Documents\\scripts sql de prueba\\05.tipo_contrato_prestador.sql", "C:\\Users\\Ivancc\\Documents\\scripts sql de prueba\\10.guardar_vistas_tipo_contrato_prestador.sql" };

            ScriptManager scriptManager = new();
            scriptManager.AddScript(urls);
            var a = scriptManager.Scripts[0].ScriptName;
            var b = scriptManager.Scripts[1].ScriptName;
            a.Should().Be("05.tipo_contrato_prestador.sql");
            b.Should().Be("10.guardar_vistas_tipo_contrato_prestador.sql");
        }

        [Fact]
        public void Delete_Script_From_List_Test()
        {
            string[] urls = new string[] { "C:\\Users\\Ivancc\\Documents\\scripts sql de prueba\\05.tipo_contrato_prestador.sql", "C:\\Users\\Ivancc\\Documents\\scripts sql de prueba\\10.guardar_vistas_tipo_contrato_prestador.sql" };

            ScriptManager scriptManager = new();
            scriptManager.AddScript(urls);

            Script script = new()
            {
                ScriptName = "05.tipo_contrato_prestador.sql"
            };

            scriptManager.DeleteSelectedItemsFromScriptList(script);

            scriptManager.Scripts[0].ScriptName.Should().Be("10.guardar_vistas_tipo_contrato_prestador.sql");
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