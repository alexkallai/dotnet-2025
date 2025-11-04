using Microsoft.Win32;
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


        private void startProcessPipeline()
        {
            Console.WriteLine(FirstRangeSlider.LowerValue);
            Console.WriteLine(FirstRangeSlider.HigherValue);
            double firstRangeMin = FirstRangeSlider.Minimum;
            double firstRangeMax = FirstRangeSlider.Maximum;
            int firstByteRangeStart = Convert.ToInt32(OpenedFile.fileBytesLength * (FirstRangeSlider.LowerValue / FirstRangeSlider.Maximum));
            int firstByteRangeEnd = Convert.ToInt32(OpenedFile.fileBytesLength * (FirstRangeSlider.HigherValue / FirstRangeSlider.Maximum));
            int secondByteRangeStart = Convert.ToInt32(OpenedFile.fileBytesLength * (SecondRangeSlider.LowerValue / SecondRangeSlider.Maximum));
            int secondByteRangeEnd = Convert.ToInt32(OpenedFile.fileBytesLength * (SecondRangeSlider.HigherValue / SecondRangeSlider.Maximum));

            ScottPlot.Plottables.Heatmap leftheatmap = PlotLeft1.Plot.Add.Heatmap(OpenedFile.GetWrappedByteData(OpenedFile.GetRange(firstByteRangeStart, firstByteRangeEnd), PlotLeft1.Height, PlotLeft1.Width));
            PlotLeft1.Plot.Axes.AutoScale();
            PlotLeft1.Refresh();



            PlotTabA.Plot.Add.Heatmap(OpenedFile.digraph);
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