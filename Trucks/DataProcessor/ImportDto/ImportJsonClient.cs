using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Trucks.Data.Models;

namespace Trucks.DataProcessor.ImportDto
{
    public class ImportJsonClient
    {
        [Required, MinLength(3), MaxLength(40)]
        public string? Name { get; set; }

        [Required]
        public string? Nationality { get; set; }

        public string? Type { get; set; }
        public ICollection<ClientTruck> ClientsTrucks { get; set; }
    }
}
