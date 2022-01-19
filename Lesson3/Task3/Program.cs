using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Task3 {
    class Program {
        static public void SearchMail(ref string s) {
            int n = s.IndexOf('&');
            if (n < 0) { s = null; return; }
            n++; while (s[n] == ' ') n++;
            s = s.Substring(n);
        }
        static void Main(string[] args) {
            string[] str = File.ReadAllLines("sample.txt");
            for (int i = 0; i < str.Length; i++) {
                Console.Write(str[i]);
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.Write(" -> ");
                SearchMail(ref str[i]);
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine(str[i]);
                Console.ForegroundColor = ConsoleColor.Gray;
            }
            File.WriteAllLines("output.txt",str);
            Console.WriteLine(); Console.Write("Press any key to continue..."); Console.ReadKey(true);
        }
    }
}
