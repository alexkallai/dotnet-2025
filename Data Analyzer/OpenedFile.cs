using ScottPlot;
using ScottPlot.Colormaps;
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

    // TODO move this to separate class
    public class SharpTurbo : IColormap
    {
        public string Name => "SharpTurbo";

        private readonly CustomPalette Colormap;

        public Color GetColor(double position) => Colormap.GetColor(position);

        public SharpTurbo()
        {
            // Define a custom ARGB array with a sharp change at the start
            uint[] argbs = new uint[256];

            // First value is black (ARGB: 0xFF000000)
            argbs[0] = 0xFF000000;

            // Second value is a distinct colour (e.g., red, ARGB: 0xFFFF0000)
            argbs[1] = 0xFFFF0000;

            // Fill the rest with a smooth gradient (e.g., Turbo colormap or any other gradient)
            for (int i = 2; i < 256; i++)
            {
                // Example: Linear gradient from red to blue
                double t = (i - 2) / 253.0; // Normalize to [0, 1] for the remaining range
                argbs[i] = InterpolateColor(0xFFFF0000, 0xFF0000FF, t); // Interpolate between red and blue
            }

            // Convert ARGB values to Color array
            Color[] colors = argbs.Select(Color.FromARGB).ToArray();

            // Create the custom palette
            Colormap = new CustomPalette(colors);
        }

        // Helper method to interpolate between two colours
        private uint InterpolateColor(uint startColor, uint endColor, double t)
        {
            byte startA = (byte)((startColor >> 24) & 0xFF);
            byte startR = (byte)((startColor >> 16) & 0xFF);
            byte startG = (byte)((startColor >> 8) & 0xFF);
            byte startB = (byte)(startColor & 0xFF);

            byte endA = (byte)((endColor >> 24) & 0xFF);
            byte endR = (byte)((endColor >> 16) & 0xFF);
            byte endG = (byte)((endColor >> 8) & 0xFF);
            byte endB = (byte)(endColor & 0xFF);

            byte a = (byte)(startA + t * (endA - startA));
            byte r = (byte)(startR + t * (endR - startR));
            byte g = (byte)(startG + t * (endG - startG));
            byte b = (byte)(startB + t * (endB - startB));

            return (uint)((a << 24) | (r << 16) | (g << 8) | b);
        }
    }

}
