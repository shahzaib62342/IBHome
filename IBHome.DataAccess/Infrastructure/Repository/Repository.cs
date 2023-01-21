﻿using IBHome.DataAccess.Data;
using IBHome.DataAccess.Infrastructure.IRepository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace IBHome.DataAccess.Infrastructure.Repository
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly ApplicationDbContext _context;
        private  DbSet<T> _dbset;
        public Repository(ApplicationDbContext context) 
        { 
            _context = context;
            _dbset= _context.Set<T>();
        }

        public void Add(T entity)
        {
            _dbset.Add(entity);
        }

        public void Delete(T entity)
        {
           _dbset.Remove(entity);
        }

        public void DeleteRange(IEnumerable<T> entity)
        {
            _dbset.RemoveRange(entity);
        }

        public IEnumerable<T> GetAll()
        {
            return _dbset.ToList();
        }

        public T GetById(Expression<Func<T, bool>> predicate)
        {
            return _dbset.Where(predicate).FirstOrDefault();
        }
    }
}
