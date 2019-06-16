using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Data.OleDb;
using System.Data;

namespace CSA_Simulator
{
    class Program
    {
        //todo: consider making this its own class.
        public static List<CSAItem> parseFile(string filePath)
        {
            var CSAList = new List<CSAItem>();
            using (var reader = new StreamReader(filePath))
            {
                while (!reader.EndOfStream)
                {
                    var line = reader.ReadLine();
                    var values = line.Split(',');

                    if (values[0] == "Things per week")
                    {
                        continue;
                    }
                    CSAList.Add(new CSAItem(values[0], Convert.ToDouble(values[1])));                    
                }
            }
            return CSAList;
        }

        static void Main(string[] args)
        {                        
            var CSAList = parseFile(@"E:\Github\CSA-Simulator\CSA-Simulator\CSA Simulator.csv");
            var simulator = new CSASimulator(CSAList);
            var box = simulator.calculateThings();

            Console.WriteLine("Press enter to quit.");
            Console.WriteLine("Here's your box: \n");
            foreach (CSAItem item in box)
            {
                Console.WriteLine(item.GetName() + "\t\t" + item.GetPercentage() * 100 + "%");

            }
            while (Console.ReadKey().Key != ConsoleKey.Enter) 
            {
                box.Clear();
                box = simulator.calculateThings();
                Console.Clear();
                Console.WriteLine("Press enter to quit.");
                Console.WriteLine("Here's your box: \n");
                foreach (CSAItem item in box)
                {
                    Console.WriteLine(item.GetName() + "\t\t" + item.GetPercentage() * 100 + "%");

                }
            }

        }
    }
}
