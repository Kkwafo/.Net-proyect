using Microsoft.AspNetCore.Mvc;

namespace TpFinalKofi.WebApi.Controllers
{
    [ApiController]
    public class ClienteController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        //[HttpGet]

    }
}
