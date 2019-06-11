using System;

namespace TestLinqHospital.Dal.Entity
{
    public class AttributeValue
    {
        public Guid Id { get; set; }
        public Guid AttributeTypeId { get; set; }
        public AttributeType AttributeType { get; set; }
        public Guid PatientId { get; set; }
        public Patient Patient { get; set; }

        public string SerializedValue { get; set; }

        public T GetValue<T>() where T : class
        {
            if (this.AttributeType is null)
            {
                throw new Exception("Attribute type is not included in the object");
            }

            switch (this.AttributeType.DataType)
            {
                case AttributeDataType.String:
                    if (typeof(T) == typeof(string))
                    {
                        return (T)(object)this.SerializedValue;
                    }
                    break;
                case AttributeDataType.Int:
                    if (typeof(T) == typeof(int))
                    {
                        return (T)(object)this.SerializedValue;
                    }
                    break;
                case AttributeDataType.Datetime:
                    if (typeof(T) == typeof(DateTime))
                    {
                        return (T)(object)this.SerializedValue;
                    }
                    break;
                case AttributeDataType.Boolean:
                    if (typeof(T) == typeof(bool))
                    {
                        return (T)(object)this.SerializedValue;
                    }
                    break;
            }
            throw new Exception($"Unknown attribute data type{this.AttributeType.DataType}");
        }
    }
}
