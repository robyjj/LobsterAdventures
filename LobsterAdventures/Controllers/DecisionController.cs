using Microsoft.AspNetCore.Mvc;

namespace LobsterAdventures.Controllers
{
    public class DecisionController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
