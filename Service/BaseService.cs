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
            Console.Write($"Zapotrzebowanie na pojazd: " +
                $"\nPojazd:\t{demand.Vehicle?.PlateNumber}" +
                $"\nKierowca:\t{demand.DriverFirstName} {demand.DriverLastName}" +
                $"\nMiejsce:\t{demand.DestinatioLocation}" +
                $"\nData wyjazdu:\t{demand.DepartureTime}" +
                $"\nData powrotu:\t{demand.ReturnTime}" +
                $"\nCel wyjazdu:\t{demand.Purpose}" +
                $"\nDysponent:\t{demand.DisponentFirstName} {demand.DisponentLastName}{demand.DisponentPhone}");

        }
    }

}
