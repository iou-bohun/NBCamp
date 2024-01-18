using System.Globalization;
using System.Numerics;

namespace Baek
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Solution solution = new Solution();
            string o = solution.solution("awogjsdf");
            Console.WriteLine(o);
        } 
    }
    public class Solution
    {
        public string solution(string s)
        {
            string answer = "";
            foreach(var item in s.ToCharArray().OrderByDescending(x=>x))
            {
                Console.WriteLine(item);
            }
            return answer;
        }
    }
}
