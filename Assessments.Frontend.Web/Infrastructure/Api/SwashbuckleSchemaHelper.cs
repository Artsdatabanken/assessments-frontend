using System.Collections.Generic;
using System;
using System.Linq;

namespace Assessments.Frontend.Web.Infrastructure.Api
{
    /// <summary>
    /// Fixes schemaid issues (if model names are duplicated in different namespaces)
    /// </summary>
    public class SwashbuckleSchemaHelper
    {
        private readonly Dictionary<string, List<string>> _schemaNameRepetition = new();

        private static string DefaultSchemaIdSelector(Type modelType)
        {
            if (!modelType.IsConstructedGenericType) 
                return modelType.Name.Replace("[]", "Array");

            var prefix = modelType.GetGenericArguments().Select(DefaultSchemaIdSelector).Aggregate((previous, current) => previous + current);

            return $"{prefix}{modelType.Name.Split('`').First()}";
        }

        public string GetSchemaId(Type modelType)
        {
            var id = DefaultSchemaIdSelector(modelType);

            if (!_schemaNameRepetition.ContainsKey(id))
                _schemaNameRepetition.Add(id, new List<string>());

            var modelNameList = _schemaNameRepetition[id];
            var fullName = modelType.FullName ?? "";
            
            if (!string.IsNullOrEmpty(fullName) && !modelNameList.Contains(fullName))
                modelNameList.Add(fullName);

            var index = modelNameList.IndexOf(fullName);

            return $"{id}{(index >= 1 ? index.ToString() : "")}";
        }
    }
}
