using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DDS2Tool
{
    public class Validation
    {
        public static string Path(string[] args)
        {
            string suppliedPath = "";
            bool validPath = false;

            do
            {
                if (args.Length != 0)
                {
                    suppliedPath = args[0];
                }
                else
                {
                    Console.Write("Please enter a path: ");
                    suppliedPath = Console.ReadLine();
                }

                if (suppliedPath.Length > 0)
                {
                    validPath = true;
                }
                else
                {
                    Console.Clear();
                    Console.Write("Please enter a path: ");
                    suppliedPath = Console.ReadLine();
                }
            } while (validPath == false);
            return suppliedPath;
        }

        public static string Type(string validPath)
        {
            // get the file attributes for file or directory
            FileAttributes pathAttributes = File.GetAttributes(@validPath);

            //detect whether its a directory or file
            if (File.Exists(validPath))
                return "BIN File";
            else if (Directory.Exists(validPath) && Directory.GetFiles(validPath, "*.bin").Length != 0 || Directory.GetFiles(validPath, "*.BIN").Length != 0) 
                return "BIN Directory";
            else if (Directory.Exists(validPath) && Directory.GetFiles(validPath, "*.dds").Length != 0 || Directory.GetFiles(validPath, "*.DDS").Length != 0)
                return "DDS Directory";
            else
            {
                return "";
            }
        }

        public static bool CombinePrompt(ref bool combine)
        {
            bool validationLoop = true;
            while (validationLoop == true)
            {
                Console.WriteLine("Would you like to combine the extracted DDS files into single PNGs? (y/n): ");
                string input = Console.ReadLine().ToUpper();
                if (input == "Y")
                {
                    validationLoop = false;
                    combine = true;
                }
                else if (input == "N")
                validationLoop = false;
            }
            return combine;
        }
    }
}
