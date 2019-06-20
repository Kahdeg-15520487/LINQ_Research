using System;
using System.Collections.Generic;
using System.Text;

namespace TestLinq.Contract.Dtos
{
    public class CustomerDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
    }
}
