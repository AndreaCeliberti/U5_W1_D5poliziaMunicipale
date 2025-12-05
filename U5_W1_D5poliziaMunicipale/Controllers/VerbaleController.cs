using Microsoft.AspNetCore.Mvc;
using U5_W1_D5poliziaMunicipale.Models.Entities;
using U5_W1_D5poliziaMunicipale.Services;
using U5_W1_D5poliziaMunicipale.ViewModels;

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

            List<VerbaleViewModel> verbaleViewModels = verbali.Select(ve => new VerbaleViewModel()
            {
                 VerbaleId = ve.VerbaleId,
                 NominativoAgente = ve.NominativoAgente,
                 DataTrascrizione = ve.DataTrascrizione,
                 DataViolazione = ve.DataViolazione,
                 IndirizzoViolazione = ve.IndirizzoViolazione,
                 ImportoMulta = ve.ImportoMulta,
                 DecurtazionePunti = ve.DecurtazionePunti,
                 Violazione = ve.Violazione.DescrizioneViolazione
            }
            ).ToList();
            return View();
        }
    }
}
