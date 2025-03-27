using Business.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
	[Route("api/books")]
	[ApiController]
	public class BooksController : ControllerBase
	{
		IBookService _bookService;

		public BooksController(IBookService bookService)
		{
			_bookService = bookService;
		}

		[HttpGet("getall")]
		public IActionResult GetAll()
		{
			var result = _bookService.GetAll();
			if (result.Success)
			{
				return Ok(result);
			}

			return BadRequest(result);
		}

		[HttpGet("getbooksbycategory")]
		public IActionResult GetBooksByCategory(int categoryId)
		{
			var result = _bookService.GetBooksByCategory(categoryId);
			if (result.Success)
			{
				return Ok(result);
			}

			return BadRequest(result);
		}

		[HttpGet("searchbytitle")]
		public IActionResult SearchByTitle(string title)
		{
			var result = _bookService.GetSearchByTitle(title);
			if (result.Success)
			{
				return Ok(result);
			}

			return BadRequest(result);
		}

		[HttpGet("getbyid")]
		public IActionResult GetById(int id)
		{
			var result = _bookService.GetById(id);
			if (result.Success)
			{
				return Ok(result);
			}

			return BadRequest(result);
		}

		[HttpPost("add")]
		public IActionResult Add(BookDto book)
		{
			var result = _bookService.Add(book);
			if (result.Success)
			{
				return Ok(result);
			}

			return BadRequest(result);
		}

		[HttpPost("delete")]
		public IActionResult Delete(int id)
		{
			var result = _bookService.Delete(id);
			if (result.Success)
			{
				return Ok(result);
			}

			return BadRequest(result);
		}

		[HttpPut("update")]
		public IActionResult Update(BookDto book)
		{
			var result = _bookService.Update(book);
			if (result.Success)
			{
				return Ok(result);
			}

			return BadRequest(result);
		}
	}
}