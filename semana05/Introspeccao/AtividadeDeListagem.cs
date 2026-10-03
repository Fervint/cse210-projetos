using System;
using System.Collections.Generic;

public class AtividadeDeListagem : Atividade
{
    private int _contador;
    private List<string> _perguntas;
    private Random _rand = new Random();

    public AtividadeDeListagem()
        : base("Listagem 📋", "Esta atividade ajudará você a refletir sobre as coisas boas da sua vida, listando o máximo de itens que puder. 🌈")
    {
        _perguntas = new List<string>
        {
            "👥 Quem são as pessoas que você aprecia?",
            "💪 Quais são seus pontos fortes pessoais?",
            "🤝 Quem são as pessoas que você ajudou esta semana?",
            "✨ Quando você sentiu o Espírito Santo neste mês?",
            "🦸‍♂️ Quem são alguns dos seus heróis pessoais?"
        };
    }

    public void Executar()
    {
        ExibirMensagemInicial();
        string pergunta = ObterPerguntaAleatoria();
        Console.WriteLine($"\n{pergunta}");
        Console.Write("⏳ Você terá alguns segundos para pensar... ");
        ExibirReloginho(5);

        List<string> respostas = ObterListaDoUsuario();
        _contador = respostas.Count;

        Console.WriteLine($"\n🎉 Você listou {_contador} itens!");
        ExibirMensagemFinal();
    }

    private string ObterPerguntaAleatoria()
    {
        return _perguntas[_rand.Next(_perguntas.Count)];
    }

    private List<string> ObterListaDoUsuario()
    {
        List<string> lista = new List<string>();
        DateTime fim = DateTime.Now.AddSeconds(_duracao);

        while (DateTime.Now < fim)
        {
            int segundosRestantes = (int)Math.Ceiling((fim - DateTime.Now).TotalSeconds);
            Console.Write($"\n⏱️ Restam {segundosRestantes} segundos... ✍️ Digite um item: ");
            string resposta = Console.ReadLine();

            if (DateTime.Now >= fim)
            {
                break;
            }

            if (!string.IsNullOrWhiteSpace(resposta))
            {
                lista.Add(resposta);
            }
        }

        return lista;
    }
}
