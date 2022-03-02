using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task1 {
    interface ICoder {
        string Encoder(string toCode);

        string Decoder(string toDecode);
    }

    class ACoder : ICoder {
        public string Encoder(string toCode) {
            var str = new char[toCode.Length];
            for (int i = 0; i < toCode.Length; i++) str[i] = (char)(toCode[i] + 1);
            return new string(str);
        }

        public string Decoder(string toDecode) {
            var str = new char[toDecode.Length];
            for (int i = 0; i < toDecode.Length; i++) str[i] = (char)(toDecode[i] - 1);
            return new string(str);
        }
    }

    class BCoder : ICoder {
        public string Encoder(string toCode) {
            var str = new char[toCode.Length];
            for (int i = 0; i < toCode.Length; i++) {
                char c = toCode[i];
                if ((c >= 'А') && (c <= 'Я')) c = (char)('Я' - c + 'А');
                if ((c >= 'а') && (c <= 'я')) c = (char)('я' - c + 'а');
                if ((c >= 'A') && (c <= 'Z')) c = (char)('Z' - c + 'A');
                if ((c >= 'a') && (c <= 'z')) c = (char)('z' - c + 'a');
                if ((c >= '0') && (c <= '9')) c = (char)('9' - c + '0');
                str[i] = c;
            }
            return new string(str);
        }

        public string Decoder(string toDecode) => Encoder(toDecode);
    }


    class Program {
        static void Main(string[] args) {
            var test1 = new ACoder();
            var test2 = new BCoder();
            Console.WriteLine(test1.Encoder("АБВГДЕЁЖЗИЙКЛМНОПРСТУФХЦЧШЩЪЫЬЭЮЯ"));
            Console.WriteLine(test1.Decoder(test1.Encoder("абвгдеёжзиЙклмнопрстуфхцчшщъыьэюя")));
            Console.WriteLine();
            Console.WriteLine(test2.Encoder("АБВГДЕЁЖЗИЙКЛМНОПРСТУФХЦЧШЩЪЫЬЭЮЯ"));
            Console.WriteLine(test2.Decoder(test2.Encoder("абвгдеёжзиЙклмнопрстуфхцчшщъыьэюя")));
            Console.WriteLine();
            Console.WriteLine(test2.Encoder("ABCDEFGHIJKLMNOPQRSTUVWXYZ"));
            Console.WriteLine(test2.Decoder(test2.Encoder("abcdefghijklmnopqrstuvwxyz")));
            Console.WriteLine();
            Console.WriteLine(test2.Encoder("0123456789"));
            Console.WriteLine(test2.Decoder(test2.Encoder("0123456789")));
            Console.WriteLine();
            /*
            Console.WriteLine(); Console.Write(test2.Decoder(test2.Encoder("Press any key to continue..."))); Console.ReadKey(true);
            Console.Clear();
            var key = new ConsoleKeyInfo();
            var ch = new char[1];
            while (key.Key != ConsoleKey.Escape) {
                Console.Write("Press any key :> "); 
                key = Console.ReadKey(true);
                ch[0] = key.KeyChar;
                Console.WriteLine(test2.Encoder(new string(ch)));
            }
            */
            Console.WriteLine(); Console.Write(test2.Decoder(test2.Encoder("Press any key to exit..."))); Console.ReadKey(true);
        }
    }
}
