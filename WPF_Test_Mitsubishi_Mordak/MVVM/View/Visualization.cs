using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media;
using System.Linq;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;

namespace WPF_Test_Mitsubishi_Mordak.MVVM.ViewModel
{
    public class Visualization
    {
        public void DrawVisualization(Canvas canvas, int[] height, int[] left_max, int[] right_max)
        {
            canvas.Children.Clear();
            if (height == null || height.Length == 0)
            {  
              return; 
            }

            double barWidth = canvas.ActualWidth / height.Length;
            double maxHeight = height.Max();

            for (int i = 0; i < height.Length; i++)
            {
                double barHeight = (height[i] / maxHeight) * canvas.ActualHeight;
                Rectangle bar = new Rectangle
                {
                    Width = barWidth - 2,
                    Height = barHeight,
                    Fill = Brushes.Gray,
                    Stroke = Brushes.Black,
                    StrokeThickness = 1
                };

                Canvas.SetLeft(bar, i * barWidth);
                Canvas.SetTop(bar, canvas.ActualHeight - barHeight);
                canvas.Children.Add(bar);

                if (height[i] < Math.Min(left_max[i], right_max[i]))
                {
                    double waterHeight = ((Math.Min(left_max[i], right_max[i]) - height[i]) / maxHeight) * canvas.ActualHeight;
                    Rectangle water = new Rectangle
                    {
                        Width = barWidth - 2,
                        Height = waterHeight,
                        Fill = Brushes.Blue,
                        Opacity = 0.5
                    };
                    Canvas.SetLeft(water, i * barWidth);
                    Canvas.SetTop(water, canvas.ActualHeight - barHeight - waterHeight);
                    canvas.Children.Add(water);
                }
            }
        }
    }
}
