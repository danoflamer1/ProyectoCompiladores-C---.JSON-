using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace MyCompiler
{
    internal class Lexico
    {
        public List<string> Errors;
        private List<Simbolo> TablaSimbolos;

        Dictionary<string, string> _regexPatterns = new Dictionary<string, string>
        {
            {"Comentario", @"//.*"},
            {"ComentarioBloque", @"/\*.*?\*/"},
            {"PalabraReservada", @"\b(class|return|main|void)\b"},
            {"TipoDeDato", @"\b(int|float|double|char|bool|string)\b"},
            {"Texto", "\"[^\"]*\""},
            {"Numero", @"\b\d+\b"},
            {"Identificador", @"\b[a-zA-Z_]\w*\b"},
            {"ParentesisIzq", @"\("},
            {"ParentesisDer", @"\)"},
            {"LlaveAbre", @"\{"},
            {"LlaveCierra", @"\}"},
            {"FinSentencia", @";"},
            {"Coma", @","},
            {"Espacio", @"\s+"},
            {"OperadorDoble", @"::"},
            {"Asignacion", @"="}
        };

        public List<Simbolo> Analizar(string sourceCode)
        {
            Errors = new List<string>();
            TablaSimbolos = new List<Simbolo>();

            string[] lines = sourceCode.Split(new[] { "\r\n", "\r", "\n" }, StringSplitOptions.None);
            int lineNumber = 1;

            foreach (var line in lines)
            {
                int index = 0;
                while (index < line.Length)
                {
                    bool matchFound = false;

                    foreach (var pattern in _regexPatterns)
                    {
                        Regex regex = new Regex("^" + pattern.Value);
                        var match = regex.Match(line.Substring(index));

                        if (match.Success)
                        {
                            string value = match.Value;

                            if (pattern.Key != "Comentario" && pattern.Key != "ComentarioBloque" && pattern.Key != "Espacio")
                            {
                                TablaSimbolos.Add(new Simbolo
                                {
                                    Lexema = value,
                                    Token = pattern.Key,
                                    Linea = lineNumber,
                                    Columna = index + 1
                                });
                            }

                            index += value.Length;
                            matchFound = true;
                            break;
                        }
                    }

                    if (!matchFound)
                    {
                        string simbolo = line[index].ToString();
                        Errors.Add($"Error ({lineNumber}): Símbolo no reconocido cerca de '{simbolo}'");
                        index++;
                    }
                }

                lineNumber++;
            }

            return TablaSimbolos;
        }
    }
}