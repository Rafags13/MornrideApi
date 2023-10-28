using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MornrideApi.Domain.Entities.Model
{
    public class Bike
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        [MaxLength(100)]
        public string Title { get; set; } = string.Empty;

        [Required]
        [MaxLength(250)]
        public string Description { get; set; } = string.Empty;

        [Required]
        public int Stock { get; set; }

        [Required]
        public float Price { get; set; }

        public ICollection<BikeCategory> BikeCategories { get; set; }
        public ICollection <Images> BikeImages { get; set; }

        [NotMapped]
        public List<string> AvaliableColors
        {
            get
            {
                return AvaliableColors;
            }
            set
            {
                var avaliableColors = BikeImages.Select(x => x.HexColor).ToList();
                AvaliableColors = avaliableColors ?? new List<string>();
            }
        }
    }
}
