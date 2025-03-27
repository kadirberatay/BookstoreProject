using Business.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
	[Route("api/categories")]
	[ApiController]
	public class CategoriesController : ControllerBase
	{
		ICategoryService _categoryService;

		public CategoriesController(ICategoryService categoryService)
		{
			_categoryService = categoryService;
		}

		[HttpGet("getall")]
		public IActionResult GetAll()
		{
			var result = _categoryService.GetAll();
			if (result.Success)
			{
				return Ok(result);
			}

			return BadRequest(result);
		}

		[HttpGet("getbyid")]
		public IActionResult GetById(int id)
		{
			var result = _categoryService.GetById(id);
			if (result.Success)
			{
				return Ok(result);
			}

			return BadRequest();
		}

		[HttpPost("add")]
		public IActionResult Add(CategoryDto category)
		{
			var result = _categoryService.Add(category);
			if (result.Success)
			{
				return Ok(result);
			}

			return BadRequest(result);
		}

		[HttpPost("delete")]
		public IActionResult Delete(int id)
		{
			var result = _categoryService.Delete(id);
			if (result.Success) 
			{
				return Ok(result);
			}

			return BadRequest(result);
		}

		[HttpPut("update")]
		public IActionResult Update(CategoryDto category)
		{
			var result = _categoryService.Update(category);
			if (result.Success)
			{
				return Ok(result);
			}

			return BadRequest(result);
		}
	}
}
