using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TestLinqHospital.Dal.Entity
{
    public enum AttributeDataType
    {
        String,
        Int,
        Datetime,
        Boolean
    }

    public class AttributeType
    {
        public Guid Id { get; set; }
        public string DisplayName { get; set; }
        public string Abbreviation { get; set; }
        public AttributeDataType DataType { get; set; }
    }
}
