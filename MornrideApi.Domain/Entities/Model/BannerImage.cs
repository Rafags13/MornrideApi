using System.ComponentModel.DataAnnotations;

using System.ComponentModel.DataAnnotations.Schema;

namespace MornrideApi.Domain.Entities.Model
{
    public class BannerImage
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }

        [Required]
        [MaxLength(250)]
        public string Label { get; set; } = string.Empty;

        [Required]
        [MaxLength(50)]
        public string Collection { get; set; } = string.Empty;

        [Required]
        [Column(Order = 1)]
        [ForeignKey("ImageId")]
        public int ImageId { get; set; }
        public Image? ImageFromBanner { get; set; }

    }
}