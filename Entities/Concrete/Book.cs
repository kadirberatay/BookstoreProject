using Core.Entities.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Entities.Concrete
{
	public class Book : EntityBase
	{
	    public int CategoryId { get; set; }
		public virtual Category Category { get; set; }
		public string Title { get; set; }
		public string Author { get; set; }
		public string ISBN { get; set; }
		public decimal Price { get; set; }
		public int StockQuantity { get; set; }
		public int PublicationYear { get; set; }
		public ICollection<Order> Orders { get; set; }
	}
}
