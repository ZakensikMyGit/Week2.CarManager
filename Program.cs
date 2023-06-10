namespace Week2.CarManager
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
                Console.WriteLine("(0) Wyjdź z programu");
            }
        }

    }
}