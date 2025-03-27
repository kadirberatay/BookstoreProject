using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Core.DataAccess
{
	public interface IEntityRepository<TEntity, TDto>
	where TEntity : class, IEntity, new()
	where TDto : class
	{
		List<TDto> GetAll(Expression<Func<TEntity, bool>> filter = null);
		TDto Get(Expression<Func<TEntity, bool>> filter);
		void Add(TDto dto);
		void Update(TDto dto);
		void Delete(int id);
	}
}
