using System;
using System.Threading;

public class Atividade
{
    protected string _nome;
    protected string _descricao;
    protected int _duracao;

    public Atividade(string nome, string descricao)
    {
        _nome = nome;
        _descricao = descricao;
    }

    public void ExibirMensagemInicial()
    {
        Console.Clear();
        Console.WriteLine($"Bem-vindo à atividade: {_nome}");
        Console.WriteLine(_descricao);
        Console.Write("\nDigite a duração em segundos: ");
        _duracao = int.Parse(Console.ReadLine());
        Console.Write("Prepare-se para começar... ");
        ExibirReloginho(3);
    }

    public void ExibirMensagemFinal()
    {
        Console.WriteLine("\nExcelente trabalho!");
        Console.Write($"Você concluiu a atividade {_nome} por {_duracao} segundos... ");
        ExibirReloginho(3);
    }

    public void ExibirProgresso(int segundos)
    {
        ExibirContagemRegressiva(segundos);
    }

    public void ExibirContagemRegressiva(int segundos)
    {
        ExibirContagemRegressiva(segundos, true);
    }

    protected void ExibirContagemRegressiva(int segundos, bool quebrarLinha)
    {
        for (int i = segundos; i > 0; i--)
        {
            Console.Write($"{i}... ");
            Thread.Sleep(1000);
        }

        if (quebrarLinha)
        {
            Console.WriteLine();
        }
    }

    protected static void ExibirReloginho(int segundos)
    {
        string[] simbolos = { "|", "/", "-", "\\" };

        for (int i = 0; i < segundos; i++)
        {
            Console.Write(simbolos[i % simbolos.Length]);
            Thread.Sleep(1000);
            Console.Write("\b \b");
        }

        Console.WriteLine();
    }
}
