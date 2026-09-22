// Biblioteca de Escrituras
// Criei essa classe para guardar várias escrituras e deixar o programa mais dinâmico.
// Em vez de trabalhar só com uma passagem, agora ele escolhe aleatoriamente entre 30 diferentes.
// Isso ajuda a treinar a memorização de várias partes da Bíblia e torna o exercício mais interessante.
// Foi minha forma de ir além dos requisitos básicos e mostrar criatividade no projeto.

using System;
using System.Collections.Generic;

class Biblioteca
{
    private readonly List<Escritura> _escrituras;
    private readonly Random _aleatorio = new Random();

    public Biblioteca()
    {
        _escrituras = new List<Escritura>
        {
            new Escritura(new Referencia("João", 3, 16),
                "Porque Deus amou o mundo de tal maneira que deu o seu Filho unigênito."),
            new Escritura(new Referencia("Provérbios", 3, 5, 6),
                "Confia no Senhor de todo o teu coração e não te apoies no teu próprio entendimento."),
            new Escritura(new Referencia("Salmos", 23, 1),
                "O Senhor é o meu pastor; nada me faltará."),
            new Escritura(new Referencia("Romanos", 8, 28),
                "Sabemos que todas as coisas cooperam para o bem daqueles que amam a Deus."),
            new Escritura(new Referencia("Filipenses", 4, 13),
                "Posso todas as coisas naquele que me fortalece."),
            new Escritura(new Referencia("Mateus", 5, 9),
                "Bem-aventurados os pacificadores, porque eles serão chamados filhos de Deus."),
            new Escritura(new Referencia("Mateus", 11, 28),
                "Vinde a mim todos os que estais cansados e oprimidos, e eu vos aliviarei."),
            new Escritura(new Referencia("Isaías", 41, 10),
                "Não temas, porque eu sou contigo; não te assombres, porque eu sou o teu Deus."),
            new Escritura(new Referencia("Jeremias", 29, 11),
                "Porque eu bem sei os pensamentos que tenho de vós, diz o Senhor."),
            new Escritura(new Referencia("Salmos", 119, 105),
                "Lâmpada para os meus pés é a tua palavra, e luz para o meu caminho."),
            new Escritura(new Referencia("Hebreus", 11, 1),
                "Ora, a fé é o firme fundamento das coisas que se esperam."),
            new Escritura(new Referencia("Tiago", 1, 5),
                "Se algum de vós tem falta de sabedoria, peça-a a Deus."),
            new Escritura(new Referencia("1 Coríntios", 13, 4),
                "O amor é paciente, o amor é bondoso."),
            new Escritura(new Referencia("2 Timóteo", 1, 7),
                "Porque Deus não nos deu espírito de temor, mas de poder."),
            new Escritura(new Referencia("Salmos", 46, 1),
                "Deus é o nosso refúgio e fortaleza, socorro bem presente na angústia."),
            new Escritura(new Referencia("João", 14, 6),
                "Eu sou o caminho, e a verdade e a vida."),
            new Escritura(new Referencia("João", 8, 32),
                "E conhecereis a verdade, e a verdade vos libertará."),
            new Escritura(new Referencia("Mateus", 6, 33),
                "Mas buscai primeiro o reino de Deus e a sua justiça."),
            new Escritura(new Referencia("Salmos", 37, 5),
                "Entrega o teu caminho ao Senhor; confia nele, e ele o fará."),
            new Escritura(new Referencia("Salmos", 91, 1),
                "Aquele que habita no esconderijo do Altíssimo, à sombra do Onipotente descansará."),
            new Escritura(new Referencia("Salmos", 100, 5),
                "Porque o Senhor é bom; a sua misericórdia dura para sempre."),
            new Escritura(new Referencia("Isaías", 40, 31),
                "Mas os que esperam no Senhor renovarão as suas forças."),
            new Escritura(new Referencia("Mateus", 7, 7),
                "Pedi, e dar-se-vos-á; buscai, e encontrareis."),
            new Escritura(new Referencia("Lucas", 6, 31),
                "E como vós quereis que os homens vos façam, da mesma maneira fazei-lhes vós também."),
            new Escritura(new Referencia("João", 15, 13),
                "Ninguém tem maior amor do que este: de dar alguém a sua vida pelos seus amigos."),
            new Escritura(new Referencia("Romanos", 12, 2),
                "E não vos conformeis com este mundo, mas transformai-vos pela renovação da vossa mente."),
            new Escritura(new Referencia("Efésios", 2, 8),
                "Porque pela graça sois salvos, mediante a fé."),
            new Escritura(new Referencia("Colossenses", 3, 23),
                "E tudo quanto fizerdes, fazei-o de todo o coração, como ao Senhor."),
            new Escritura(new Referencia("1 Pedro", 5, 7),
                "Lançando sobre ele toda a vossa ansiedade, porque ele tem cuidado de vós."),
            new Escritura(new Referencia("Apocalipse", 21, 4),
                "E Deus limpará de seus olhos toda a lágrima.")
        };
    }

    public Escritura EscolherAleatoria()
    {
        int indice = _aleatorio.Next(_escrituras.Count);
        return _escrituras[indice];
    }
}
