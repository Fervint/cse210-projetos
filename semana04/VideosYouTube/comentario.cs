using System;

namespace VideosYouTube
{
    public class Comentario
    {
        private string _nome;
        private string _texto;

        public Comentario(string nome, string texto)
        {
            _nome = nome;
            _texto = texto;
        }

        public string GetNome() => _nome;
        public void SetNome(string nome) => _nome = nome;

        public string GetTexto() => _texto;
        public void SetTexto(string texto) => _texto = texto;
    }
}
