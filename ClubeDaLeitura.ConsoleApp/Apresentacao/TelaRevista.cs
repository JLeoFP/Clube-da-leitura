

using ClubeDaLeitura.ConsoleApp.Dominio;
using ClubeDaLeitura.ConsoleApp.Infraestrutura;

namespace ClubeDaLeitura.ConsoleApp.Apresentacao;

public class TelaRevista : TelaBase
{       
    private RepositorioCaixa repositorioCaixa;
    private RepositorioRevista repositorioRevista;

    public TelaRevista(RepositorioRevista rR, RepositorioCaixa rC) : base("Revista", rR)
    {
        repositorioRevista = rR;
        repositorioCaixa = rC;
    }

    protected override EntidadeBase ObterDatosCadatrais()
    {
        Console.WriteLine("Digite o titulo da revista: ");
        string? titulo = Console.ReadLine();

        Console.WriteLine("Digite o numero da edisao: ");
        int numeroEdi = Convert.ToInt32(Console.ReadLine());

        Console.WriteLine("Digite o ano de publicacao: ");
        int anoPublicacao = Convert.ToInt32(Console.ReadLine());

        string idSelecionado = SelecionarCaixaId();

        Caixa? caixaSelecionada = (Caixa?) repositorioCaixa.SelecionarPorId(idSelecionado);

        return new Revista(titulo, numeroEdi, anoPublicacao, caixaSelecionada);
    }

    private string SelecionarCaixaId()
    {
        Console.WriteLine(
            "{0, -7} | {1, -20} | {2, -10} | {3, -20}",
            "Id", "Etiqueta", "Cor", "Tempo de Empréstimo"
        );

        EntidadeBase?[] caixas = repositorioCaixa.SelecionarTodas();

        for(int i = 0; i< caixas.Length; i++)
        {
            Caixa? c= (Caixa?)caixas[i];

            if(c == null)
                continue;
            Console.WriteLine(
                "{0, -7} | {1, -20} | {2, -10} | {3, -20}",
                c.Id, c.Etiqueta, c.Cor, c.DiasDeEmprestimo
            );
        }

        Console.WriteLine("=================================");

        string? idSelecionado;

        do
        {
            Console.WriteLine("Digite o ID do registro que deseja editar");
            idSelecionado = Console.ReadLine();

            if(!string.IsNullOrWhiteSpace(idSelecionado) && idSelecionado.Length == 7)
                break;
        }while(true);

        return idSelecionado;
    }

    public override void VisualizarTodos(bool deveExibirCabecalho)
    {
        if(deveExibirCabecalho)
            ExibirCabecalho("Visualização de Revistas");
        

       Console.WriteLine(
            "{0, -7} | {1, -25} | {2, -6} | {3, -4} | {4, -15}",
            "Id", "Título", "Edição", "Ano", "Caixa"
        );

        EntidadeBase?[] revistas = repositorioRevista.SelecionarTodas();

        for(int i =0; i< revistas.Length; i++)
        {
            Revista? r = (Revista?)revistas[i];

            if(r == null)
                continue;

            Console.Write("{0, -7} | ", r.Id);
            Console.Write("{0, -25} | ", r.Titulo);
            Console.Write("{0, -6} | ", r.NumeroEdi);
            Console.Write("{0, -4} | ", r.AnoPublicacao);

            string corSelecionada = r.Caixa.Cor;

            if (corSelecionada == "Vermelho")
                Console.ForegroundColor = ConsoleColor.Red;

            else if (corSelecionada == "Verde")
                Console.ForegroundColor = ConsoleColor.Green;

            else if (corSelecionada == "Azul")
                Console.ForegroundColor = ConsoleColor.Blue;

            Console.Write("{0, -15}", r.Caixa.Etiqueta);

            Console.ResetColor();
            Console.WriteLine();
        }

        if (deveExibirCabecalho)
        {
            Console.WriteLine("---------------------------------");
            Console.WriteLine("Digite ENTER para continuar...");
            Console.ReadLine();
        }
    }
    
}
