using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace U5_W1_D5poliziaMunicipale.Models.Entities
{
    public class Anagrafica
    {
        [Key]
        public Guid AnagraficaId { get; set; }
        [Required]
        public string Nome { get; set; }  
        [Required]
        public string Cognome { get; set; }
        [Required]
        public string CodiceFiscale { get; set; }
        [Required]  
        public string Indirizzo { get; set; }
        [Required]
        public string Citta { get; set; }
        [Required]
        public int Cap {  get; set; }
        //dichiaro le relazioni
        public Guid VerbaleId { get; set; }
        [ForeignKey(nameof(VerbaleId))]
        public Verbale Verbale { get; set; } 

    }
}
