using System;
using System.Collections.Generic;
using System.Linq;

namespace PedidosOnline
{
    public class PedidoProgram
    {
        private readonly List<Produto> produtos;
        public Cliente Cliente { get; }

        public PedidoProgram(Cliente cliente)
        {
            Cliente = cliente;
            produtos = new List<Produto>();
        }

        public void AdicionarProduto(Produto produto)
        {
            produtos.Add(produto);
        }

        public double CalcularPrecoTotal()
        {
            return produtos.Sum(p => p.Preco * p.Quantidade);
        }

        public string GetEtiquetaEmbalagem()
        {
            string etiqueta = "Etiqueta de Embalagem:\n";
            etiqueta += $"Cliente: {Cliente.Nome}\n";
            etiqueta += $"Endereço: {Cliente.Endereco}\n";
            etiqueta += "Produtos:\n";

            foreach (var produto in produtos)
            {
                etiqueta += $"- {produto.Nome} ({produto.Codigo}) x{produto.Quantidade}\n";
            }

            return etiqueta;
        }

        public string GetEtiquetaEnvio()
        {
            return $"Etiqueta de Envio:\nCliente: {Cliente.Nome}\nEndereço: {Cliente.Endereco}\n";
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Endereco endereco1 = new Endereco("123 Main St", "New York", "NY", "EUA");
            Cliente cliente1 = new Cliente("John Doe", endereco1);
            PedidoProgram pedido1 = new PedidoProgram(cliente1);
            pedido1.AdicionarProduto(new Produto("Mouse", "P001", 20.0, 2));
            pedido1.AdicionarProduto(new Produto("Teclado", "P002", 50.0, 1));

            Endereco endereco2 = new Endereco("Av. Brasil, 456", "São Paulo", "SP", "Brasil");
            Cliente cliente2 = new Cliente("Maria Silva", endereco2);
            PedidoProgram pedido2 = new PedidoProgram(cliente2);
            pedido2.AdicionarProduto(new Produto("Monitor", "P003", 800.0, 1));
            pedido2.AdicionarProduto(new Produto("Headset", "P004", 200.0, 2));

            List<PedidoProgram> pedidos = new List<PedidoProgram> { pedido1, pedido2 };

            foreach (PedidoProgram p in pedidos)
            {
                Console.WriteLine(p.GetEtiquetaEmbalagem());
                Console.WriteLine(p.GetEtiquetaEnvio());
                Console.WriteLine($"Preço Total: ${p.CalcularPrecoTotal()}\n");
            }
        }
    }
}
