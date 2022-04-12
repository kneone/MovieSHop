using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Contracts.Repositories
{
    // to have a base interface with some base functionality CRUD operations that can be re used across multiple repos
    public interface IRepository<T> where T : class
    {
        //  get record from table by id
        T GetById(int id);

        // getting all the records for the table
        IEnumerable<T> GetAll();

        T Add(T entity);
        T Update(T entity);
        void Delete(T entity);

    }
}