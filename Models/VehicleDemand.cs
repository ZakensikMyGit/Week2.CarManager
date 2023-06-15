using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Week2.CarManager.Models
{
    public class VehicleDemand
    {
        public Vehicle? Vehicle { get; set; }
        public string? DriverFirstName { get; set; }
        public string? DriverLastName { get; set; }
        public string? DestinatioLocation { get; set; }
        public DateTime DepartureTime { get; set; }
        public DateTime ReturnTime { get; set; }
        public string? Purpose { get; set; }
        public string? DisponentFirstName { get; set; }
        public string? DisponentLastName { get; set; }
        public string? DisponentPhone { get; set; }

        public VehicleDemand(Vehicle? vehicle, string? driverFirstName, string? driverLastName, string? destinatioLocation, DateTime departureTime, DateTime returnTime, string? purpose, string? disponentFirstName, string? disponentLastName, string? disponentPhone)
        {
            Vehicle = vehicle;
            DriverFirstName = driverFirstName;
            DriverLastName = driverLastName;
            DestinatioLocation = destinatioLocation;
            DepartureTime = departureTime;
            ReturnTime = returnTime;
            Purpose = purpose;
            DisponentFirstName = disponentFirstName;
            DisponentLastName = disponentLastName;
            DisponentPhone = disponentPhone;
        }
    }
}
