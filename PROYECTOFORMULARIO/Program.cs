﻿using System;
using System.Windows.Forms;

namespace PROYECTOFORMULARIO
{
    static class Program
    {
        [STAThread]
        static void Main()
        {
            ApplicationConfiguration.Initialize();
            Application.Run(new Form1());
        }
    }
}