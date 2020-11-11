using Microsoft.CodeAnalysis.CSharp.Syntax;
using System;
using System.Collections.Generic;
using System.Text;

namespace ForgedOnce.TsLanguageServices.AstGeneratorPlugin.Extensions
{
    public static class ListExtensions
    {
        public static void AddIfNotContains<T>(this List<T> subject, T item)
        {
            if (!subject.Contains(item))
            {
                subject.Add(item);
            }
        }

        public static void AddRangeIfNotContains<T>(this List<T> subject, IEnumerable<T> items)
        {
            foreach (var item in items)
            {
                if (!subject.Contains(item))
                {
                    subject.Add(item);
                }
            }
        }
    }
}
