﻿using System;
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
            foreach (VehicleType types in Enum.GetValues(typeof(VehicleType)))
            {
                Console.WriteLine($"{(int)types}. {types}");
            }

            VehicleType selectedType = VehicleType.Car;
            bool isTypeValid = false;
            while (!isTypeValid)
            {
               // string userInput = Console.ReadLine();
                isTypeValid = Enum.TryParse(Console.ReadLine(), out selectedType) && Enum.IsDefined(typeof(VehicleType), selectedType);
                if (!isTypeValid)
                {
                    Console.WriteLine("Niepoprawny wybór. Wybierz prawidłowy typ pojazdu.");
                }
            }
            var plateNumber = CreatePlateNumber();

            Vehicles vehicles = new Vehicles
            {
                Type = selectedType,
                PlateNumber = plateNumber
            };
            VehiclesList.Add(vehicles);
        }

        public void RemoveVehicle()
        {
            if (VehiclesList.Count > 0)
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
                Int32.TryParse(Console.ReadLine(), out removeChoose);
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
        public void ShowVehicles()
        {
            if (VehiclesList.Count > 0)
            {
                Console.WriteLine("\nLista pojazdów: \nId\tTyp\tNr rejestr.\t");
                for (int i = 0; i < VehiclesList.Count; i++)
                {
                    var vehicle = VehiclesList[i];
                    Console.WriteLine($"{i + 1}\t{vehicle.Type}\t{vehicle.PlateNumber}");
                }
            }
            else
            {
                Console.WriteLine("\n!!! Brak pojazdów !!!\n");
            }
        }
        public string ShowVehicles(int a)
        {
            Console.WriteLine("\nLista pojazdów: \nId\tTyp\tNr rejestr.\t");
            if (a > 0 && a <= VehiclesList.Count)
            {
                var vehicle = VehiclesList[a - 1];
                return $"{a}\t{vehicle.Type}\t{vehicle.PlateNumber}";
            }
            else
            {
                return "Nie znaleziono pojazdu o podanym numerze.";
            }
        }
        public string CreatePlateNumber()
        {
            string? plateNumber;
            do
            {
                Console.Write("Podaj numer tablicy rejestracyjnej (7 znaków): ");
                plateNumber = Console.ReadLine();
            }
            while (plateNumber.Length != 7);

            plateNumber = plateNumber.ToUpper().Insert(3, " ");

            return plateNumber;
        }
    }
}

