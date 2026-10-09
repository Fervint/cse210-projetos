public class MetaSimples : Meta
{
    private bool _estaConcluida;

    public MetaSimples(string nome, string descricao, int pontos)
        : base(nome, descricao, pontos)
    {
        _estaConcluida = false;
    }

    public MetaSimples(string nome, string descricao, int pontos, bool estaConcluida)
        : base(nome, descricao, pontos)
    {
        _estaConcluida = estaConcluida;
    }

    public override int RegistrarEvento()
    {
        if (_estaConcluida)
        {
            return 0;
        }

        _estaConcluida = true;
        return _pontos;
    }

    public override bool EstaConcluida()
    {
        return _estaConcluida;
    }

    public override string ObterRepresentacaoEmTexto()
    {
        return $"Simples|{_nome}|{_descricao}|{_pontos}|{(_estaConcluida ? "true" : "false")}";
    }
}
