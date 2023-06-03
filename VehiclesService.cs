using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Week2.CarManager
{
    public class VehiclesService
    {
        public List<Vehicles> VehiclesList { get; set; }
        public VehiclesService()
        {
            VehiclesList = new List<Vehicles>();
        }

        public void AddNewVehicle()
        {
            Console.WriteLine("\nWybierz typ pojazdu: ");
            foreach (TypeVehicles types in Enum.GetValues(typeof(TypeVehicles)))
            {
                Console.WriteLine($"{(int)types}. {types}");
            }
            TypeVehicles selectedType;
            Enum.TryParse(Console.ReadLine(), out selectedType);

            switch (selectedType)
            {
                case TypeVehicles.car:
                    selectedType = TypeVehicles.car;
                    break;
                case TypeVehicles.bus:
                    selectedType = TypeVehicles.bus;
                    break;
                case TypeVehicles.truck:
                    selectedType = TypeVehicles.truck;
                    break;
                case TypeVehicles.other:
                    selectedType = TypeVehicles.other;
                    break;
                default:
                    Console.WriteLine("Nie ma takiego typu pojazdu w naszej bazie");
                    break;
            }

            Console.WriteLine("Podaj numer rejestracyjny:");
            string plateNumber = Console.ReadLine();

            Vehicles vehicles = new Vehicles
            {
                Type = selectedType,
                PlateNumber = plateNumber
            };
            VehiclesList.Add(vehicles);
        }

        public void RemoveVehicle()
        {
            Console.WriteLine($"\nKtóry pojazd chcesz usunąć z bazy: \n");
            ShowVehicles(); 
            int removeItem;
            Int32.TryParse(Console.ReadLine(), out removeItem);

            Vehicles removeVehicle = new Vehicles();
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
            Int32.TryParse(Console.ReadLine(),out removeChoose);
            if (removeItem > 0 && removeItem <= VehiclesList.Count)
            {
                VehiclesList.RemoveAt(removeItem - 1);
                Console.WriteLine("Pojazd został usunięty");
            }
            else
            {
                Console.WriteLine("Nie znaleziono pojazdu o podanym numerze.");
            }

        }
        public void ShowVehicles()
        {
            if (VehiclesList.Count > 0)
            {
                Console.WriteLine("\nPojazdy w naszej bazie: \n");
                for (int i = 0; i < VehiclesList.Count; i++)
                {
                    var vehicle = VehiclesList[i];
                    Console.WriteLine($"Pojazd: {i + 1}; {vehicle.Type}; {vehicle.PlateNumber}");
                }
            }
            else
            {
                Console.WriteLine("\nBrak pojazdów w bazie.\n");
            }
        }
        public string ShowVehicles(int a)
        {
            if (a > 0 && a <= VehiclesList.Count)
            {
                var vehicle = VehiclesList[a - 1];
                return $"Pojazd: {a}; {vehicle.Type}; {vehicle.PlateNumber}";
            }
            else
            {
                return "Nie znaleziono pojazdu o podanym numerze.";
            }
        }
    }
}

