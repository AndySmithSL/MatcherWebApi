using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MatcherWebApi.Models
{
    public class Trade
    {
        public int TradeId { get; set; }

        public int NewOrderId { get; set; }
        public OrderBookItem NewOrder { get; set; }

        public int ExistingOrderId { get; set; }
        public OrderBookItem ExistingOrder { get; set; }

        public DateTime TradeDate { get; set; }
    }
}
