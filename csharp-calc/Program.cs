using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

Console.Write("\nkalkulator");
Thread.Sleep(1500);
Console.Clear();

Console.Write("\nwpisz co chcesz zrobic (+, -, *, /) : ");
string niewiem =  Console.ReadLine();
if (!char.TryParse(niewiem, out char dzialanie))
{
    Console.ForegroundColor = ConsoleColor.Red;
    Console.Write("\nblad mozna wpisac tylko jeden znak");
    Console.ResetColor();
    Console.Write("\nnacisnij cos zeby wyjsc");
    Console.ReadKey(intercept: true);
    return;
} else if (dzialanie != '+' && dzialanie != '-' && dzialanie != '*' && dzialanie != '/')
{
    Console.ForegroundColor = ConsoleColor.Red;
    Console.Write($"\nblad nie mozna nic zrobic z '{dzialanie}'");
    Console.ResetColor();
    Console.Write("\nnacisnij cos zeby wyjsc");
    Console.ReadKey(intercept: true);
    return;
}

Console.Write("\npodaj ile liczb chcesz uzyc w dzialaniu: ");
int liczbaLiczb = int.Parse(Console.ReadLine());

if (liczbaLiczb < 2)
{
    Console.ForegroundColor = ConsoleColor.Red;
    Console.Write($"\nblad za malo liczb");
    Console.ResetColor();
    Console.Write("\nnacisnij cos zeby wyjsc");
    Console.ReadKey(intercept: true);
    return;
}

List<double> listaLiczb = new List<double>();

for (int i = 0; i < liczbaLiczb; i++)
{
    Console.Write($"\nwpisz liczbe {i + 1}: ");
    double liczba = double.Parse(Console.ReadLine());
    listaLiczb.Add(liczba);
}

if (dzialanie == '/' && listaLiczb.Skip(1).Contains(0))
{
    Console.ForegroundColor = ConsoleColor.Red;
    Console.Write("\n blad nie mozna dzielic przez 0");
    Console.ResetColor();
    Console.Write("\nnacisnij cos zeby wyjsc");
    Console.ReadKey(intercept: true);
    return;
}

Console.Write($"\nzebrano wszystkie liczby. jest ich {listaLiczb.Count}");

double wynik;

if (dzialanie == '-' || dzialanie == '/')
{
    wynik = listaLiczb[0];
} else if (dzialanie == '*')
{
    wynik = 1;
}
else
{
    wynik = 0;
}

if (dzialanie == '+')
{
    foreach (double pojedynczaLiczba in listaLiczb)
    {
        wynik += pojedynczaLiczba;
    }
} else if (dzialanie == '-')
{
    foreach (double pojedynczaLiczba in listaLiczb.Skip(1))
    {
        wynik -= pojedynczaLiczba;
    }
}  else if (dzialanie == '*')
{
    foreach (double pojedynczaLiczba in listaLiczb)
    {
        wynik *= pojedynczaLiczba;
    }
} else if (dzialanie == '/')
{
    foreach (double pojedynczaLiczba in listaLiczb.Skip(1))
    {
        wynik /= pojedynczaLiczba;
    }
}

Console.Write($"\nwynik: {wynik}");
Console.Write("\nnacisnij cos zeby wyjsc");
Console.ReadKey(intercept: true);
Environment.Exit(0);
