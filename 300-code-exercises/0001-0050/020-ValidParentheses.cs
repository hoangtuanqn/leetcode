using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _300_code_exercises._0001_0050
{
    internal class _020_ValidParentheses
    {
        /*
            Solution: Using stack
            Video: ...
         */
        public bool IsValid(string s)
        {
            var isValid = true;
            Stack<char> stack = new Stack<char>();
            foreach (var item in s)
            {
                if (!isValid) break;
             
                if (item == '}' || item == ')' || item == ']')
                {
                    if (stack.TryPop(out var result))
                    {
                        isValid = result switch
                        {
                            '{' => item == '}',
                            '[' => item == ']',
                            '(' => item == ')',
                            _ => false
                        };
                    }
                    else
                    {
                        isValid = false;
                    }
                }
                else
                {
                    stack.Push(item);
                }

            }

            return isValid && stack.Count == 0;
        }

    }
}
