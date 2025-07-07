using MyCompiler;

class Program
{
    static void Main(string[] args)
    {
        string codigo = @"
class Persona
{
    int edad;
    float altura;
};

int main()
{
    Persona p1(""Daniel"", 25);
    return 0;
}
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
    }
}