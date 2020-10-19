using System;

namespace ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel
{
    public abstract class StLineAndCharacter
    {
        public StLineAndCharacter(System.Int32 line, System.Int32 character)
        {
            this.line = line;
            this.character = character;
        }

        public System.Int32 line
        {
            get;
            set;
        }

        public System.Int32 character
        {
            get;
            set;
        }
    }
}