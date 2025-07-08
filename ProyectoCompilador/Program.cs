using MyCompiler;

class Program
{
    static void Main(string[] args)
    {
        string codigo = @"
class Persona{
     string nombre;
     int edad;
}
class Animal{
     string nombre;
     string tipo;
}
Persona p1(""Maria Gonzales"", 28);
Animal a2(""Misi"", ""gato"");
Persona p3(""Ana Lopez"", 42);
Animal a1(""Max"", ""perro"");
Persona p2(""Carlos Ruiz"", 35);
Animal a3(""Piolin"", ""canario"");
";

        Lexico lexer = new Lexico();
        var simbolos = lexer.Analizar(codigo);

        Console.WriteLine("Tabla de símbolos:");
        foreach (var s in simbolos)
        {
            Console.WriteLine($"{s.Token} = '{s.Lexema}'");
        }

        Console.WriteLine("\nErrores:");
        foreach (var e in lexer.Errors)
        {
            Console.WriteLine(e);
        }

        Sintactico parser = new Sintactico();
        if (!parser.Analizar(simbolos))
        {
            Console.WriteLine("Errores sintácticos: ");
            parser.Errors.ForEach(e => Console.WriteLine(e));
            return;
        }

        string json = GeneradorCodigo.GenerarJSON(parser.Instancias);
        Console.WriteLine(json);
    }
}