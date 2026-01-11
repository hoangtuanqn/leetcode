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
            Video: https://youtu.be/SLBYeRsKu9A
     */
    internal class _001_TwoSum
    {
        public int[] TwoSum(int[] nums, int target)
        {
            var map = new Dictionary<int, int>();
            for (int i = 0; i < nums.Length; i++)
            {
                var subtraction = target - nums[i];
                if (map.ContainsKey(subtraction))
                {
                    return [map[i], i];
                }
                else
                {
                    map[nums[i]] = i;
                }

            }
            return [];
        }
    }
}
