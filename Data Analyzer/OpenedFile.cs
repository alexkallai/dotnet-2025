using System.IO;

namespace Data_Analyzer
{
    class OpenedFile
    {
        public static string filePath { get; set; }
        public static bool initialized = false;
        public static string fileName { get; set; }
        //public static byte[] fileBytes;
        public static double[] fileDoubleBytes;
        public static int fileBytesLength;
        public static double[,] digraph = new double[256, 256];

        public OpenedFile(string filePath)
        {
            OpenedFile.filePath = filePath;
            fileName = Path.GetFileName(filePath);
            //fileBytes = File.ReadAllBytes(OpenedFile.filePath);
            // TODO add immediate conversion and null fileBytest
            fileDoubleBytes = Array.ConvertAll(File.ReadAllBytes(OpenedFile.filePath), new Converter<byte, double>(Convert.ToDouble));
            initialized = true;
            GC.Collect();
            GC.WaitForPendingFinalizers();
        }

        public static double[,] GetDigraph(ReadOnlyMemory<double> range)
        {
            var span = range.Span;
            var workDigraph = new double[256, 256];

            for (int i = 0; i < span.Length - 1; i++)
            {
                int first = (int)span[i];
                int second = (int)span[i + 1];
                workDigraph[first, second]++;
            }

            return workDigraph;
        }



        public static ReadOnlyMemory<byte> GetRange(byte[] bytes, int start, int end)
        {
            return bytes.AsMemory(start, end - start);
        }

        public static double[,] GetWrappedByteData(ReadOnlyMemory<double> doubleRange, double ratioX, double ratioY)
        {
            var span = doubleRange.Span;
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
