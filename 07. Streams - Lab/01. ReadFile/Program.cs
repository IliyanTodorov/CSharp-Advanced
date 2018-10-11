using System;
using System.IO;

namespace _01._ReadFile
{
    class Program
    {
        static void Main()
        {
            string path = "../../../";
            string fileName = "Program.cs";
            
            path = Path.Combine(path, fileName);

            using (StreamReader reader = new StreamReader(path))
            {
                string line = reader.ReadLine();
                int lineNumber = 1;
               
                while (line != null)
                {
                    Console.WriteLine($"Line {lineNumber++}: {line}");
                    line = reader.ReadLine();
                }
            }
        }
    }
}   
