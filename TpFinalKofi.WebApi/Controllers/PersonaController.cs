using Microsoft.AspNetCore.Mvc;

namespace TpFinalKofi.WebApi.Controllers
{
    [ApiController]
    public class PersonaController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        //[HttpGet]

    }
}
