namespace Plugins.Unify.Core.Attributes
{
    public class DependencyOverride
    {
        public string ID { get; set; }
        public object[] CustomParameters;

        public DependencyOverride(string id, object[] customParameters)
        {
            this.CustomParameters = customParameters;
            ID = id;
        }
    }
}