using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BuildingLibrary;

namespace BuildingTest {
  
    class Menu {
        private string[] items;
        private int num, max;
        private int width;

        public Menu(int _max, int _width) {
            max = _max; items = new string[max]; num = 0; width = _width;
        }

        public void Reset() {
            num = 0;
        }

        public void Append(string str) {
            if (num == max) return;
            for (int i = 0; i < num; i++) if (str == items[i]) return;
            items[num++] = str;
        }

        private void ShowItem(int x, int y, int i, bool Selected) {
            Console.SetCursorPosition(x, y + i);
            if (Selected) { Console.BackgroundColor = ConsoleColor.Cyan; Console.ForegroundColor = ConsoleColor.Black; } 
            else { Console.BackgroundColor = ConsoleColor.Blue; Console.ForegroundColor = ConsoleColor.White; }
            Console.Write($"  {items[i]}  "); for (int j = items[i].Length; j < width; j++) Console.Write(" ");
        }

        public int ShowMenu(int x, int y) {
            int i;
            Console.CursorVisible = false;
            for (i = 0; i < num; i++) ShowItem(x, y, i, (i == 0));
            for (i = 0; true;) {
                switch (Console.ReadKey(true).Key) {
                    case ConsoleKey.UpArrow:
                        ShowItem(x, y, i, false);
                        if (i == 0) i = num - 1; else i--;
                        ShowItem(x, y, i, true); 
                        break;
                    case ConsoleKey.DownArrow:
                        ShowItem(x, y, i, false);
                        if (i == num - 1) i = 0; else i++;
                        ShowItem(x, y, i, true); 
                        break;
                    case ConsoleKey.Enter:
                        Console.CursorVisible = true; Console.SetCursorPosition(0, y + num + 2);
                        Console.BackgroundColor = ConsoleColor.Black; Console.ForegroundColor = ConsoleColor.White;
                        return i;
                }
            }
        }
    }

    class Program {
        static int InputNumber(string comment, bool positive) {
            do {
                Console.Write(comment);
                try { 
                    int number = Int32.Parse(Console.ReadLine());
                    if (positive && (number <= 0)) Console.WriteLine("Number must be positive");
                    else return number;
                } catch { Console.WriteLine("Incorrect input. Try again. Must be number."); }
            }
            while (true);
        }

        static void Main(string[] args) {

            var menu = new Menu(5 , 16);
            var menu_add = new Menu(3, 23);
            var menu_chng = new Menu(20, 24);

            menu.Append("Add building");
            menu.Append("List buildings");
            menu.Append("Building details");
            menu.Append("Remove building");
            menu.Append("Exit");

            menu_add.Append("Add by id");
            menu_add.Append("Add with all details");
            menu_add.Append("Add sequental automatic");

            menu_chng.Append("Change nothing");
            menu_chng.Append("Change everything");
            menu_chng.Append("Change height");
            menu_chng.Append("Change number of floors");
            menu_chng.Append("Change number of rooms");
            menu_chng.Append("Change number of porches");

            Creator.CreateBuild(1, 15, 5, 60, 3);
            Creator.CreateBuild();

            do {
                Console.Clear();
                switch (menu.ShowMenu(1, 1)) {
                    case 0: switch (menu_add.ShowMenu(23, 1)) {
                            case 0: Creator.CreateBuild(InputNumber("Building ID :> ", true)); break;
                            case 1:
                                Creator.CreateBuild(
                                    InputNumber("Building ID :> ", true),
                                    InputNumber("Building height :> ", true),
                                    InputNumber("Building floors :> ", true),
                                    InputNumber("Building rooms :> ", true),
                                    InputNumber("Building porches :> ", true));
                                break;
                            case 2: Creator.CreateBuild(); break;
                        }
                        break;
                    case 1:
                        Console.Clear();
                        Console.WriteLine("Buildings List:");
                        Console.WriteLine();
                        Console.WriteLine($"+---------+---------+---------+---------+---------+");
                        Console.WriteLine($"|      ID |  Height |  Floors |   Rooms | Porches |");
                        Console.WriteLine($"+---------+---------+---------+---------+---------+");
                        foreach (Building tmp in Creator.BuildingsList())
                            Console.WriteLine($"| {tmp.id,7} | {tmp.height,7} | {tmp.floors,7} | {tmp.rooms,7} | {tmp.porches,7} |");
                        Console.WriteLine($"+---------+---------+---------+---------+---------+");
                        Console.WriteLine(); Console.Write("Press any key to return to menu..."); Console.ReadKey(true);
                        break;
                    case 2:
                        Console.Clear();
                        Building b = Creator.GetByID(InputNumber("Enter building ID :> ", true));
                        if (b == null) {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("No such building!");
                            Console.ForegroundColor = ConsoleColor.Gray;
                            Console.WriteLine(); Console.Write("Press any key to return to menu..."); Console.ReadKey(true);
                            break;
                        }
                        Console.Clear();
                        Console.WriteLine($"Building ID: {b.id}");
                        Console.WriteLine($"Building height: {b.height}");
                        Console.WriteLine($"Building floors: {b.floors}");
                        Console.WriteLine($"Building rooms: {b.rooms}");
                        Console.WriteLine($"Building porches: {b.porches}");
                        Console.WriteLine();
                        Console.Write("Floor height: "); try { Console.WriteLine(b.FloorHeight()); } catch { Console.WriteLine("-"); } 
                        Console.Write("Rooms per porch: "); try { Console.WriteLine(b.RoomsPerPorch()); } catch { Console.WriteLine("-"); }
                        Console.Write("Rooms per floor: "); try { Console.WriteLine(b.RoomsPerFloor()); } catch { Console.WriteLine("-"); }
                        switch (menu_chng.ShowMenu(1,10)) {
                            case 0: break;
                            case 1:
                                b.height = InputNumber("Enter building height :> ", true);
                                b.floors = InputNumber("Enter number of floors :> ", true);
                                b.rooms = InputNumber("Enter number of rooms :> ", true);
                                b.porches = InputNumber("Enter number of porches :> ", true);
                                break;
                            case 2: b.height = InputNumber("Enter building height :> ", true); break;
                            case 3: b.floors = InputNumber("Enter number of floors :> ", true); break;
                            case 4: b.rooms = InputNumber("Enter number of rooms :> ", true); break;
                            case 5: b.porches = InputNumber("Enter number of porches :> ", true); break;
                        }
                        break; 
                    case 3: Creator.DeleteById(InputNumber("Enter building ID to remove :> ", true)); break; 
                    case 4: Console.Clear(); return;
                }
            } while (true);
        }
    }
}
