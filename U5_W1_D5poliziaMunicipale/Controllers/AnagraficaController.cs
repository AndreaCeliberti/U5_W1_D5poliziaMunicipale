using Microsoft.AspNetCore.Mvc;
using U5_W1_D5poliziaMunicipale.Models.Entities;
using U5_W1_D5poliziaMunicipale.Services;
using U5_W1_D5poliziaMunicipale.ViewModels;

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

            List<AnagraficaViewModel> anagraficaViewModels = anagrafiche.Select(a => new AnagraficaViewModel()
            {
                 AnagraficaId = a.AnagraficaId,
                 Nome = a.Nome,
                 Cognome = a.Cognome,
                 CodiceFiscale = a.CodiceFiscale,
                 Indirizzo = a.Indirizzo,
                 Citta = a.Citta,
                 Cap = a.Cap,
                 Verbale = a.Verbale.Violazione.DescrizioneViolazione,
            }
            ).ToList();
            return View();
        }
    }
}
