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
        public Bike(string title, string description, int stock, float price)
        {
            this.Title = title;
            this.Description = description;
            this.Stock = stock;
            this.Price = price;
        }

        public Bike() { }

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

        public ICollection<BikeCategory>? BikeCategories { get; set; }
        public ICollection<BikeImage>? BikeImages { get; set; }
        
        private ICollection<string>? _avaliableColors;
        [NotMapped]
        public ICollection<string>? AvaliableColors
        {
            get
            {
                var avaliableColors = BikeImages?.Select(x => x.HexColor).ToList();
                _avaliableColors = avaliableColors ?? new List<string>();
                return _avaliableColors;
            }
            set => _avaliableColors = value;
        }
    }
}
