using ForgedOnce.TsLanguageServices.ModelBuilder.TypeData;
using ForgedOnce.TsLanguageServices.Model.TypeData;
using System;
using System.Collections.Generic;
using System.Text;

namespace ForgedOnce.TsLanguageServices.ModelBuilder.Interfaces
{
    public interface ILtsTypeRepository
    {
        string RegisterTypeDefinition(string name, string ns, string file, IEnumerable<TypeParameter> parameters);

        string RegisterTypeReferenceDefined(string definedTypeId, IEnumerable<string> parameterTypeReferenceIds = null);

        string RegisterTypeReferenceBuiltin(string name, IEnumerable<string> parameterTypeReferenceIds = null);

        string RegisterTypeReferenceExternal(string name, string ns, string module, IEnumerable<string> parameterTypeReferenceIds = null);

        string RegisterTypeReferenceUnion(IEnumerable<string> typeReferenceIds);

        string RegisterTypeReferenceInlineIndexer(string keyName, string valueTypeId);

        TypeDefinitionUpdateResult UpdateTypeDefinitionFile(string typeDefinitionId, string file);
    }
}
