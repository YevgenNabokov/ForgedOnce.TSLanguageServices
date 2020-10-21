using System;
using System.Collections.Generic;
using System.Text;

namespace ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel
{
    public interface IStNodeBase
    {
        StNodeBase Parent { get; set; }

        void SetAnnotation(string key, string value);

        bool HasAnnotation(string key);

        string GetAnnotation(string key);

        void MakeReadonly();

        object GetTransportModelNode();
    }
}
