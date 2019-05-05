﻿using Game08.Sdk.CSToTS.TranslationLauncher;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game08.Sdk.CSToTS.TranslationLauncher
{
    class Program
    {
        static void Main(string[] args)
        {
            TranslationManager manager = new TranslationManager(args[0], args[1], args.Length > 2 ? new string[] { args[2] } : null);

            manager.Translate();
        }
    }
}
