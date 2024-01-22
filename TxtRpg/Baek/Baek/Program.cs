using System.Globalization;
using System.Numerics;

namespace Baek
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Solution solution = new Solution();
            int[] o = solution.solution(3,12);
            foreach (int i in o)
            {
                Console.WriteLine(i);
            }
        } 
    }
    public class Solution
    {
        public int[] solution(int n, int m)
        {
            int[] answer = new int[2];
            answer[0] = Gcd(n, m);
            answer[1] = n*m/ Gcd(n, m);
            return answer;
        }
        public int Gcd(int a, int b)
        {
            if(a%b == 0)
            {
                return b;
            }
            else
            {
                return Gcd(b, a % b);
            }
        }
    }
}
