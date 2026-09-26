using System;

namespace PedidosOnline
{
    public class Endereco
    {
        private string _rua;
        private string _cidade;
        private string _estado;
        private string _pais;

        public Endereco(string rua, string cidade, string estado, string pais)
        {
            _rua = rua;
            _cidade = cidade;
            _estado = estado;
            _pais = pais;
        }

        public string GetRua() => _rua;
        public void SetRua(string rua) => _rua = rua;

        public string GetCidade() => _cidade;
        public void SetCidade(string cidade) => _cidade = cidade;

        public string GetEstado() => _estado;
        public void SetEstado(string estado) => _estado = estado;

        public string GetPais() => _pais;
        public void SetPais(string pais) => _pais = pais;

        public bool EhNosEUA()
        {
            return _pais.ToUpper() == "EUA";
        }

        public string GetEnderecoCompleto()
        {
            return $"{_rua}\n{_cidade}, {_estado}\n{_pais}";
        }
    }
}
