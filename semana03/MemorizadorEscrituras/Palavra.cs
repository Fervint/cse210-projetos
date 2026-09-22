// Classe Palavra
// Essa classe representa cada palavra individual da escritura.
// Ela guarda o texto original e controla se a palavra está visível ou escondida.
// Também tem os métodos para esconder, verificar se está escondida
// e retornar o texto de exibição (a palavra ou os sublinhados).
// Fiz assim para deixar o código mais organizado e seguir o princípio de encapsulamento.

class Palavra
{
    private readonly string _texto;
    private bool _escondida;

    public Palavra(string texto)
    {
        _texto = texto;
        _escondida = false;
    }

    public void Esconder() => _escondida = true;
    public void Revelar() => _escondida = false;
    public bool EstaEscondida() => _escondida;
    public string ObterTexto() => _escondida ? new string('_', _texto.Length) : _texto;
}
