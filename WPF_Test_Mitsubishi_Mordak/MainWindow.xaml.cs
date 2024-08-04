using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Media.Media3D;
using System.Windows.Navigation;
using System.Windows.Shapes;
using WPF_Test_Mitsubishi_Mordak.MVVM.Model;
using WPF_Test_Mitsubishi_Mordak.MVVM.ViewModel;

namespace WPF_Test_Mitsubishi_Mordak
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        private Calculation calculation;
        private Visualization visualization;

        public MainWindow()
        {
            InitializeComponent();
            calculation = new Calculation();
            visualization = new Visualization();
        }

        private void CalculateWaterTrapped(object sender, RoutedEventArgs e)
        {
            try
            {
                int[] height = HeightInput.Text.Split(',').Select(int.Parse).ToArray();
                int waterTrapped = calculation.Trap(height, out int[] left_max, out int[] right_max);
                ResultText.Text = $"Water trapped: {waterTrapped} cubes";
                visualization.DrawVisualization(VisualizationCanvas, height, left_max, right_max);
            }
            catch (Exception)
            {
                ResultText.Text = "Invalid input";
            }
        }

        private void TestWithExampleData(object sender, RoutedEventArgs e)
        {
            int[] exampleData = { 0, 1, 0, 2, 1, 0, 1, 3, 2, 1, 2, 1 };
            HeightInput.Text = string.Join(",", exampleData);
            CalculateWaterTrapped(sender, e);
        }

    }

}

