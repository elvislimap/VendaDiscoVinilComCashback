using Microsoft.AspNetCore.Mvc;
using System.Linq;
using VinylRecordSale.Domain.Interfaces.Services;

namespace VinylRecordSale.Service.Api.Controllers
{
    [ApiController]
    public abstract class MainController : ControllerBase
    {
        private readonly INotificationService _notificationService;

        protected MainController(INotificationService notificationService)
        {
            _notificationService = notificationService;
        }


        protected ActionResult CustomResponse(object result = null)
        {
            if (_notificationService.HaveNotification())
            {
                return BadRequest(new
                {
                    success = false,
                    errors = _notificationService.GetNotifications().Select(n => n.Message)
                });
            }

            return Ok(new
            {
                success = true,
                data = result
            });
        }
    }
}