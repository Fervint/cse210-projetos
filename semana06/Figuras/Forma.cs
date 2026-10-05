// Veja o comentário abaixo sobre o método abstrato. Como temos um método abstrato,
// esta classe também deve ser declarada como uma classe abstrata.
public abstract class Forma
{
    private string _cor;

    public Forma(string cor)
    {
        _cor = cor;
    }

    public string ObterCor()
    {
        return _cor;
    }

    public void DefinirCor(string cor)
    {
        _cor = cor;
    }

    // Como não faz sentido definir um corpo padrão para este método na classe base,
    // em vez de criar uma função "virtual" aqui, como:
    //
    // public virtual double GetArea()
    // {
    //     return 0;
    // }
    //
    // Podemos, em vez disso, declarar a função como uma função "abstrata". Isso significa
    // que ela é uma função virtual vazia que deve ser implementada ou "preenchida" por
    // qualquer classe que herde de Forma. Então, qualquer classe que tenha um método abstrato
    // também deve ser declarada como abstrata.
    public abstract double ObterArea();
}