using ForgedOnce.TsLanguageServices.AstGeneratorPlugin.ParametersModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ForgedOnce.TsLanguageServices.AstGeneratorPlugin
{
    public class TransportModelHelper
    {
        public static bool TypeReferenceInherits(TransportModelTypeReference parent, TransportModelTypeReference child)
        {
            if (parent.Equals(child))
            {
                return true;
            }

            if (parent is ITransportModelTypeReferenceTransportModelItem<TransportModelItem> parentRef
                && child is ITransportModelTypeReferenceTransportModelItem<TransportModelItem> childRef)
            {
                if (parentRef.GenericArguments.Count > 0)
                {
                    throw new InvalidOperationException("Cannot check inheritance for types with generic arguments.");
                }

                return TypeInherits(parentRef.TransportModelItem, childRef.TransportModelItem);
            }

            return false;
        }

        public static bool TypeInherits(TransportModelItem parent, TransportModelItem child)
        {
            if (parent == child)
            {
                return true;
            }

            if (parent is TransportModelInterface parentInterface)
            {
                if (child is TransportModelEntity childEntity)
                {
                    return childEntity.Interfaces.Any(i => TypeInherits(parent, i)) || (childEntity.BaseEntity != null && TypeInherits(parent, childEntity.BaseEntity.TransportModelItem));
                }
                else
                {
                    if (child is TransportModelInterface childInerface)
                    {
                        return childInerface.Interfaces.Any(i => TypeInherits(parent, i));
                    }
                }
            }
            else
            {
                if (parent is TransportModelEntity parentEntity)
                {
                    if (child is TransportModelEntity childEntity)
                    {
                        return childEntity.BaseEntity != null && TypeInherits(parent, childEntity.BaseEntity.TransportModelItem);
                    }
                    else
                    {
                        if (child is TransportModelInterface childInerface)
                        {
                            return false;
                        }
                    }
                }
            }

            return false;
        }
    }
}
