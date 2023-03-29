using System;

namespace Unify.Core.Attributes
{
    public class InjectWithIdAttribute : Attribute
    {
        public readonly string ID;

        public InjectWithIdAttribute(string id)
        {
            ID = id;
        }
    }
}