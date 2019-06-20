using System;
using System.Collections.Generic;
using System.Text;
using TestLinq.Contract.Dtos;

namespace TestLinq.Contract
{
    public interface IBlogService
    {
        IEnumerable<BlogDto> GetAll();
        BlogDto Get(Guid id);
        BlogDto Create(BlogDto blog);
    }
}
