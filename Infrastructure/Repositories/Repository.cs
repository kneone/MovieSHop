﻿using ApplicationCore.Contracts.Repositories;
using Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositories
{
    public class Repository<T> : IRepository<T> where T : class
    {
        // we are gonna use MovieShopDbContext

        protected readonly MovieShopDbContext _dbContext;

        public Repository(MovieShopDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public T Add(T entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(T entity)
        {
            throw new NotImplementedException();
        }

        public virtual IEnumerable<T> GetAll()
        {
            throw new NotImplementedException();
        }

        public virtual T GetById(int id)
        {
            throw new NotImplementedException();
        }

        public T Update(T entity)
        {
            throw new NotImplementedException();
        }
    }
}