using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TestLinqHospital.Dal.Entity
{
    public class Patient
    {
        public Guid Id { get; set; }
        public string Name { get; set; }

        public ICollection<AttributeValue> AttributeValues { get; set; }
    }
}
