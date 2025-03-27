using Business.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using Entities.Enums;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
	[Route("api/orders")]
	[ApiController]
	public class OrdersController : ControllerBase
	{
		IOrderService _orderService;

		public OrdersController(IOrderService orderService)
		{
			_orderService = orderService;
		}

		[HttpGet("getall")]
		public IActionResult GetAll()
		{
			var result = _orderService.GetAll();
			if (result.Success)
			{
				return Ok(result);
			}

			return BadRequest(result);
		}

		[HttpGet("getbyid")]
		public IActionResult GetById(int id)
		{
			var result = _orderService.GetById(id);
			if (result.Success) 
			{
				return Ok(result);
			}

			return BadRequest(result);
		}

		[HttpPost("add")]
		public IActionResult Add(OrderDto order)
		{
			var result = _orderService.Add(order);
			if (result.Success)
			{
				return Ok(result);
			}

			return BadRequest(result);
		}

		[HttpPost("delete")]
		public IActionResult Delete(int id)
		{
			var result = _orderService.Delete(id);
			if (result.Success)
			{
				return Ok(result);
			}

			return BadRequest(result);
		}

		[HttpPut("update")]
		public IActionResult Update(OrderDto order)
		{
			var result = _orderService.Update(order);
			if (result.Success)
			{
				return Ok(result);
			}

			return BadRequest(result);
		}

		[HttpPut("updatestatus")]
		public IActionResult UpdateStatus(int id, OrderStatus status)
		{
			var result = _orderService.UpdateStatus(id, status);
			if (result.Success)
			{
				return Ok(result);
			}

			return BadRequest(result);
		}
	}
}