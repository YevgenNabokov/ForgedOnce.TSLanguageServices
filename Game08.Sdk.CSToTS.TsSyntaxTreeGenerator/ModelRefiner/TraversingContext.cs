using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace Game08.Sdk.CSToTS.TsSyntaxTreeGenerator.ModelRefiner
{
    public class TraversingContext<T>
    {
        private List<TraversingLevel> _levelCache = new List<TraversingLevel>();

        public T Payload { get; set; }

        public List<TraversingLevel> CurrentPath { get; private set; }

        public TraversingContext(T payload)
        {
            this.Payload = payload;
            this.CurrentPath = new List<TraversingLevel>();
        }

        public TraversingLevel Enter(object node, PropertyInfo parentProperty, int? index = null)
        {
            TraversingLevel level = null;
            if (_levelCache.Count > 0)
            {
                level = _levelCache[_levelCache.Count - 1];
                _levelCache.RemoveAt(_levelCache.Count - 1);
            }
            else
            {
                level = new TraversingLevel();
            }

            if (this.CurrentPath.Count > 0)
            {
                level.Parent = this.CurrentPath[this.CurrentPath.Count - 1];
                this.CurrentPath[this.CurrentPath.Count - 1].Child = level;
            }

            level.Node = node;
            level.ParentProperty = parentProperty;
            level.Index = index;

            this.CurrentPath.Add(level);
            return level;
        }

        public void Exit()
        {
            var level = this.CurrentPath[this.CurrentPath.Count - 1];
            this.CurrentPath.RemoveAt(this.CurrentPath.Count - 1);
            if (this.CurrentPath.Count > 0)
            {
                this.CurrentPath[this.CurrentPath.Count - 1].Child = null;
            }

            level.Reset();
            _levelCache.Add(level);
        }

        public bool IsInPropertyOf(string propertyName, Type type, bool lookImmediateParentOnly = false)
        {
            if (this.CurrentPath.Count > 0)
            {
                var node = this.CurrentPath[this.CurrentPath.Count - 1];
                while (node != null)
                {
                    if (node.ParentProperty != null)
                    {
                        if (node.ParentProperty.Name == propertyName && type.IsAssignableFrom(node.Parent.Node.GetType()))
                        {
                            return true;
                        }
                    }

                    if (lookImmediateParentOnly)
                    {
                        return false;
                    }

                    node = node.Parent;
                }
            }

            return false;
        }
    }
}
