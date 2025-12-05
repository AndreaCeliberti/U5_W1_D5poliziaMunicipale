using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace U5_W1_D5poliziaMunicipale.Models.Entities
{
    public class Violazione
    {
        [Key]
        public Guid ViolazioneId { get; set; }
        [Required]
        public string DescrizioneViolazione { get; set; }

        [InverseProperty(nameof(Verbale.Violazione))]
        public List<Verbale> Verbali { get; set; }

    }
}
