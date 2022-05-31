using System;
using System.Collections.Generic;

namespace carrr.TableBd
{
    public partial class Triptimeclient
    {
        public int IdTripTime { get; set; }
        public DateTimeOffset Time { get; set; }
        public int? IdTrip { get; set; }

        public virtual Trip? IdTripNavigation { get; set; }
    }
}
