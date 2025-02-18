using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DreamScapeInteractive.Data.Classes
{
    internal class User
    {
        public ObservableCollection<UserItem> Inventory { get; set; } = new ObservableCollection<UserItem>();
    }
}
