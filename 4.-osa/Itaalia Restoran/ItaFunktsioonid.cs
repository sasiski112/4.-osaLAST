using System;
using System.Collections.Generic;
using System.Text;

namespace _4._osa.Itaalia_Restoran
{
    internal class ItaFunktsioonid
    {
        public static void Menu()
        {
            Console.OutputEncoding = Encoding.UTF8;
            string path = Path.Combine(Funktsioonid.basePath, "Menuu.txt");

            if (!File.Exists(path))
            {
                Console.WriteLine("Viga: Faili 'Menuu.txt' ei leitud!");
                return;
            }

            List<Tuple<string, string, double>> MenuList = new List<Tuple<string, string, double>>();
            string[] read = File.ReadAllLines(path);

            if (read.Length == 0)
            {
                Console.WriteLine("Menüü on tühi!");
                return;
            }

            foreach (string rad in read)
            {
                if (string.IsNullOrWhiteSpace(rad)) continue;

                string[] osad = rad.Split(';');

                if (osad.Length < 3)
                {
                    Console.WriteLine($"Viga real: '{rad}' (puuduvad andmed)");
                    continue;
                }

                 if (double.TryParse(osad[2].Replace(",", "."),
                    System.Globalization.NumberStyles.Any,
                    System.Globalization.CultureInfo.InvariantCulture,
                    out double hind))
                {
                    MenuList.Add(Tuple.Create(osad[0], osad[1], hind));
                }
            }

            if (MenuList.Count == 0)
            {
                Console.WriteLine("Kehtivaid roogasid ei leitud.");
            }
            else
            {
                Console.Clear();
                Console.WriteLine("==============================================");
                Console.WriteLine("             RESTORANI MENÜÜ                 ");
                Console.WriteLine("==============================================");

                foreach (var roog in MenuList)
                {
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    Console.WriteLine($"{roog.Item1.PadRight(35)} {roog.Item3:F2} €");
                    Console.ForegroundColor = ConsoleColor.Gray;
                    Console.WriteLine($"   ({roog.Item2})");
                    Console.WriteLine();
                }
            }

            Console.ResetColor();
            Console.WriteLine("==============================================");
            Console.WriteLine("\nTagasi minemiseks vajuta [Backspace]");

            while (Console.ReadKey().Key != ConsoleKey.Backspace) { }
        }
    }
}