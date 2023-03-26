using System;

namespace Unify.Core
{
    public struct UnifyDependency
    {
        public Type Type;
        public string ID;

        public UnifyDependency(Type type, string id)
        {
            Type = type;
            ID = id;
        }

        public override string ToString()
        {
            return $"type: {Type.ToString()} id: {ID}";
        }
    }
}