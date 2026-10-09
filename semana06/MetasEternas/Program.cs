using System;

// Projeto: Metas Eternas
// A ideia deste programa é transformar hábitos e objetivos em uma experiência de progresso,
// onde o usuário pode criar metas, registrar conquistas e acompanhar sua pontuação.
// Aqui a criatividade ficou em um pequeno "banner" inicial para deixar o programa mais acolhedor.

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("========================================");
        Console.WriteLine("         METAS ETERNAS");
        Console.WriteLine("  A jornada do seu progresso começa aqui");
        Console.WriteLine("========================================");
        Console.WriteLine();

        GerenciadorDeMetas gerenciador = new GerenciadorDeMetas();
        gerenciador.Iniciar();
    }
}