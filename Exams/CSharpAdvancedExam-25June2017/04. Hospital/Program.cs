namespace _04._Hospital
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class Program
    {
        static void Main()
        {
            var departments = new Dictionary<string, List<string>>();
            var doctors = new Dictionary<string, List<string>>();

            string input;
            while ((input = Console.ReadLine()) != "Output")
            {
                var tokens = input.Split();

                var department = tokens[0];
                var doctor = tokens[1] + " " + tokens[2];
                var patient = tokens[3];

                if (!departments.ContainsKey(department))
                {
                    departments.Add(department, new List<string>());
                }

                if (!doctors.ContainsKey(doctor))
                {
                    doctors.Add(doctor, new List<string>());
                }

                departments[department].Add(patient);
                doctors[doctor].Add(patient);
            }

            string command = Console.ReadLine();
            while (command != "End")
            {
                var tokens = command.Split();

                if (tokens.Length == 1)
                {
                    foreach (var patients in departments[command])
                    {
                        Console.WriteLine(patients);
                    }
                }
                else if (int.TryParse(tokens[1], out int result))
                {
                    if (int.Parse(tokens[1]) > 20)
                    {
                        continue;
                    }

                    var patients = departments[tokens[0]];
                    var room = patients.Skip(3 * (int.Parse(tokens[1]) - 1)).Take(3).OrderBy(p => p);

                    foreach (var patient in room)
                    {
                        Console.WriteLine(patient);
                    }
                }
                else
                {
                    var patients = doctors[command];
                    patients.Sort();
                    foreach (var patient in patients)
                    {
                        Console.WriteLine(patient);
                    }
                }
                
            }
        }
    }
}
