using System;
using System.Collections.Generic;

public class GeradorDePerguntas
{
    private readonly List<string> _perguntas = new()
    {
        "Quem foi a pessoa mais interessante com quem interagi hoje?",
        "Qual foi a melhor parte do meu dia?",
        "Como vi a mão do Senhor em minha vida hoje?",
        "Qual foi a emoção mais forte que senti hoje?",
        "Se eu pudesse fazer uma coisa hoje, o que seria?"
    };

    public string ObterPerguntaAleatoria()
    {
        Random aleatorio = new();
        int indice = aleatorio.Next(_perguntas.Count);
        return _perguntas[indice];
    }
}
