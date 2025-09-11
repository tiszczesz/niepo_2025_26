using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SummerEx.Models
{
    public class Holiday
    {
        public int Id { get; set; }

        [DisplayName("Miejsce")]
        public string? Place { get; set; }

        [DisplayName("Data początkowa")]
        public DateTime DateStart { get; set; }

        [DisplayName("Data początkowa")]
        public DateTime DateEnd { get; set; }

        [DisplayName("Cena")]
        public decimal Price { get; set; }
        
        [DisplayName("Ilość osób")]
        public int Count { get; set; }
        
        [DisplayName("Wyżywienie w cenie")]
        public bool IsFoodIncluded { get; set; }

    }
}
