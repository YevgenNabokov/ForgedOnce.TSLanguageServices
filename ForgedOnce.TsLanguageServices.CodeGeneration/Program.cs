using ForgedOnce.TsLanguageServices.CodeMixer.Launcher.MSBuild.WithDefaultAdapters;
using System;
using System.Collections.Generic;
using System.Text;

namespace ForgedOnce.TsLanguageServices.CodeGeneration
{
    public static class Program
    {
        public static void Main(string[] args)
        {
            Launcher launcher = new Launcher();
            launcher.Launch(args[0], args[1]);
        }
    }
}
