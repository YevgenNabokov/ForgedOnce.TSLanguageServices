using System;
using System.Collections.Generic;
using System.Text;

namespace Game08.Sdk.CSToTS.TsSyntaxTreeGenerator.Extensions
{
    public static class StringBuilderExtensions
    {
        public static bool StartsWith(this StringBuilder subject, string str)
        {
            if (subject.Length < str.Length)
            {
                return false;
            }

            for (var i = 0; i < str.Length; i++)
            {
                if (subject[i] != str[i])
                {
                    return false;
                }
            }

            return true;
        }
    }
}
