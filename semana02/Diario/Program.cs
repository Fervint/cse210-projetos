using System;

class Program
{
    static void Main(string[] args)
    {
        Diario diario = new Diario();
        GeradorDePerguntas gerador = new GeradorDePerguntas();
        bool continuar = true;

        while (continuar)
        {
            Console.WriteLine("Por favor selecione uma das seguintes opções:");
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
                    Registro registro = new Registro();
                    registro._data = DateTime.Now.ToShortDateString();
                    registro._textoPergunta = gerador.ObterPerguntaAleatoria();
                    Console.WriteLine($"Pergunta: {registro._textoPergunta}");
                    Console.Write("Resposta: ");
                    registro._textoResposta = Console.ReadLine();
                    diario.AdicionarRegistro(registro);
                    break;

                case "2":
                    diario.ExibirTodos();
                    break;

                case "3":
                    Console.Write("Qual é o nome do arquivo? ");
                    string arquivoCarregar = Console.ReadLine();
                    diario.CarregarDoArquivo(arquivoCarregar);
                    break;

                case "4":
                    Console.Write("Qual é o nome do arquivo? ");
                    string arquivoSalvar = Console.ReadLine();
                    diario.SalvarNoArquivo(arquivoSalvar);
                    break;

                case "5":
                    continuar = false;
                    break;

                default:
                    Console.WriteLine("Opção inválida. Tente novamente.");
                    break;
            }
        }
    }
}
