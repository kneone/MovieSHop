using ApplicationCore.Contracts.Repositories;
using ApplicationCore.Contracts.Services;
using ApplicationCore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Infrastructure.Services
{
    public class CastService : ICastService
    {
        private readonly ICastRepository _castRepository;
        public CastService(ICastRepository castRepository)
        {
            _castRepository = castRepository;
        }

        
        public async Task<CastModel> GetCastDetails(int id)
        {
            var cast = await _castRepository.GetById(id);
            var castDetails = new CastModel
            {

                Id = cast.Id,
                Name = cast.Name,
                ProfilePath = cast.ProfilePath,
                
            };
            //may need to return castDetailModel
            return castDetails;
                
        }
    }
}
