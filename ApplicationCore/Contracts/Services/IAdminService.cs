using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ApplicationCore.Models;

namespace ApplicationCore.Contracts.Services
{
    public interface IAdminService
    {
        Task<bool> AddMovie(MovieAdminModel movie);
        Task<bool> UpdateMovie(MovieAdminModel movie);
    }
}
