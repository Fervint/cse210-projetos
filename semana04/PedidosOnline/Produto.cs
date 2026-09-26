using System;

namespace PedidosOnline
{
    public class Produto
    {
        private string _nome;
        private string _idProduto;
        private double _precoUnitario;
        private int _quantidade;

        public Produto(string nome, string idProduto, double precoUnitario, int quantidade)
        {
            _nome = nome;
            _idProduto = idProduto;
            _precoUnitario = precoUnitario;
            _quantidade = quantidade;
        }

        public string GetNome() => _nome;
        public void SetNome(string nome) => _nome = nome;

        public string GetIdProduto() => _idProduto;
        public void SetIdProduto(string idProduto) => _idProduto = idProduto;

        public double GetPrecoUnitario() => _precoUnitario;
        public void SetPrecoUnitario(double precoUnitario) => _precoUnitario = precoUnitario;

        public int GetQuantidade() => _quantidade;
        public void SetQuantidade(int quantidade) => _quantidade = quantidade;

        public double CalcularCustoTotal()
        {
            return _precoUnitario * _quantidade;
        }
    }
}
