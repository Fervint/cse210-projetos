using System;

public class Registro
{
    public string _data;
    public string _textoPergunta;
    public string _textoResposta;

    public void Exibir()
    {
        Console.WriteLine($"Data: {_data} - Pergunta: {_textoPergunta}");
        Console.WriteLine(_textoResposta);
        Console.WriteLine();
    }
}
