﻿using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using static System.Runtime.InteropServices.JavaScript.JSType;

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

                            if (ts[index].Token != "TipoDeDato")
                            {
                                Errors.Add($"Error ({ts[index].Linea}): Tipo de dato inválido: '{ts[index].Lexema}'");
                                return false;
                            }

                            string tipo = ts[index].Lexema;
                            index++;
                            while (true)
                            {
                                if (ts[index].Token != "Identificador")
                                {
                                    Errors.Add($"Error ({ts[index].Linea}): Se esperaba nombre de atributo");
                                    return false;
                                }

                                string atributo = ts[index].Lexema;
                                atributos.Add(atributo);
                                index++;

                                if (ts[index].Token == "Coma")
                                {
                                    index++;
                                    continue;
                                }
                                else if (ts[index].Token == "FinSentencia")
                                {
                                    index++;
                                    break;
                                }
                                else
                                {
                                    Errors.Add($"Error ({ts[index].Linea}): Se esperaba ',' o ';'");
                                    return false;
                                }
                            }
                        }

                        index++; 
                        if (index < ts.Count && ts[index].Token == "FinSentencia") index++;
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
                if (index < ts.Count && ts[index].Token == "Identificador")
                {
                    string instancia = ts[index].Lexema;
                    index++;
                    if (index < ts.Count && ts[index].Token == "ParentesisIzq")
                    {
                        index++;
                        var atributos = new Dictionary<string, object>();
                        int atributoIndex = 0;
                        while (index < ts.Count && ts[index].Token != "ParentesisDer")
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
                                while (index < ts.Count && ts[index].Token != "ParentesisDer" && ts[index].Token != "FinSentencia")
                                    index++;
                                break;
                            }

                            index++;
                            if (index < ts.Count && ts[index].Token == "Coma") index++;
                        }

                        if (index < ts.Count && ts[index].Token == "ParentesisDer")
                            index++; 

                        if (index >= ts.Count || ts[index].Token != "FinSentencia")
                        {
                            int lineaError = (index < ts.Count) ? ts[index - 1].Linea : ts[ts.Count - 1].Linea;
                            Errors.Add($"Error ({lineaError}): Se esperaba ';' al final de la instancia de {clase}");
                            while (index < ts.Count && ts[index].Token != "FinSentencia" && ts[index].Token != "Identificador" && ts[index].Token != "PalabraReservada")
                                index++;
                            if (index < ts.Count && ts[index].Token == "FinSentencia")
                                index++; 
                            return false;
                        }
                        index++; 
                           
                        string nom_clase= clase.ToLower();
                        if (!Instancias.ContainsKey(nom_clase))
                            Instancias[nom_clase] = new List<Dictionary<string, object>>();
                        
                        Instancias[nom_clase].Add(atributos);
                        
                        return true;
                    }
                }
            }

            index = start;
            return false;
        }
    }
}