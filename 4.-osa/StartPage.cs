using System;
using System.IO;
using System.Collections.Generic;
using _4._osa.Itaalia_Restoran;

class StartPage
{
    public static void Main()
    {
        bool a = true;
        while (a)
        {
            Console.WriteLine("\n=== MENU ===");
            Console.WriteLine("1 - Lemmiktoidu salvestamine faili");
            Console.WriteLine("2 - Kogu menüü kuvamine");
            Console.WriteLine("del - Menuu kustutamine");
            Console.WriteLine("3 - Koostisosade muutmine nimekirjas");
            Console.WriteLine("4 - Külmkapi kontroll");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("5 - ITAALIA RESTORAN");
            Console.ResetColor();
            Console.WriteLine("0 - Välja");
            Console.WriteLine("Sinu valik:");
            string valik = Console.ReadLine();

            switch (valik)
            {
                case "1":
                    Console.Clear();
                    Funktsioonid.LemToit();
                    break;
                case "2":
                    Console.Clear();
                    Funktsioonid.ShowMenu();
                    break;
                case "3":
                    Console.Clear();
                    Funktsioonid.MenuMuutmine();
                    break;
                case "del":
                    Console.Clear();
                    Funktsioonid.DeleteMenu();
                    break;
                case "4":
                    Console.Clear();
                    Funktsioonid.KülmkapiKontroll();
                    break;
                case "5":
                    ItaFunktsioonid.Menu();
                    break;
                case "0":
                    Console.WriteLine("Bye");
                    a = false;
                    break;
                default:
                    Console.WriteLine("Vali üks pakutud variantidest!");
                    break;
            }
        }
    }
}