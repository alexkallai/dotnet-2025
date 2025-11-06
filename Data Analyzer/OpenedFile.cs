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
            int rX = Math.Max( (int)ratioX, 1);
            int rY = Math.Max((int)ratioY, 1);

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
    public class Greens : IColormap
    {
        public string Name => "Greens";

        private readonly CustomPalette Colormap;

        public Color GetColor(double position) => Colormap.GetColor(position);

        public Greens()
        {
            int[] rgbColors =
            {
            -16761088, -16760832, -16760575, -16760318, -16760061, -16759804, -16759547, -16759290,
            -16759033, -16758776, -16758519, -16758006, -16757749, -16757492, -16757235, -16756979,
            -16756722, -16756465, -16756208, -16755951, -16755694, -16755437, -16755180, -16754667,
            -16754410, -16688617, -16688360, -16688104, -16687847, -16687590, -16687333, -16687076,
            -16621283, -16621026, -16620769, -16620512, -16620256, -16554463, -16554206, -16553949,
            -16553692, -16487899, -16487642, -16487385, -16421336, -16421080, -16420823, -16355030,
            -16354773, -16288980, -16288723, -16222930, -16222930, -16222673, -16156880, -16156623,
            -16090830, -16025038, -16024781, -15958988, -15958731, -15892938, -15827145, -15826889,
            -15761096, -15695303, -15695046, -15629254, -15563461, -15497924, -15497667, -15431875,
            -15366082, -15300289, -15234496, -15234240, -15168447, -15102654, -15037118, -14971325,
            -14905532, -14839740, -14773947, -14708154, -14642618, -14576825, -14511033, -14445240,
            -14379447, -14313655, -14248118, -14182326, -14116533, -14050741, -13985204, -13919412,
            -13853619, -13722291, -13656498, -13590962, -13525169, -13459377, -13328048, -13262512,
            -13196720, -13130927, -13065391, -12934063, -12868270, -12802478, -12671406, -12605613,
            -12539821, -12408749, -12342957, -12277164, -12146092, -12080300, -12014508, -11883435,
            -11817643, -11686315, -11620779, -11554986, -11423914, -11358122, -11226794, -11161258,
            -11029929, -10964137, -10833065, -10767273, -10636201, -10570408, -10439080, -10373544,
            -10242216, -10176680, -10045351, -09914023, -09848487, -09717159, -09651623, -09520294,
            -09389222, -09323430, -09192102, -09061029, -08995237, -08864165, -08798372, -08667300,
            -08535972, -08404643, -08339107, -08207779, -08076706, -08010914, -07879842, -07748513,
            -07682977, -07551648, -07420576, -07289248, -07223711, -07092383, -06961054, -06895518,
            -06764189, -06633116, -06501788, -06436251, -06304923, -06173850, -06108057, -05976984,
            -05845656, -05714583, -05648790, -05517717, -05386389, -05320596, -05189523, -05123730,
            -04992657, -04861328, -04795791, -04664462, -04598925, -04467596, -04336523, -04270730,
            -04139400, -04073863, -03942534, -03876997, -03745667, -03680130, -03614337, -03483007,
            -03417470, -03286140, -03220603, -03154809, -03023479, -02957942, -02892148, -02826610,
            -02760817, -02629487, -02563949, -02498155, -02432617, -02366823, -02301029, -02235491,
            -02169697, -02103903, -02038365, -01972571, -01906777, -01841239, -01775444, -01709650,
            -01644112, -01578318, -01512523, -01446985, -01381191, -01315396, -01249858, -01249599,
            -01183805, -01118266, -01052472, -00986678, -00986675, -00920880, -00855086, -00789547,
            -00723753, -00723494, -00657956, -00592161, -00526367, -00526108, -00460569, -00394775,
            -00394516, -00328977, -00263183, -00197388, -00197385, -00131591, -00065796, -00000001,
        };

            // Reverse the array
            Array.Reverse(rgbColors);

            // Set the first colour to black
            rgbColors[0] = -16777216; // ARGB for black (0xFF000000)

            // Convert the reversed and modified array to Color[]
            Color[] colors = rgbColors.Select(Color.FromARGB).ToArray();

            // Create the custom palette
            Colormap = new CustomPalette(colors);
        }
    }



}
