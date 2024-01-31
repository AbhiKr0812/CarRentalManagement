using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRentalMang.WinFormApp
{
    internal class CarModel
    {
        public int ModelId { get; set; }
        public string Name { get; set; }
        public bool IsAvailable { get; set; }
    }
}
