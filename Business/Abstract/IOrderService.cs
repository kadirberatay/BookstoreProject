using Core.Utilities.Results;
using Entities.Concrete;
using Entities.DTOs;
using Entities.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
	public interface IOrderService
	{
		IResult Add(OrderDto order);
		IResult Delete(int id);
		IResult Update(OrderDto order);
		IResult UpdateStatus(int id, OrderStatus status);
		IDataResult<List<OrderDto>> GetAll();
		IDataResult<OrderDto> GetById(int id);
	}
}
