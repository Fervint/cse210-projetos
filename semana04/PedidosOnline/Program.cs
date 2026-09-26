using System;
using System.Collections.Generic;
using PedidosOnline;

namespace PedidosOnline
{
    class Program
    {
        static void Main(string[] args)
        {
            Endereco endereco1 = new Endereco("123 Main St", "New York", "NY", "EUA");
            Cliente cliente1 = new Cliente("John Doe", endereco1);
            Pedido pedido1 = new Pedido(cliente1);
            pedido1.AdicionarProduto(new Produto("Mouse", "P001", 20.0, 2));
            pedido1.AdicionarProduto(new Produto("Teclado", "P002", 50.0, 1));

            Endereco endereco2 = new Endereco("Av. Brasil, 456", "São Paulo", "SP", "Brasil");
            Cliente cliente2 = new Cliente("Maria Silva", endereco2);
            Pedido pedido2 = new Pedido(cliente2);
            pedido2.AdicionarProduto(new Produto("Monitor", "P003", 800.0, 1));
            pedido2.AdicionarProduto(new Produto("Headset", "P004", 200.0, 2));

            List<Pedido> pedidos = new List<Pedido> { pedido1, pedido2 };

            foreach (Pedido p in pedidos)
            {
                Console.WriteLine(p.GetEtiquetaEmbalagem());
                Console.WriteLine(p.GetEtiquetaEnvio());
                Console.WriteLine($"Preço Total: ${p.CalcularPrecoTotal()}\n");
            }
        }
    }
}
