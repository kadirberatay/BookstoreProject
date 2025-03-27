using Business.Constants;
using Core.Utilities.Results;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
	public interface IBookService
	{
		IResult Add(BookDto book);
		IResult Delete(int id);
		IResult Update(BookDto book);
		IResult GetSearchByTitle(string title);
		IResult GetBooksByCategory(int categoryId);
		IDataResult<List<BookDto>> GetAll();
		IDataResult<BookDto> GetById(int bookId);
	}
}
