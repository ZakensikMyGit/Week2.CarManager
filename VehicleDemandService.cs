namespace Week2.CarManager
{
    public partial class VehicleDemandService
    {
        private List<VehicleDemand> VehicleDemandsList { get; set; }

        public VehicleDemandService()
        {
            VehicleDemandsList = new List<VehicleDemand>();
        }
        public void AddNewVehicleDemand(VehiclesService vehiclesService)
        {
            DateTime departureTime = GetValidDateTime("Podaj czas wyjazdu (format: YYYY-MM-DD HH:MM): ");
            DateTime returnTime = GetValidDateTime("Podaj czas powrotu (format: YYYY-MM-DD HH:MM): ", departureTime);

            Console.WriteLine("Wybierz pojazd: ");
            int index = 1;

            if (vehiclesService.VehiclesList.Count == 0)
            {
                Console.WriteLine("Brak dostępnych pojazdów.");
                return;
            }
            foreach (var vehicle in vehiclesService.VehiclesList)
            {
                Console.WriteLine($"{index}. {vehicle.PlateNumber}");
                index++;
            }

            int selectedIndex;
            Int32.TryParse(Console.ReadLine(), out selectedIndex);

            if (selectedIndex <= 0 || selectedIndex > vehiclesService.VehiclesList.Count)
            {
                Console.WriteLine("Nie ma takiego pojazdu w naszej bazie");
                return;
            }

            Vehicle selectedVehicle = vehiclesService.VehiclesList[selectedIndex - 1];

            if (!IsVehicleAvailable(selectedVehicle, departureTime, returnTime))
            {
                Console.WriteLine("Wybrany pojazd nie jest dostępny w podanym okresie czasu.");
                return;
            }

            string driverFirstName = GetNotEmptyInput("Podaj imię kierowcy: ");
            string driverLastName = GetNotEmptyInput("Podaj nazwisko kierowcy: ");
            string destinationLocation = GetNotEmptyInput("Podaj miejsce przeznaczenia: ");
            string purpose = GetNotEmptyInput("Podaj cel wyjazdu: ");
            string disponentFirstName = GetNotEmptyInput("Podaj imię dysponenta: ");
            string disponentLastName = GetNotEmptyInput("Podaj nazwisko dysponenta: ");
            string disponentPhone = GetNotEmptyInput("Podaj telefon kontaktowy do dysponenta:  ");

            VehicleDemand newDemand = new VehicleDemand(
                selectedVehicle,
                driverFirstName,
                driverLastName,
                destinationLocation,
                departureTime,
                returnTime,
                purpose,
                disponentFirstName,
                disponentLastName,
                disponentPhone);

            VehicleDemandsList.Add(newDemand);
            ShowVehicleDemandsList(newDemand);
        }

        public void ShowVehicleDemandsList(VehicleDemand newDemand)
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

        public string GetNotEmptyInput(string message)
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
        public DateTime GetValidDateTime(string message, DateTime? minDate = null)
        {
            DateTime dateTime;
            do
            {
                Console.Write(message);
                DateTime.TryParse(Console.ReadLine(), out dateTime);

                if (minDate.HasValue && dateTime <= minDate.Value)
                {
                    Console.WriteLine("Data i godzina powinny być późniejsze niż " + minDate.Value);
                    dateTime = default(DateTime);
                }
            }
            while (dateTime == default(DateTime));
            return dateTime;
        }
        private bool IsVehicleAvailable(Vehicle vehicle, DateTime departureTime, DateTime returnTime)
        {
            foreach (var demand in VehicleDemandsList)
            {
                if (demand.Vehicle == vehicle)
                {
                    if ((departureTime >= demand.DepartureTime && departureTime <= demand.ReturnTime) ||
                        (returnTime >= demand.DepartureTime && returnTime <= demand.ReturnTime))
                    {
                        return false;
                    }
                }
            }
            return true;
        }
    }
}

