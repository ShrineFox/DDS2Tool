using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DDS2Tool
{
    public static class Bin
    {
        public static int ReadInt32(BinaryReader reader) //Read 32-bit value with endian shifted
        {
            return reader.ReadByte() << 24 | reader.ReadByte() << 16 | reader.ReadByte() << 8 | reader.ReadByte();
        }

        public static int ConvertInt32(int word)
        {
            byte[] bytes = BitConverter.GetBytes(word);
            if (BitConverter.IsLittleEndian)
                Array.Reverse(bytes);
            int result = BitConverter.ToInt32(bytes, 0);
            return result;
        }

        public static string ReadName(BinaryReader reader) //Read DDS filename
        {
            return Encoding.ASCII.GetString(reader.ReadBytes(32)).TrimEnd('\0');
        }

        public static void PadDdsName32(BinaryWriter writer, List<string> ddsFiles, int x)
        {
            writer.Write(Encoding.ASCII.GetBytes(Path.GetFileName(ddsFiles[x])));
            int padAmount = 32 - Path.GetFileName(ddsFiles[x]).Length;
            writer.Write(new byte[padAmount]);
        }

        public static void PadDds2Name32(BinaryWriter writer, List<string> ddsFiles, int x)
        {
            writer.Write(Encoding.ASCII.GetBytes(Path.GetFileName($"{ddsFiles[x]}2 ")));
            int padAmount = 32 - Path.GetFileName($"{ddsFiles[x]}2 ").Length;
            writer.Write(new byte[padAmount]);
        }

        public static int GetFileSize(string filePath)
        {
            FileInfo file = new FileInfo(filePath);
            int length = (int)file.Length;
            return length;
        }

        public static void Extract(string validPath, bool combine)
        {
            using (BinaryReader reader = new BinaryReader(File.Open(validPath, FileMode.Open)))
            {
                int dds2Count = Bin.ReadInt32(reader); //Count how many DDS2 files are in BIN
                string binName = Path.GetFileNameWithoutExtension(validPath);
                Directory.CreateDirectory($"{Path.GetDirectoryName(validPath)}\\{binName}");
                for (int i = dds2Count; i > 0; i--) //For each DDS2 file,
                {

                    string dds2Name = Bin.ReadName(reader); //Get filename
                    int dds2Size = Bin.ReadInt32(reader); //Get filesize
                    int dds2FileCount = Bin.ReadInt32(reader); //Get filecount
                    for (int x = dds2FileCount; x > 0; x--) //For each DDS file in DDS2,
                    {
                        string ddsName = Bin.ReadName(reader); //Get name
                        int ddsSize = Bin.ReadInt32(reader); //Get filesize
                        byte[] ddsFile = reader.ReadBytes(ddsSize); //Copy DDS file to byte array
                        try
                        {
                            using (FileStream stream = new FileStream(
                                                        $"{Path.GetDirectoryName(validPath)}\\{binName}\\{ddsName}", FileMode.Create))
                            {
                                using (BinaryWriter writer = new BinaryWriter(stream))
                                {
                                    writer.Write(ddsFile); //Put DDS file in a new DDS folder using filename from DDS2
                                }
                            }
                        }
                        catch
                        {
                            Console.WriteLine($"{binName} did not contain a DDS2 file. Skipping...");
                            break;
                        }
                    }
                    reader.ReadBytes(20);
                }
            }
            if (combine == true)
            {
                Bin.CombineExtracted(validPath);
            }
                       
        }

        public static void CombineExtracted(string binFile)
        {
            string folder = $"{Path.GetDirectoryName(binFile)}\\{Path.GetFileNameWithoutExtension(binFile)}";
            List<string> ddsFiles = new List<string>();
            foreach (string ddsFile in Directory.GetFiles(folder, "*.dds"))
                {
                ddsFiles.Add(ddsFile);
                }
                for (int i = 0; i < ddsFiles.Count; i++)
                {
                    Png.Convert(ddsFiles[i]);
                }

                List<string> pngFiles = new List<string>();
                try
                {
                    foreach (string pngFile in Directory.GetFiles($"{folder}\\Png", "*.png"))
                    {
                        pngFiles.Add(pngFile);
                    }
                    for (int i = 0; i < pngFiles.Count; i++)
                    {
                        Png.Combine(pngFiles[i + 1], pngFiles[i]);
                        i++;
                    }
                }
                catch { }
                
        }

        public static void Create(string validPath)
        {
            List<string> ddsFiles = new List<string>();
            foreach (string ddsFile in Directory.GetFiles(validPath, 
                $"{Path.GetFileName(validPath)}*.dds")) {
                ddsFiles.Add(ddsFile); //Add DDS Files to list
            }
            int dds2Count = ddsFiles.Count() / 2; //Count DDS2 Files that will be created

            using (FileStream stream = new FileStream(
                            $"{Path.GetDirectoryName(validPath)}\\{Path.GetFileName(validPath)}.bin", 
                            FileMode.Create))
            {
                using (BinaryWriter writer = new BinaryWriter(stream))
                {
                    writer.Write(Bin.ConvertInt32(dds2Count)); //Convert DDS2 file count to big endian
                    int x = 0; //DDS Count overall, used for DDS list
                    for (int i = dds2Count; i > 0; i--) //For each DDS2 file,
                    {
                        Bin.PadDds2Name32(writer, ddsFiles, x); //Write DDS2 name and add padding after
                        int ddsSize1 = Bin.GetFileSize(ddsFiles[x]);
                        int ddsSize2 = Bin.GetFileSize(ddsFiles[x + 1]);
                        int dds2Size = Bin.ConvertInt32(ddsSize1 + ddsSize2 + 96); //Add padding, fileinfo and junk data amount to total dds2 size
                        writer.Write(dds2Size); //Sets size of whole DDS2
                        writer.Write(Bin.ConvertInt32(2)); //Sets 2 as number of files inside DDS2
                        Bin.PadDdsName32(writer, ddsFiles, x); //Write first DDS name and add padding after
                        writer.Write(Bin.ConvertInt32(ddsSize1)); //Write first DDS filesize
                        byte[] firstDDS = File.ReadAllBytes(ddsFiles[x]);
                        writer.Write(firstDDS); //Write entire DDS file to BIN
                        x++;

                        Bin.PadDdsName32(writer, ddsFiles, x); //Write second DDS name and pad after
                        writer.Write(Bin.ConvertInt32(ddsSize2)); //Write second DDS filesize
                        byte[] secondDDS = File.ReadAllBytes(ddsFiles[x]);
                        writer.Write(secondDDS); //Write entire DDS file to BIN
                        x++;
                        writer.Write(new byte[20]); //Adds 20 bytes of padding between DDS2 files
                    }
                }
            }
        }

    }
}
