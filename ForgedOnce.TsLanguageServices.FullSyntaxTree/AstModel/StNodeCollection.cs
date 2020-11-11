using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace ForgedOnce.TsLanguageServices.FullSyntaxTree.AstModel
{
    public class StNodeCollection<TItem> : IReadOnlyList<TItem>, ICollection<TItem> where TItem : IStNode
    {
        private StNode owner;

        private List<TItem> items = new List<TItem>();

        public StNodeCollection(StNode owner)
        {
            this.owner = owner;
        }

        public int Count => this.items.Count;

        public bool IsReadOnly => false;

        public TItem this[int i]
        {
            get
            {
                return this.items[i];
            }

            set
            {
                if (value != null)
                {
                    if (i >= 0 && i < this.items.Count && this.items[i] != null)
                    {
                        this.items[i].Parent = null;
                    }

                    value.Parent = this.owner;
                    this.items[i] = value;
                }
            }
        }

        public int IndexOf(TItem item)
        {
            return this.items.IndexOf(item);
        }

        public void Add(TItem item)
        {
            if (item != null)
            {
                item.Parent = this.owner;
                this.items.Add(item);
            }
        }

        public void AddRange(IEnumerable<TItem> values)
        {
            if (values != null)
            {
                foreach (var item in values)
                {
                    this.Add(item);
                }
            }
        }

        public void Clear()
        {
            foreach (var item in items)
            {
                item.Parent = null;
            }

            this.items.Clear();
        }

        public bool Contains(TItem item)
        {
            return this.items.Contains(item);
        }

        public void CopyTo(TItem[] array, int arrayIndex)
        {
            this.items.CopyTo(array, arrayIndex);
        }

        public IEnumerator<TItem> GetEnumerator()
        {
            return this.items.GetEnumerator();
        }

        public bool Remove(TItem item)
        {
            if (this.items.Contains(item))
            {
                item.Parent = null;
                return this.items.Remove(item);
            }

            return false;
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.items.GetEnumerator();
        }

        public void Reverse()
        {
            this.items.Reverse();
        }
    }
}
