using HelixToolkit.Wpf;
using Microsoft.Win32;
using OpenTK.Mathematics;
using ScottPlot;
using ScottPlot.Panels;
using ScottPlot.WPF;
using System.Diagnostics;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Media3D;

namespace Data_Analyzer
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private static OpenedFile openedFile;
        private static ColorBar digraphColorbar;
        private static ColorBar hilbertColorbar;
        private static double[] secondArr;
        public MainWindow()
        {
            InitializeComponent();
            Loaded += MainWindow_Loaded;
            FirstRangeSlider.PreviewMouseLeftButtonUp += FirstRangeSlider_MouseUp;
            SecondRangeSlider.PreviewMouseLeftButtonUp += SecondRangeSlider_MouseUp;
            PlotLeft1.Plot.Layout.Frameless();
            PlotLeft2.Plot.Layout.Frameless();

        }

        private void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {

        }


        private void btnOpenFile_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            if (openFileDialog.ShowDialog() == true)
            {
                string filePath = openFileDialog.FileName;
                Trace.WriteLine(filePath + " opened");
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
            // SELECTION PLOT 1
            // the sliders are inverted in logic
            double max1 = FirstRangeSlider.Maximum;
            double invLow1 = (max1 - FirstRangeSlider.HigherValue) / max1;
            double invHigh1 = (max1 - FirstRangeSlider.LowerValue) / max1;

            int firstByteRangeStart = (int)(OpenedFile.fileDoubleBytes.Length * invLow1);
            int firstByteRangeEnd = (int)(OpenedFile.fileDoubleBytes.Length * invHigh1);

            var firstRange = OpenedFile.fileDoubleBytes.AsMemory(firstByteRangeStart, firstByteRangeEnd - firstByteRangeStart);
            PlotLeft1.Plot.Clear();
            ScottPlot.Plottables.Heatmap heatMapSel1 = PlotLeft1.Plot.Add.Heatmap(OpenedFile.GetWrappedByteData(firstRange.Span.ToArray(), PlotLeft1.Height, PlotLeft1.Width));
            //heatMapSel1.Colormap = usedColormap;
            RefreshPlot(PlotLeft1);


            // SELECTION PLOT 1
            // the sliders are inverted in logic
            double max2 = SecondRangeSlider.Maximum;
            double invLow2 = (max2 - SecondRangeSlider.HigherValue) / max2;
            double invHigh2 = (max2 - SecondRangeSlider.LowerValue) / max2;

            int secondByteRangeStart = (int)(firstRange.Length * invLow2);
            int secondByteRangeEnd = (int)(firstRange.Length * invHigh2);

            var firstArr = firstRange.Span.ToArray();
            secondArr = firstArr[secondByteRangeStart..secondByteRangeEnd];

            PlotLeft2.Plot.Clear();
            ScottPlot.Plottables.Heatmap heatMapSel2 = PlotLeft2.Plot.Add.Heatmap(OpenedFile.GetWrappedByteData(secondArr, PlotLeft2.Height, PlotLeft2.Width));
            //heatMapSel1.Colormap = usedColormap;
            RefreshPlot(PlotLeft2);

            PlotTabA.Plot.Clear();
            try
            {
                PlotTabA.Plot.Remove(digraphColorbar);
            }
            catch { }

            // DIGRAPH
            var heatmap = PlotTabA.Plot.Add.Heatmap(OpenedFile.GetDigraph(secondArr.ToArray()));
            heatmap.Colormap = new ScottPlot.Colormaps.Greens();
            digraphColorbar = PlotTabA.Plot.Add.ColorBar(heatmap);
            PlotTabA.Plot.Axes.AutoScale();
            PlotTabA.Refresh();

            // HISTOGRAM
            PlotTabB.Plot.Clear();
            var hist = ScottPlot.Statistics.Histogram.WithBinCount(256, 0, 256);
            var histPlot = PlotTabB.Plot.Add.Histogram(hist);
            histPlot.BarWidthFraction = 0.8;
            hist.AddRange(secondArr);
            PlotTabB.Plot.Axes.AutoScale();
            PlotTabB.Refresh();

            // 2D Hilbert
            PlotTabC.Plot.Clear();
            try
            {
                PlotTabC.Plot.Remove(hilbertColorbar);
            }
            catch { }
            var heatmapHilbert = PlotTabC.Plot.Add.Heatmap(HilbertArray.To2D(secondArr.ToArray(), 0.0));
            heatmapHilbert.Colormap = new ScottPlot.Colormaps.Greens();
            hilbertColorbar = PlotTabC.Plot.Add.ColorBar(heatmapHilbert);
            PlotTabC.Plot.Axes.AutoScale();
            PlotTabC.Refresh();

            //ShowHilbert3D(secondArr.ToArray(), 0.0);
        }


        // Slider mouse up hook methods
        private void FirstRangeSlider_MouseUp(object sender, MouseButtonEventArgs e)
        {
            double lo = FirstRangeSlider.LowerValue;
            double hi = FirstRangeSlider.HigherValue;
            Trace.WriteLine($"Finished: {lo} - {hi}");
            startProcessPipeline();
        }

        private void SecondRangeSlider_MouseUp(object sender, MouseButtonEventArgs e)
        {
            double lo = FirstRangeSlider.LowerValue;
            double hi = FirstRangeSlider.HigherValue;
            Trace.WriteLine($"Finished: {lo} - {hi}");
            startProcessPipeline();
        }

        private void TabControl_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (Tab1.IsSelected)
            {
                Trace.WriteLine("Tab1 selected");
            }
            if (Tab2.IsSelected)
            {
                Trace.WriteLine("Tab2 selected");
            }
            if (Tab3.IsSelected)
            {
                Trace.WriteLine("Tab3 selected");
            }
            if (Tab4.IsSelected && OpenedFile.initialized)
            {
                Trace.WriteLine("Tab4 selected");
                ShowHilbert3D(secondArr.ToArray(), 0.0);
            }

        }
        public void ShowHilbert3D(double[] data, double pad = 0)
        {
            var grid = HilbertArray.To3D(data, pad);
            int n = grid.GetLength(0);

            // value range for color mapping
            double min = data.Min();
            double max = data.Max();
            double range = Math.Max(1e-12, max - min);

            // simple gradient buckets
            int buckets = 8;                     // increase for smoother colors
            var visuals = new PointsVisual3D[buckets];
            var pts = new Point3DCollection[buckets];

            for (int b = 0; b < buckets; b++)
            {
                pts[b] = new Point3DCollection();
                visuals[b] = new PointsVisual3D
                {
                    Size = 3,
                    Color = ColorFromBucket(b, buckets)
                };
            }

            // assign each Hilbert point to a bucket
            for (int x = 0; x < n; x++)
                for (int y = 0; y < n; y++)
                    for (int z = 0; z < n; z++)
                    {
                        double v = grid[x, y, z];
                        double t = (v - min) / range;         // 0..1
                        int bucket = Math.Min(buckets - 1, (int)(t * buckets));
                        pts[bucket].Add(new Point3D(x, y, z));
                    }

            // add visuals to scene
            PointGroups.Children.Clear();
            for (int b = 0; b < buckets; b++)
            {
                visuals[b].Points = pts[b];
                PointGroups.Children.Add(visuals[b]);
            }

            Viewport.ZoomExtents();
        }

        // Simple color palette
        private System.Windows.Media.Color ColorFromBucket(int index, int total)
        {
            double t = (double)index / (total - 1); // 0..1
            byte r = (byte)(255 * t);
            byte g = (byte)(255 * (1 - t));
            byte b = (byte)(128 + 127 * Math.Sin(t * Math.PI));
            return System.Windows.Media.Color.FromRgb(r, g, b);
        }

    }
}