using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodingTEST
{
    class Program
    {
        static void Main(string[] args)
        {
            int test = solution(5, "1A 2H 3E 4D 4G");
        }
        public static int solution(int N, string S)
        {
            int maxFamilies = 0;
            string[] reservedSeats;
            List<string> rowReserved = new List<string>();
            reservedSeats = S.Split();

            for (int i = 1; i <= N; i++)
            {
                rowReserved = reservedSeats.Where(x => x.Contains(i.ToString())).ToList();
                maxFamilies += GetAvailableFamilySeats(rowReserved);
            }

            return maxFamilies;
        }
        public static int GetAvailableFamilySeats(List<string> rowReserved)
        {
            int possibleFamilySeats = 3;
            if (rowReserved.Where(x => x.Contains("A") || x.Contains("B") || x.Contains("C")).Count() >= 1)
            {
                possibleFamilySeats--;
            }
            if (rowReserved.Where(x => x.Contains("H") || x.Contains("J") || x.Contains("K")).Count() >= 1)
            {
                possibleFamilySeats--;
            }
            if (rowReserved.Where(x => x.Contains("E") || x.Contains("F")).Count() >= 1)
            {
                possibleFamilySeats--;
            }
            else if (rowReserved.Where(x => x.Contains("D")).Count() >= 1)
            {
                if (rowReserved.Where(x => x.Contains("G")).Count() >= 1)
                {
                    possibleFamilySeats--;
                }
                    
            }
            return possibleFamilySeats;
        }
    }
}
