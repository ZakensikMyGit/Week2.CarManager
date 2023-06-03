using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Week2.CarManager
{
    public class Vehicles
    {
        public int Id { get; set; }
        public TypeVehicles Type { get; set; }
        public string PlateNumber { get; set; }

    }
    public enum TypeVehicles
    {
        car = 1,
        bus = 2,
        truck = 3,
        other = 4
    }

}
