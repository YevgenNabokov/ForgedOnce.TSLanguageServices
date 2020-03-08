using L = ForgedOnce.Launcher.MSBuild.WithDefaultAdapters;
using System;
using System.Collections.Generic;
using System.Text;

namespace ForgedOnce.TsLanguageServices.CodeGeneration
{
    public static class Program
    {
        public static void Main(string[] args)
        {
            L.Launcher launcher = new L.Launcher();
            launcher.Launch(args[0], args[1]);
        }
    }
}
