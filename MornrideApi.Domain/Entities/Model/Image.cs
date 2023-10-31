using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MornrideApi.Domain.Entities.Model
{
    public class Image
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        [StringLength(7)]
        public string HexColor { get; set; } = string.Empty;

        [Required]
        public string FullBike { get; set; } = string.Empty;

        [Required]
        public string FrontBike { get; set;} = string.Empty;

        [Required]
        public string FrontWheel { get; set;} = string.Empty;

        [Required]
        public string BackWheel { get; set;} = string.Empty;

        [ForeignKey("BikeId")]
        public int BikeId { get; set; }
        public Bike? BikeFromThisImage { get; set; }
    }
}
