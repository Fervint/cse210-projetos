using System;
using System.Collections.Generic;

namespace PedidosOnline
{
    public class Pedido
    {
        private List<Produto> _produtos = new List<Produto>();
        private Cliente _cliente;

        public Pedido(Cliente cliente)
        {
            _cliente = cliente;
        }

        public void AdicionarProduto(Produto produto)
        {
            _produtos.Add(produto);
        }

        public double CalcularPrecoTotal()
        {
            double total = 0;
            foreach (Produto p in _produtos)
            {
                total += p.CalcularCustoTotal();
            }

            total += _cliente.MoraNosEUA() ? 5 : 35;
            return total;
        }

        public string GetEtiquetaEmbalagem()
        {
            string etiqueta = "Etiqueta de Embalagem:\n";
            foreach (Produto p in _produtos)
            {
                etiqueta += $"{p.GetNome()} (ID: {p.GetIdProduto()})\n";
            }
            return etiqueta;
        }

        public string GetEtiquetaEnvio()
        {
            return $"Etiqueta de Envio:\n{_cliente.GetNome()}\n{_cliente.GetEndereco().GetEnderecoCompleto()}";
        }
    }
}
