﻿using System;
using System.Collections.Generic;

namespace carrr.TableBd
{
    public partial class Wallet
    {
        public int IdWallet { get; set; }
        public decimal Sum { get; set; }
        public int? IdClient { get; set; }

        public virtual Client? IdClientNavigation { get; set; }
    }
}
