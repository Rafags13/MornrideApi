using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MornrideApi.Domain.Entities.Model
{
    public class BikeImage
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        [StringLength(7)]
        public string HexColor { get; set; } = string.Empty;

        [Column(Order = 1)]
        [ForeignKey("ImageId")]
        public int ImageId { get; set; }
        public Image? Image { get; set; }

        [Column(Order = 2)]
        [ForeignKey("BikeId")]
        public int BikeId { get; set; }
        public Bike? Bike { get; set; }
    }
}