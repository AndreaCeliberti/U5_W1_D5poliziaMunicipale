using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using U5_W1_D5poliziaMunicipale.Models.Entities;
using U5_W1_D5poliziaMunicipale.Services;
using U5_W1_D5poliziaMunicipale.ViewModels;

namespace U5_W1_D5poliziaMunicipale.Controllers
{
    public class VerbaleController : Controller
    {
        private readonly VerbaleService _verbaleService;
        private readonly ViolazioneService _violazioneService;

        public VerbaleController(VerbaleService verbaleService, ViolazioneService violazioneService)
        {
            _verbaleService = verbaleService;
            _violazioneService = violazioneService;
        }

        // Mostra tutti i verbali
        public async Task<IActionResult> Index()
        {
            List<Verbale> verbali = await _verbaleService.GetVerbaliAsync();

            List<VerbaleViewModel> verbaleViewModels = verbali.Select(ve => new VerbaleViewModel()
            {
                VerbaleId = ve.VerbaleId,
                NominativoAgente = ve.NominativoAgente,
                DataTrascrizione = ve.DataTrascrizione,
                DataViolazione = ve.DataViolazione,
                IndirizzoViolazione = ve.IndirizzoViolazione,
                ImportoMulta = ve.ImportoMulta,
                DecurtazionePunti = ve.DecurtazionePunti,
                Violazione = ve.Violazione != null ? ve.Violazione.DescrizioneViolazione : string.Empty
            }).ToList();

            return View(verbaleViewModels);
        }

        // Mostra il form per creare un verbale
        public async Task<IActionResult> Create()
        {
            var violazioni = await _violazioneService.GetViolazioniAsync();
            var viewModel = new VerbaleViewModel()
            {
                ListaViolazioni = violazioni.Select(v => new SelectListItem
                {
                    Value = v.DescrizioneViolazione,
                    Text = v.DescrizioneViolazione
                })
            };
            return View(viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> CreateSave(VerbaleViewModel verbaleViewModel)
        {
            // Validazione lato server: Violazione obbligatoria
            if (string.IsNullOrWhiteSpace(verbaleViewModel.Violazione))
            {
                ModelState.AddModelError("Violazione", "Seleziona una violazione valida.");
            }

            
            if (!ModelState.IsValid)
            {
                
                var violazioni = await _violazioneService.GetViolazioniAsync();
                verbaleViewModel.ListaViolazioni = violazioni.Select(v => new SelectListItem
                {
                    Value = v.DescrizioneViolazione,
                    Text = v.DescrizioneViolazione
                });
                return View("Create", verbaleViewModel);
            }

            
            Violazione? violazione = await _verbaleService.GetViolazioneByDescrizioneAsync(verbaleViewModel.Violazione);

            if (violazione == null)
            {
                ModelState.AddModelError("Violazione", "Violazione non trovata nel database.");
                var violazioni = await _violazioneService.GetViolazioniAsync();
                verbaleViewModel.ListaViolazioni = violazioni.Select(v => new SelectListItem
                {
                    Value = v.DescrizioneViolazione,
                    Text = v.DescrizioneViolazione
                });
                return View("Create", verbaleViewModel);
            }

            // Creazione nuovo verbale
            Verbale verbale = new Verbale()
            {
                VerbaleId = Guid.NewGuid(),
                NominativoAgente = verbaleViewModel.NominativoAgente,
                DataViolazione = verbaleViewModel.DataViolazione,
                DataTrascrizione = verbaleViewModel.DataTrascrizione,
                IndirizzoViolazione = verbaleViewModel.IndirizzoViolazione,
                ImportoMulta = verbaleViewModel.ImportoMulta,
                DecurtazionePunti = verbaleViewModel.DecurtazionePunti,
                ViolazioneId = violazione.ViolazioneId,
                Violazione = violazione
            };

            
            bool saved = await _verbaleService.CreateVerbaleAsync(verbale);
            if (!saved)
            {
                ModelState.AddModelError("", "Errore durante il salvataggio del verbale.");
                var violazioni = await _violazioneService.GetViolazioniAsync();
                verbaleViewModel.ListaViolazioni = violazioni.Select(v => new SelectListItem
                {
                    Value = v.DescrizioneViolazione,
                    Text = v.DescrizioneViolazione
                });
                return View("Create", verbaleViewModel);
            }

            
            TempData["SuccessMessage"] = "Verbale salvato con successo!";
            return RedirectToAction("Create");
        }

    }
}
