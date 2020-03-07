using Game08.Sdk.CodeMixer.Launcher.MSBuild.WithDefaultAdapters;
using System;
using System.Collections.Generic;
using System.Text;

namespace Game08.Sdk.CodeGeneration
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
