using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C_2._0
{
    internal class HW6
    {
        public List<string> FindNumbers(int[] nums, int number)
        {
            Array.Sort(nums);
            List<string> result = new List<string>();
            for (int i = 0; i < nums.Length - 2; i++)
            {
                int left = i + 1;
                int right = nums.Length - 1;
                while (left < right)
                {
                    int sum = nums[left] + nums[i] + nums[right];
                    if (sum == number)
                    {
                        result.Add($"{nums[left]} {nums[i]} {nums[right]}");
                        left++;
                        right--;
                    }
                    else if (sum < number)
                    {
                        left++;
                    }
                    else
                    {
                        right--;
                    }
                }
            }
            return result;
        }
    }
}
