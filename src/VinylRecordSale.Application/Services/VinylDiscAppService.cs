using VinylRecordSale.Application.Interfaces;
using VinylRecordSale.Domain.Interfaces.Repositories.Dapper;
using VinylRecordSale.Domain.ValueObjects;

namespace VinylRecordSale.Application.Services
{
    public class VinylDiscAppService : IVinylDiscAppService
    {
        private readonly IVinylDiscDapperRepository _vinylDiscDapperRepository;

        public VinylDiscAppService(IVinylDiscDapperRepository vinylDiscDapperRepository)
        {
            _vinylDiscDapperRepository = vinylDiscDapperRepository;
        }


        public Result Get(int vinylDiscId)
        {
            return new Result(_vinylDiscDapperRepository.GetById(vinylDiscId));
        }

        public Result GetPaged(int page, int musicGenreId)
        {
            return new Result(_vinylDiscDapperRepository.Get(page, musicGenreId));
        }
    }
}