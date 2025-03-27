using Core.DataAccess;
using Entities.Concrete;
using Entities.DTOs;
using Entities.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Abstract
{
	public interface IOrderDal : IEntityRepository<Order,OrderDto>
	{
		void UpdateStatus(int id, OrderStatus status);
	}
}