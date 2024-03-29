﻿using AutoMapper;
using TestLinq.Contract.Dtos;
using TestLinq.Entity;

namespace TestLinq
{
    internal class AutoMapperProfileConfiguration : Profile
    {
        public AutoMapperProfileConfiguration()
        {
            this.CreateMap<User, UserDto>();
            this.CreateMap<Blog, BlogDto>();
            this.CreateMap<Post, PostDto>();
            this.CreateMap<Customer, CustomerDto>();

            this.CreateMap<UserDto, User>();
            this.CreateMap<BlogDto, Blog>();
            this.CreateMap<PostDto, Post>();
            this.CreateMap<CustomerDto, Customer>();
        }

        public AutoMapperProfileConfiguration(string profileName)
            : base(profileName)
        {

        }
    }
}