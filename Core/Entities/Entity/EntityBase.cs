﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entities.Entity
{
	public abstract class EntityBase : IEntity
	{
		public virtual int Id { get; set; }
	}
}
