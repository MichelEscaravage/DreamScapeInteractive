using System.Collections.Generic;
using DreamScapeInteractive.Data.Classes;

namespace DreamScapeInteractive.Data.Lists
{
    internal class TypeList
    {
        public List<ItemType> ItemTypes = new List<ItemType>
        {
            new ItemType {Id = 1, Name = "Sword"},
            new ItemType {Id = 2, Name = "Dagger"},
            new ItemType {Id = 3, Name = "Staff"},
            new ItemType {Id = 4, Name = "Shield"},
            new ItemType {Id = 5, Name = "Ring"},
            new ItemType {Id = 6, Name = "Bow"},
            new ItemType {Id = 7, Name = "Amulet"},
            new ItemType {Id = 8, Name = "Boots"},
            new ItemType {Id = 9, Name = "Helmet"},
            new ItemType {Id = 10, Name = "Tome"}
        };

        public List<ItemType> GetItemTypeList()
        {
            return ItemTypes;
        }
    }
}
