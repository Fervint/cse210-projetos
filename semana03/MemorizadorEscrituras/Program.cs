using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static void Main(string[] args)
    {
        Referencia referencia = new Referencia("João 3:16");
        Escritura escritura = new Escritura(
            referencia,
            "Porque Deus amou o mundo de tal maneira que deu o seu Filho unigênito.");

        escritura.Exibir();

        // O código começa exibindo "escritura" e aguarda que o usuário pressione a tecla Enter
        Console.WriteLine("escritura exibida, pressione Enter para continuar...");
        Console.ReadLine();

        // Oculta uma palavra aleatoria da escritura por vez ao pressionar Enter.
        while (!escritura.EstaCompletamenteEscondida())
        {
            Console.Clear();
            escritura.Exibir();
            Console.WriteLine("pressione Enter para esconder uma palavra aleatória da escritura...");
            Console.ReadLine();
            escritura.EsconderPalavrasAleatorias(1);
        }   

        Console.Clear();
        // Oculta uma palavra aleatória.
        escritura.EsconderPalavrasAleatorias(1);    

        // Sublinhar onde a palavra oculta está no console
        for (int i = 0; i < escritura.ObterTexto().Length; i++)
        {
            Console.Write("_");
        }
        Console.WriteLine();

        // Agora mostra "_______" no console onde costumava estar "palvara" e aguarda que o usuário pressione a tecla Enter
        Console.WriteLine("palavra escondida, pressione Enter para continuar...");
        Console.ReadLine();
    }
}

class Escritura
{
    private readonly Referencia _referencia;
    private readonly List<Palavra> _palavras;

    public Escritura(Referencia referencia, string texto)
    {
        _referencia = referencia;
        _palavras = texto.Split(' ', StringSplitOptions.RemoveEmptyEntries)
            .Select(textoPalavra => new Palavra(textoPalavra))
            .ToList();
    }

    public void EsconderPalavrasAleatorias(int numeroParaEsconder)
    {
        Random aleatorio = new Random();
        foreach (Palavra palavra in _palavras
            .Where(palavra => !palavra.EstaEscondida())
            .OrderBy(_ => aleatorio.Next())
            .Take(numeroParaEsconder))
        {
            palavra.Esconder();
        }
    }

    public string ObterTexto() => string.Join(" ", _palavras.Select(palavra => palavra.ObterTexto()));
    public bool EstaCompletamenteEscondida() => _palavras.All(palavra => palavra.EstaEscondida());
    public void Exibir() => Console.WriteLine($"{_referencia.ObterTexto()} {ObterTexto()}");
}

class Palavra
{
    private readonly string _texto;
    private bool _escondida;

    public Palavra(string texto) => _texto = texto;
    public void Esconder() => _escondida = true;
    public void Exibir() => Console.Write(ObterTexto() + " ");
    public bool EstaEscondida() => _escondida;
    public string ObterTexto() => _escondida ? new string('_', _texto.Length) : _texto;
}

class Referencia
{
    private readonly string _texto;

    public Referencia(string texto) => _texto = texto;
    public string ObterTexto() => _texto;
}

