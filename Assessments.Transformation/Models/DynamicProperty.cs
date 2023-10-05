using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assessments.Transformation.Models
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

