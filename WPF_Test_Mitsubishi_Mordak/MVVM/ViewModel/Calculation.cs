using System;

namespace WPF_Test_Mitsubishi_Mordak.MVVM.Model
{
    public class Calculation
    {
        public int Trap(int[] height, out int[] left_max, out int[] right_max)
        {
            left_max = new int[height.Length];
            right_max = new int[height.Length];

            if (height == null || height.Length == 0)
                return 0;

            int n = height.Length;

            left_max[0] = height[0];
            for (int i = 1; i < n; i++)
            {
                left_max[i] = Math.Max(left_max[i - 1], height[i]);
            }

            right_max[n - 1] = height[n - 1];
            for (int i = n - 2; i >= 0; i--)
            {
                right_max[i] = Math.Max(right_max[i + 1], height[i]);
            }

            int water_cubes = 0;
            for (int i = 0; i < n; i++)
            {
                water_cubes += Math.Min(left_max[i], right_max[i]) - height[i];
            }

            return water_cubes;
        }
    }
}
