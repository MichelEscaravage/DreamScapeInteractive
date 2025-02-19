using System.Collections.Generic;
using DreamScapeInteractive.Data.Classes;

namespace DreamScapeInteractive.Data.Lists
{
    internal class ItemList
    {
        public List<Item> Items = new List<Item>
        {
            new Item {Id = 1, Name = "Burning Sword of Damnation", Description = "It feels weirdly cool to the touch", TypeId = 1, Rarity = 50, Power = 40, Speed = 10, Durability = 99, MagicPropertyId = 10},
            new Item {Id = 2, Name = "Frozen Dagger of the North", Description = "Its blade glistens with eternal frost", TypeId = 2, Rarity = 60, Power = 25, Speed = 35, Durability = 80, MagicPropertyId = 7},
            new Item {Id = 3, Name = "Staff of the Eternal Sun", Description = "It radiates warmth and whispers of ancient knowledge", TypeId = 3, Rarity = 90, Power = 55, Speed = 5, Durability = 70, MagicPropertyId = 3},
            new Item {Id = 4, Name = "Shield of the Forgotten King", Description = "Its surface reflects the memories of fallen heroes", TypeId = 4, Rarity = 75, Power = 10, Speed = -5, Durability = 120, MagicPropertyId = 5},
            new Item {Id = 5, Name = "Ring of Shadows", Description = "Wearing it feels like slipping into the darkness itself", TypeId = 5, Rarity = 85, Power = 15, Speed = 20, Durability = 50, MagicPropertyId = 9},
            new Item {Id = 6, Name = "Cursed Bow of the Phantom", Description = "The bowstring hums with a mournful song", TypeId = 6, Rarity = 65, Power = 30, Speed = 40, Durability = 60, MagicPropertyId = 11},
            new Item {Id = 7, Name = "Amulet of the Starcaller", Description = "Its gem pulses with the energy of distant stars", TypeId = 7, Rarity = 95, Power = 20, Speed = 10, Durability = 40, MagicPropertyId = 6},
            new Item {Id = 8, Name = "Boots of the Windwalker", Description = "You feel lighter just by wearing them", TypeId = 8, Rarity = 55, Power = 5, Speed = 50, Durability = 45, MagicPropertyId = 4},
            new Item {Id = 9, Name = "Helmet of Echoing Thoughts", Description = "Whispers of ancient minds fill your ears", TypeId = 9, Rarity = 70, Power = 8, Speed = 2, Durability = 85, MagicPropertyId = 6},
            new Item {Id = 10, Name = "Tome of the Abyss", Description = "The pages are blank, but you hear them screaming", TypeId = 10, Rarity = 100, Power = 65, Speed = 0, Durability = 30, MagicPropertyId = 10},
            new Item {Id = 11, Name = "Blazing Claymore of Ruin", Description = "Flames dance along its edge without heat", TypeId = 1, Rarity = 73, Power = 80, Speed = 15, Durability = 95, MagicPropertyId = 2},
            new Item {Id = 12, Name = "Venomfang Dirk", Description = "Its venomous edge never dulls", TypeId = 2, Rarity = 55, Power = 45, Speed = 60, Durability = 85, MagicPropertyId = 8},
            new Item {Id = 13, Name = "Wand of Lurking Shadows", Description = "Dark mist trails its tip", TypeId = 3, Rarity = 78, Power = 50, Speed = 10, Durability = 40, MagicPropertyId = 1},
            new Item {Id = 14, Name = "Aegis of the Stormborn", Description = "Thunder rumbles when struck", TypeId = 4, Rarity = 92, Power = 15, Speed = -3, Durability = 130, MagicPropertyId = 3},
            new Item {Id = 15, Name = "Ring of the Moonlit Veil", Description = "Faint lunar glow when worn", TypeId = 5, Rarity = 99, Power = 25, Speed = 18, Durability = 48, MagicPropertyId = 5},
            new Item {Id = 16, Name = "Phantom Recurve", Description = "Arrows vanish into mist upon release", TypeId = 6, Rarity = 82, Power = 55, Speed = 45, Durability = 70, MagicPropertyId = 7},
            new Item {Id = 17, Name = "Celestial Talisman", Description = "Hums with cosmic energy", TypeId = 7, Rarity = 89, Power = 30, Speed = 15, Durability = 50, MagicPropertyId = 6},
            new Item {Id = 18, Name = "Greaves of the Gale", Description = "Every step leaves a wisp of wind", TypeId = 8, Rarity = 60, Power = 10, Speed = 65, Durability = 55, MagicPropertyId = 4},
            new Item {Id = 19, Name = "Crown of the Dreamwalker", Description = "Visions of past and future haunt the wearer", TypeId = 9, Rarity = 88, Power = 20, Speed = 5, Durability = 75, MagicPropertyId = 3},
            new Item {Id = 20, Name = "Grimoire of Forgotten Secrets", Description = "Ink moves across the pages on its own", TypeId = 10, Rarity = 100, Power = 70, Speed = 2, Durability = 35, MagicPropertyId = 11},
            new Item {Id = 21, Name = "Greatsword of the Blazing Sun", Description = "Its blade burns with an eternal golden flame.", TypeId = 1, Rarity = 82, Power = 60, Speed = 12, Durability = 95, MagicPropertyId = 10}, // Sword  
            new Item {Id = 22, Name = "Venomfang Dagger", Description = "A faint green liquid drips from its serrated edge.", TypeId = 2, Rarity = 72, Power = 28, Speed = 40, Durability = 78, MagicPropertyId = 3}, // Dagger  
            new Item {Id = 23, Name = "Runed Staff of the Arcane Flow", Description = "Glowing runes shift and rearrange on its surface.", TypeId = 3, Rarity = 88, Power = 52, Speed = 7, Durability = 68, MagicPropertyId = 7}, // Staff  
            new Item {Id = 24, Name = "Aegis of the Stormcaller", Description = "Electricity arcs between the engraved symbols.", TypeId = 4, Rarity = 80, Power = 15, Speed = -3, Durability = 110, MagicPropertyId = 5}, // Shield  
            new Item {Id = 25, Name = "Eclipse Ring", Description = "Its dark gemstone absorbs the light around it.", TypeId = 5, Rarity = 90, Power = 18, Speed = 22, Durability = 55, MagicPropertyId = 9}, // Ring  
            new Item {Id = 26, Name = "Phantom Longbow", Description = "The arrows fired vanish mid-flight before striking.", TypeId = 6, Rarity = 75, Power = 35, Speed = 38, Durability = 62, MagicPropertyId = 6}, // Bow  
            new Item {Id = 27, Name = "Celestial Amulet", Description = "A soft hum emanates from the crystal centerpiece.", TypeId = 7, Rarity = 95, Power = 22, Speed = 12, Durability = 42, MagicPropertyId = 8}, // Amulet  
            new Item {Id = 28, Name = "Skystrider Boots", Description = "A rush of wind follows your every step.", TypeId = 8, Rarity = 60, Power = 6, Speed = 55, Durability = 48, MagicPropertyId = 4}, // Boots  
            new Item {Id = 29, Name = "Crown of the Dreamwalker", Description = "It pulses with visions from unseen realms.", TypeId = 9, Rarity = 78, Power = 10, Speed = 5, Durability = 87, MagicPropertyId = 2}, // Helmet  
            new Item {Id = 30, Name = "Grimoire of Forgotten Truths", Description = "Its pages whisper secrets in a long-dead tongue.", TypeId = 10, Rarity = 100, Power = 70, Speed = 0, Durability = 35, MagicPropertyId = 11} // Tome  
        };

        public List<Item> GetItemList()
        {
            return Items;
        }
    }
}
