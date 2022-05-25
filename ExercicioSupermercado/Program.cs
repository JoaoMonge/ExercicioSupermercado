
using System.Reflection;
using ExercicioSupermercado;

Produto p1 = new Produto("Cafe",12.3,34);
Produto p2 = new Produto("Gelado",3.4,12);
Produto p3 = new Produto("Papel",0.5,6);

List<Produto> produtosNaLoja = new List<Produto>();
produtosNaLoja.Add(p1);
produtosNaLoja.Add(p2);
produtosNaLoja.Add(p3);


novocliente:
Console.WriteLine("Bem vindo!");
List<Item> listaCompras = new List<Item>();

while (true)
{
    Console.WriteLine("Escolha um produto:");
    var i = 1;
    foreach (var p in produtosNaLoja)
    {
        Console.WriteLine("{0}) {1}",i,p.Nome);
        i++;
    }
escolhaopcao:
    var opcao = Int16.Parse(Console.ReadLine());
    if (opcao > 1 && opcao < produtosNaLoja.Count)
    {
        Console.WriteLine("Digite a quantidade pretendida:");
        escolhaquantidade:
        var quantidade = Int16.Parse(Console.ReadLine());
        var stock = produtosNaLoja[opcao - 1].Stock;
        if (stock >= quantidade)
        {
            var item = new Item(produtosNaLoja[opcao - 1], quantidade);
            listaCompras.Add(item);
        }
        else
        {
            Console.WriteLine("Não existe stock suficiente. Apenas {0}.\n.",stock);
            Console.WriteLine("Escolha de novo uma quantidade dentro do stock existente.");
            goto escolhaquantidade;
        }
    }
    else
    {
        Console.WriteLine("Opção inválida. Tente de novo:");
        goto escolhaopcao;
    }
    Console.WriteLine("Deseja continuar as compras: S ou N?");
    var sn = Console.ReadLine();
    if (sn.ToLower() != "s")
    {
        break;
    }
}

double total = 0.0;
foreach (var item in listaCompras)
{
    total += item.Quantidade * item.Produto.Preco;
}
Console.WriteLine("Total: {0} €",total);
escolhameiopag:
Console.WriteLine("Escolha o meio de pagamento:\n 1)Multibanco\n 2)Cheque\n 3)Dinheiro");
int opcaoPagamento = Int16.Parse(Console.ReadLine());
switch (opcaoPagamento)
{
    case 1:
        Console.WriteLine("Pagamento por multibanco.");
        break;
    case 2:
        Console.WriteLine("Pagamento por cheque.");
        break;
    case 3:
        Console.WriteLine("Pagamento por dinheiro.");
        break;
    default:
        Console.WriteLine("Opção de pagamento inválida. Volte a tentar.");
        goto escolhameiopag;
}

foreach (var p in listaCompras)
{
    p.Produto.Stock -= p.Quantidade;
}

Console.WriteLine("Obrigado e volte sempre.");
Console.WriteLine("Próximo cliente!!!");
goto novocliente;