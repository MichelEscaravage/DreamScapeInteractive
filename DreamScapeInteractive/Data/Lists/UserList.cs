using System.Collections.Generic;
using DreamScapeInteractive.Data.Classes;

namespace DreamScapeInteractive.Data.Lists
{
    internal class UserList
    {
        public List<User> Users = new List<User>
        {
            new User {Id = 1, Username = "DreamSeeker", EmailAddress = "seeker@dreamscape.com", HashedPassword = SecureHasher.Hash("123"), IsAdmin = true},
            new User {Id = 2, Username = "StarWanderer", EmailAddress = "wanderer@dreamscape.com", HashedPassword = SecureHasher.Hash("123"), IsAdmin = false},
            new User {Id = 3, Username = "MysticGuardian", EmailAddress = "guardian@dreamscape.com", HashedPassword = SecureHasher.Hash("123"), IsAdmin = false},
            new User {Id = 4, Username = "ShadowWalker", EmailAddress = "walker@dreamscape.com", HashedPassword = SecureHasher.Hash("123"), IsAdmin = false},
            new User {Id = 5, Username = "LunaCaller", EmailAddress = "luna@dreamscape.com", HashedPassword = SecureHasher.Hash("123"), IsAdmin = false}
        };

        public List<User> GetUserList()
        {
            return Users;
        }
    }
}
