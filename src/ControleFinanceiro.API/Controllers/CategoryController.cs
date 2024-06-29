using ControleFinanceiro.API.Notifications;
using Microsoft.AspNetCore.Mvc;

namespace ControleFinanceiro.API.Controllers
{
    [Route("api/categories")]
    public class CategoryController : MainController
    {
        public CategoryController(INotificator notificator) : base(notificator)
        {
        }

        [HttpPost]
        public IActionResult Index()
        {
            return CustomResponse();
        }
    }
}
