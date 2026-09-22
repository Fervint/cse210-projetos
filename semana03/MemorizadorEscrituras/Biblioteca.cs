using System;
using System.Collections.Generic;
using System.IO;

class Biblioteca
{
    private readonly List<Escritura> _escrituras;
    private readonly Random _aleatorio = new Random();

    public Biblioteca()
    {
        _escrituras = new List<Escritura>();

        // Localiza o arquivo automaticamente
        string caminhoArquivo = LocalizarArquivo();

        if (caminhoArquivo == null)
        {
            Console.WriteLine("Arquivo 'escrituras.txt' não encontrado!");
            Console.WriteLine("Verifique se ele está na pasta do projeto ou na pasta do executável (bin/Debug/net8.0).");
            Console.WriteLine("Pressione Enter para sair...");
            Console.ReadLine();
            Environment.Exit(0);
        }

        var linhas = File.ReadAllLines(caminhoArquivo);
        foreach (var linha in linhas)
        {
            var partes = linha.Split('|');
            if (partes.Length == 4)
            {
                string livro = partes[0];
                int capitulo = int.Parse(partes[1]);
                int versiculo = int.Parse(partes[2]);
                string texto = partes[3];

                _escrituras.Add(new Escritura(new Referencia(livro, capitulo, versiculo), texto));
            }
        }
    }

    // Método que procura o arquivo em vários locais possíveis
    private string LocalizarArquivo()
    {
        string[] caminhosPossiveis =
        {
            Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "escrituras.txt"),
            Path.Combine(Directory.GetCurrentDirectory(), "escrituras.txt"),
            Path.Combine(Directory.GetCurrentDirectory(), "semana03", "MemorizadorEscrituras", "escrituras.txt")
        };

        foreach (var caminho in caminhosPossiveis)
        {
            if (File.Exists(caminho))
                return caminho;
        }

        return null;
    }

    public Escritura EscolherAleatoria()
    {
        int indice = _aleatorio.Next(_escrituras.Count);
        return _escrituras[indice];
    }
}
