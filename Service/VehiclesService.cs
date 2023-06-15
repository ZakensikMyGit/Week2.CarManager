using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Week2.CarManager.Models;

namespace Week2.CarManager.Service
{
    public class VehiclesService : BaseService
    {
        public VehiclesService()
        {
            VehiclesList = new List<Vehicle>
            {
                new Vehicle {VehicleType = VehicleType.Car, PlateNumber = "HWA ASD2a"},
                new Vehicle {VehicleType = VehicleType.Car, PlateNumber = "HWA YK13d"},
                new Vehicle {VehicleType = VehicleType.Car, PlateNumber = "HWE NO23s"}
            };
        }
        public void AddNewVehicle()
        {
            VehicleType selectedType = SelectVehicleType();
            var plateNumber = CreatePlateNumber();
            Vehicle vehicles = new Vehicle
            {
                VehicleType = selectedType,
                PlateNumber = plateNumber
            };
            VehiclesList.Add(vehicles);
        }
        private static VehicleType SelectVehicleType()
        {
            Console.WriteLine("\nWybierz typ pojazdu: ");
            foreach (VehicleType types in Enum.GetValues(typeof(VehicleType)))
            {
                Console.WriteLine($"{(int)types}. {types}");
            }
            VehicleType selectedType = VehicleType.Car;
            bool isTypeValid = false;
            while (!isTypeValid)
            {
                isTypeValid = Enum.TryParse(Console.ReadLine(), out selectedType) && Enum.IsDefined(typeof(VehicleType), selectedType);
                if (!isTypeValid)
                {
                    Console.WriteLine("Niepoprawny wybór. Wybierz prawidłowy typ pojazdu.");
                }
            }
            return selectedType;
        }
        public string CreatePlateNumber()
        {
            string? plateNumber;
            do
            {
                Console.Write("Podaj numer tablicy rejestracyjnej (7 znaków): ");
                plateNumber = Console.ReadLine();
            }
            while (plateNumber?.Length != 7);
            plateNumber = plateNumber.ToUpper().Insert(3, " ");
            return plateNumber;
        }

        public void RemoveVehicle()
        {
            if (VehiclesList.Count > 0)
            {
                Console.WriteLine($"\nKtóry pojazd chcesz usunąć z bazy: \n");
                ShowVehicles();
                int removeItem;
                int.TryParse(Console.ReadLine(), out removeItem);

                Vehicle removeVehicle = new Vehicle();
                foreach (var item in VehiclesList)
                {
                    if (item.Id == removeItem)
                    {
                        removeVehicle = item;
                        break;
                    }
                }
                Console.WriteLine($"Czy chcesz usunąć pojazd: {ShowVehicles(removeItem)}\n1: tak");
                int removeChoose;
                int.TryParse(Console.ReadLine(), out removeChoose);
                if (removeChoose == 1 && removeItem > 0 && removeItem <= VehiclesList.Count)
                {
                    VehiclesList.RemoveAt(removeItem - 1);
                    Console.WriteLine("Pojazd został usunięty");
                }
                else
                {
                    Console.WriteLine("Pojazd nie został usunięty.");
                }
            }
            else
            {
                Console.WriteLine("\n!!! Brak pojazdów !!! \n");
            }
        }
        public  string ShowVehicles(int id)
        {
            Console.WriteLine("\nLista pojazdów: \nId\tTyp\tNr rejestr.\t");
            if (id > 0 && id <= VehiclesList.Count)
            {
                var vehicle = VehiclesList[id - 1];
                return $"{id}\t{vehicle.VehicleType}\t{vehicle.PlateNumber}";
            }
            else
            {
                return "Nie znaleziono pojazdu o podanym numerze.";
            }
        }
    }
}

