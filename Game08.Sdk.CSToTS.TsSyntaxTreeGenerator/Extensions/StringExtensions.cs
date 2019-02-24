using System;
using System.Collections.Generic;
using System.Text;

namespace Game08.Sdk.CSToTS.TsSyntaxTreeGenerator.Extensions
{
    public static class StringExtensions
    {
        public static bool StartsWith(this string subject, StringBuilder builder)
        {
            if (subject.Length < builder.Length)
            {
                return false;
            }

            for (var i = 0; i < builder.Length; i++)
            {
                if (subject[i] != builder[i])
                {
                    return false;
                }
            }

            return true;
        }
    }
}
