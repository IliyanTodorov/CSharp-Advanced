namespace _02._AverageStudentGrades
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class Program
    {
        static void Main()
        {
            var classbook = new Dictionary<string, List<double>>();
            
            int num = int.Parse(Console.ReadLine());

            for (int i = 0; i < num; i++)
            {
                var input = Console.ReadLine()
                    .Split()
                    .ToArray();

                string name = input[0];
                double grade = double.Parse(input[1]);

                if (!classbook.ContainsKey(name))
                {
                    classbook[name] = new List<double>();
                }

                classbook[name].Add(grade);
            }

            

            foreach (var info in classbook)
            {
                double avg = classbook[info.Key].Average();

                Console.Write($"{info.Key} -> ");
                foreach (var grade in info.Value)
                {
                    Console.Write($"{grade:f2} ");
                }

                Console.WriteLine($"(avg: {avg:f2})");
            }
        }
    }
}
