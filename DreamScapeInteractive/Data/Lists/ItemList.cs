using System.Collections.Generic;
using DreamScapeInteractive.Data.Classes;

namespace DreamScapeInteractive.Data.Lists
{
    internal class ItemList
    {
        public List<Item> Items = new List<Item>
        {
            new Item {Id = 1, Name = "Burning Sword of Damnation", Description = "It feels weirdly cool to the touch", TypeId = 1, Rarity = 50, Power = 40, Speed = 10, Durability = 99, MagicPropertyId = 10}, // Sword
            new Item {Id = 2, Name = "Frozen Dagger of the North", Description = "Its blade glistens with eternal frost", TypeId = 2, Rarity = 60, Power = 25, Speed = 35, Durability = 80, MagicPropertyId = 7}, // Dagger
            new Item {Id = 3, Name = "Staff of the Eternal Sun", Description = "It radiates warmth and whispers of ancient knowledge", TypeId = 3, Rarity = 90, Power = 55, Speed = 5, Durability = 70, MagicPropertyId = 3}, // Staff
            new Item {Id = 4, Name = "Shield of the Forgotten King", Description = "Its surface reflects the memories of fallen heroes", TypeId = 4, Rarity = 75, Power = 10, Speed = -5, Durability = 120, MagicPropertyId = 5}, // Shield
            new Item {Id = 5, Name = "Ring of Shadows", Description = "Wearing it feels like slipping into the darkness itself", TypeId = 5, Rarity = 85, Power = 15, Speed = 20, Durability = 50, MagicPropertyId = 9}, // Ring
            new Item {Id = 6, Name = "Cursed Bow of the Phantom", Description = "The bowstring hums with a mournful song", TypeId = 6, Rarity = 65, Power = 30, Speed = 40, Durability = 60, MagicPropertyId = 11}, // Bow
            new Item {Id = 7, Name = "Amulet of the Starcaller", Description = "Its gem pulses with the energy of distant stars", TypeId = 7, Rarity = 95, Power = 20, Speed = 10, Durability = 40, MagicPropertyId = 6}, // Amulet
            new Item {Id = 8, Name = "Boots of the Windwalker", Description = "You feel lighter just by wearing them", TypeId = 8, Rarity = 55, Power = 5, Speed = 50, Durability = 45, MagicPropertyId = 4}, // Boots
            new Item {Id = 9, Name = "Helmet of Echoing Thoughts", Description = "Whispers of ancient minds fill your ears", TypeId = 9, Rarity = 70, Power = 8, Speed = 2, Durability = 85, MagicPropertyId = 6}, // Helmet
            new Item {Id = 10, Name = "Tome of the Abyss", Description = "The pages are blank, but you hear them screaming", TypeId = 10, Rarity = 100, Power = 65, Speed = 0, Durability = 30, MagicPropertyId = 10} // Tome
        };

        public List<Item> GetItemList()
        {
            return Items;
        }
    }
}
