using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MornrideApi.Domain.Entities.Model
{
    public class BikeCategory
    {

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }

        [Column(Order = 1)]
        [ForeignKey("BikeId")]
        public int BikeId { get; set; }

        [Column(Order = 2)]
        [ForeignKey("CategoryId")]
        public int CategoryId { get; set; }

        public virtual Bike Bike { get; set; }
        public virtual Category Category { get; set; }
    }
}
