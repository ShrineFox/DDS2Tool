using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DDS2Tool
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("DDS2Tool by ShrineFox\nUse to extract from or create P5 Bustup BIN files");
            Console.WriteLine("Usage:\n - Supply a folder with DDS files to generate a BIN");
            Console.WriteLine(" - Supply a folder with BIN files to extract DDS files");
            Console.WriteLine(" - Supply a BIN file containing DDS2 to extract DDS files");
            Console.WriteLine("-------------------------------------------------------------\n");
            string validPath = Validation.Path(args); //Make sure path or file exists
            string pathType = Validation.Type(validPath); //Find out if path is a file or a directory
            bool combine = false;

            if (pathType == "BIN File") { //If path is a file, extract DDS files from it
                Validation.CombinePrompt(ref combine); //Ask if you want to combine exported images
                Bin.Extract(validPath, combine);
                Console.WriteLine("Extraction succeeded! Press any key to exit.");
                Console.ReadKey();
            }
            else if (pathType == "BIN Directory")
            {
                Validation.CombinePrompt(ref combine); //Ask if you want to combine exported images
                foreach (string binFile in Directory.GetFiles(@validPath))
                {
                    Bin.Extract(binFile, combine);
                }
                Console.WriteLine("Extraction succeeded! Press any key to exit.");
                Console.ReadKey();
            }
            else if (pathType == "DDS Directory") {
                Bin.Create(validPath);
                Console.WriteLine("BIN created! Press any key to exit.");
                Console.ReadKey();
            }
            else
            {
                Console.WriteLine("No valid files or directories found!");
                Console.ReadKey();
            } 

        }
    }
}
