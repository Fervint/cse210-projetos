using System;
using System.Collections.Generic;

namespace VideosYouTube
{
    public class Video
    {
        private string _titulo;
        private string _autor;
        private int _duracaoSegundos;
        private List<Comentario> _comentarios = new List<Comentario>();

        public Video(string titulo, string autor, int duracaoSegundos)
        {
            _titulo = titulo;
            _autor = autor;
            _duracaoSegundos = duracaoSegundos;
        }

        public string GetTitulo() => _titulo;
        public void SetTitulo(string titulo) => _titulo = titulo;

        public string GetAutor() => _autor;
        public void SetAutor(string autor) => _autor = autor;

        public int GetDuracaoSegundos() => _duracaoSegundos;
        public void SetDuracaoSegundos(int duracao) => _duracaoSegundos = duracao;

        public void AdicionarComentario(Comentario comentario)
        {
            _comentarios.Add(comentario);
        }

        public int ObterNumeroComentarios()
        {
            return _comentarios.Count;
        }

        public void ExibirInformacoes()
        {
            Console.WriteLine($"Título: {_titulo}");
            Console.WriteLine($"Autor: {_autor}");
            Console.WriteLine($"Duração: {_duracaoSegundos} segundos");
            Console.WriteLine($"Número de comentários: {ObterNumeroComentarios()}");
            Console.WriteLine("Comentários:");
            foreach (Comentario c in _comentarios)
            {
                Console.WriteLine($"- {c.GetNome()}: {c.GetTexto()}");
            }
            Console.WriteLine();
        }
    }
}
