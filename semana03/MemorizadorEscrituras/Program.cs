// Projeto Semana 03 - Programa de Memorização de Escrituras
// Autor: Fabio
// Data: 22/09/2026
//
// Este programa foi desenvolvido aplicando o princípio de encapsulamento,
// com classes separadas para Escritura, Palavra, Referencia e Biblioteca.
//
// Além dos requisitos básicos, adicionei:
// - Uma biblioteca com 30 escrituras da Igreja de Jesus Cristo dos Santos dos Últimos Dias
// - Carregamento automático de arquivo externo (escrituras.txt)
// - Opção de revelar e reiniciar o treino
// - Contador de progresso mostrando quantas palavras já foram escondidas
// - Verificação automática do arquivo e mensagens amigáveis de erro
// - Configuração do VS Code com launch.json para execução direta do projeto
//
// Essas melhorias tornam o programa mais dinâmico, educativo e pronto para uso real,
// demonstrando criatividade e superando os requisitos básicos da tarefa.

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

