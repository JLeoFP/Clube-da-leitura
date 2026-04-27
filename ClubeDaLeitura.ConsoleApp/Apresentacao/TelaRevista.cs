

using ClubeDaLeitura.ConsoleApp.Dominio;
using ClubeDaLeitura.ConsoleApp.Infraestrutura;

namespace ClubeDaLeitura.ConsoleApp.Apresentacao;

public class TelaRevista
{       
    private RepositorioCaixa repositorioCaixa;
    private RepositorioRevista repositorioRevista;

    public TelaRevista(RepositorioRevista rR, RepositorioCaixa rC)
    {
        repositorioRevista = rR;
        repositorioCaixa = rC;
    }

    public string? ObterOpcaoMenu()
    {
        Console.Clear();
        Console.WriteLine("=================================");
        Console.WriteLine("Gestao de Revistas");
        Console.WriteLine("=================================");
        Console.WriteLine("1 - Cadastrar revistas");
        Console.WriteLine("2 - Editar revistas");
        Console.WriteLine("3 - Excluir revistas");
        Console.WriteLine("4 - Vizualizar revistas");
        Console.WriteLine("S - Voltar Munu Principal");
        Console.WriteLine("=================================");
        Console.Write("> ");
        string? opcaoMenu = Console.ReadLine()?.ToUpper();

        return opcaoMenu;
    }
    public void Cadastrar()
    {
        ExibirCabecalho("Cadastro de Revistas");

        Revista novaRevista = ObterDatosCadastrais();

        //validar

        string[] erros = novaRevista.Validar();

        if(erros.Length > 0)
        {
            Console.WriteLine("=================================");
            Console.ForegroundColor = ConsoleColor.Red;

            for(int i = 0; i < erros.Length; i++)
            {
                string erro = erros[i];
                Console.WriteLine(erro);
            }

            Console.ResetColor();
            Console.WriteLine("=================================");
            Console.WriteLine("Digite ENTER para continuar...");
            Console.ReadLine();

            Cadastrar();
            return;
        }

        //armazenar a revista no repositorio

        repositorioRevista.Cadastrar(novaRevista);

        ExibirMensagem($"O registro \"{novaRevista.Id}\" foi cadastrado com sucesso! ");
        
    }

    private Revista ObterDatosCadastrais()
    {
        Console.WriteLine("Digite o titulo da revista: ");
        string? titulo = Console.ReadLine();

        Console.WriteLine("Digite o numero da edisao: ");
        int numeroEdi = Convert.ToInt32(Console.ReadLine());

        Console.WriteLine("Digite o ano de publicacao: ");
        int anoPublicacao = Convert.ToInt32(Console.ReadLine());

        string idSelecionado = SelecionarCaixaId();

        Caixa? caixaSelecionada = repositorioCaixa.SelecionarPorId(idSelecionado);

        return new Revista(titulo, numeroEdi, anoPublicacao, caixaSelecionada);
    }

    private string SelecionarCaixaId()
    {
        Console.WriteLine(
            "{0, -7} | {1, -20} | {2, -10} | {3, -20}",
            "Id", "Etiqueta", "Cor", "Tempo de Empréstimo"
        );

        Caixa?[] caixas = repositorioCaixa.SelecionarTodas();

        for(int i = 0; i< caixas.Length; i++)
        {
            Caixa? c= caixas[i];

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
    public void Editar()
    {
        
    }
    public void Vizualizar()
    {
        
    }
    public void Excluir()
    {
        
    }

    public void VizualizarTodos(bool deveExibirCabecalho)
    {
        if(deveExibirCabecalho)
            ExibirCabecalho("Visualização de Revistas");
        

       Console.WriteLine(
            "{0, -7} | {1, -25} | {2, -6} | {3, -4} | {4, -15}",
            "Id", "Título", "Edição", "Ano", "Caixa"
        );

        Revista?[] revistas = repositorioRevista.SelecionarTodas();

        for(int i =0; i< revistas.Length; i++)
        {
            Revista? r = revistas[i];

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

    public void ExibirCabecalho(string titulo)
    {   
        Console.Clear();
        Console.WriteLine("=================================");
        Console.WriteLine("Gestao de Caixa");
        Console.WriteLine("=================================");
        Console.WriteLine(titulo);
        Console.WriteLine("=================================");
    }
     private static void ExibirMensagem(string mesagem)
    {
        Console.WriteLine("=================================");
        Console.WriteLine(mesagem);
        Console.WriteLine("=================================");
        Console.WriteLine("Digite ENTER para continuar...");
        Console.ReadLine();
    }

    
}
