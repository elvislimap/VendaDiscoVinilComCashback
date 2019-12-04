using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using VinylRecordSale.Application.Interfaces;
using VinylRecordSale.Domain.Entities;
using VinylRecordSale.Service.Api.Commons;

namespace VinylRecordSale.Service.Api.Controllers.V1
{
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/sale")]
    public class SaleController : ControllerBase
    {
        private readonly ISaleAppService _saleAppService;

        public SaleController(ISaleAppService saleAppService)
        {
            _saleAppService = saleAppService;
        }


        [HttpGet("GetById/{saleId}")]
        public Task<ObjectResult> GetById(int saleId)
        {
            return _saleAppService.Get(saleId).TaskResult();
        }

        [HttpGet("GetPaged/{page}/{initialDate}/{finalDate}")]
        public Task<ObjectResult> GetPaged(int page, DateTime initialDate, DateTime finalDate)
        {
            return _saleAppService.GetPaged(page, initialDate, finalDate).TaskResult();
        }

        [HttpPost("Insert")]
        public Task<ObjectResult> Insert([FromBody] Sale sale)
        {
            return _saleAppService.Insert(sale).TaskResult();
        }
    }
}