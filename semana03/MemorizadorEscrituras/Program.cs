// Projeto Semana 03 - Programa de Memorização de Escrituras
// Autor: Fabio Ricardo
// Data: 23/09/2026
//
// Este arquivo contém o fluxo principal do programa.
// Ele controla a interação com o usuário, exibe escrituras,
// esconde palavras progressivamente e gerencia o encerramento.
//
// 🔥 Criatividade além do pedido:
// - Exibição inicial da escritura antes de começar o treino (melhora a experiência do usuário).
// - Contador de progresso mostrando quantas palavras já foram escondidas.
// - Opção de revelar todas as palavras e reiniciar o treino com a mesma escritura.
// - Encerramento amigável com mensagens claras e pausa final.
// Essas melhorias tornam o programa mais dinâmico e educativo,
// indo além dos requisitos básicos da tarefa.

using System;

partial class Program
{
    static void Main(string[] args)
    {
        // Cria a biblioteca que carrega todas as escrituras do arquivo externo
        Biblioteca biblioteca = new Biblioteca();
        bool continuar = true;

        // Loop principal do programa (permite várias rodadas de treino)
        while (continuar)
        {
            // Seleciona uma escritura aleatória da biblioteca
            Escritura escritura = biblioteca.EscolherAleatoria();

            // 🔥 Criatividade: exibe a escritura completa antes de começar a esconder
            Console.Clear();
            Console.WriteLine("Nova escritura selecionada:\n");
            escritura.Exibir();
            Console.WriteLine("\nPressione Enter para começar a esconder palavras...");
            Console.ReadLine();

            // Loop interno: esconde palavras até que todas estejam ocultas
            while (!escritura.EstaCompletamenteEscondida())
            {
                Console.Clear();
                escritura.Exibir();

                // 🔥 Criatividade: mostra progresso do treino em tempo real
                Console.WriteLine($"\nProgresso: {escritura.PalavrasEscondidas()} de {escritura.TotalPalavras()} palavras escondidas.");
                Console.WriteLine("\nPressione Enter para esconder uma palavra aleatória ou digite 'sair' para encerrar.");
                string entrada = Console.ReadLine();

                // Permite encerrar o programa digitando "sair"
                if (entrada?.ToLower() == "sair")
                {
                    continuar = false;
                    break;
                }

                // Esconde uma palavra aleatória
                escritura.EsconderPalavrasAleatorias(1);
            }

            // Se o usuário escolheu sair, interrompe o loop principal
            if (!continuar) break;

            // Quando todas as palavras estão escondidas
            Console.Clear();
            Console.WriteLine($"\nReferência: {escritura.ObterReferencia()}");
            escritura.Exibir();
            Console.WriteLine("\nTodas as palavras foram escondidas!");
            Console.WriteLine("\nDeseja revelar as palavras e continuar com a mesma escritura? (s/n)");
            string resposta = Console.ReadLine()?.ToLower();

            if (resposta == "s")
            {
                // 🔥 Criatividade: opção de revelar todas as palavras e reiniciar o treino
                escritura.RevelarTodas();
                Console.Clear();
                escritura.Exibir();
                Console.WriteLine("\nEscritura revelada novamente! Pressione Enter para continuar o treino...");
                Console.ReadLine();
            }
            else
            {
                // 🔥 Criatividade: encerramento amigável com mensagem final
                continuar = false;
                Console.WriteLine("\nPrograma encerrado. Obrigado por praticar!");
                Console.WriteLine("Pressione Enter para sair...");
                Console.ReadLine();
            }
        }
    }
}
