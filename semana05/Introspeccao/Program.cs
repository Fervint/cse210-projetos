// 💡 Criatividade adicional: adicionei emojis e animações (pontinhos e reloginho)
// em todas as atividades para tornar o programa mais envolvente e divertido, e opção 4 de sair encerrar programa .

using System;
using System.Text;

class Program
{
    static void Main(string[] args)
    {
        Console.OutputEncoding = new UTF8Encoding(false);
        Console.InputEncoding = new UTF8Encoding(false);

        bool executando = true;

        while (executando)
        {
            Console.Clear();
            WriteColored("╔══════════════════════════════════════╗\n", ConsoleColor.DarkCyan);
            WriteColored("║       🌿 Programa de Introspecção    ║\n", ConsoleColor.Cyan);
            WriteColored("╚══════════════════════════════════════╝\n\n", ConsoleColor.DarkCyan);
            WriteColored("  1. 🧘 Atividade de Respiração\n", ConsoleColor.Green);
            WriteColored("  2. 💭 Atividade de Reflexão\n", ConsoleColor.Magenta);
            WriteColored("  3. 📝 Atividade de Listagem\n", ConsoleColor.Yellow);
            WriteColored("  4. 🚪 Sair\n", ConsoleColor.Red);
            WriteColored("\n  Escolha uma opção: ", ConsoleColor.White);
            string opcao = Console.ReadLine();

            switch (opcao)
            {
                case "1":
                    new AtividadeDeRespiracao().Executar();
                    break;
                case "2":
                    new AtividadeDeReflexao().Executar();
                    break;
                case "3":
                    new AtividadeDeListagem().Executar();
                    break;
                case "4":
                    executando = false;
                    break;
                default:
                    WriteColored("Opção inválida! Tente novamente.", ConsoleColor.Red);
                    Console.WriteLine();
                    Thread.Sleep(1500);
                    break;
            }
        }

        WriteColored("\n🌱 Encerrando o programa...", ConsoleColor.Cyan);
        Console.WriteLine();
        Thread.Sleep(1500);
    }

    private static void WriteColored(string mensagem, ConsoleColor cor)
    {
        ConsoleColor corOriginal = Console.ForegroundColor;
        Console.ForegroundColor = cor;
        Console.Write(mensagem);
        Console.ForegroundColor = corOriginal;
    }
}
