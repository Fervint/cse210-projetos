using System;

namespace Diario
{
    public class Registro
    {
        public string _data { get; set; }
        public string _textoPergunta { get; set; }
        public string _textoResposta { get; set; }

        public void Exibir()
        {
            Console.WriteLine($"Data: {_data} - Pergunta: {_textoPergunta}");
            Console.WriteLine($"Resposta: {_textoResposta}");
        }
    }
}
