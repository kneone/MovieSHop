using ApplicationCore.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Contracts.Repositories
{
    public interface IPurchaseRepository : IRepository<Purchase>
    {
        public Task<Purchase> GetPurchaseById(int id, int movieId);
        Task<List<Purchase>> GetPurchasesForUser(int id);
    }
}
