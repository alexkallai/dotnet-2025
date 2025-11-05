using Microsoft.Win32;
using ScottPlot.WPF;
using System.Windows;
using System.Windows.Input;

namespace Data_Analyzer
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private static OpenedFile openedFile;
        public MainWindow()
        {
            InitializeComponent();
            FirstRangeSlider.PreviewMouseLeftButtonUp += FirstRangeSlider_MouseUp;
            SecondRangeSlider.PreviewMouseLeftButtonUp += SecondRangeSlider_MouseUp;

        }
        private void btnOpenFile_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            if (openFileDialog.ShowDialog() == true)
            {
                string filePath = openFileDialog.FileName;
                Console.WriteLine(filePath + "opened");
                openedFile = new OpenedFile(filePath);
                startProcessPipeline();


            }

        }

        private void RefreshPlot(WpfPlot plot)
        {
            plot.Plot.Axes.AutoScale();
            plot.Refresh();
        }


        private void startProcessPipeline()
        {
            Console.WriteLine(FirstRangeSlider.LowerValue);
            Console.WriteLine(FirstRangeSlider.HigherValue);
            double firstRangeMin = FirstRangeSlider.Minimum;
            double firstRangeMax = FirstRangeSlider.Maximum;
            int firstByteRangeStart = Convert.ToInt32(OpenedFile.fileDoubleBytes.Length * (FirstRangeSlider.LowerValue / FirstRangeSlider.Maximum));
            int firstByteRangeEnd = Convert.ToInt32(OpenedFile.fileDoubleBytes.Length * (FirstRangeSlider.HigherValue / FirstRangeSlider.Maximum));

            ReadOnlyMemory<double> firstRange = OpenedFile.fileDoubleBytes.AsMemory(firstByteRangeStart, firstByteRangeEnd - firstByteRangeStart);
            //ReadOnlyMemory<byte> firstRange = OpenedFile.GetRange(OpenedFile.fileBytes, firstByteRangeStart, firstByteRangeEnd);
            PlotLeft1.Plot.Clear();
            PlotLeft1.Plot.Add.Heatmap(OpenedFile.GetWrappedByteData(firstRange.ToArray(), PlotLeft1.Height, PlotLeft1.Width));
            RefreshPlot(PlotLeft1);

            int secondByteRangeStart = Convert.ToInt32(firstRange.Length * (SecondRangeSlider.LowerValue / SecondRangeSlider.Maximum));
            int secondByteRangeEnd = Convert.ToInt32(firstRange.Length * (SecondRangeSlider.HigherValue / SecondRangeSlider.Maximum));
            ReadOnlyMemory<double> secondRange = firstRange.ToArray()[secondByteRangeStart..secondByteRangeEnd];

            PlotLeft2.Plot.Clear();
            PlotLeft2.Plot.Add.Heatmap(OpenedFile.GetWrappedByteData(secondRange, PlotLeft2.Height, PlotLeft2.Width));
            RefreshPlot(PlotLeft2);



            PlotTabA.Plot.Add.Heatmap(OpenedFile.GetDigraph(secondRange));
            PlotTabA.Plot.Axes.AutoScale();
            PlotTabA.Refresh();


        }

        // Slider mouse up hook methods
        private void FirstRangeSlider_MouseUp(object sender, MouseButtonEventArgs e)
        {
            double lo = FirstRangeSlider.LowerValue;
            double hi = FirstRangeSlider.HigherValue;
            Console.WriteLine($"Finished: {lo} - {hi}");
            startProcessPipeline();
        }

        private void SecondRangeSlider_MouseUp(object sender, MouseButtonEventArgs e)
        {
            double lo = FirstRangeSlider.LowerValue;
            double hi = FirstRangeSlider.HigherValue;
            Console.WriteLine($"Finished: {lo} - {hi}");
            startProcessPipeline();
        }

    }
}