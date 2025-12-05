using Microsoft.AspNetCore.Mvc;
using U5_W1_D5poliziaMunicipale.Models.Entities;
using U5_W1_D5poliziaMunicipale.Services;

namespace U5_W1_D5poliziaMunicipale.Controllers
{
    public class AnagraficaController : Controller
    {
        private readonly AnagraficaService _anagraficaService;
        public AnagraficaController(AnagraficaService anagraficaService)
        {
            _anagraficaService = anagraficaService;
        }
        public async Task <IActionResult> Index()
        {
            List<Anagrafica> anagrafiche = await _anagraficaService.GetAnagraficheAsync();
            return View();
        }
    }
}
