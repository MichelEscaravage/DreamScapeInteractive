using System.Collections.Generic;
using DreamScapeInteractive.Data.Classes;

namespace DreamScapeInteractive.Data.Lists
{
    internal class Magic_PropertyList
    {
        public List<Magic_Property> MagicProperties = new List<Magic_Property>
        {
            new Magic_Property {Id = 1, Name = "Flame Enchantment", Value = 3},
            new Magic_Property {Id = 2, Name = "Frostbite Aura", Value = 4},
            new Magic_Property {Id = 3, Name = "Storm Surge", Value = 5},
            new Magic_Property {Id = 4, Name = "Windwalker’s Grace", Value = 2},
            new Magic_Property {Id = 5, Name = "Stoneheart Barrier", Value = 3},
            new Magic_Property {Id = 6, Name = "Shadow Cloak", Value = 4},
            new Magic_Property {Id = 7, Name = "Venomous Touch", Value = 3},
            new Magic_Property {Id = 8, Name = "Radiant Blessing", Value = 5},
            new Magic_Property {Id = 9, Name = "Timewarp Echo", Value = 5},
            new Magic_Property {Id = 10, Name = "Abyssal Curse", Value = 6},
            new Magic_Property {Id = 11, Name = "Abyssal Curses", Value = 8}
        };

        public List<Magic_Property> GetMagicPropertyList()
        {
            return MagicProperties;
        }
    }
}
