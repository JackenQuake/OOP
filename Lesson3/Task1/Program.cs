using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task1 {
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
        public bool Deposit(double amount) {
            if (balance + amount < 0) {
                if (type == Type.Debit) return false;
                if (amount < 0) balance += 0.1 * ((balance > 0) ? (balance + amount) : amount);  // Bank takes 10% for using credit ;)
            }
            balance += amount;
            return true;
        }
        public bool Withdraw(double amount) { return Deposit(-amount); }
        public bool Transfer(Account source, double amount) {
            if (amount < 0) return false;
            if (!source.Withdraw(amount)) return false;
            Deposit(amount);
            return true; 
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
            int id = 0, from_id = 0;
            char ch = '0';
            double amount = 0;
            var TestAccounts = new Account[rnd.Next(90) + 10];
            for (int i = 0; i < TestAccounts.Length; i++) {
                TestAccounts[i] = new Account();
                TestAccounts[i].balance = rnd.Next(1000) + rnd.Next(999) / 1000.0;
                TestAccounts[i].type = (rnd.Next(2) == 0) ? Account.Type.Credit : Account.Type.Debit;
            }
            do {
                Console.WriteLine("Galaxy First Electronic Virtual Bank (GFEVB) *emulated. (C) 2022");
                Console.WriteLine();
                Console.WriteLine($"Now {TestAccounts.Length} accounts in Data Base for {DateTime.Now}.");
                Console.Write($"Choose account ID (1..{TestAccounts.Length}) to manage or 0 to exit :> ");
                do {
                    try {
                        id = Int32.Parse(Console.ReadLine());
                        if ((id >= 0) && (id <= TestAccounts.Length)) break;
                        Console.Write($"Input error. Enter number from 0 to {TestAccounts.Length} :> ");
                    } catch { Console.Write($"Input error. Enter number. Please try again. Enter ID or 0 to exit :> "); }
                } while (true);
                if (id == 0) break; else id--;
                Console.WriteLine();
                PrintSummary(TestAccounts[id]);
                Console.Write("(D)eposit or (W)ithdraw or (T)ransfer:> ");
                do {
                    ch = char.ToUpper(Console.ReadKey().KeyChar);
                    Console.WriteLine();
                    if ((ch == 'D') || (ch == 'W') || (ch == 'T')) break;
                    Console.Write("Input error. Press (D) or (W) or (T):> ");
                } while (true);
                if (ch == 'T') {
                    Console.Write($"Choose account ID (1..{TestAccounts.Length}) to transfer from :> ");
                    do {
                        try {
                            from_id = Int32.Parse(Console.ReadLine());
                            if ((from_id >= 1) && (from_id <= TestAccounts.Length)) break;
                            Console.Write($"Input error. Enter number from 1 to {TestAccounts.Length} :> ");
                        } catch { Console.Write($"Input error. Enter number. Please try again :> "); }
                    } while (true);
                    Console.WriteLine();
                    from_id--;
                    PrintSummary(TestAccounts[from_id]);
                }
                Console.Write("Amount :> ");
                do {
                    try {
                        amount = Double.Parse(Console.ReadLine());
                        break;
                    } catch { Console.Write($"Input error. Enter number. Try again (enter ammount) :> "); }
                } while (true);
                if (ch == 'D') if (!TestAccounts[id].Deposit(amount)) {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Operation failed. Not enough money.");
                        Console.ForegroundColor = ConsoleColor.White;
                    }
                if (ch == 'W') if (!TestAccounts[id].Withdraw(amount)) {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Operation failed. Not enough money.");
                        Console.ForegroundColor = ConsoleColor.White;
                    }
                if (ch == 'T') if (!TestAccounts[id].Transfer(TestAccounts[from_id], amount)) {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Operation failed. Not enough money.");
                        Console.ForegroundColor = ConsoleColor.White;
                    }
                Console.WriteLine();
                PrintSummary(TestAccounts[id]);
                Console.WriteLine();
            } while (true);
            Console.WriteLine(); Console.Write("Press any key to continue..."); Console.ReadKey(true);
        }
    }
}
