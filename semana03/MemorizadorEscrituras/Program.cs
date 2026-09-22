// Projeto Semana 03 - Programa de Memorização de Escrituras
// Fiz esse código usando classes separadas (Escritura, Palavra, Referencia e Biblioteca)
// para deixar mais organizado e seguir o princípio de encapsulamento.
// Além dos requisitos básicos, adicionei uma biblioteca com várias escrituras
// que são escolhidas aleatoriamente, assim o programa fica mais dinâmico.
// Também adicionei a opção de revelar todas as palavras e continuar o treino,
// deixando o programa mais interativo e completo.

using System;

class Program
{
    static void Main(string[] args)
    {
        Biblioteca biblioteca = new Biblioteca();
        bool continuar = true;

        while (continuar)
        {
            Escritura escritura = biblioteca.EscolherAleatoria();

            while (!escritura.EstaCompletamenteEscondida())
            {
                Console.Clear();
                escritura.Exibir();
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
            }
        }
    }
}
