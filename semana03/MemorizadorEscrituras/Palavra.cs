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
