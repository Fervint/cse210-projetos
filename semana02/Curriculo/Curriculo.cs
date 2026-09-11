using System;

public class Curriculo
{
    public string _nome;

    // Make sure to initialize your list to a new List before you use it.
    public List<Emprego> _empregos = new List<Emprego>();

    public void Exibir()
    {
        Console.WriteLine($"Nome: {_nome}");
        Console.WriteLine("Empregos:");

        // Notice the use of the custom data type "Job" in this loop
        foreach (Emprego emprego in _empregos)
        {
            // This calls the Display method on each job
            emprego.Exibir();
        }
    }
}

public class Emprego
{
    public string _empresa;
    public string _cargo;
    public string _anoInicio;
    public string _anoFim;

    public void Exibir()
    {
        Console.WriteLine($"{_cargo} em {_empresa} ({_anoInicio} - {_anoFim})");
    }
}