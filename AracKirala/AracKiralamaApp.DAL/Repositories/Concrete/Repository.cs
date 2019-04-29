﻿using AracKiralamaApp.DAL.Repositories.Abstract;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AracKiralamaApp.DAL.Repositories.Concrete
{
	public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
	{
		protected DbContext _context;
		private DbSet<TEntity> _dbSet;

		public Repository(DbContext context)
		{
			_context = context;
			_dbSet = _context.Set<TEntity>();
		}

		public void Add(TEntity entity)
		{
			_dbSet.Add(entity);
		}

		public void AddRange(IEnumerable<TEntity> entities)
		{
			_dbSet.AddRange(entities);
		}

		public IEnumerable<TEntity> GetAll()
		{
			return _dbSet.ToList<TEntity>();
		}

		public TEntity GetById(int id)
		{
			return _dbSet.Find(id);
		}

		public void Remove(int id)
		{
			_dbSet.Remove(GetById(id));
		}

		public void RemoveRange(IEnumerable<TEntity> entities)
		{
			_dbSet.RemoveRange(entities);
		}
	}
}
