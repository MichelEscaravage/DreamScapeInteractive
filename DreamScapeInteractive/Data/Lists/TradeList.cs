using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DreamScapeInteractive.Data.Classes;

using Windows.Devices.Bluetooth.Advertisement;

namespace DreamScapeInteractive.Data.Lists
{
    internal class TradeList
    {
        public List<Trade> Trades = new List<Trade>
        {
            new Trade { Id = 1, UserItem1Id = 1, UserItem2Id = 2, Status = "Pending", TradeDate = DateTime.Now },
            new Trade { Id = 2, UserItem1Id = 2, UserItem2Id = 3, Status = "Completed", TradeDate = DateTime.Now.AddDays(-1) },
            new Trade { Id = 3, UserItem1Id = 4, UserItem2Id = 5, Status = "Cancelled", TradeDate = DateTime.Now.AddDays(-2) }
        };

        public List<Trade> GetTradeList()
        {
            return Trades;
        }
    }
}
