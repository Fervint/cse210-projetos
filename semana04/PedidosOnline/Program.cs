using System;
using System.Collections.Generic;

namespace VideosYouTube
{
    class Comentario
    {
        public string Autor { get; }
        public string Texto { get; }

        public Comentario(string autor, string texto)
        {
            Autor = autor;
            Texto = texto;
        }
    }

    class Video
    {
        public string Titulo { get; }
        public string Autor { get; }
        public int Duracao { get; }
        private List<Comentario> comentarios;

        public Video(string titulo, string autor, int duracao)
        {
            Titulo = titulo;
            Autor = autor;
            Duracao = duracao;
            comentarios = new List<Comentario>();
        }

        public void AdicionarComentario(Comentario comentario)
        {
            comentarios.Add(comentario);
        }

        public void ExibirInformacoes()
        {
            Console.WriteLine($"Título: {Titulo}");
            Console.WriteLine($"Autor: {Autor}");
            Console.WriteLine($"Duração: {Duracao} segundos");
            Console.WriteLine($"Quantidade de comentários: {comentarios.Count}");

            foreach (Comentario comentario in comentarios)
            {
                Console.WriteLine($"- {comentario.Autor}: {comentario.Texto}");
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
}
