using Game08.Sdk.LTS.Builder.TypeData;
using Game08.Sdk.LTS.Model.TypeData;
using System;
using System.Collections.Generic;
using System.Text;

namespace Game08.Sdk.LTS.Builder.Interfaces
{
    public interface ILtsTypeRepository
    {
        string RegisterTypeDefinition(string name, string ns, string file, IEnumerable<TypeParameter> parameters);

        string RegisterTypeReferenceDefined(string definedTypeId, IEnumerable<string> parameterTypeReferenceIds = null);

        string RegisterTypeReferenceBuiltin(string name, IEnumerable<string> parameterTypeReferenceIds = null);

        string RegisterTypeReferenceExternal(string name, string ns, string module, IEnumerable<string> parameterTypeReferenceIds = null);

        string RegisterTypeReferenceUnion(IEnumerable<string> typeReferenceIds);

        TypeDefinitionUpdateResult UpdateTypeDefinitionFile(string typeDefinitionId, string file);
    }
}
