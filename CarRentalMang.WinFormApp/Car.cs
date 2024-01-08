using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRentalMang.WinFormApp
{
    public  class Car
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Color { get; set; }

        public string LicensePlateNumber { get; set; }

        public string Make { get; set; }

        public bool Availability { get; set; }
    }
}
