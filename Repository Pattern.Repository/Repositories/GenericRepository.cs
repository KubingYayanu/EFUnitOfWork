﻿using Repository_Pattern.Entity;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;

namespace Repository_Pattern.Repository
{
    public abstract class GenericRepository<TDbContext, TEntity> : IRepository<TEntity> where TEntity : class, new()
    {
        public GenericRepository(IDbContextFactory contextFactory)
        {
            _context = contextFactory.GetDbContext<TDbContext>();
            _dbSet = _context.Set<TEntity>();
        }

        protected DbContext _context { get; }
        protected DbSet<TEntity> _dbSet { get; }

        public TEntity Get(int id)
        {
            return _dbSet.Find(id);
        }

        public IEnumerable<TEntity> GetAll()
        {
            return _dbSet.ToList();
        }

        public IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> predicate)
        {
            return _dbSet.Where(predicate);
        }

        public void Add(TEntity entity)
        {
            _dbSet.Add(entity);
            SaveChanges();
        }

        public void AddRange(IEnumerable<TEntity> entities)
        {
            _dbSet.AddRange(entities);
            SaveChanges();
        }

        public void Remove(TEntity entity)
        {
            _dbSet.Remove(entity);
            SaveChanges();
        }

        public void RemoveRange(IEnumerable<TEntity> entities)
        {
            _dbSet.RemoveRange(entities);
            SaveChanges();
        }

        public void Update(TEntity entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
            SaveChanges();
        }

        public void UpdateRange(IEnumerable<TEntity> entities)
        {
            foreach (var model in entities)
            {
                _context.Entry(model).State = EntityState.Modified;
            }
            SaveChanges();
        }

        private void SaveChanges()
        {
            _context.SaveChanges();
        }
    }
}