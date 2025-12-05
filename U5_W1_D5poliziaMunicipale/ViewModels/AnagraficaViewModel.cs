using System.ComponentModel.DataAnnotations;

namespace U5_W1_D5poliziaMunicipale.ViewModels
{
    public class AnagraficaViewModel
    {
        [Key]
        public Guid AnagraficaId { get; set; }
        
        public string Nome { get; set; }
        
        public string Cognome { get; set; }
        
        public string CodiceFiscale { get; set; }
        
        public string Indirizzo { get; set; }
        
        public string Citta { get; set; }
        
        public int Cap { get; set; }

        public string Verbale { get; set; }
    }
}
