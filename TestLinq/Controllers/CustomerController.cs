using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TestLinq.Contract.Dtos;
using TestLinq.Entity;

namespace TestLinq.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private static Func<TestDbContext, IEnumerable<Customer>> Query1 = EF.CompileQuery<TestDbContext, Customer>(context => context.Customers.Where(cust => cust.City == "London"));
        private static Func<TestDbContext, IEnumerable<Customer>> Query2 = EF.CompileQuery<TestDbContext, Customer>(context => context.Customers.Where(cust => cust.Address.StartsWith("221b")));

        private readonly TestDbContext context;
        private readonly IMapper mapper;

        public CustomerController(TestDbContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        [HttpGet("query1")]
        public IEnumerable<CustomerDto> GetQuery1()
        {
            return this.mapper.Map<IEnumerable<CustomerDto>>(Query1(this.context));
        }

        [HttpGet("query2")]
        public IEnumerable<CustomerDto> GetQuery2()
        {
            return this.mapper.Map<IEnumerable<CustomerDto>>(Query2(this.context));
        }
    }
}
