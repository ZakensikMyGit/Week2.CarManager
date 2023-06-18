using Week2.CarManager.Models;

namespace Week2.CarManager.Service
{
    public class VehicleDemandLoggerService : BaseService
    {

        public void LogVehicleDemand(VehiclesService vehiclesService)
        {
            DateTime departureTime = GetValidDateTime("Podaj czas wyjazdu (format: YYYY-MM-DD HH:MM): ");
            DateTime returnTime = GetValidDateTime("Podaj czas powrotu (format: YYYY-MM-DD HH:MM): ", departureTime);

            Vehicle? selectedVehicle = null;
            string driverFirstName = GetInput("Podaj imię kierowcy: ");
            string driverLastName = GetInput("Podaj nazwisko kierowcy: ");
            string destinatioLocation = GetInput("Podaj miejsce przeznaczenia: ");
            string purpose = GetInput("Podaj cel wyjazdu: ");
            string disponentFirstName = GetInput("Podaj imię dysponenta: ");
            string disponentLastName = GetInput("Podaj nazwisko dysponenta: ");
            string disponentPhone = GetInput("Podaj telefon kontaktowy do dysponenta:  ");

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
            writer.WriteLine(newDemand.DriverFirstName);
            writer.WriteLine(newDemand.DriverLastName);
            writer.WriteLine(newDemand.DestinatioLocation);
            writer.WriteLine(newDemand.DepartureTime);
            writer.WriteLine(newDemand.ReturnTime);
            writer.WriteLine(newDemand.Purpose);
            writer.WriteLine(newDemand.DisponentFirstName);
            writer.WriteLine(newDemand.DisponentLastName);
            writer.WriteLine(newDemand.DisponentPhone);

            LogToFileToPrint(newDemand);
        }
        private void LogToFileToPrint(VehicleDemand newDemand)
        {
            using StreamWriter writer = new StreamWriter(FilePathToPrint, append: true);
            writer.WriteLine($"Zapotrzebowanie na pojazd: ");
            writer.WriteLine($"Pojazd:\t"); // zostawić puste pole, 
            writer.WriteLine($"Kierowca:\t{newDemand.DriverFirstName} {newDemand.DriverLastName}");
            writer.WriteLine($"Miejsce:\t{newDemand.DestinatioLocation}");
            writer.WriteLine($"Data wyjazdu:\t{newDemand.DepartureTime}");
            writer.WriteLine($"Data powrotu:\t{newDemand.ReturnTime}");
            writer.WriteLine($"Cel wyjazdu:\t{newDemand.Purpose}");
            writer.WriteLine($"Dysponent:\t{newDemand.DisponentFirstName} {newDemand.DisponentLastName}");
            writer.WriteLine($"Telefon do dysponenta:\t{newDemand.DisponentPhone}");
        }
        public override string GetInput(string message)
        {
            Console.Write($"\n{message}");
            return Console.ReadLine() ?? string.Empty;
        }
    }
}

