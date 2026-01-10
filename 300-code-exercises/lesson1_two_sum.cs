using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _300_code_exercises
{   
    /*
        Solution:
            Sử dụng dictionary
     */
    internal class lesson1_two_sum
    {
        public int[] TwoSum(int[] nums, int target)
        {
            var map = new Dictionary<int, int>();
            for (int i = 0; i < nums.Length; i++)
            {
                var subtraction = target - nums[i];
                if (map.TryGetValue(subtraction, out var result))
                {
                    return [result, i];
                }
                if (!map.ContainsKey(nums[i]))
                {
                    map.Add(nums[i], i);
                }
            }
            return [];
        }
    }
}
