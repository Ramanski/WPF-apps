using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using Microsoft.Win32;
using System.Windows.Forms;
using System.Windows.Media;
using System.Windows.Shapes;
using System.Collections.ObjectModel;

namespace Graphic_editor
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Microsoft.Win32.OpenFileDialog openFD;
        Microsoft.Win32.SaveFileDialog saveFD;
        RhombSettings rhombSet= new RhombSettings();
        ObservableCollection <RhombSettings> arrayList = new ObservableCollection<RhombSettings>();
        ColorDialog ColDialFon;
        const string pathDir = "C:\\Users\\Dondan\\source\\repos\\WPF-apps\\Graphic editor\\";

        public MainWindow()
        {
            InitializeComponent();
            BuFon.Background = new SolidColorBrush(Color.FromRgb(rhombSet.fillColor[0], rhombSet.fillColor[1],rhombSet.fillColor[2]));
            BuStoke.Background = new SolidColorBrush(Color.FromRgb(rhombSet.outerColor[0], rhombSet.outerColor[1], rhombSet.outerColor[2]));
        }

        //Returns the rhomb as a figure based on current rhomb settings
        public Polygon createRhomb(RhombSettings rhombSet)
        {
            Polygon polygon = new Polygon();
            polygon.Stroke = new SolidColorBrush(Color.FromRgb(rhombSet.outerColor[0], rhombSet.outerColor[1], rhombSet.outerColor[2]));
            polygon.Fill = new SolidColorBrush(Color.FromRgb(rhombSet.fillColor[0], rhombSet.fillColor[1], rhombSet.fillColor[2]));
            polygon.StrokeThickness = rhombSet.thickness;
            //Collection of points for a polygon
            Point pointLeft = new Point(0, RhombSettings.height * rhombSet.scale);
            Point pointTop = new Point(RhombSettings.width * rhombSet.scale, 0 * rhombSet.scale);
            Point pointRight = new Point(2 * RhombSettings.width * rhombSet.scale, RhombSettings.height * rhombSet.scale);
            Point pointBottom = new Point(RhombSettings.width * rhombSet.scale, 2 * RhombSettings.height * rhombSet.scale);
            PointCollection rhombPoints = new PointCollection();
            rhombPoints.Add(pointLeft);
            rhombPoints.Add(pointTop);
            rhombPoints.Add(pointRight);
            rhombPoints.Add(pointBottom);
            polygon.Points = rhombPoints;
            return polygon;
        }

        private void Canvas_MouseLeftButtonDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            Polygon rhomb = createRhomb(rhombSet);
            Point p = e.GetPosition(canvas);
            rhombSet.x = p.X - RhombSettings.width*rhombSet.scale;
            rhombSet.y = p.Y - RhombSettings.height*rhombSet.scale;
            canvas.Children.Add(rhomb);
            Canvas.SetLeft(rhomb, rhombSet.x);
            Canvas.SetTop(rhomb, rhombSet.y);
            arrayList.Add((RhombSettings)rhombSet.Clone());
        }

        private void Canvas_MouseMove(object sender, System.Windows.Input.MouseEventArgs e)
        {
            Point p = e.GetPosition(canvas);
            status.Content = $"X:{p.X.ToString()} Y:{p.Y.ToString()}";
        }

        private void CommandBinding_Executed_Open(object sender, System.Windows.Input.ExecutedRoutedEventArgs e)
        {
            openFD = new Microsoft.Win32.OpenFileDialog();
            openFD.InitialDirectory = pathDir;
            openFD.Filter = "Project file (*.dat)|*.dat|All files (*.*)|*.*";
            openFD.CheckFileExists = true;
            openFD.Multiselect = false;
            openFD.ShowDialog();
            canvas.Children.Clear();
            mainWindow.Title = openFD.SafeFileName;
            BinaryFormatter formatter = new BinaryFormatter();
            using (FileStream fs = new FileStream(openFD.FileName, FileMode.Open))
            {
                ObservableCollection<RhombSettings> deserlist = (ObservableCollection<RhombSettings>)formatter.Deserialize(fs);
                foreach (RhombSettings deserRhombSet in deserlist)
                {
                    Polygon rhomb = createRhomb(deserRhombSet);
                    canvas.Children.Add(rhomb);
                    Canvas.SetLeft(rhomb, deserRhombSet.x);
                    Canvas.SetTop(rhomb, deserRhombSet.y);
                    arrayList.Add(rhombSet);
                    }
                System.Windows.MessageBox.Show("Deserialization completed");
            }
        }

        private void CommandBinding_Executed_New(object sender, System.Windows.Input.ExecutedRoutedEventArgs e)
        {
            canvas.Children.Clear();
            arrayList.Clear();
            mainWindow.Title = "New masterpiece";
        }

        private void MenuItem_Background(object sender, RoutedEventArgs e)
        {
            ColDialFon = new ColorDialog();
            ColDialFon.FullOpen = true;
            ColDialFon.ShowDialog();

            var Line = (ColDialFon.Color);
            rhombSet.fillColor[0] = Line.R;
            rhombSet.fillColor[1] = Line.G;
            rhombSet.fillColor[2] = Line.B;
            BuFon.Background = new SolidColorBrush(Color.FromRgb(rhombSet.fillColor[0], rhombSet.fillColor[1], rhombSet.fillColor[2]));
        }

        private void MenuItem_Stroke(object sender, RoutedEventArgs e)
        {
            ColDialFon = new ColorDialog();
            ColDialFon.FullOpen = true;
            ColDialFon.ShowDialog();

            var Line = (ColDialFon.Color);
            rhombSet.outerColor[0] = Line.R;
            rhombSet.outerColor[1] = Line.G;
            rhombSet.outerColor[2] = Line.B;
            BuStoke.Background = new SolidColorBrush(Color.FromRgb(rhombSet.outerColor[0], rhombSet.outerColor[1], rhombSet.outerColor[2]));
        }

        private void slThickness_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            rhombSet.thickness = slThickness.Value;
        }

        private void slSize_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            rhombSet.scale = slSize.Value;
        }

        private void CommandBinding_Executed_Close(object sender, System.Windows.Input.ExecutedRoutedEventArgs e)
        {
            App.Current.Shutdown();
        }

        private void CommandBinding_Executed_Save(object sender, System.Windows.Input.ExecutedRoutedEventArgs e)
        {
            saveFD = new Microsoft.Win32.SaveFileDialog();
            saveFD.InitialDirectory = pathDir;
            saveFD.Filter = "Project file (*.dat)|*.dat|All files (*.*)|*.*";
            saveFD.OverwritePrompt = true;
            saveFD.Title = "Where shall we save your masterpiece?";
            saveFD.ShowDialog();
            mainWindow.Title = saveFD.SafeFileName;
            BinaryFormatter formatter = new BinaryFormatter();
            using (FileStream fs = new FileStream(saveFD.FileName, FileMode.Create))
            {
                formatter.Serialize(fs, arrayList);
                System.Windows.MessageBox.Show($"Serialization of {arrayList.Count} objects completed.");
            }
        }

        private void BuFon_MouseEnter(object sender, System.Windows.Input.MouseEventArgs e)
        {
            BuFon.Background = new SolidColorBrush(Color.FromRgb(rhombSet.fillColor[0], rhombSet.fillColor[1], rhombSet.fillColor[2]));
            BuStoke.Background = new SolidColorBrush(Color.FromRgb(rhombSet.outerColor[0], rhombSet.outerColor[1], rhombSet.outerColor[2]));
        }

        private void MainWindow_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (canvas.Children.Count > 0)
                switch (System.Windows.MessageBox.Show("Do you want to save your work?", "Save Dialog", MessageBoxButton.YesNoCancel))
                {
                    case MessageBoxResult.Yes:
                        CommandBinding_Executed_Save(mainWindow, null);
                        break;
                    case MessageBoxResult.No:
                        App.Current.Shutdown();
                        break;
                    case MessageBoxResult.Cancel:
                        e.Cancel = true;
                        break;
                }
            else e.Cancel = false;
        }
    }

    
}
