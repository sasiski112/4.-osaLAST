using System;
using System.Globalization;

class Funktsioonid
{
    public static string basePath = AppDomain.CurrentDomain.BaseDirectory;
   
    public static void LemToit()
    {
        if (!File.Exists(Path.Combine(basePath, "Retseptid.txt")))
        {
            Console.WriteLine("Viga fail!");
        }
        else
        {
            string path = Path.Combine(basePath, "Retseptid.txt");
            StreamWriter sw = new StreamWriter(path,true);
            Console.WriteLine("Sisesta sinu lemmik toit: ");
            string lt = Console.ReadLine();
            sw.WriteLine(lt);
            sw.Close();
        }
    }
    
    public static void DeleteMenu()
    {
        if (!File.Exists(Path.Combine(basePath, "Retseptid.txt")))
        {
            Console.WriteLine("Viga fail!");
            return;
        }
        else
        {
            string path = Path.Combine(basePath, "Retseptid.txt");
            StreamWriter sw = new StreamWriter(path);
            sw.Write("");
            Console.WriteLine("Menüü kustutatud!");
            sw.Close();
        }
    }


    public static void ShowMenu()
    {
        string path = Path.Combine(basePath, "Retseptid.txt");

        // 1. Простая проверка на существование
        if (!File.Exists(path))
        {
            Console.WriteLine("Viga: Faili ei leitud!");
            return;
        }

        // 2. Читаем всё содержимое сразу одной командой
        string sisu = File.ReadAllText(path);

        // 3. Проверка: не пустой ли текст внутри
        if (string.IsNullOrWhiteSpace(sisu))
        {
            Console.WriteLine("Menüü on tühi!");
        }
        else
        {
            Console.WriteLine(sisu);
        }
    }



    public static void MenuMuutmine()
    {
        string path = Path .Combine(basePath, "Koostisosad.txt");
        if (!File.Exists(Path.Combine(basePath, "Retseptid.txt")))
        {
            Console.WriteLine("Viga fail!");
            return;
        }
        List<string> koostisosad = new List<string>();
        if (koostisosad.Count > 0)
        {
            koostisosad[0] = "Kvaliteetne oliiviõli";
        }
        if (koostisosad.Contains("Ketšup"))
        {
            koostisosad.Remove("Ketšup");
        }
        else
        {
            Console.WriteLine("Ketšupit ei leitud!\n");
        }
        while (true)
        {
            Console.WriteLine("Vali tegemus: " +
            "\n1 - Koostisosa lisa" +
            "\n2 - Koostisosa muuta" +
            "\n3 - Kuva menüü" +
            "\n0 - Tagasi");
        string valik = Console.ReadLine();
            switch (valik)
            {
                case "1":
                    Console.Clear();
                    Console.WriteLine("Sisesta koostisosa: ");
                    string Uus = Console.ReadLine();
                    koostisosad.Add(Uus);
                    Console.WriteLine("Koostisosa lisatud!");
                    File.WriteAllLines(path, koostisosad);
                    break;

                case "2":
                    Console.Clear();
                    Console.WriteLine("Sisesta vana koostisosa: ");
                    string vana = Console.ReadLine();
                    Console.WriteLine("Sisesta uus koostisosa: ");
                    string uus = Console.ReadLine();
                    if (koostisosad.Contains(vana))
                    {
                        int index = koostisosad.IndexOf(vana);
                        koostisosad[index] = uus;
                        Console.WriteLine("Koostisosa muudetud!");
                    }
                    else
                    {
                        Console.WriteLine("Vana koostisosa ei leitud!");
                    }
                    break;
                    case "3":
                    Console.Clear();
                    foreach (string koostis in koostisosad)
                    {
                        Console.WriteLine(koostis);
                    }
                    break;
                    case "0":
                    Console.Clear();
                    return;
            } 
        }
    }
    public static void KülmkapiKontroll()
    {
        string path = Path.Combine(basePath, "Koostisosad.txt");

        if (!File.Exists(path))
        {
            Console.WriteLine("Viga: Koostisosade faili ei leitud!");
            return;
        }

        Console.WriteLine("Sisesta otsitav toit: ");
        string fal = Console.ReadLine();

        string failiSisu = File.ReadAllText(path);

        if (failiSisu.Contains(fal, StringComparison.OrdinalIgnoreCase))
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"Jah! {fal} on külmkapis olemas.");
        }
        else
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"Ei, toitu '{fal}' ei leitud.");
        }

        Console.ResetColor();
    }
}
