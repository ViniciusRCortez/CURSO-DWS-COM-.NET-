using AutoMapper;
using Dws.Note_one.Api.Domain.Models;
using Dws.Note_one.Api.Resource;

namespace Dws.Note_one.Api.Mapping
{
    public class ModelToResourceProfile : Profile
    {
        public ModelToResourceProfile()
        {
            CreateMap<Category, CategoryResource>();
            CreateMap<Product, ProductResource>();
            CreateMap<User, UserResource>();
            CreateMap<Costumer, CostumerResource>();
        }
    }
}