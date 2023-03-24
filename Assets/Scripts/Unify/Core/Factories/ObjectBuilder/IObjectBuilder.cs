namespace Unify.Core.Factories.ObjectBuilder
{
    public interface IObjectBuilder
    {
        T Build<T>(string name = default);
    }
}