namespace Week2.CarManager
{
        public class VehicleDemandLoggerService : BaseService
        {
            private const string FilePath = @"plik.txt";

            public void LogVehicleDemand(VehiclesService vehiclesService)
            {
                DateTime departureTime = GetValidDateTime("Podaj czas wyjazdu (format: YYYY-MM-DD HH:MM): ");
                DateTime returnTime = GetValidDateTime("Podaj czas powrotu (format: YYYY-MM-DD HH:MM): ", departureTime);

            // POPRAWIĆ kod, usunąć wybór pojazdu


            //Console.WriteLine("Wybierz pojazd: ");
            //int index = 1;

            //foreach (var vehicle in vehiclesService.VehiclesList)
            //{
            //    Console.WriteLine($"{index}. {vehicle.PlateNumber}");
            //    index++;
            //}

            //int selectedIndex;
            //Int32.TryParse(Console.ReadLine(), out selectedIndex);

            //Vehicle selectedVehicle = vehiclesService.VehiclesList[selectedIndex - 1];
                Vehicle? selectedVehicle = default;
                string driverFirstName = GetInput("Podaj imię kierowcy (może być puste): ");
                string driverLastName = GetInput("Podaj nazwisko kierowcy (może być puste): ");
                string destinatioLocation = GetInput("Podaj miejsce przeznaczenia (może być puste): ");
                string purpose = GetInput("Podaj cel wyjazdu (może być puste): ");
                string disponentFirstName = GetInput("Podaj imię dysponenta (może być puste): ");
                string disponentLastName = GetInput("Podaj nazwisko dysponenta (może być puste): ");
                string disponentPhone = GetInput("Podaj telefon kontaktowy do dysponenta (może być puste):  ");

                VehicleDemand newDemand = new VehicleDemand(
                    selectedVehicle,
                    driverFirstName,
                    driverLastName,
                    destinatioLocation,
                    departureTime,
                    returnTime,
                    purpose,
                    disponentFirstName,
                    disponentLastName,
                    disponentPhone);

                LogToFile(newDemand);
            }
            private void LogToFile(VehicleDemand newDemand)
            {
                using StreamWriter writer = new StreamWriter(FilePath, append: true);
                writer.WriteLine($"Zapotrzebowanie na pojazd: ");
                writer.WriteLine($"Pojazd:\t"); // zostawić puste pole, 
                writer.WriteLine($"Kierowca:\t{newDemand.DriverFirstName} {newDemand.DriverLastName}");
                writer.WriteLine($"Miejsce:\t{newDemand.DestinatioLocation}");
                writer.WriteLine($"Data wyjazdu:\t{newDemand.DepartureTime}");
                writer.WriteLine($"Data powrotu:\t{newDemand.ReturnTime}");
                writer.WriteLine($"Cel wyjazdu:\t{newDemand.Purpose}");
                writer.WriteLine($"Dysponent:\t{newDemand.DisponentFirstName} {newDemand.DisponentLastName} {newDemand.DisponentPhone}");
            }
        }
    }

