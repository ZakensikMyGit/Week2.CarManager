using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Week2.CarManager
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
            this.Vehicle = vehicle;
            this.DriverFirstName = driverFirstName;
            this.DriverLastName = driverLastName;
            this.DestinatioLocation = destinatioLocation;
            this.DepartureTime = departureTime;
            this.ReturnTime = returnTime;
            this.Purpose = purpose;
            this.DisponentFirstName = disponentFirstName;
            this.DisponentLastName = disponentLastName;
            this.DisponentPhone = disponentPhone;        
        }
    }
}
