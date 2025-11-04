using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data_Analyzer
{
    class OpenedFile
    {
        public static string filePath { get; set; }
        public static string fileName { get; set; }
        public static byte[] fileBytes;
        public static ulong[,] digraph = new ulong[256, 256];

        public OpenedFile(string filePath)
        {
            OpenedFile.filePath = filePath;
            fileName = Path.GetFileName(filePath);
            fileBytes = File.ReadAllBytes(OpenedFile.filePath);
            GenerateDigraph();
        }

        public static void GenerateDigraph()
        {
            for (int i = 0; i < fileBytes.GetLength(0) - 1; i++)
            {
                int first = Convert.ToInt32(fileBytes[i]);
                int second = Convert.ToInt32(fileBytes[i + 1]);
                digraph[first,second] += 1;
                
            }
            
        }

    }
}
