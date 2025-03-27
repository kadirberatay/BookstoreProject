using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DTOs
{
	public class BookDto : BaseDto
	{
		public string Title { get; set; }
		public string Author { get; set; }
		public string ISBN { get; set; }
		public decimal Price { get; set; }
		public int StockQuantity { get; set; }
		public int PublicationYear { get; set; }
		public int CategoryId { get; set; }
	}
}
