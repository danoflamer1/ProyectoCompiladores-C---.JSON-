using System.Text.Json;
using System.Text.Json.Serialization;

namespace MyCompiler
{
    internal class GeneradorCodigo
    {
        public static string GenerarJSON(Dictionary<string, List<Dictionary<string, object>>> instancias)
        {
            var resultado = new
            {
                clases = instancias
            };

            var opciones = new JsonSerializerOptions
            {
                WriteIndented = true,
                NumberHandling = JsonNumberHandling.AllowReadingFromString
            };

            return JsonSerializer.Serialize(resultado, opciones);
        }
    }
}