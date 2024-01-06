using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using Databank.Domain.Taxonomy;

namespace Assessments.Transformation.DynamicProperties
{
    public class DynamicPropertyIDComparer : IEqualityComparer<DynamicProperty>
    {
        public bool Equals(DynamicProperty x, DynamicProperty y)
        {
            return x.Id == y.Id;
        }

        public int GetHashCode([DisallowNull] DynamicProperty obj)
        {
            if (obj == null) { return 0; }

            return obj.Id.GetHashCode();
        }
    }
}