using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task2 {
    class Program {
        static string BackwardsString(string str) {
            int L = str.Length; if (L == 0) return null;
            string result_str = "";
            for (int i = 0; i < L; i++) result_str += str[L - i - 1];
            return result_str;
        }
        static void Main(string[] args) {
            Console.Write("Enter string to write backwards :> ");
            Console.WriteLine("Result: " + BackwardsString(Console.ReadLine()));
            Console.WriteLine(); Console.Write("Press any key to continue..."); Console.ReadKey(true);
        }
    }
}
