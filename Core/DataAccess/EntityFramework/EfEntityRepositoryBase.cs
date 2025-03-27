using AutoMapper;
using Core.DataAccess;
using Core.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

public class EfEntityRepositoryBase<TEntity, TDto, TContext> : IEntityRepository<TEntity,TDto>
	where TEntity : class, IEntity, new()
	where TDto : class, new()
	where TContext : DbContext
{
	private readonly TContext _context;
	private readonly IMapper _mapper;

	public EfEntityRepositoryBase(TContext context, IMapper mapper)
	{
		_context = context;
		_mapper = mapper;
	}

	public void Add(TDto dto)
	{
		var entity = _mapper.Map<TEntity>(dto);
		var addedEntity = _context.Entry(entity);
		addedEntity.State = EntityState.Added;
		_context.SaveChanges();
	}

	public void Delete(int id)
	{
		var entity = _context.Set<TEntity>().Find(id);
		if (entity != null)
		{
			_context.Set<TEntity>().Remove(entity);
			_context.SaveChanges();
		}
		else
		{
			throw new Exception("Entity not found.");
		}
	}

	public TDto Get(Expression<Func<TEntity, bool>> filter)
	{
		var entity = _context.Set<TEntity>().SingleOrDefault(filter);
		return _mapper.Map<TDto>(entity);
	}

	public List<TDto> GetAll(Expression<Func<TEntity, bool>> filter = null)
	{
		var entities = filter == null
			? _context.Set<TEntity>().ToList()
			: _context.Set<TEntity>().Where(filter).ToList();

		return _mapper.Map<List<TDto>>(entities);
	}

	public void Update(TDto dto)
	{
		var entity = _mapper.Map<TEntity>(dto);
		var updatedEntity = _context.Entry(entity);
		updatedEntity.State = EntityState.Modified;
		_context.SaveChanges();
	}
}
