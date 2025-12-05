using Microsoft.AspNetCore.Mvc;
using U5_W1_D5poliziaMunicipale.Services;

namespace U5_W1_D5poliziaMunicipale.Controllers
{
    public class ViolazioneController : Controller
    {
        private readonly ViolazioneService _violazioneService;
        public ViolazioneController(ViolazioneService violazioneService)
        {
            _violazioneService = violazioneService;
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}
