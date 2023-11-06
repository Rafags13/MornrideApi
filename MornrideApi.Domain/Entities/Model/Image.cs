using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace MornrideApi.Domain.Entities.Model
{
    public class Image
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        public string Url { get; set; } = string.Empty;

        [Required]
        [MaxLength(250)]
        public string Description { get; set; } = string.Empty;

        public ICollection<BannerImage>? Banners { get; set; }
        public ICollection <BikeImage>? BikeImages { get; set; }
    }
}
