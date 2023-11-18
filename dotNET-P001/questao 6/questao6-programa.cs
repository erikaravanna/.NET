using System;

class Program
{
    static void Main()
    {
        // Strings
        string str1 = "Murilo";
        string str2 = "Novais";

        // Verificar se as strings são iguais
        bool saoIguais = str1 == str2;

        // Exibir o resultado
        if (saoIguais)
        {
            Console.WriteLine("As strings são iguais.");
        }
        else
        {
            Console.WriteLine("As strings não são iguais.");
        }
    }
}