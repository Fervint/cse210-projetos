using System;
using System.Collections.Generic;
using System.IO;

public class GerenciadorDeMetas
{
    private List<Meta> _metas;
    private int _pontos;
    private const string ArquivoMetas = "metas.txt";

    public GerenciadorDeMetas()
    {
        _metas = new List<Meta>();
        _pontos = 0;
    }

    public int Pontos => _pontos;

    public void Iniciar()
    {
        bool executar = true;

        while (executar)
        {
            if (!Console.IsOutputRedirected)
            {
                Console.Clear();
            }

            Console.WriteLine("=== Metas Eternas ===");
            Console.WriteLine($"Pontuação atual: {_pontos}");
            Console.WriteLine();
            Console.WriteLine("1. Listar nomes das metas");
            Console.WriteLine("2. Listar detalhes das metas");
            Console.WriteLine("3. Criar meta");
            Console.WriteLine("4. Registrar evento");
            Console.WriteLine("5. Salvar metas");
            Console.WriteLine("6. Carregar metas");
            Console.WriteLine("0. Sair");
            Console.Write("Escolha uma opção: ");

            string escolha = Console.ReadLine();

            switch (escolha)
            {
                case "1":
                    ListarNomesDasMetas();
                    break;
                case "2":
                    ListarDetalhesDasMetas();
                    break;
                case "3":
                    CriarMeta();
                    break;
                case "4":
                    RegistrarEvento();
                    break;
                case "5":
                    SalvarMetas();
                    break;
                case "6":
                    CarregarMetas();
                    break;
                case "0":
                    executar = false;
                    break;
                default:
                    Console.WriteLine("Opção inválida.");
                    Pause();
                    break;
            }
        }
    }

    public void ExibirInfoJogador()
    {
        Console.WriteLine($"Pontuação do jogador: {_pontos}");
    }

    public void ListarNomesDasMetas()
    {
        if (_metas.Count == 0)
        {
            Console.WriteLine("Nenhuma meta cadastrada.");
            Pause();
            return;
        }

        Console.WriteLine("Metas cadastradas:");
        foreach (Meta meta in _metas)
        {
            Console.WriteLine($"- {meta.Nome}");
        }

        Pause();
    }

    public void ListarDetalhesDasMetas()
    {
        if (_metas.Count == 0)
        {
            Console.WriteLine("Nenhuma meta cadastrada.");
            Pause();
            return;
        }

        foreach (Meta meta in _metas)
        {
            Console.WriteLine(meta.ObterDetalhesEmTexto());
        }

        Pause();
    }

    public void CriarMeta()
    {
        Console.Write("Tipo da meta (1-Simples, 2-Eterna, 3-Lista): ");
        string tipo = Console.ReadLine();
        Console.Write("Nome: ");
        string nome = Console.ReadLine();
        Console.Write("Descrição: ");
        string descricao = Console.ReadLine();
        Console.Write("Pontos: ");
        int pontos = Convert.ToInt32(Console.ReadLine());

        Meta novaMeta;

        if (tipo == "1")
        {
            novaMeta = new MetaSimples(nome, descricao, pontos);
        }
        else if (tipo == "2")
        {
            novaMeta = new MetaEterna(nome, descricao, pontos);
        }
        else if (tipo == "3")
        {
            Console.Write("Quantidade total: ");
            int total = Convert.ToInt32(Console.ReadLine());
            Console.Write("Bônus: ");
            int bonus = Convert.ToInt32(Console.ReadLine());
            novaMeta = new MetaDeListaDeTarefas(nome, descricao, pontos, total, bonus);
        }
        else
        {
            Console.WriteLine("Tipo de meta inválido.");
            Pause();
            return;
        }

        _metas.Add(novaMeta);
        Console.WriteLine("Meta criada com sucesso!");
        Pause();
    }

    public void RegistrarEvento()
    {
        if (_metas.Count == 0)
        {
            Console.WriteLine("Não há metas para registrar evento.");
            Pause();
            return;
        }

        Console.WriteLine("Escolha uma meta:");
        for (int i = 0; i < _metas.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {_metas[i].Nome}");
        }

        Console.Write("Número da meta: ");
        int indice = Convert.ToInt32(Console.ReadLine()) - 1;

        if (indice < 0 || indice >= _metas.Count)
        {
            Console.WriteLine("Índice inválido.");
            Pause();
            return;
        }

        int pontosGanhos = _metas[indice].RegistrarEvento();
        _pontos += pontosGanhos;
        Console.WriteLine($"Evento registrado. Você ganhou {pontosGanhos} pontos.");
        Pause();
    }

    public void SalvarMetas()
    {
        using StreamWriter escritor = new StreamWriter(ArquivoMetas);
        escritor.WriteLine($"Pontuacao|{_pontos}");

        foreach (Meta meta in _metas)
        {
            escritor.WriteLine(meta.ObterRepresentacaoEmTexto());
        }

        Console.WriteLine("Metas salvas com sucesso!");
        Pause();
    }

    public void CarregarMetas()
    {
        if (!File.Exists(ArquivoMetas))
        {
            Console.WriteLine("Arquivo de metas não encontrado.");
            Pause();
            return;
        }

        _metas.Clear();

        string[] linhas = File.ReadAllLines(ArquivoMetas);
        foreach (string linha in linhas)
        {
            if (string.IsNullOrWhiteSpace(linha))
            {
                continue;
            }

            if (linha.StartsWith("Pontuacao|"))
            {
                _pontos = int.Parse(linha.Split('|')[1]);
                continue;
            }

            string[] partes = linha.Split('|');
            string tipo = partes[0];

            switch (tipo)
            {
                case "Simples":
                    _metas.Add(new MetaSimples(partes[1], partes[2], int.Parse(partes[3]), bool.Parse(partes[4])));
                    break;
                case "Eterna":
                    _metas.Add(new MetaEterna(partes[1], partes[2], int.Parse(partes[3])));
                    break;
                case "Lista":
                    _metas.Add(new MetaDeListaDeTarefas(partes[1], partes[2], int.Parse(partes[3]), int.Parse(partes[4]), int.Parse(partes[5]), int.Parse(partes[6])));
                    break;
            }
        }

        Console.WriteLine("Metas carregadas com sucesso!");
        Pause();
    }

    private static void Pause()
    {
        if (Console.IsInputRedirected || Console.IsOutputRedirected)
        {
            Console.WriteLine();
            return;
        }

        Console.WriteLine("Pressione qualquer tecla para continuar...");
        Console.ReadKey();
    }
}
