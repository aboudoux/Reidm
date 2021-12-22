namespace Reidm.Infrastructure.Serialization
{
    public interface ISerializer
    {
        string Serialize(object value);
        object Deserialize(string value);
    }
}