namespace Week2.CarManager
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Program do zarządzania pojazdami");
            VehiclesService vehiclesService = new VehiclesService();
            bool isRunning = true;
            while (isRunning)
            {
                Console.WriteLine("Wybierz dostępną opcję");
                Console.WriteLine("\n1. Dodaj pojazd");
                Console.WriteLine("2. Sprawdź stan pojazdów");
                Console.WriteLine("3. Usuń pojazd");
                Console.WriteLine("0. Wyjdź z programu");

                int choose;
                Int32.TryParse(Console.ReadLine(), out choose);
                if (choose == 0)
                {
                    Console.WriteLine("Dziękujemy za skorzystanie z programu.");
                    isRunning = false;
                }
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
                    default:
                        break;
                }
            }
            Console.ReadLine();
        }
    }
}