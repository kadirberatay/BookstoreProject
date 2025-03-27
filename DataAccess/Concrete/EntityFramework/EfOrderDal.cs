using AutoMapper;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
using Entities.DTOs;
using Entities.Enums;
using System;

public class EfOrderDal : EfEntityRepositoryBase<Order,OrderDto, BookstoreProjectContext>, IOrderDal
{
	private readonly BookstoreProjectContext _context;

	public EfOrderDal(BookstoreProjectContext context,IMapper mapper) : base(context, mapper)
	{
		_context = context;
	}

	public void UpdateStatus(int id, OrderStatus status)
	{
		var order = _context.Orders.Find(id);
		if (order != null)
		{
			order.Status = status;

			_context.Orders.Update(order);
			_context.SaveChanges();
		}
		else
		{
			throw new Exception("Order not found");
		}
	}
}

