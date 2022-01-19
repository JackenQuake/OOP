using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task4 {
    public class Account {
        public enum Type {
            Credit,
            Debit
        }
        private static int counter = 0;
        private int _id;
        private double _balance;
        private Type _type;

        public int id {
            get => _id;
        }
        public double balance {
            get => _balance;
            set { _balance = value; }
        }
        public Type type {
            get => _type;
            set { _type = value; }
        }
        private void Set_ID() { _id = (++counter); }
        public Account() {
            Set_ID();
            balance = 0;
            type = Account.Type.Credit;
        }
        public Account(double _value) {
            Set_ID();
            balance = _value;
            type = Account.Type.Credit;
        }
        public Account(Type _type) {
            Set_ID();
            balance = 0;
            type = _type;
        }
        public Account(double _value, Type _type) {
            Set_ID();
            balance = _value;
            type = _type;
        }
    }
    class Program {
        static void PrintSummary(Account PrintAccount) {
            Console.WriteLine("Summary account information:");
            Console.WriteLine($"Account ID: #{PrintAccount.id.ToString("d8")}");
            Console.WriteLine($"Account balance: {PrintAccount.balance.ToString("f2")}");
            Console.WriteLine($"Account type: {PrintAccount.type.ToString()}");
        }
        static void Main(string[] args) {
            Random rnd = new Random();
            var TestAccounts = new Account[rnd.Next(90) + 10];
            for (int i = 0; i < TestAccounts.Length; i++) {
                TestAccounts[i] = new Account();
                TestAccounts[i].balance = rnd.Next(1000) + rnd.Next(999) / 1000.0;
                TestAccounts[i].type = (DateTime.Now.Millisecond % 2 == 0) ? Account.Type.Credit : Account.Type.Debit;
                Console.WriteLine($"Account {i}.");
                PrintSummary(TestAccounts[i]);
                Console.WriteLine();
            }
            Console.WriteLine(); Console.Write("Press any key to continue..."); Console.ReadKey(true);
        }
    }
}
