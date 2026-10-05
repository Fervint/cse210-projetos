using System;

class Program
{
    static void Main(string[] args)
    {
        // Observe que a lista é uma lista de objetos "Forma". Isso significa que
        // você pode colocar qualquer objeto Forma nela, assim como qualquer objeto cuja
        // classe herde de Forma.
        List<Forma> formas = new List<Forma>();

        Quadrado f1 = new Quadrado("Vermelho", 3);
        formas.Add(f1);

        Retangulo f2 = new Retangulo("Azul", 4, 5);
        formas.Add(f2);

        Circulo f3 = new Circulo("Verde", 6);
        formas.Add(f3);

        foreach (Forma f in formas)
        {
            // Observe que todas as formas possuem um método ObterCor da classe base
            string cor = f.ObterCor();

            // Observe que todas as formas possuem um método ObterArea, mas o comportamento é
            // diferente para cada tipo de forma
            double area = f.ObterArea();

            Console.WriteLine($"A forma {cor} tem uma area de {area}.");
        }
    }
}