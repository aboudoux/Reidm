﻿namespace Reidm.Domain.Common.Events
{
    /// <summary>
    /// Last = 25
    /// </summary>
    public sealed class SerializableTypeIdentifierAttribute : Attribute
    {
        public SerializableTypeIdentifierAttribute(string identifier) => Identifier = identifier;

        public string Identifier { get; }
    }
}