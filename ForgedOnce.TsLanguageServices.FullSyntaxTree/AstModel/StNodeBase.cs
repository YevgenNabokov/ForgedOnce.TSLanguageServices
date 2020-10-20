using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel
{
    public abstract class StNodeBase : IStNodeBase
    {
        public virtual object GetTransportModelNode()
        {
            return null;
        }

        protected List<T> GetTransportModelNodes<T>(IEnumerable<IStNodeBase> nodes)
        {
            return nodes != null ? nodes.Select(n => (T)n.GetTransportModelNode()).ToList() : null;
        }
    }
}
