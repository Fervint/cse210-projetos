public class MetaEterna : Meta
{
    public MetaEterna(string nome, string descricao, int pontos)
        : base(nome, descricao, pontos)
    {
    }

    public override int RegistrarEvento()
    {
        return _pontos;
    }

    public override bool EstaConcluida()
    {
        return false;
    }

    public override string ObterRepresentacaoEmTexto()
    {
        return $"Eterna|{_nome}|{_descricao}|{_pontos}";
    }
}
