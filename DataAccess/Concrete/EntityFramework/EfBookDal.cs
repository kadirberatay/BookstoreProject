using AutoMapper;
using Core.Entities;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
using Entities.DTOs;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

public class EfBookDal : EfEntityRepositoryBase<Book, BookDto, BookstoreProjectContext>, IBookDal
{
	private readonly BookstoreProjectContext _context;
	private readonly IMapper _mapper;

	public EfBookDal(BookstoreProjectContext context, IMapper mapper) : base(context, mapper)
	{
		_context = context;
		_mapper = mapper;
	}

	public List<BookDto> GetBooksByCategory(int categoryId)
	{
		var books = _context.Books.Where(b => b.CategoryId == categoryId).ToList();
		return _mapper.Map<List<BookDto>>(books);
	}

	public List<BookDto> GetSearchByTitle(string title)
	{
		var books = _context.Books
			.Where(p => p.Title.ToLower().Contains(title.ToLower()))
			.ToList();

		return _mapper.Map<List<BookDto>>(books);
	}
}

