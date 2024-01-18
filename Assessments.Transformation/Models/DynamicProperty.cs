// ReSharper disable once CheckNamespace
namespace Databank.Domain.Taxonomy // keep namespace from Databank - to avoid trouble down the line if someone is dependent on namespace on the other side of ravendb
{
    public class DynamicProperty
    {
        public class Property
        {
            public string Name { get; set; }
            public string Value { get; set; }
            public Property[] Properties { get; set; }
        }

        public string Id { get; set; }
        public string[] References { get; set; }

        public Property[] Properties { get; set; }
    }
}

