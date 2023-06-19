using Week2.CarManager.Models;

namespace Week2.CarManager.Service
{
    public partial class VehicleDemandService : BaseService
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
            int.TryParse(Console.ReadLine(), out selectedIndex);

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

            string driverFirstName = GetInput("Podaj imię kierowcy: ");
            string driverLastName = GetInput("Podaj nazwisko kierowcy: ");
            string destinationLocation = GetInput("Podaj miejsce przeznaczenia: ");
            string purpose = GetInput("Podaj cel wyjazdu: ");
            string disponentFirstName = GetInput("Podaj imię dysponenta: ");
            string disponentLastName = GetInput("Podaj nazwisko dysponenta: ");
            string disponentPhone = GetInput("Podaj telefon kontaktowy do dysponenta:  ");

            VehicleDemand newDemand = new VehicleDemand(
                driverFirstName,
                driverLastName,
                destinationLocation,
                departureTime,
                returnTime,
                purpose,
                disponentFirstName,
                disponentLastName,
                disponentPhone,
                selectedVehicle
                );

            VehicleDemandsList.Add(newDemand);
            foreach (var demand in VehicleDemandsList)
            {
                ShowVehicleDemand(demand);
            }
        }
        public void ShowVehicleDemandsList(VehicleDemand newDemand)
        {
            foreach (var demand in VehicleDemandsList)
            {
                ShowVehicleDemand(demand);
            }
        }
        public override string GetInput(string message)
        {
            string input;
            do
            {
                Console.Write($"\n{message}");
                input = Console.ReadLine() ?? string.Empty;
                if (string.IsNullOrEmpty(input))
                {
                    Console.WriteLine("\nUzupełnij pole...");
                }
            }
            while (string.IsNullOrEmpty(input));
            return input;
        }
        private bool IsVehicleAvailable(Vehicle vehicle, DateTime departureTime, DateTime returnTime)
        {
            foreach (var demand in VehicleDemandsList)
            {
                if (demand.Vehicle == vehicle)
                {
                    if (departureTime >= demand.DepartureTime && departureTime <= demand.ReturnTime ||
                        returnTime >= demand.DepartureTime && returnTime <= demand.ReturnTime)
                    {
                        return false;
                    }
                }
            }
            return true;
        }
    }
}

