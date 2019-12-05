using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using VinylRecordSale.Application.Interfaces;
using VinylRecordSale.Domain.Entities;
using VinylRecordSale.Domain.Interfaces.Repositories.Dapper;
using VinylRecordSale.Domain.Interfaces.Services;

namespace VinylRecordSale.Service.Api.Controllers.V1
{
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/sale")]
    public class SaleController : MainController
    {
        private readonly ISaleAppService _saleAppService;
        private readonly ISaleDapperRepository _saleDapperRepository;

        public SaleController(INotificationService notificationService, ISaleAppService saleAppService,
            ISaleDapperRepository saleDapperRepository) : base(notificationService)
        {
            _saleAppService = saleAppService;
            _saleDapperRepository = saleDapperRepository;
        }


        [HttpGet("GetById/{saleId}")]
        public async Task<ActionResult<Sale>> GetById(int saleId)
        {
            return CustomResponse(await _saleDapperRepository.GetById(saleId));
        }

        [HttpGet("GetPaged/{page}/{initialDate}/{finalDate}")]
        public async Task<ActionResult<IEnumerable<Sale>>> GetPaged(int page, DateTime initialDate, DateTime finalDate)
        {
            return CustomResponse(await _saleDapperRepository.Get(page, initialDate, finalDate));
        }

        [HttpPost("Insert")]
        public async Task<ActionResult> Insert([FromBody] Sale sale)
        {
            return CustomResponse(await _saleAppService.Insert(sale));
        }
    }
}