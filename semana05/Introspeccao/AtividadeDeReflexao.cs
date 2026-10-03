using System;
using System.Collections.Generic;

public class AtividadeDeReflexao : Atividade
{
    private List<string> _reflexoes;
    private List<string> _perguntas;
    private Random _rand = new Random();

    public AtividadeDeReflexao()
        : base("Reflexão 🤔", "Esta atividade ajudará você a refletir sobre momentos da sua vida em que demonstrou força e resiliência. 💪")
    {
        _reflexoes = new List<string>
        {
            "🌟 Pense em uma ocasião em que você defendeu outra pessoa.",
            "🔥 Pense em uma ocasião em que você fez algo realmente difícil.",
            "🤝 Pense em uma ocasião em que você ajudou alguém necessitado.",
            "💖 Pense em uma ocasião em que você fez algo verdadeiramente altruísta."
        };

        _perguntas = new List<string>
        {
            "❓ Por que essa experiência foi significativa para você?",
            "🔄 Você já fez algo assim antes?",
            "🚀 Como você começou?",
            "😊 Como você se sentiu quando terminou?",
            "⚡ O que tornou esse momento diferente de outras vezes?",
            "🪞 O que você aprendeu sobre si mesmo por meio dessa experiência?"
        };
    }

    public void Executar()
    {
        ExibirMensagemInicial();
        ExibirReflexoes();

        DateTime fim = DateTime.Now.AddSeconds(_duracao);
        List<string> usadas = new List<string>();

        while (DateTime.Now < fim)
        {
            string pergunta = ObterPerguntaAleatoria(usadas);
            Console.Write($"\n{pergunta} ");
            int segundosRestantes = (int)Math.Ceiling((fim - DateTime.Now).TotalSeconds);
            ExibirReloginho(Math.Min(4, segundosRestantes));
        }

        ExibirMensagemFinal();
    }

    private void ExibirReflexoes()
    {
        string reflexao = _reflexoes[_rand.Next(_reflexoes.Count)];
        Console.Write($"\n{reflexao} ");
        ExibirReloginho(3);
    }

    private string ObterPerguntaAleatoria(List<string> usadas)
    {
        if (usadas.Count == _perguntas.Count) usadas.Clear();

        string pergunta;
        do
        {
            pergunta = _perguntas[_rand.Next(_perguntas.Count)];
        } while (usadas.Contains(pergunta));

        usadas.Add(pergunta);
        return pergunta;
    }
}
