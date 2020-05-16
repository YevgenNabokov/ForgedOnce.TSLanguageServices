# Syntax Tree Extensions Plugin
This is a [ForgedOnce](https://github.com/YevgenNabokov/ForgedOnce) code generation pipeline plugin that allows to
generate C# extensions for fluent modification for a set of input classes.
Originally was created to extend syntax tree definitions.

For example for a given class
```csharp
using System;
public class TestClass
{
    public int PropA { get; set; }
    public string PropB { get; set; }
}
```
it will generate the following extension
```csharp
using System;
namespace YourTargetNamespace
{
    public static partial class TestClassExtensions
    {
        public static TestClass WithPropA(this TestClass subject, int propA)
        {
            subject.PropA = propA;
            return subject;
        }

        public static TestClass WithPropB(this TestClass subject, string propB)
        {
            subject.PropB = propB;
            return subject;
        }
    }
}
```
that allows to modify the instance of TestClass like this
```csharp
TestClass a = new TestClass().WithPropA(10).WithPropB("Some string.");
```

## Configuration
In a pipeline this plugin can be configured with the following parameters:
* **outputNamespace** - output namespace for the extensions
* **requiredClassBaseType** (optional) - fully qualified .NET type that is required for input class to be or inherit or implement as interface.
* **typesToUnfold** (optional) - semicolon delimitered fully qualified .NET types that will be inlined in extension methods. No extensions are generated for those if encountreed in the input.
* **ignorePropertyNames** (optional) - semicolon delimitered list of property names for which no extension methods will be generated.
* **unpluralizeVariables** (optional, default=false) - boolean parameter allowing to unpluralize plural names for collection-like properties in extension methods that will add single item.

Example configuration:
```json
"config": {
                "outputNamespace": "ForgedOnce.TsLanguageServices.ModelBuilder.ExtensionMethods",
                "requiredClassBaseType": "ForgedOnce.TsLanguageServices.ModelBuilder.DefinitionTree.Node",
                "typesToUnfold": "ForgedOnce.TsLanguageServices.ModelBuilder.DefinitionTree.Identifier;ForgedOnce.TsLanguageServices.ModelBuilder.DefinitionTree.TypeReferenceId",
                "ignorePropertyNames": "Parent",
                "unpluralizeVariables": "true"
              }
```

## Parameters and Settings
Plugin parameters and settings to use with custom preprocessor are represented by **ForgedOnce.TsLanguageServices.SyntaxTreeExtensionsPlugin.Parameters** and
**ForgedOnce.TsLanguageServices.SyntaxTreeExtensionsPlugin.Settings** and documented within a code.

## Metadata
Plugin is recording two kinds of metadata in the output code files:
* Root level *SymbolGenerated*
* For each extension class *SymbolGenerated* with relation to source class