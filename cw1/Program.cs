using System;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace cw1
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            StringBuilder log = new StringBuilder();
            try
            {
                var pathCSV = args.Length > 0 ? args[0] : "data.csv";
                var destination = args.Length > 1 ? args[1] : "result.xml";
                var format = args.Length > 2 ? args[2] : "xml";

                var lines = File.ReadLines(pathCSV);

                foreach (var line in lines)
                {
                    Console.WriteLine($"{line}");
                }

                var parsedDate = DateTime.Parse("09.03.2020");
                Console.WriteLine(parsedDate);
                var now = DateTime.UtcNow;
                Console.WriteLine(now);
                var today = DateTime.Today;
                Console.WriteLine(today.ToShortDateString());

                var hash = new HashSet
                hash.Add(stud1);
                hash.Add(stud2);
                hash.Add(stud3);

                var newStud = new Student();

                if (hash.Add(newStud))
                {
                    errors.Add(newStud);
                }

            }
            catch (ArgumentException e)
            {
                Console.WriteLine(e);
                log.Append("Podana sciezka jest niepoprawna");
                throw;
            }
            catch (FileNotFoundException e)
            {
                Console.WriteLine(e);
                log.Append($"Plik {args[0]} nie istnieje");
            }
        }
    }
}
