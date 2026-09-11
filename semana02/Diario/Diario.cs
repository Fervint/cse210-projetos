using System;
using System.Collections.Generic;
using System.IO;

public class Diario
{
    public List<Registro> _registros = new List<Registro>();

    public void AdicionarRegistro(Registro novoRegistro)
    {
        _registros.Add(novoRegistro);
    }

    public void ExibirTodos()
    {
        foreach (Registro registro in _registros)
        {
            registro.Exibir();
        }
    }

    public void SalvarNoArquivo(string arquivo)
    {
        string caminhoCompleto = Path.Combine(Environment.CurrentDirectory, arquivo);

        using (StreamWriter saida = new StreamWriter(caminhoCompleto))
        {
            foreach (Registro registro in _registros)
            {
                saida.WriteLine($"{registro._data}|{registro._textoPergunta}|{registro._textoResposta}");
            }
        }

        Console.WriteLine($"Arquivo '{arquivo}' salvo com sucesso em: {caminhoCompleto}");
    }

    public void CarregarDoArquivo(string arquivo)
    {
        string caminhoExecutavel = Path.Combine(Environment.CurrentDirectory, arquivo);
        string caminhoProjeto = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "..", "..", "..", "semana02", "Diario", arquivo);
        caminhoProjeto = Path.GetFullPath(caminhoProjeto);

        string caminhoFinal = File.Exists(caminhoExecutavel) ? caminhoExecutavel : caminhoProjeto;

        if (File.Exists(caminhoFinal))
        {
            string[] linhas = File.ReadAllLines(caminhoFinal);
            _registros.Clear();

            foreach (string linha in linhas)
            {
                string[] partes = linha.Split('|');
                if (partes.Length == 3)
                {
                    Registro registro = new Registro
                    {
                        _data = partes[0],
                        _textoPergunta = partes[1],
                        _textoResposta = partes[2]
                    };
                    _registros.Add(registro);
                }
            }

            Console.WriteLine($"Arquivo '{arquivo}' carregado com sucesso!");
        }
        else
        {
            Console.WriteLine($"Arquivo '{arquivo}' não encontrado.");
            Console.WriteLine($"Verifique se ele está em: {caminhoExecutavel} ou {caminhoProjeto}");
        }
    }
}