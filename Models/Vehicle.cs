using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Week2.CarManager.Models
{
    public class Vehicle
    {
        public int Id { get; set; }
        public VehicleType VehicleType { get; set; }
        public string? PlateNumber { get; set; }
    }
}
