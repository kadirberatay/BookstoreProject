using AutoMapper;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFramework
{
	public class EfCategoryDal : EfEntityRepositoryBase<Category, CategoryDto, BookstoreProjectContext>, ICategoryDal
	{
		public EfCategoryDal(BookstoreProjectContext context,IMapper mapper) : base(context,mapper)
		{
		}
	}
}
