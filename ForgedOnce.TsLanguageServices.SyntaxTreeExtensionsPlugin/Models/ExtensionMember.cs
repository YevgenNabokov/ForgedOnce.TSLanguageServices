using Microsoft.CodeAnalysis;
using System;
using System.Collections.Generic;
using System.Text;

namespace ForgedOnce.TsLanguageServices.SyntaxTreeExtensionsPlugin.Models
{
    /// <summary>
    /// Parameters for extension method.
    /// </summary>
    public class ExtensionMember
    {
        /// <summary>
        /// Source class property name.
        /// </summary>
        public string Name;

        /// <summary>
        /// Source class property symbol.
        /// </summary>
        public IPropertySymbol SourcePropertySymbol;
        
        /// <summary>
        /// Indicates whether source class property is collection.
        /// </summary>
        public bool IsCollection;

        /// <summary>
        /// Type symbol of the source class property.
        /// </summary>
        public ITypeSymbol ItemType;

        /// <summary>
        /// Indicates whether source class property type is/inherits/implements cofigured required base type for input class.
        /// </summary>
        public bool ItemTypeInheritsRequiredBaseType;

        /// <summary>
        /// Indicates whether extension method parameter for this property value will have type of Func<T, T> and default value will be created by extension method passed to provided Func<T, T>.
        /// </summary>
        public bool GenerateFuncParameterInExtensionMethod;

        /// <summary>
        /// Type symbol of containing source class.
        /// </summary>
        public INamedTypeSymbol ContainerSymbol;

        /// <summary>
        /// Preprocessed source property name that will be a part of extension method name.
        /// </summary>
        public string PreprocessedItemName;

        /// <summary>
        /// Indicates whether this item value properties will be unfolded and embedded into extension method.
        /// </summary>
        public bool Unfold = false;

        /// <summary>
        /// List of unfolded properties to embed into extension method. Used when Unfold is set to true.
        /// </summary>
        public List<UnfoldedProperty> UnfoldedProperties = new List<UnfoldedProperty>();

        /// <summary>
        /// Indicates whether this member will be generated.
        /// </summary>
        public bool Include = true;
    }
}
