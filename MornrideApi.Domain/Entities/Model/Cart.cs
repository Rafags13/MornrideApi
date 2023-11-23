using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MornrideApi.Domain.Entities.Model
{
    public class Cart
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        public int Amount { get; set; }

        [Required]
        [Column(Order = 1)]
        [ForeignKey("BikeId")]
        public int BikeId { get; set; }
        public Bike? CurrentBike { get; set; }
    }
}
