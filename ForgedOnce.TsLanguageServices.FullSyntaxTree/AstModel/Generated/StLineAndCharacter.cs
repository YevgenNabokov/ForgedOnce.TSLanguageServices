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

        System.Int32 _line;
        System.Int32 _character;
        public System.Int32 line
        {
            get
            {
                return this._line;
            }

            set
            {
                this.EnsureIsEditable();
                this._line = value;
            }
        }

        public System.Int32 character
        {
            get
            {
                return this._character;
            }

            set
            {
                this.EnsureIsEditable();
                this._character = value;
            }
        }
    }
}