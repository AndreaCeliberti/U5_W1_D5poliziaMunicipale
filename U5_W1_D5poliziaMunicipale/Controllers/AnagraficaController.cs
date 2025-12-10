using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using U5_W1_D5poliziaMunicipale.Models.Entities;
using U5_W1_D5poliziaMunicipale.Services;
using U5_W1_D5poliziaMunicipale.ViewModels;

namespace U5_W1_D5poliziaMunicipale.Controllers
{
    public class AnagraficaController : Controller
    {
        private readonly AnagraficaService _anagraficaService;
        private readonly VerbaleService _verbaleService;

        public AnagraficaController(
            AnagraficaService anagraficaService,
            VerbaleService verbaleService)
        {
            _anagraficaService = anagraficaService;
            _verbaleService = verbaleService;
        }

        public async Task<IActionResult> Index()
        {
            List<Anagrafica> anagrafiche = await _anagraficaService.GetAnagraficheAsync();

            List<AnagraficaViewModel> viewModel = anagrafiche.Select(a => new AnagraficaViewModel
            {
                AnagraficaId = a.AnagraficaId,
                Nome = a.Nome,
                Cognome = a.Cognome,
                CodiceFiscale = a.CodiceFiscale,
                Indirizzo = a.Indirizzo,
                Citta = a.Citta,
                Cap = a.Cap,

                // ID del verbale
                Verbale = a.VerbaleId,

                // Per mostrare la descrizione a schermo
                VerbaleDescrizione = a.Verbale?.Violazione?.DescrizioneViolazione
            }).ToList();

            return View(viewModel);
        }

        public async Task<IActionResult> Create()
        {
            var verbali = await _verbaleService.GetVerbaliAsync();

            var model = new AnagraficaViewModel
            {
                ListaVerbali = new SelectList(
                    verbali,
                    "VerbaleId",
                    "Violazione.DescrizioneViolazione"
                )
            };

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> CreateSave(AnagraficaViewModel viewModel)
        {
            var anagrafica = new Anagrafica
            {
                AnagraficaId = Guid.NewGuid(),
                Nome = viewModel.Nome,
                Cognome = viewModel.Cognome,
                CodiceFiscale = viewModel.CodiceFiscale,
                Indirizzo = viewModel.Indirizzo,
                Citta = viewModel.Citta,
                Cap = viewModel.Cap,

                // ID del verbale selezionato
                VerbaleId = (Guid)viewModel.Verbale
            };

            await _anagraficaService.CreateAnagraficaAsync(anagrafica);

            return RedirectToAction("Index");
        }
    }
}
