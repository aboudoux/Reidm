namespace Reidm.Domain.Common.Events
{
    /// <summary>
    /// Last = 37
    /// </summary>
    public sealed class SerializableTypeIdentifierAttribute : Attribute
    {
        public SerializableTypeIdentifierAttribute(string identifier) => Identifier = identifier;

        public string Identifier { get; }
    }
}