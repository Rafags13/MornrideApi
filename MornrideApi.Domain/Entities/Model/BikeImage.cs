using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MornrideApi.Domain.Entities.Model
{
    public class BikeImage
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }

        [Required]
        [StringLength(7)]
        public string HexColor { get; set; } = string.Empty;

        [Required]
        [Column(Order = 1)]
        [ForeignKey("FullBikeImageId")]
        public int IdFullBikeImage { get; set; }
        public virtual Image? FullBikeImage { get; set; }

        [Required]
        [Column(Order = 2)]
        [ForeignKey("BikeId")]
        public int BikeId { get; set; }
        public virtual Bike? Bike { get; set; }
    }
}