using AutoMapper;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.MappingProfile
{
	public class MappingProfile : Profile
	{
		public MappingProfile()
		{
			CreateMap<Category, CategoryDto>().ReverseMap();
			CreateMap<Book, BookDto>().ReverseMap();
			CreateMap<Order, OrderDto>().ReverseMap();
		}
	}
}
