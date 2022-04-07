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
            ConcatenationMethods.SplitScriptName(scripts);

            Data.scriptsSplited[0].Should().BeEquivalentTo(new ScriptNameSplit("1", "prueba"));
            Data.scriptsSplited[1].Should().BeEquivalentTo(new ScriptNameSplit("1", "2", "prueba"));
            Data.scriptsSplited[2].Should().BeEquivalentTo(new ScriptNameSplit("2", "prueba2"));
        }

        [Fact]
        public void Add_Scripts_Test()
        {
            string[] urls = new string[] { "C:\\Users\\Ivancc\\Documents\\scripts sql de prueba\\05.tipo_contrato_prestador.sql", "C:\\Users\\Ivancc\\Documents\\scripts sql de prueba\\10.guardar_vistas_tipo_contrato_prestador.sql" };

            ConcatenationMethods concatenationMethods = new();
            concatenationMethods.AddScript(urls);

			Data.scripts[0].ScriptName.Should().Be("05.tipo_contrato_prestador.sql");
            Data.scripts[1].ScriptName.Should().Be("10.guardar_vistas_tipo_contrato_prestador.sql");
        }

        [Fact]
        public void Delete_Script_From_List_Test()
        {
            string[] urls = new string[] { "C:\\Users\\Ivancc\\Documents\\scripts sql de prueba\\05.tipo_contrato_prestador.sql", "C:\\Users\\Ivancc\\Documents\\scripts sql de prueba\\10.guardar_vistas_tipo_contrato_prestador.sql" };

            ConcatenationMethods concatenationMethods = new();
            concatenationMethods.AddScript(urls);

            Script script = new()
            {
                ScriptName = "05.tipo_contrato_prestador.sql"
            };

            ConcatenationMethods.DeleteSelectedItemsFromScriptList(script);

            Data.scripts[0].ScriptName.Should().Be("10.guardar_vistas_tipo_contrato_prestador.sql");
        }
    }
}