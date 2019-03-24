using Game08.Sdk.CSToTS.Core;
using Game08.Sdk.CSToTS.Core.Interfaces;
using Microsoft.CodeAnalysis.MSBuild;
using System;
using System.Collections.Generic;
using System.Text;

namespace Game08.Sdk.CSToTS.VsSolutionMetadataProvider
{
    public class TranslationMetadataProvider : ITranslationMetadataProvider
    {
        private string solutionFilePath;

        public TranslationMetadataProvider(string solutionFilePath)
        {
            this.solutionFilePath = solutionFilePath;
        }

        public TranslationMetadata GetMetadata()
        {
            var msWorkspace = MSBuildWorkspace.Create();

            var solution = msWorkspace.OpenSolutionAsync(this.solutionFilePath).Result;
            foreach (var proj in solution.Projects)
            {

            }

            throw new NotImplementedException();
        }
    }
}
