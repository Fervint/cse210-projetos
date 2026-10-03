using System;
using System.Threading;

public class AtividadeDeRespiracao : Atividade
{
    public AtividadeDeRespiracao()
        : base("Respiração 🧘‍♂️", "Esta atividade ajudará você a relaxar, inspirando e expirando lentamente. 🌿 Limpe sua mente e concentre-se na sua respiração.")
    {
    }

    public void Executar()
    {
        ExibirMensagemInicial();
        DateTime fim = DateTime.Now.AddSeconds(_duracao);

        while (DateTime.Now < fim)
        {
            Console.Write("\nInspire... ");
            ExibirContagemRespiracao(1, 4);

            Console.Write(" Agora expire... ");
            ExibirContagemRespiracao(6, 1);
        }

        ExibirMensagemFinal();
    }

    private static void ExibirContagemRespiracao(int inicio, int fim)
    {
        int passo = inicio <= fim ? 1 : -1;

        for (int i = inicio; passo > 0 ? i <= fim : i >= fim; i += passo)
        {
            Console.Write(i);
            Thread.Sleep(1000);
            Console.Write("\b \b");
        }
    }
}
