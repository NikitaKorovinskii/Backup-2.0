﻿using System;
using System.Collections.Generic;

namespace carrr.TableBd
{
    public partial class HistoryWallet
    {
        public int Id { get; set; }
        public DateOnly DateOperation { get; set; }
        public DateTimeOffset TimeOperation { get; set; }
        public decimal Sum { get; set; }
        public int IdWallet { get; set; }
    }
}
