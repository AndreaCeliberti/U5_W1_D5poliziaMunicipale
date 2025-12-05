using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;
using U5_W1_D5poliziaMunicipale.Models.Entities;

namespace U5_W1_D5poliziaMunicipale.Services
{
    public class AnagraficaService : ServiceBase
    {

        public AnagraficaService(MulteDbContext multeDbContext) : base(multeDbContext)
        {
        }
         public async Task <List<Anagrafica>> GetAnagraficheAsync()
            {
                List<Anagrafica> anagrafiche = await _multeDbContext.Anagrafiche.
                Include(ve => ve.Verbale).ThenInclude(vi => vi.Violazione).ToListAsync();
                return anagrafiche;
            }
        
    }
}
