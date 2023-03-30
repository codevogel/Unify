namespace Unify.Core.Builders.ObjectBuilder
{
    public interface IObjectBuilder<out TObject>
    {
        TObject Build(string name = default);
    }
}