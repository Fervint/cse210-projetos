using System;
using System.Collections.Generic;

class Produto
{
    private string nome;
    private string idProduto;
    private double precoUnitario;
    private int quantidade;

    public Produto(string nome, string idProduto, double precoUnitario, int quantidade)
    {
        this.nome = nome;
        this.idProduto = idProduto;
        this.precoUnitario = precoUnitario;
        this.quantidade = quantidade;
    }

    public string GetNome() => nome;
    public string GetIdProduto() => idProduto;
    public double GetPrecoUnitario() => precoUnitario;
    public int GetQuantidade() => quantidade;

    public double CalcularCustoTotal()
    {
        return precoUnitario * quantidade;
    }
}

class Endereco
{
    private string rua;
    private string cidade;
    private string estado;
    private string pais;

    public Endereco(string rua, string cidade, string estado, string pais)
    {
        this.rua = rua;
        this.cidade = cidade;
        this.estado = estado;
        this.pais = pais;
    }

    public bool EhNosEUA()
    {
        return pais.ToUpper() == "EUA";
    }

    public string GetEnderecoCompleto()
    {
        return $"{rua}\n{cidade}, {estado}\n{pais}";
    }
}

class Cliente
{
    private string nome;
    private Endereco endereco;

    public Cliente(string nome, Endereco endereco)
    {
        this.nome = nome;
        this.endereco = endereco;
    }

    public string GetNome() => nome;
    public Endereco GetEndereco() => endereco;

    public bool MoraNosEUA()
    {
        return endereco.EhNosEUA();
    }
}

class Pedido
{
    private List<Produto> produtos = new List<Produto>();
    private Cliente cliente;

    public Pedido(Cliente cliente)
    {
        this.cliente = cliente;
    }

    public void AdicionarProduto(Produto produto)
    {
        produtos.Add(produto);
    }

    public double CalcularPrecoTotal()
    {
        double total = 0;
        foreach (Produto p in produtos)
        {
            total += p.CalcularCustoTotal();
        }

        // custo de envio
        total += cliente.MoraNosEUA() ? 5 : 35;
        return total;
    }

    public string GetEtiquetaEmbalagem()
    {
        string etiqueta = "Etiqueta de Embalagem:\n";
        foreach (Produto p in produtos)
        {
            etiqueta += $"{p.GetNome()} (ID: {p.GetIdProduto()})\n";
        }
        return etiqueta;
    }

    public string GetEtiquetaEnvio()
    {
        return $"Etiqueta de Envio:\n{cliente.GetNome()}\n{cliente.GetEndereco().GetEnderecoCompleto()}";
    }
}

class Program
{
    static void Main(string[] args)
    {
        // Cliente nos EUA
        Endereco endereco1 = new Endereco("123 Main St", "New York", "NY", "EUA");
        Cliente cliente1 = new Cliente("John Doe", endereco1);
        Pedido pedido1 = new Pedido(cliente1);
        pedido1.AdicionarProduto(new Produto("Mouse", "P001", 20.0, 2));
        pedido1.AdicionarProduto(new Produto("Teclado", "P002", 50.0, 1));

        // Cliente fora dos EUA
        Endereco endereco2 = new Endereco("Av. Brasil, 456", "São Paulo", "SP", "Brasil");
        Cliente cliente2 = new Cliente("Maria Silva", endereco2);
        Pedido pedido2 = new Pedido(cliente2);
        pedido2.AdicionarProduto(new Produto("Monitor", "P003", 800.0, 1));
        pedido2.AdicionarProduto(new Produto("Headset", "P004", 200.0, 2));

        // Exibir resultados
        List<Pedido> pedidos = new List<Pedido> { pedido1, pedido2 };

        foreach (Pedido p in pedidos)
        {
            Console.WriteLine(p.GetEtiquetaEmbalagem());
            Console.WriteLine(p.GetEtiquetaEnvio());
            Console.WriteLine($"Preço Total: ${p.CalcularPrecoTotal()}\n");
        }
    }
}
