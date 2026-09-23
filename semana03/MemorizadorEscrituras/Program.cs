// Projeto Semana 03 - Programa de Memorização de Escrituras
// Autor: Fabio
// Data: 22/09/2026

using System;

partial class Program
{
    static void Main(string[] args)
    {
        Biblioteca biblioteca = new Biblioteca();
        bool continuar = true;

        while (continuar)
        {
            Escritura escritura = biblioteca.EscolherAleatoria();

            Console.Clear();
            Console.WriteLine("Nova escritura selecionada:\n");
            escritura.Exibir();
            Console.WriteLine("\nPressione Enter para começar a esconder palavras...");
            Console.ReadLine();

            while (!escritura.EstaCompletamenteEscondida())
            {
                Console.Clear();
                escritura.Exibir();
                Console.WriteLine($"\nProgresso: {escritura.PalavrasEscondidas()} de {escritura.TotalPalavras()} palavras escondidas.");
                Console.WriteLine("\nPressione Enter para esconder uma palavra aleatória ou digite 'sair' para encerrar.");
                string entrada = Console.ReadLine();

                if (entrada?.ToLower() == "sair")
                {
                    continuar = false;
                    break;
                }

                escritura.EsconderPalavrasAleatorias(1);
            }

            if (!continuar) break;

            Console.Clear();
            Console.WriteLine($"\nReferência: {escritura.ObterReferencia()}");
            escritura.Exibir();
            Console.WriteLine("\nTodas as palavras foram escondidas!");
            Console.WriteLine("\nDeseja revelar as palavras e continuar com a mesma escritura? (s/n)");
            string resposta = Console.ReadLine()?.ToLower();

            if (resposta == "s")
            {
                escritura.RevelarTodas();
                Console.Clear();
                escritura.Exibir();
                Console.WriteLine("\nEscritura revelada novamente! Pressione Enter para continuar o treino...");
                Console.ReadLine();
            }
            else
            {
                continuar = false;
                Console.WriteLine("\nPrograma encerrado. Obrigado por praticar!");
                Console.WriteLine("Pressione Enter para sair...");
                Console.ReadLine();
            }
        }
    }
}
