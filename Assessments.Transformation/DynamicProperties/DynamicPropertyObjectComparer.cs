using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using Assessments.Transformation.Models;

namespace Assessments.Transformation.DynamicProperties
{
    public class DynamicPropertyObjectComparer : IEqualityComparer<DynamicProperty>
    {
        public bool Equals(DynamicProperty x, DynamicProperty y)
        {
            // If both are null, or both are the same instance, return true
            if (ReferenceEquals(x, y))
            {
                return true;
            }

            // If one is null, return false
            if (x is null || y is null)
            {
                return false;
            }

            return x.Id == y.Id &&
                   ((IStructuralEquatable)x.References).Equals(y.References, EqualityComparer<string>.Default) &&
                   CheckPropertiesEquality(x.Properties, y.Properties);
        }

        public int GetHashCode([DisallowNull] DynamicProperty obj)
        {
            if (obj == null) { return 0; }

            int hashId = obj.Id.GetHashCode();
            int hashReferences = ((IStructuralEquatable)obj.References).GetHashCode(EqualityComparer<string>.Default);
            int HashProperties = obj.Properties?.Select(p => p.Name?.GetHashCode() + p.Value?.GetHashCode() + p.Properties?.Select(p2 => p2.Name?.GetHashCode() + p2.Value?.GetHashCode() ?? 0).Sum()).Sum() ?? 0; //NOTE: calculates hash codes 2 levels down into the recurrent Property object, this should be sufficient for assessments

            return HashCode.Combine(hashId, hashReferences, HashProperties);
        }

        private static bool CheckPropertiesEquality(DynamicProperty.Property[] xProps, DynamicProperty.Property[] yProps)
        {
            if (xProps == yProps) return true;
            if (xProps is null || yProps is null) return false;
            if (xProps.Length != yProps.Length) return false;

            for (int i = 0; i < xProps.Length; i++)
            {
                if (xProps[i].Name != yProps[i].Name || xProps[i].Value != yProps[i].Value)
                    return false;

                if (!CheckPropertiesEquality(xProps[i].Properties, yProps[i].Properties))
                    return false;
            }

            return true;
        }
    }
}