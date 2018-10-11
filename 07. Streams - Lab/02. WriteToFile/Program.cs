using System.IO;
using System.Linq;

namespace _02._WriteToFile
{
    class Program
    {
        static void Main()
        {
            string path = "../../../";
            string inputFileName = "Program.cs";
            string outputFileName = "../../../reversed.txt";

            path = Path.Combine(path, inputFileName);

            using (StreamReader reader = new StreamReader(path))
            {
                using (StreamWriter writer = new StreamWriter(outputFileName))
                {
                    string line = reader.ReadLine();
                    int lineNumber = 1;
                
                    while (line != null)
                    {
                        writer.WriteLine($"Line {lineNumber++}: {string.Join("", line.Reverse())}");

                        line = reader.ReadLine();
                    }
                }
            }
        }
    }
}
