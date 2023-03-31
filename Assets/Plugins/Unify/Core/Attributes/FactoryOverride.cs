using System;

namespace Plugins.Unify.Core.Attributes
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