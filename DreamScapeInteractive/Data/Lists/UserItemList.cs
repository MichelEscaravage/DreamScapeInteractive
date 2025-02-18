using DreamScapeInteractive.Data.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DreamScapeInteractive.Data.Lists
{
    internal class UserItemList
    {
        public List<UserItem> userItems = new List<UserItem>
        {
            new UserItem { UserItemId = 1, UserId = 1, ItemId = 1, Quantity = 20 },
            new UserItem { UserItemId = 2, UserId = 2, ItemId = 2, Quantity = 10 },
            new UserItem { UserItemId = 3, UserId = 3, ItemId = 3, Quantity = 5 },
            new UserItem { UserItemId = 4, UserId = 4, ItemId = 4, Quantity = 15 },
            new UserItem { UserItemId = 5, UserId = 5, ItemId = 5, Quantity = 3 },
        };

        public List<UserItem> GetUserItemList()
        {
            return userItems;
        }
    }
}
