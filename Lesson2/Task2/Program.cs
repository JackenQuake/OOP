using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task2 {
    public class Account {
        public enum Type {
            Credit,
            Debit
        }
        private static int counter = 0;
        private int ID;
        private double balance;
        private Type type;
        public void Set_ID() { ID = (++counter); }
        public void Set_Balance(double _value) { balance = _value; }
        public void Set_Type(Type _type) { type = _type; }
        public int Get_ID() => ID;
        public double Get_Balance() => balance;
        public Type Get_Type() => type;
    }
    class Program {
        static void PrintSummary(Account PrintAccount) {
            Console.WriteLine("Summary account information:");
            Console.WriteLine($"Account ID: #{PrintAccount.Get_ID().ToString("d8")}");
            Console.WriteLine($"Account balance: {PrintAccount.Get_Balance().ToString("f2")}");
            Console.WriteLine($"Account type: {PrintAccount.Get_Type().ToString()}");
        }
        static void Main(string[] args) {
            Random rnd = new Random();
            var TestAccounts = new Account[rnd.Next(90) + 10];
            for (int i = 0; i < TestAccounts.Length; i++) {
                TestAccounts[i] = new Account();
                TestAccounts[i].Set_ID();
                TestAccounts[i].Set_Balance(rnd.Next(1000) + rnd.Next(999) / 1000.0);
                if (DateTime.Now.Millisecond % 2 == 0) TestAccounts[i].Set_Type(Account.Type.Credit);
                else TestAccounts[i].Set_Type(Account.Type.Debit);
                Console.WriteLine($"Account {i}.");
                PrintSummary(TestAccounts[i]);
                Console.WriteLine();
            }
            Console.WriteLine(); Console.Write("Press any key to continue..."); Console.ReadKey(true);
        }
    }
}
