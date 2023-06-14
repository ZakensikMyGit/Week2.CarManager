using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Week2.CarManager
{
    public abstract class BaseService
    {
        protected string GetInput(string message)
        {
            Console.Write($"\n{message}");
            return Console.ReadLine(); // Nie sprawdzamy, czy jest puste
        }

        protected DateTime GetValidDateTime(string message, DateTime? minDate = null)
        {
            DateTime dateTime;
            minDate = DateTime.Now;
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
    }

}
