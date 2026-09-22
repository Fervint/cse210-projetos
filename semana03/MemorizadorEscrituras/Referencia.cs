class Referencia
{
    private readonly string _livro;
    private readonly int _capitulo;
    private readonly int _versiculo;
    private readonly int _ultimoVersiculo;

    public Referencia(string livro, int capitulo, int versiculo)
    {
        _livro = livro;
        _capitulo = capitulo;
        _versiculo = versiculo;
        _ultimoVersiculo = versiculo;
    }

    public Referencia(string livro, int capitulo, int versiculoInicial, int versiculoFinal)
    {
        _livro = livro;
        _capitulo = capitulo;
        _versiculo = versiculoInicial;
        _ultimoVersiculo = versiculoFinal;
    }

    public string ObterTexto()
    {
        if (_versiculo == _ultimoVersiculo)
            return $"{_livro} {_capitulo}:{_versiculo}";
        else
            return $"{_livro} {_capitulo}:{_versiculo}-{_ultimoVersiculo}";
    }
}
