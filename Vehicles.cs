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
        public VehicleType Type { get; set; }
        public string? PlateNumber { get; set; }
        public int DrivenKilometers { get; set; }
    }
    public enum VehicleType
    {
        Car = 1,
        Bus = 2,
        Truck = 3,
        Other = 4
    }
}
