using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DreamScapeInteractive.Data.Classes
{
    public class Item
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int TypeId { get; set; }
        public int Rarity { get; set; }
        public int Power { get; set; }
        public int Speed { get; set; }
        public int Durability { get; set; }
        public int MagicPropertyId { get; set; }

        public Magic_Property MagicProperty { get; set; }
        public ItemType Type { get; set; }
        public ICollection<UserItem> UserItems { get; set; } = new List<UserItem>();
    }


}
