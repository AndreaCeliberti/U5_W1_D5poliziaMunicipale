using Microsoft.AspNetCore.Mvc;
using U5_W1_D5poliziaMunicipale.Models.Entities;
using U5_W1_D5poliziaMunicipale.Services;
using U5_W1_D5poliziaMunicipale.ViewModels;

namespace U5_W1_D5poliziaMunicipale.Controllers
{
    public class ViolazioneController : Controller
    {
        private readonly ViolazioneService _violazioneService;
        public ViolazioneController(ViolazioneService violazioneService)
        {
            _violazioneService = violazioneService;
        }

        public async Task<IActionResult> Index()
        {
            List<Violazione> violazioni = await _violazioneService.GetViolazioniAsync();

            List<ViolazioneViewModel> violazioneViewModels = violazioni.Select(vi => new ViolazioneViewModel()
            {
                 ViolazioneId = vi.ViolazioneId,
                 DescrizioneViolazione = vi.DescrizioneViolazione
            }
            ).ToList();
            return View();
        }
    }
}
