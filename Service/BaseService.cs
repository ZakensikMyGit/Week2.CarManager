using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Week2.CarManager.Models;

namespace Week2.CarManager.Service
{
    public abstract class BaseService
    {
        protected const string FilePath = @"plik.txt";
        protected const string FilePathToPrint = @"drukuj.txt";
        public List<Vehicle> VehiclesList { get; set; }
        public virtual string GetInput(string message)
        {
            Console.Write($"\n{message}");
            return Console.ReadLine() ?? string.Empty;
        }
        protected DateTime GetValidDateTime(string message, DateTime? minDate = null)
        {
            DateTime dateTime;
            minDate = DateTime.Now;
            do
            {
                Console.Write(message);
                DateTime.TryParse(Console.ReadLine(), out dateTime);

                if (minDate.HasValue && dateTime <= minDate.Value)
                {
                    Console.WriteLine("Data i godzina powinny być późniejsze niż " + minDate.Value);
                    dateTime = default;
                }
            }
            while (dateTime == default);
            return dateTime;
        }
        public void ShowVehicleDemand(VehicleDemand demand)
        {
            if (demand == null)
            {
                Console.WriteLine("Lista jest pusta");
                return;
            }
            else
            {
                Console.Write($"Zapotrzebowanie na pojazd: " +
                    $"\nPojazd:\t{demand.Vehicle?.PlateNumber}" +
                    $"\nKierowca:\t{demand.DriverFirstName} {demand.DriverLastName}" +
                    $"\nMiejsce:\t{demand.DestinatioLocation}" +
                    $"\nData wyjazdu:\t{demand.DepartureTime}" +
                    $"\nData powrotu:\t{demand.ReturnTime}" +
                    $"\nCel wyjazdu:\t{demand.Purpose}" +
                    $"\nDysponent:\t{demand.DisponentFirstName} {demand.DisponentLastName}" +
                    $"\nDysponent telefof:\t{demand.DisponentPhone}");
            }
        }
        public void ShowVehicles()
        {
            if (VehiclesList.Count > 0)
            {
                Console.WriteLine("\nLista pojazdów: \nId\tTyp\tNr rejestr.\t");
                for (int i = 0; i < VehiclesList.Count; i++)
                {
                    var vehicle = VehiclesList[i];
                    Console.WriteLine($"{i + 1}\t{vehicle.VehicleType}\t{vehicle.PlateNumber}");
                }
            }
            else
            {
                Console.WriteLine("\n!!! Brak pojazdów !!!\n");
            }
        }
    }

}
