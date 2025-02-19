using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DreamScapeInteractive.Utility
{
    public class FilterState
    {
        public string? MagicProperty { get; set; }
        public string? ItemNameOrType { get; set; }
        public double? Rarity { get; set; }
        public double? Power { get; set; }
        public double? Speed { get; set; }
        public double? Durability { get; set; }
    }
}
