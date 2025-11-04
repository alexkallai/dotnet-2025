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
        public static int fileBytesLength;
        public static double[,] digraph = new double[256, 256];

        public OpenedFile(string filePath)
        {
            OpenedFile.filePath = filePath;
            fileName = Path.GetFileName(filePath);
            fileBytes = File.ReadAllBytes(OpenedFile.filePath);
            fileBytesLength = fileBytes.Length;
            digraph = GetDigraph();
        }

        public static double[,] GetDigraph()
        {
            double[,] workDigraph = new double[256, 256];
            for (int i = 0; i < fileBytes.GetLength(0) - 1; i++)
            {
                int first = Convert.ToInt32(fileBytes[i]);
                int second = Convert.ToInt32(fileBytes[i + 1]);
                workDigraph[first,second] += 1;
                
            }
            return workDigraph;
            
        }

        public static byte[] GetFirstRange(int start, int end)
        {
                return fileBytes[start..end];
        }

        public static ReadOnlyMemory<byte> GetRange(int start, int end)
        {
            return fileBytes.AsMemory(start, end - start);
        }

        public static double[,] GetWrappedByteData(ReadOnlyMemory<byte> byteRange, double ratioX, double ratioY)
        {
            var span = byteRange.Span;
            int rX = (int)ratioX;
            int rY = (int)ratioY;

            // reduce ratio
            int g = Gcd(rX, rY);
            rX /= g;
            rY /= g;

            int length = span.Length;

            // number of ratio blocks needed
            int blocks = (int)Math.Ceiling(length / (double)(rX * rY));

            // k so that width = rX*k, height = rY*k
            int k = (int)Math.Ceiling(Math.Sqrt(blocks));

            int width = rX * k;
            int height = rY * k;

            var result = new double[height, width];

            // fill existing bytes
            for (int i = 0; i < length; i++)
            {
                int y = i / width;
                int x = i % width;
                result[y, x] = span[i];
            }

            // padding already 0.0 for doubles
            return result;
        }

        private static int Gcd(int a, int b) => b == 0 ? a : Gcd(b, a % b);



    }
}
