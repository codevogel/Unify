using System;

namespace Unify.Core.Attributes
{
    public class FactoryOverrideAttribute : Attribute
    {
        public readonly string ID;

        public FactoryOverrideAttribute(string id)
        {
            ID = id;
        }
    }
}