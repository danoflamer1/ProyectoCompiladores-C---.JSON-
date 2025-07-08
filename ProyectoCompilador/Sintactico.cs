using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace MyCompiler
{
    internal class Sintactico
    {
        public List<string> Errors = new();
        public Dictionary<string, List<string>> Clases = new(); 
        public Dictionary<string, List<Dictionary<string, object>>> Instancias = new(); 

        private int index;

        public bool Analizar(List<Simbolo> ts)
        {
            index = 0;
            while (index < ts.Count)
            {
                if (EsClase(ts)) continue;
                if (EsInstancia(ts)) continue;

                Errors.Add($"Error ({ts[index].Linea}): Estructura no reconocida cerca de '{ts[index].Lexema}'");
                index++;
            }

            return Errors.Count == 0;
        }

        private bool EsClase(List<Simbolo> ts)
        {
            int start = index;
            if (ts[index].Lexema == "class")
            {
                index++;
                if (ts[index].Token == "Identificador")
                {
                    string className = ts[index].Lexema;
                    index++;
                    if (ts[index].Token == "LlaveAbre")
                    {
                        index++;
                        List<string> atributos = new();

                        while (ts[index].Token != "LlaveCierra")
                        {
                            string tipo = ts[index].Lexema;
                            index++;

                            if (ts[index].Token != "Identificador")
                            {
                                Errors.Add($"Error ({ts[index].Linea}): Se esperaba un nombre de atributo");
                                return false;
                            }

                            string atributo = ts[index].Lexema;
                            atributos.Add(atributo);
                            index++;

                            if (ts[index].Token != "FinSentencia")
                            {
                                Errors.Add($"Error ({ts[index].Linea}): Se esperaba ';'");
                                return false;
                            }

                            index++;
                        }

                        index++; // LlaveCierra
                        if (index < ts.Count && ts[index].Token == "FinSentencia") index++; // consume el ";"
                        Clases[className] = atributos;
                        return true;
                    }
                }
            }

            index = start;
            return false;
        }

        private bool EsInstancia(List<Simbolo> ts)
        {
            int start = index;
            if (ts[index].Token == "Identificador")
            {
                string clase = ts[index].Lexema;
                if (!Clases.ContainsKey(clase)) return false;

                index++;
                if (ts[index].Token == "Identificador")
                {
                    string instancia = ts[index].Lexema;
                    index++;
                    if (ts[index].Token == "ParentesisIzq")
                    {
                        index++;
                        var atributos = new Dictionary<string, object>();
                        int atributoIndex = 0;
                        while (ts[index].Token != "ParentesisDer")
                        {
                            object valor;
                            if (ts[index].Token == "Texto")
                                valor = ts[index].Lexema.Trim('"');
                            else if (ts[index].Token == "Numero" && int.TryParse(ts[index].Lexema, out var n))
                                valor = n;
                            else
                                valor = ts[index].Lexema;

                            if (atributoIndex < Clases[clase].Count)
                            {
                                atributos[Clases[clase][atributoIndex]] = valor;
                                atributoIndex++;
                            }
                            else
                            {
                                Errors.Add($"Error ({ts[index].Linea}): Demasiados argumentos en instancia de {clase}");
                                return false;
                            }

                            index++;
                            if (ts[index].Token == "Coma") index++;
                        }

                        index++; // ParentesisDer
                        if (ts[index].Token == "FinSentencia") index++;

                        string plural = clase.ToLower() + "s";
                        if (!Instancias.ContainsKey(plural))
                            Instancias[plural] = new List<Dictionary<string, object>>();
                        Instancias[plural].Add(atributos);

                        return true;
                    }
                }
            }

            index = start;
            return false;
        }
    }
}