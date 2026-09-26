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

            // Taxa de envio: $5 para EUA, $35 para outros países
            total += _cliente.MoraNosEUA() ? 5 : 35;
            return total;
        }

        public string GetEtiquetaEmbalagem()
        {
            string etiqueta = "Etiqueta de Embalagem:\n";
            etiqueta += $"Cliente: {_cliente.GetNome()}\n";
            etiqueta += $"Endereço:\n{_cliente.GetEndereco().GetEnderecoCompleto()}\n";
            etiqueta += "Produtos:\n";
            foreach (Produto p in _produtos)
            {
                etiqueta += $"- {p.GetNome()} ({p.GetIdProduto()}) x{p.GetQuantidade()}\n";
            }
            return etiqueta;
        }

        public string GetEtiquetaEnvio()
        {
            return $"Etiqueta de Envio:\nCliente: {_cliente.GetNome()}\nEndereço:\n{_cliente.GetEndereco().GetEnderecoCompleto()}";
        }
    }
}
