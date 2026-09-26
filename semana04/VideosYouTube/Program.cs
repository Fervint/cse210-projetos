using System;
using System.Collections.Generic;

class Comentario
{
    public string Nome { get; set; }
    public string Texto { get; set; }

    public Comentario(string nome, string texto)
    {
        Nome = nome;
        Texto = texto;
    }
}

class Video
{
    public string Titulo { get; set; }
    public string Autor { get; set; }
    public int DuracaoSegundos { get; set; }
    private List<Comentario> comentarios = new List<Comentario>();

    public Video(string titulo, string autor, int duracaoSegundos)
    {
        Titulo = titulo;
        Autor = autor;
        DuracaoSegundos = duracaoSegundos;
    }

    public void AdicionarComentario(Comentario comentario)
    {
        comentarios.Add(comentario);
    }

    public int ObterNumeroComentarios()
    {
        return comentarios.Count;
    }

    public void ExibirInformacoes()
    {
        Console.WriteLine($"Título: {Titulo}");
        Console.WriteLine($"Autor: {Autor}");
        Console.WriteLine($"Duração: {DuracaoSegundos} segundos");
        Console.WriteLine($"Número de comentários: {ObterNumeroComentarios()}");
        Console.WriteLine("Comentários:");
        foreach (Comentario c in comentarios)
        {
            Console.WriteLine($"- {c.Nome}: {c.Texto}");
        }
        Console.WriteLine();
    }
}

class Program
{
    static void Main(string[] args)
    {
        // Criando vídeos
        Video video1 = new Video("Aprendendo C#", "Fabio Dev", 600);
        video1.AdicionarComentario(new Comentario("Maria", "Ótima explicação!"));
        video1.AdicionarComentario(new Comentario("João", "Muito útil, obrigado."));
        video1.AdicionarComentario(new Comentario("Ana", "Gostei bastante do exemplo."));

        Video video2 = new Video("Receita de Bolo", "Cozinha Fácil", 510);
        video2.AdicionarComentario(new Comentario("Carlos", "Fiz e deu super certo!"));
        video2.AdicionarComentario(new Comentario("Fernanda", "Delicioso, recomendo."));
        video2.AdicionarComentario(new Comentario("Paulo", "Vou tentar no fim de semana."));

        Video video3 = new Video("Treino em Casa", "Fitness Brasil", 900);
        video3.AdicionarComentario(new Comentario("Luiza", "Excelente treino!"));
        video3.AdicionarComentario(new Comentario("Ricardo", "Suando muito aqui!"));
        video3.AdicionarComentario(new Comentario("Beatriz", "Adorei, fácil de seguir."));

        // Lista de vídeos
        List<Video> listaVideos = new List<Video> { video1, video2, video3 };

        // Exibindo informações
        foreach (Video v in listaVideos)
        {
            v.ExibirInformacoes();
        }
    }
}
