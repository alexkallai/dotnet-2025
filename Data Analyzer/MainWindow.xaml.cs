using Microsoft.Win32;
using ScottPlot;
using System.IO;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

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

        }
        private void btnOpenFile_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            if (openFileDialog.ShowDialog() == true)
            {
                string filePath = openFileDialog.FileName;
                Console.WriteLine(filePath+"opened");
                openedFile = new OpenedFile(filePath);
                startProcessPipeline();

            }
                
        }

        private void startProcessPipeline()
        {
            Console.WriteLine(FirstRangeSlider.LowerValue);
            Console.WriteLine(FirstRangeSlider.HigherValue);

            ScottPlot.Plottables.Heatmap leftheatmap = PlotLeft1.Plot.Add.Heatmap(OpenedFile.GetWrappedByteData(PlotLeft1.Height, PlotLeft1.Width));
            PlotLeft1.Plot.Axes.AutoScale();
            PlotLeft1.Refresh();



            PlotTabA.Plot.Add.Heatmap(OpenedFile.digraph);
            PlotTabA.Plot.Axes.AutoScale();
            PlotTabA.Refresh();


        }
    }
}