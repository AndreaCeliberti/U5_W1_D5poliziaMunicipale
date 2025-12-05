using System.ComponentModel.DataAnnotations;

namespace U5_W1_D5poliziaMunicipale.ViewModels
{
    public class ViolazioneViewModel
    {
        [Key]
        public Guid ViolazioneId { get; set; }
        
        public string DescrizioneViolazione { get; set; }
    }
}
