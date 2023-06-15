namespace Week2.CarManager.Service
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("-----------------------------------------------");
            Console.WriteLine("\tProgram do zarządzania pojazdami");
            Console.WriteLine("-----------------------------------------------\n");
            VehiclesService vehiclesService = new VehiclesService();
            VehicleDemandService vehicleDemandService = new VehicleDemandService();
            VehicleDemandLoggerService vehicleDemandLoggerService = new VehicleDemandLoggerService();
            FileService fileService = new FileService();

            bool isRunning = true;
            while (isRunning)
            {
                MainMenuView();

                int choose;
                int.TryParse(Console.ReadLine(), out choose);

                switch (choose)
                {
                    case 1:
                        vehiclesService.AddNewVehicle();
                        break;
                    case 2:
                        vehiclesService.ShowVehicles();
                        break;
                    case 3:
                        vehiclesService.RemoveVehicle();
                        break;
                    case 4:
                        vehicleDemandService.AddNewVehicleDemand(vehiclesService);
                        break;
                    case 5:
                        vehicleDemandLoggerService.LogVehicleDemand(vehiclesService);
                        break;
                    case 6:
                        fileService.ReadLogFromFile();
                        break;
                    default:
                        isRunning = false;
                        break;
                }
            }

            void MainMenuView()
            {
                Console.WriteLine("\n*** Wybierz dostępną opcję ***\n");
                Console.WriteLine("(1) Dodaj pojazd");
                Console.WriteLine("(2) Lista pojazdów");
                Console.WriteLine("(3) Usuń pojazd");
                Console.WriteLine("(4) Zapotrzebowanie na pojazd");
                Console.WriteLine("(5) Zapotrzebowanie na pojazd - do pliku");
                Console.WriteLine("(6) Wczytaj zapotrzebowania z pliku");
                Console.WriteLine("(0) Wyjdź z programu");
            }
        }

    }
}