

namespace Week2.CarManager
{
    internal class Program
    {
        static void Main(string[] args)
        {
            DailyTasks.Message();
            string click = Console.ReadLine();
            Console.Clear();

            Console.WriteLine("-----------------------------------------------");
            Console.WriteLine("\tProgram do zarządzania pojazdami");
            Console.WriteLine("-----------------------------------------------\n");
            VehiclesService vehiclesService = new VehiclesService() ;
            VehicleDemandService vehicleDemandService = new VehicleDemandService();
            VehicleDemandLoggerService vehicleDemandLoggerService = new VehicleDemandLoggerService();

            bool isRunning = true;
            while (isRunning)
            {
                MainMenuView();

                int choose;
                Int32.TryParse(Console.ReadLine(), out choose);

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
                Console.WriteLine("(0) Wyjdź z programu");
            }
        }

    }
}