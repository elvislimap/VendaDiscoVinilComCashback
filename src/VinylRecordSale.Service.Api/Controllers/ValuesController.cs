using Microsoft.AspNetCore.Mvc;
using VinylRecordSale.Domain.Interfaces.Repositories.Dapper;

namespace VinylRecordSale.Service.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        private readonly IVinylDiscDapperRepository _vinylDiscDapperRepository;

        public ValuesController(IVinylDiscDapperRepository vinylDiscDapperRepository)
        {
            _vinylDiscDapperRepository = vinylDiscDapperRepository;
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public ActionResult<string> Get(int id)
        {
            var client = _vinylDiscDapperRepository.GetById(id);
            return $"{client.VinylDiscId} - {client.Name} - {client.Value}";
        }
    }
}
