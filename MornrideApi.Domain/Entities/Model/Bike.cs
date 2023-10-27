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

        //public List<string> AvaliableColors { get;set; } = new List<string>();
        // the avaliable colors will be implemented when the bikeImages table
        // is created

        [Required]
        public float Price { get; set; }

        //public List<string> Categories { get; set; } = new List<string>();
        // the categories will be implemented when the Categories table
        // is created
    }
}
