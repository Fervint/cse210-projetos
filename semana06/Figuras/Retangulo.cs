public class Retangulo : Forma
{
    private double _comprimento;
    private double _largura;

    public Retangulo(string cor, double comprimento, double largura) : base(cor)
    {
        _comprimento = comprimento;
        _largura = largura;
    }

    // Observe o uso da palavra-chave override aqui
    public override double ObterArea()
    {
        return _comprimento * _largura;
    }
}