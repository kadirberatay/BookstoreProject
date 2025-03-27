using Business.Abstract;
using Business.Constants;
using Core.Utilities.Business;
using Core.Utilities.Results;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
using Entities.DTOs;
using Entities.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
	public class OrderManager : IOrderService
	{
		IOrderDal _orderDal;
		IBookService _bookService;

		public OrderManager(IOrderDal orderDal, IBookService bookService)
		{
			_orderDal = orderDal;
			_bookService = bookService;
		}

		public IResult Add(OrderDto order)
		{
			try
			{
				IResult result = BusinessRules.Run(CheckIfStockExists(order.BookId, order.Quantity));

				if (result != null)
				{
					return result;
				}

				_orderDal.Add(order);

				return new SuccessResult(Messages.EntityAdded);
			}
			catch (Exception ex)
			{
				return new ErrorResult(Messages.InvalidOrderData);
			}
		}

		public IResult Delete(int id)
		{
			_orderDal.Delete(id);

			return new SuccessResult(Messages.EntityDeleted);
		}

		public IDataResult<List<OrderDto>> GetAll()
		{
			return new SuccessDataResult<List<OrderDto>>(_orderDal.GetAll(), Messages.EntitysListed);
		}

		public IDataResult<OrderDto> GetById(int id)
		{
			return new SuccessDataResult<OrderDto>(_orderDal.Get(p => p.Id == id));
		}

		public IResult Update(OrderDto order)
		{
			IResult result = BusinessRules.Run(CheckIfStockExists(order.BookId, order.Quantity));

			if (result != null)
			{
				return result;
			}

			_orderDal.Update(order);

			return new SuccessResult(Messages.EntityUpdated);
		}

		private IResult CheckIfStockExists(int? bookId, int orderQuantity)
		{
			if (!bookId.HasValue || bookId.Value <= 0)
			{
				return new ErrorResult(Messages.InvalidInputData);
			}

			var totalOrderedQuantity = _orderDal.GetAll(p => p.BookId == bookId.Value).Sum(o => o.Quantity) + orderQuantity;

			var bookStockQuantity = _bookService.GetById(bookId.Value).Data.StockQuantity;

			if (bookStockQuantity < totalOrderedQuantity)
			{
				return new ErrorResult(Messages.CheckIfStockQuantity);
			}

			return new SuccessResult();
		}

		public IResult UpdateStatus(int id, OrderStatus status)
		{
			_orderDal.UpdateStatus(id, status);

			return new SuccessResult(Messages.EntityUpdated);
		}
	}
}
