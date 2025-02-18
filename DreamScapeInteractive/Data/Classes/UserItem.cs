using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DreamScapeInteractive.Data.Classes
{
    public class UserItem
    {
        public int  UserItemId { get; set; }
        public int UserId { get; set; }
        public int ItemId { get; set; }
        public int Quantity { get; set; }

        public User User { get; set; }
        public Item Item { get; set; }
    }
}
