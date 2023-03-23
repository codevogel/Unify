using System;

namespace Unify.Core.Attributes
{
    internal class InjectWithIdAttribute : Attribute
    {
        public readonly string ID;

        public InjectWithIdAttribute(string id)
        {
            ID = id;
        }
    }
}