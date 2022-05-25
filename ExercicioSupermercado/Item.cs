namespace ExercicioSupermercado;

public class Item
{
    private Produto produto;
    private int quantidade;

    public Item(Produto produto, int quantidade)
    {
        this.produto = produto;
        this.quantidade = quantidade;
    }

    public Produto Produto => produto;

    public int Quantidade
    {
        get => quantidade;
        set => quantidade = value;
    }
}