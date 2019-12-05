using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using VinylRecordSale.Domain.Entities;
using VinylRecordSale.Domain.Interfaces.Repositories.Dapper;
using VinylRecordSale.Domain.Interfaces.Services;

namespace VinylRecordSale.Service.Api.Controllers.V1
{
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/vinyldisc")]
    public class VinylDiscController : MainController
    {
        private readonly IVinylDiscDapperRepository _vinylDiscDapperRepository;

        public VinylDiscController(INotificationService notificationService,
            IVinylDiscDapperRepository vinylDiscDapperRepository) : base(notificationService)
        {
            _vinylDiscDapperRepository = vinylDiscDapperRepository;
        }


        [HttpGet("GetById/{vinylDiscId}")]
        public async Task<ActionResult<VinylDisc>> GetById(int vinylDiscId)
        {
            return CustomResponse(await _vinylDiscDapperRepository.GetById(vinylDiscId));
        }

        [HttpGet("GetPaged/{page}/{musicGenreId}")]
        public async Task<ActionResult<IEnumerable<VinylDisc>>> GetPaged(int page, int musicGenreId)
        {
            return CustomResponse(await _vinylDiscDapperRepository.Get(page, musicGenreId));
        }
    }
}