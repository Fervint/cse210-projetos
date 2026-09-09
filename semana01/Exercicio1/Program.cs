using System;

class Program
{
    static void Main(string[] args)
    {
        Console.Write("Qual é seu primeiro nome? ");
        string primeiroNome = Console.ReadLine();

        Console.Write("Qual é seu sobrenome? ");
        string sobrenome = Console.ReadLine();

        Console.WriteLine($"Seu nome é {sobrenome}, {primeiroNome} {sobrenome}!");
    }
}