using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Week2.CarManager
{
    public class VehicleDemand
    {
        public Vehicles? Vehicle { get; set; }
        public string? DriverFirstName { get; set; }
        public string? DriverLastName { get; set; }
        public string? DestinatioLocation { get; set; }
        public DateTime DepartureTime { get; set; }
        public DateTime ReturnTime { get; set; }
        public string? Purpose { get; set; }
        public string? DisponentFirstName { get; set; }
        public string? DisponentLastName { get; set; }
        public string? DisponentPhone { get; set; }
    }
}
