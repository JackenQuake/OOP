using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task3 {
    public class Account {
        public enum Type {
            Credit,
            Debit
        }
        private static int counter = 0;
        private int ID;
        private double balance;
        private Type type;
        private void Set_ID() { ID = (++counter); }
        public void Set_Balance(double _value) { balance = _value; }
        public void Set_Type(Type _type) { type = _type; }
        public int Get_ID() => ID;
        public double Get_Balance() => balance;
        public Type Get_Type() => type;
        public Account () {
            Set_ID();
            Set_Balance(0);
            Set_Type(Account.Type.Credit);
        }
        public Account(double _value) {
            Set_ID();
            Set_Balance(_value);
            Set_Type(Account.Type.Credit);
        }
        public Account(Type _type) {
            Set_ID();
            Set_Balance(0);
            Set_Type(_type);
        }
        public Account(double _value, Type _type) {
            Set_ID();
            Set_Balance(_value);
            Set_Type(_type);
        }
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
                TestAccounts[i] = new Account(rnd.Next(1000) + rnd.Next(999) / 1000.0, (DateTime.Now.Millisecond % 2 == 0) ? Account.Type.Credit : Account.Type.Debit);
                Console.WriteLine($"Account {i}.");
                PrintSummary(TestAccounts[i]);
                Console.WriteLine();
            }
            Console.WriteLine(); Console.Write("Press any key to continue..."); Console.ReadKey(true);
        }
    }
}
