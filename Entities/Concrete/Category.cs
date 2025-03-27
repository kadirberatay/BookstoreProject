using Core.Entities.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Entities.Concrete
{
	public class Category : EntityBase
	{
		public string Name { get; set; }
		public ICollection<Book> Books { get; set; }
	}
}
