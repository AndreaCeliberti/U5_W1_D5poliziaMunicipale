using Microsoft.AspNetCore.Mvc.Rendering;

namespace U5_W1_D5poliziaMunicipale.ViewModels
{
    public class AnagraficaViewModel
    {
        public Guid? AnagraficaId { get; set; }
        public string Nome { get; set; }
        public string Cognome { get; set; }
        public string CodiceFiscale { get; set; }
        public string Indirizzo { get; set; }
        public string Citta { get; set; }
        public int Cap { get; set; }
        public Guid? Verbale { get; set; }
        public string? VerbaleDescrizione { get; set; }
        public SelectList? ListaVerbali { get; set; }
    }
}
