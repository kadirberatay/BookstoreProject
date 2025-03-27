using Core.Entities;
using Entities.Concrete;
using Entities.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DTOs
{
	public class OrderDto : BaseDto
	{
		public int BookId { get; set; }
		public int Quantity { get; set; }
		public decimal TotalPrice { get; set; }
		public DateTime OrderDate { get; set; }
		public OrderStatus Status { get; set; }
	}
}
