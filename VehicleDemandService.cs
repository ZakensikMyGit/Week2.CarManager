using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Week2.CarManager
{
    public class VehicleDemandService
    {
        public List<VehicleDemand> VehicleDemandsList { get; set; }

        public VehicleDemandService()
        {
            VehicleDemandsList = new List<VehicleDemand>();
        }

        public void AddNewVehicleDemand(VehiclesService vehiclesService)
        {
            VehicleDemand newDemand = new VehicleDemand();

            Console.WriteLine("Wybierz pojazd: ");
            int index = 1;
            foreach (var vehicle in vehiclesService.VehiclesList)
            {
                Console.WriteLine($"{index}. {vehicle.PlateNumber}");
                index++;
            }

            int selectedIndex;
            Int32.TryParse(Console.ReadLine(), out selectedIndex);

            if (selectedIndex > 0 && selectedIndex <= vehiclesService.VehiclesList.Count)
            {
                newDemand.Vehicle = vehiclesService.VehiclesList[selectedIndex - 1];
            }
            else
            {
                Console.WriteLine("Nie ma takiego pojazdu w naszej bazie");
            }

            newDemand.DriverFirstName = GetNoEpmtyInput("Podaj imię kierowcy: ");
            newDemand.DriverLastName = GetNoEpmtyInput("Podaj nazwisko kierowcy: ");
            newDemand.DestinatioLocation = GetNoEpmtyInput("Podaj miejsce przeznaczenia: ");

            bool isTimeValid = false;
            while (!isTimeValid)
            {
                Console.Write("Podaj czas wyjazdu (format: YYYY-MM-DD HH:MM): ");
                DateTime departureTime;
                DateTime.TryParse(Console.ReadLine(), out departureTime);
                newDemand.DepartureTime = departureTime;

                Console.Write("Podaj czas powrotu (format: YYYY-MM-DD HH:MM): ");
                DateTime returnTime;
                DateTime.TryParse(Console.ReadLine(), out returnTime);
                newDemand.ReturnTime = returnTime;

                DateTime actualDateTime = DateTime.Now;
                if (returnTime > departureTime && departureTime > actualDateTime)
                {
                    isTimeValid = true;
                }
                else
                {
                    Console.WriteLine("Podaj poprawne dane wyjazdu i powrotu pojazdu");
                }
            }

            newDemand.Purpose = GetNoEpmtyInput("Podaj cel wyjazdu: ");
            newDemand.DisponentFirstName = GetNoEpmtyInput("Podaj imię dysponenta: ");
            newDemand.DisponentLastName = GetNoEpmtyInput("Podaj nazwisko dysponenta: ");
            newDemand.DisponentPhone = GetNoEpmtyInput("Podaj telefon kontaktowy do dysponenta:  ");

            VehicleDemandsList.Add(newDemand);
            ShowVehicleDemandsList(newDemand);
        }
        public void ShowVehicleDemandsList()
        {
            foreach (VehicleDemand de in VehicleDemandsList)
            {
                Console.Write($"Zapotrzebowanie na pojazd: " +
                    $"\nPojazd:\t{de.Vehicle.PlateNumber}" +
                    $"\nKierowca:\t{de.DriverFirstName} {de.DriverLastName}" +
                    $"\nMiejsce:\t{de.DestinatioLocation}" +
                    $"\nData wyjazdu:\t{de.DepartureTime}" +
                    $"\nData powrotu:\t{de.ReturnTime}" +
                    $"\nCel wyjazdu:\t{de.Purpose}" +
                    $"\nDysponent:\t{de.DisponentFirstName} {de.DisponentLastName} {de.DisponentPhone}");
            }
        }
        public void ShowVehicleDemandsList(VehicleDemand de)
        {
            Console.Write($"Zapotrzebowanie na pojazd: " +
                $"\nPojazd:\t{de.Vehicle.PlateNumber}" +
                $"\nKierowca:\t{de.DriverFirstName} {de.DriverLastName}" +
                $"\nMiejsce:\t{de.DestinatioLocation}" +
                $"\nData wyjazdu:\t{de.DepartureTime}" +
                $"\nData powrotu:\t{de.ReturnTime}" +
                $"\nCel wyjazdu:\t{de.Purpose}" +
                $"\nDysponent:\t{de.DisponentFirstName} {de.DisponentLastName} {de.DisponentPhone}");

        }
        public string GetNoEpmtyInput(string message)
        {
            string? input;
            do
            {
                Console.Write($"\n{message}");
                input = Console.ReadLine();
                if (string.IsNullOrEmpty(input))
                {
                    Console.WriteLine("\nUzupełnij pole...");
                }
            }
            while (string.IsNullOrEmpty(input));

            return input;
        }
    }
}
