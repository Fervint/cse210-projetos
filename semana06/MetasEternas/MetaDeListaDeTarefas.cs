public class MetaDeListaDeTarefas : Meta
{
    private int _concluidas;
    private int _total;
    private int _bonus;

    public MetaDeListaDeTarefas(string nome, string descricao, int pontos, int total, int bonus)
        : base(nome, descricao, pontos)
    {
        _concluidas = 0;
        _total = total;
        _bonus = bonus;
    }

    public MetaDeListaDeTarefas(string nome, string descricao, int pontos, int concluidas, int total, int bonus)
        : base(nome, descricao, pontos)
    {
        _concluidas = concluidas;
        _total = total;
        _bonus = bonus;
    }

    public override int RegistrarEvento()
    {
        if (EstaConcluida())
        {
            return 0;
        }

        _concluidas++;

        if (EstaConcluida())
        {
            return _pontos + _bonus;
        }

        return _pontos;
    }

    public override bool EstaConcluida()
    {
        return _concluidas >= _total;
    }

    public override string ObterDetalhesEmTexto()
    {
        return $"{(EstaConcluida() ? "[X]" : "[ ]")} {_nome} - {_descricao} ({_concluidas}/{_total})";
    }

    public override string ObterRepresentacaoEmTexto()
    {
        return $"Lista|{_nome}|{_descricao}|{_pontos}|{_concluidas}|{_total}|{_bonus}";
    }
}
