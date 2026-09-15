using System;
using Diario;

class Program
{
    static void Main(string[] args)
    {
        var diario = new Diario.Diario();
        GeradorDePerguntas gerador = new GeradorDePerguntas();
        bool continuar = true;

        // 💡 Comentário de criatividade extra:
        // Este programa foi aprimorado para salvar e carregar registros em formato CSV,
        // permitindo abrir o diário diretamente no Excel. Também adiciona mensagens coloridas
        // para melhor experiência visual do usuário.

        while (continuar)
        {
            Console.WriteLine("\nPor favor selecione uma das seguintes opções:");
            Console.WriteLine("1. Escrever");
            Console.WriteLine("2. Exibir");
            Console.WriteLine("3. Carregar");
            Console.WriteLine("4. Salvar");
            Console.WriteLine("5. Sair");
            Console.Write("O que você gostaria de fazer? ");
            string opcao = Console.ReadLine();

            switch (opcao)
            {
                case "1":
                    Registro registro = new Registro
                    {
                        _data = DateTime.Now.ToShortDateString(),
                        _textoPergunta = gerador.ObterPerguntaAleatoria()
                    };
                    Console.WriteLine($"Data: {registro._data} - Pergunta: {registro._textoPergunta}");
                    Console.Write("Resposta: ");
                    registro._textoResposta = Console.ReadLine();
                    diario.AdicionarRegistro(registro);
                    break;

                case "2":
                    diario.ExibirTodos();
                    break;

                case "3":
                    Console.Write("Qual é o nome do arquivo? ");
                    diario.CarregarDoArquivo(Console.ReadLine());
                    break;

                case "4":
                    Console.Write("Qual é o nome do arquivo? ");
                    diario.SalvarNoArquivo(Console.ReadLine());
                    break;

                case "5":
                    continuar = false;
                    break;

                default:
                    Console.WriteLine("Opção inválida.");
                    break;
            }
        }
    }
}
