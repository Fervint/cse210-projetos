using System;
using System.Collections.Generic;
using System.Linq;

class Escritura
{
    private readonly Referencia _referencia;
    private readonly List<Palavra> _palavras;

    public Escritura(Referencia referencia, string texto)
    {
        _referencia = referencia;
        _palavras = texto.Split(' ', StringSplitOptions.RemoveEmptyEntries)
            .Select(p => new Palavra(p))
            .ToList();
    }

    public void EsconderPalavrasAleatorias(int numeroParaEsconder)
    {
        Random aleatorio = new Random();
        var palavrasVisiveis = _palavras.Where(p => !p.EstaEscondida()).ToList();

        foreach (Palavra palavra in palavrasVisiveis
            .OrderBy(_ => aleatorio.Next())
            .Take(numeroParaEsconder))
        {
            palavra.Esconder();
        }
    }

    public void RevelarTodas()
    {
        foreach (Palavra palavra in _palavras)
        {
            palavra.Revelar();
        }
    }

    public bool EstaCompletamenteEscondida()
    {
        return _palavras.All(p => p.EstaEscondida());
    }

    public int PalavrasEscondidas()
    {
        return _palavras.Count(p => p.EstaEscondida());
    }

    public int TotalPalavras()
    {
        return _palavras.Count;
    }

    public string ObterTexto()
    {
        return string.Join(" ", _palavras.Select(p => p.ObterTexto()));
    }

    public void Exibir()
    {
        Console.WriteLine($"{_referencia.ObterTexto()} {ObterTexto()}");
    }
}
