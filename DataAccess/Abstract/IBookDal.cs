using Core.DataAccess;
using Core.Entities;
using Core.Utilities.Results;
using Entities.Concrete;
using Entities.DTOs;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Abstract
{
	public interface IBookDal : IEntityRepository<Book,BookDto>
	{
		List<BookDto> GetSearchByTitle(string title);
		List<BookDto> GetBooksByCategory(int categoryId);
	}
}
