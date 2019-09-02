using System;
using System.Collections.Generic;
using System.Text;

namespace Game08.Sdk.LTS.Builder.TypeData
{
    public class NsIndex<T> where T : new()
    {
        private readonly char separator;

        private Dictionary<string, NsIndex<T>> subIndexes = new Dictionary<string, NsIndex<T>>();

        private T item = new T();

        public NsIndex(char separator)
        {
            this.separator = separator;
        }

        public T Get(string ns)
        {
            return this.Get(ns.Split(this.separator), 0);
        }

        private T Get(string[] nsParts, int index)
        {
            if (nsParts.Length > index)
            {
                if (!subIndexes.ContainsKey(nsParts[index]))
                {
                    this.subIndexes.Add(nsParts[index], new NsIndex<T>(this.separator));
                }

                return this.subIndexes[nsParts[index]].Get(nsParts, index + 1);
            }
            else
            {
                return this.item;
            }
        }

        public IEnumerable<T> GetRecursive(string ns)
        {
            List<T> result = new List<T>();
            var nsContainer = this.Find(ns.Split(this.separator), 0);
            if (nsContainer != null)
            {
                nsContainer.Collect(result);
            }

            return result;
        }

        private void Collect(List<T> output)
        {
            output.Add(this.item);

            foreach (var subNs in this.subIndexes)
            {
                subNs.Value.Collect(output);
            }
        }

        private NsIndex<T> Find(string[] nsParts, int index)
        {
            if (nsParts.Length > index)
            {
                if (!subIndexes.ContainsKey(nsParts[index]))
                {
                    return null;
                }

                return this.subIndexes[nsParts[index]].Find(nsParts, index + 1);
            }
            else
            {
                return this;
            }
        }
    }
}
