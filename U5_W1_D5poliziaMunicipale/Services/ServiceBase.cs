using U5_W1_D5poliziaMunicipale.Models.Entities;

namespace U5_W1_D5poliziaMunicipale.Services
{
    public abstract class ServiceBase
    {
        protected readonly MulteDbContext _multeDbContext;
        protected ServiceBase (MulteDbContext multeDbContext)
        {
            _multeDbContext = multeDbContext;
        }

        protected async Task<bool> SaveAsync()
        {
            bool result = false;
            try
            {
                result = await _multeDbContext.SaveChangesAsync() > 0;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return result;
        }
    }
}
