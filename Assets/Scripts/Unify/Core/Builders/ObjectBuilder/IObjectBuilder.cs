namespace Unify.Core.Factories.ObjectBuilder
{
    public interface IObjectBuilder<out TObject>
    {
        TObject Build(string name = default);
    }
}