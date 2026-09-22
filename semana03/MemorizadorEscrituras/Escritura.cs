// Classe Escritura
// Essa classe é responsável por controlar a passagem bíblica completa.
// Ela guarda a referência e todas as palavras do texto em forma de objetos Palavra.
// Também tem os métodos para esconder palavras aleatórias, verificar se já está tudo escondido,
// revelar todas as palavras e exibir o texto atualizado no console.
// Fiz dessa forma para manter o encapsulamento e deixar o código mais organizado.

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

    public string ObterTexto()
    {
        return string.Join(" ", _palavras.Select(p => p.ObterTexto()));
    }

    public void Exibir()
    {
        Console.WriteLine($"{_referencia.ObterTexto()} {ObterTexto()}");
    }
}
