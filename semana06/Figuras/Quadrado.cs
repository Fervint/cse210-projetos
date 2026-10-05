public class Quadrado : Forma
{
    private double _lado;

    public Quadrado(string cor, double lado) : base(cor)
    {
        _lado = lado;
    }

    // Observe o uso da palavra-chave override aqui
    public override double ObterArea()
    {
        return _lado * _lado;
    }
}