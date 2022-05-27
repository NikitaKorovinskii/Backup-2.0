using System;
using System.Collections.Generic;

namespace server.BdTable
{
    public partial class HistoryWallet
    {
        public DateOnly DateOperation { get; set; }
        public DateTimeOffset TimeOperation { get; set; }
        public decimal Sum { get; set; }
        public int IdWallet { get; set; }
    }
}
