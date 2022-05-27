using System;
using System.Collections.Generic;

namespace carrr
{
    public partial class Trip
    {
        public Trip()
        {
            Triptimeclients = new HashSet<Triptimeclient>();
        }

        public int IdTrip { get; set; }
        public DateOnly StartDate { get; set; }
        public DateOnly EndDate { get; set; }
        public int? IdCar { get; set; }
        public int? IdClient { get; set; }

        public virtual Car? IdCarNavigation { get; set; }
        public virtual Client? IdClientNavigation { get; set; }
        public virtual ICollection<Triptimeclient> Triptimeclients { get; set; }
    }
}
