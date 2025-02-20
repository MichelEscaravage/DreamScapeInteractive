using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DreamScapeInteractive.Data.Classes
{
    public class User
    {
        public int Id { get; set; }
        public static User LoggedInUser { get; set; }
        public string EmailAddress { get; set; }
        public string Username { get; set; }
        public string HashedPassword { get; set; }
        public bool IsAdmin { get; set; }

        public ICollection<UserItem> UserItems { get; set; } = new List<UserItem>();
        public ICollection<Trade> Trades { get; set; } = new List<Trade>();
    }
}
