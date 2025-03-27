using Core.Entities.Entity;
using Entities.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Entities.Concrete
{
	public class Order : EntityBase
	{
		public int BookId { get; set; }
		public virtual Book Book { get; set; }
		public int Quantity { get; set; }
		public decimal TotalPrice { get; set; }
		public DateTime OrderDate { get; set; }
		public OrderStatus Status { get; set; }
	}
}
