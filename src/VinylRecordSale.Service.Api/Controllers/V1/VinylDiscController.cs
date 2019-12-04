using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using VinylRecordSale.Application.Interfaces;
using VinylRecordSale.Service.Api.Commons;

namespace VinylRecordSale.Service.Api.Controllers.V1
{
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/vinyldisc")]
    public class VinylDiscController : ControllerBase
    {
        private readonly IVinylDiscAppService _vinylDiscAppService;

        public VinylDiscController(IVinylDiscAppService vinylDiscAppService)
        {
            _vinylDiscAppService = vinylDiscAppService;
        }


        [HttpGet("GetById/{vinylDiscId}")]
        public Task<ObjectResult> GetById(int vinylDiscId)
        {
            return _vinylDiscAppService.Get(vinylDiscId).TaskResult();
        }

        [HttpGet("GetPaged/{page}/{musicGenreId}")]
        public Task<ObjectResult> GetPaged(int page, int musicGenreId)
        {
            return _vinylDiscAppService.GetPaged(page, musicGenreId).TaskResult();
        }
    }
}