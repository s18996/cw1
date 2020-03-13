using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Xml.Serialization;

namespace cw1
{
    public class Program
    {
        public const string AUTHOR = "Jan Kulisiewicz";

        public static void Main(string[] args)
        {
            var pathCSV = args.Length > 0 ? args[0] : "dane.csv";
            var destination = args.Length > 1 ? args[1] : "result.xml";
            var dataFormat = args.Length > 2 ? args[2] : "xml";
            var logPath = "log.txt";

            var log = new StringBuilder();
            var serializer = new XmlSerializer(typeof(Academy));
            var today = DateTime.Today;

            FileStream writer;
            IEnumerable<string> lines;
            try
            {
                lines = File.ReadLines(pathCSV);
                writer = new FileStream(destination, FileMode.Create);
            }
            catch (FileNotFoundException)
            {
                throw new FileNotFoundException("Plik nie istnieje");
            }
            catch (ArgumentException)
            {
                throw new ArgumentException("Podana sciezka jest niepoprawna");
            }
            var hash = new HashSet<Student>(new MyComparer());

            var academy = new Academy();
            var studentList = new List<Student>();
            var activeStudiesList = new Dictionary<string, int>();

            foreach (var line in lines)
            {
                string[] student = line.Split(',');
                if (isLineCorrect(student))
                {
                    var stud = new Student
                    {
                        FirstName = student[0],
                        LastName = student[1],
                        _Studies = new Studies
                        {
                            StudiesName = student[2],
                            StudiesMode = student[3]
                        },
                        Index = "s" + student[4],
                        Birthdate = student[5],
                        Email = student[6],
                        MothersName = student[7],
                        FathersName = student[8],
                    };
                    if (hash.Add(stud))
                    {
                        studentList.Add(stud);
                        if (!activeStudiesList.ContainsKey(stud._Studies.StudiesName))
                        {
                            activeStudiesList.Add(stud._Studies.StudiesName, 1);
                        }
                        else
                        {
                            activeStudiesList[stud._Studies.StudiesName] += 1;
                        }
                    }
                    else
                    {
                        log.Append(line + "\n");
                    }
                }
                else
                {
                    log.Append(line + "\n");
                }

            }
            academy.date = today.ToShortDateString();
            academy.author = Program.AUTHOR;
            academy.Students = studentList;
            academy.Studies = new List<ActiveStudies>();
            foreach (KeyValuePair<string, int> pair in activeStudiesList)
            {
                academy.Studies.Add(new ActiveStudies
                {
                    Name = pair.Key,
                    NumberOfStudents = pair.Value.ToString()
                });
            }
            serializer.Serialize(writer, academy);

            Console.WriteLine(today.ToShortDateString());
            Console.WriteLine(hash.Count);
            File.WriteAllText(logPath, log.ToString());
        }

        private static bool isLineCorrect(string[] line)
        {
            if (line.Length != 9) 
                return false;
            for (int i = 0; i < line.Length; i++)
            {
                if (String.IsNullOrWhiteSpace(line[i])) 
                    return false;
            }
            return true;
        }
    }
}
