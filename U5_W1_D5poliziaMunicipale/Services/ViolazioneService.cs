using Microsoft.EntityFrameworkCore;
using U5_W1_D5poliziaMunicipale.Models.Entities;

namespace U5_W1_D5poliziaMunicipale.Services
{
    public class ViolazioneService : ServiceBase
    {
        public ViolazioneService(MulteDbContext multeDbContext) : base(multeDbContext)
        {
        }
        public async Task<List<Violazione>> GetViolazioniAsync()
        {
            List<Violazione> violazioni = await _multeDbContext.Violazioni.ToListAsync();
            return violazioni;
        }
    }
}
