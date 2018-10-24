using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MatcherWebApi.Models
{
    public class MatcherContext : DbContext
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="options"></param>
        public MatcherContext(DbContextOptions<MatcherContext> options)
            : base(options)
        { }

        public DbSet<Account> Accounts { get; set; }
        public DbSet<OrderBookItem> OrderBook { get; set; }
        public DbSet<OrderHistoryItem> OrderHistory { get; set; }
        public DbSet<Trade> Trades { get; set; }
    }
}
