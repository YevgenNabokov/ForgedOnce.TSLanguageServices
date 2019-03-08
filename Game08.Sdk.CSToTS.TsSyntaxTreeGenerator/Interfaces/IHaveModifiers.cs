using Game08.Sdk.CSToTS.TsSyntaxTreeGenerator.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace Game08.Sdk.CSToTS.TsSyntaxTreeGenerator.Interfaces
{
    public interface IHaveModifiers
    {
        Modifier[] Modifiers { get; }
    }
}
