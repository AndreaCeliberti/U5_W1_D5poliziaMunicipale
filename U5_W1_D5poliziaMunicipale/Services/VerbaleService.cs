using Microsoft.EntityFrameworkCore;
using U5_W1_D5poliziaMunicipale.Models.Entities;

namespace U5_W1_D5poliziaMunicipale.Services
{
    public class VerbaleService : ServiceBase
    {
        public VerbaleService(MulteDbContext multeDbContext) : base(multeDbContext)
        {
        }
        public async Task<List<Verbale>> GetVerbaliAsync()
        {
            List<Verbale> verbali = await _multeDbContext.Verbali.
            Include(vi => vi.Violazione).ToListAsync();
            return verbali;
        }
        public async Task<bool> CreateVerbaleAsync(Verbale verbale)
        {
            _multeDbContext.Verbali.Add(verbale);
            return await SaveAsync();
        }

        public async Task<Violazione?> GetViolazioneByDescrizioneAsync(string descrizione)
        {
            return await _multeDbContext.Violazioni
                .FirstOrDefaultAsync(v => v.DescrizioneViolazione == descrizione);
        }
    }
}
