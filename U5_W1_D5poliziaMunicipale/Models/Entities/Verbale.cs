using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace U5_W1_D5poliziaMunicipale.Models.Entities
{
    public class Verbale
    {
        [Key]
        public Guid VerbaleId { get; set; }
        [Required]
        public string NominativoAgente { get; set; }
        [Required]
        public DateTime DataViolazione { get; set; }
        [Required]
        public DateTime DataTrascrizione { get; set; }
        [Required]
        public string IndirizzoViolazione { get; set; }
        [Required]
        public decimal ImportoMulta { get; set; }
        [Required]
        public int DecurtazionePunti { get; set; }
        
        //definisco le relazioni
        [InverseProperty(nameof(Anagrafica.Verbale))]
        public List<Anagrafica> Anagrafiche { get; set; }
        public Guid ViolazioneId { get; set; }

        [ForeignKey(nameof(ViolazioneId))]
        public Violazione Violazione { get; set; }

    }
}
