using System;

class Program
{
    static void Main()
    {

        double numeroDouble = 5.02;

        int numeroInteiro = (int)numeroDouble;

        Console.WriteLine($"Número Double: {numeroDouble}");
        Console.WriteLine($"Número Inteiro após conversão: {numeroInteiro}");
    }
}