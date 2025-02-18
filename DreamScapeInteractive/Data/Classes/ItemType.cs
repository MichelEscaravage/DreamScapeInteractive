using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.System;

namespace DreamScapeInteractive.Data.Classes
{
    public class ItemType
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public ICollection<Item> Items { get; set; } = new List<Item>();
    }
}
