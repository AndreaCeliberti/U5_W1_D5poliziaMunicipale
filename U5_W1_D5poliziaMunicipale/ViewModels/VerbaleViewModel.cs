using System.ComponentModel.DataAnnotations;

namespace U5_W1_D5poliziaMunicipale.ViewModels
{
    public class VerbaleViewModel
    {
        [Key]
        public Guid VerbaleId { get; set; }
        
        public string NominativoAgente { get; set; }
        
        public DateTime DataViolazione { get; set; }
        
        public DateTime DataTrascrizione { get; set; }
        
        public string IndirizzoViolazione { get; set; }
        
        public decimal ImportoMulta { get; set; }
        
        public int DecurtazionePunti { get; set; }
        
        public string Violazione { get; set; }
    }
}
