using Business.Abstract;
using Business.Constants;
using Core.Utilities.Business;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
	public class BookManager : IBookService
	{
		IBookDal _bookDal;
		ICategoryService _categoryService;
		public BookManager(IBookDal bookDal, ICategoryService categoryService)
		{
			_bookDal = bookDal;
			_categoryService = categoryService;
		}
		public IResult Add(BookDto book)
		{
			IResult result = BusinessRules.Run(CheckIfBookNameExists(book.Title));

			if(result != null)
			{
				return result;
			}

			_bookDal.Add(book);

			return new SuccessResult(Messages.EntityAdded);
		}

		public IResult Delete(int id)
		{
			_bookDal.Delete(id);

			return new SuccessResult(Messages.EntityDeleted);
		}

		public IDataResult<List<BookDto>> GetAll()
		{
			return new SuccessDataResult<List<BookDto>>(_bookDal.GetAll(), Messages.EntitysListed);
		}

		public IResult GetBooksByCategory(int categoryId)
		{
			IResult result = BusinessRules.Run(CheckIfCategoryExists(categoryId));

			if (result != null)
			{
				return result;
			}

			return new SuccessDataResult<List<BookDto>>(_bookDal.GetBooksByCategory(categoryId), Messages.EntitysListed);
		}

		public IDataResult<BookDto> GetById(int bookId)
		{
			IResult result = BusinessRules.Run(CheckIfBookExists(bookId));

			if (result != null && !result.Success)
			{
				return new ErrorDataResult<BookDto>(null, result.Message);
			}

			return new SuccessDataResult<BookDto>(_bookDal.Get(p => p.Id == bookId));
		}

		public IResult GetSearchByTitle(string title)
		{
			if (title == null)
			{
				return new ErrorResult(Messages.InvalidInputData);
			}

			return new SuccessDataResult<List<BookDto>>(_bookDal.GetSearchByTitle(title), Messages.EntitysListed);
		}

		public IResult Update(BookDto book)
		{
			IResult result = BusinessRules.Run(CheckIfBookNameExists(book.Title,book.Id));

			if (result != null)
			{
				return result;
			}

			_bookDal.Update(book);

			return new SuccessResult(Messages.EntityUpdated);
		}

		private IResult CheckIfCategoryExists(int categoryId)
		{
			var result = _categoryService.GetById(categoryId);
			if (result.Data == null)
			{	
				return new ErrorResult(Messages.CheckIfCategoryExists);
			}

			return new SuccessResult();
		}

		private IResult CheckIfBookNameExists(string title, int? bookId = null)
		{
			var result = _bookDal.GetAll(p => p.Title == title && (bookId == null || p.Id != bookId)).Any();
			if (result)
			{
				return new ErrorResult(Messages.TitleAlreadyExists);
			}

			return new SuccessResult();
		}

		private IResult CheckIfBookExists(int id)
		{
			var result = _bookDal.GetAll(p => p.Id == id).Any();
			if (!result)
			{
				return new ErrorResult(Messages.CheckIfBookExists);
			}

			return new SuccessResult();
		}
	}
}
