using System;

namespace PedidosOnline
{
    public class Produto
    {
        private string _nome;
        private string _idProduto;
        private double _preco;
        private int _quantidade;

        public Produto(string nome, string codigo, double preco, int quantidade)
        {
            _nome = nome;
            _idProduto = codigo;
            _preco = preco;
            _quantidade = quantidade;
        }

        public string Nome => _nome;
        public string Codigo => _idProduto;
        public double Preco => _preco;
        public int Quantidade => _quantidade;

        public double CalcularCustoTotal() => _preco * _quantidade;
        public string GetNome() => _nome;
        public string GetIdProduto() => _idProduto;
        public double GetPreco() => _preco;
        public int GetQuantidade() => _quantidade;
    }
}
