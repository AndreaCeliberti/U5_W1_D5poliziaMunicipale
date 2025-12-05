using Microsoft.AspNetCore.Mvc;
using U5_W1_D5poliziaMunicipale.Models.Entities;
using U5_W1_D5poliziaMunicipale.Services;

namespace U5_W1_D5poliziaMunicipale.Controllers
{
    public class VerbaleController : Controller
    {
        private readonly VerbaleService _verbaleService;
        public VerbaleController(VerbaleService verbaleService)
        {
            _verbaleService = verbaleService;
        }
        public async Task<IActionResult> Index()
        {
            List<Verbale> verbali = await _verbaleService.GetVerbaliAsync();
            return View();
        }
    }
}
