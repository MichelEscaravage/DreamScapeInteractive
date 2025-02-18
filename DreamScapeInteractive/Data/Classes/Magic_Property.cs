using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DreamScapeInteractive.Data.Classes
{
    public class Magic_Property
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Value { get; set; }

        public ICollection<Item> Items { get; set; } = new List<Item>();
    }
}
