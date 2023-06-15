using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Week2.CarManager.Models;

namespace Week2.CarManager.Service
{
    public class FileService : BaseService
    {
        private List<VehicleDemand> _vehicleDemands;

        public FileService()
        {
            _vehicleDemands = new List<VehicleDemand>();
        }
        public void ReadLogFromFile()
        {
            if (!File.Exists(FilePath))
            {
                Console.WriteLine("Plik nie istnieje.");
                return;
            }
            LoadDataFromFile();
        }
        public void LoadDataFromFile()
        {
            string[] lines = File.ReadAllLines(FilePath);
            foreach (var line in lines)
            {
                string[] parts = line.Split('\t');
                if (parts.Length == 9)
                {
                    Vehicle vehicle = new Vehicle();
                    DateTime departureTime = DateTime.Parse(parts[4]);
                    DateTime returnTime = DateTime.Parse(parts[5]);
                    VehicleDemand demand = new VehicleDemand(
                        vehicle,
                        parts[1], // driverFirstName
                        parts[2], // driverLastName
                        parts[3], // destinationLocation
                        departureTime,
                        returnTime,
                        parts[6], // purpose
                        parts[7], // disponentFirstName
                        parts[8], // disponentLastName
                        parts[9]  // disponentPhone
                    );
                    _vehicleDemands.Add(demand);
                }
            }
        }
    }
}


