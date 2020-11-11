using System;
using System.Collections.Generic;
using System.Text;

namespace ForgedOnce.TsLanguageServices.AstDescription.Model
{
    public class EnumDescription : NamedDeclaration
    {
        public List<EnumMemberDescription> Members;
    }
}
