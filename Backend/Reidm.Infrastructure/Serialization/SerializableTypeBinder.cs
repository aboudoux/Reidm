using System.Reflection;
using Newtonsoft.Json.Serialization;
using Reidm.Domain.Common.Events;

namespace Reidm.Infrastructure.Serialization
{
    public class SerializableTypeBinder : ISerializationBinder 
    {
        private readonly Dictionary<string, Type> _knownTypesDictionary;

        public SerializableTypeBinder(params Assembly[] assembliesToScan)
        {
            var assemblies = assembliesToScan.Any() ? assembliesToScan : new[] { Assembly.GetExecutingAssembly() };

            var types = assemblies.Aggregate(Enumerable.Empty<Type>(), (current, assembly) 
                => current.Concat(ScanAssemblyForRegisterAllDomainEvents(assembly)));

            _knownTypesDictionary = types.ToDictionary(a => 
                a.GetCustomAttribute<SerializableTypeIdentifierAttribute>()?.Identifier ?? throw new MissingMemberException(a.Name, typeof(SerializableTypeIdentifierAttribute).Name), a => a);
        }

        private IEnumerable<Type> ScanAssemblyForRegisterAllDomainEvents(Assembly assemblyToScan) 
            => assemblyToScan.GetAllConcreteTypeThatImplementInterface<ISerializableType>();

        public Type BindToType(string assemblyName, string typeName) => _knownTypesDictionary[typeName];

        public void BindToName(Type serializedType, out string assemblyName, out string typeName)
        {
            assemblyName = null;
            typeName = serializedType.GetCustomAttribute<SerializableTypeIdentifierAttribute>().Identifier.ToString();
        }
    }
}