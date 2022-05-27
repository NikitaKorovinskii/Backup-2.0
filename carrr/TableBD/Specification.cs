using System;
using System.Collections.Generic;

namespace carrr
{
    public partial class Specification
    {
        public int IdSpecifications { get; set; }
        public int Horsepower { get; set; }
        public decimal EngineСapacity { get; set; }
        public string Transmission { get; set; } = null!;
        public int? IdCar { get; set; }

        public virtual Car? IdCarNavigation { get; set; }
    }
}
