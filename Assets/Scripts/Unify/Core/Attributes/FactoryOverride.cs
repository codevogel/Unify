using System;

namespace Unify.Core.Attributes
{
    internal class FactoryOverrideAttribute : Attribute
    {
        public readonly string ID;

        public FactoryOverrideAttribute(string id)
        {
            ID = id;
        }
    }
}