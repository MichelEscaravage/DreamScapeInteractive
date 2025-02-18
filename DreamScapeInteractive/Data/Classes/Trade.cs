using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Security.Cryptography.Core;

namespace DreamScapeInteractive.Data.Classes
{
    public class Trade
    {
        public int Id { get; set; }
        public int UserItem1Id { get; set; }
        public int UserItem2Id { get; set; }
        public string Status { get; set; }  
        public DateTime TradeDate { get; set; }

        public UserItem UserItem1 { get; set; }
        public UserItem UserItem2 { get; set; }
    }
}
