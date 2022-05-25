namespace ExercicioSupermercado;

public class Produto
{
    private string nome;
    private double preco;
    private int stock;

    public Produto(string nome, double preco, int stock)
    {
        this.nome = nome;
        this.preco = preco;
        this.stock = stock;
    }

    public string Nome => nome;

    public double Preco
    {
        get => preco;
        set => preco = value;
    }

    public int Stock
    {
        get => stock;
        set => stock = value;
    }
}