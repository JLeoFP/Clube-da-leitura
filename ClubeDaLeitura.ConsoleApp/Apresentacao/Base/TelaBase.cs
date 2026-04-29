using ClubeDaLeitura.ConsoleApp.Dominio.Base;
using ClubeDaLeitura.ConsoleApp.Infraestrutura.Base;

namespace ClubeDaLeitura.ConsoleApp.Apresentacao.Base;

public abstract class TelaBase : ITela
{   
    private string nomeEntidade = string.Empty;
    private RepoBase repositorio;

    protected TelaBase(string nomeEntidade, RepoBase repositorio)
    {
        this.nomeEntidade = nomeEntidade;
        this.repositorio = repositorio;
    }

    public void Cadastrar()
    {   
        ExibirCabecalho($"Cadastro de {nomeEntidade}");

        EntidadeBase novaEntidade = ObterDatosCadatrais();

        
        string[] erros = novaEntidade.Validar();

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
        Console.ResetColor();

        repositorio.Cadastrar(novaEntidade);

        ExibirMensagem($"O registro \"{novaEntidade.Id}\" foi cadastrado com sucesso! ");

    }

    public void Editar()
    {
        ExibirCabecalho($"Edição de {nomeEntidade}");
        
        VisualizarTodos(deveExibirCabecalho: false);

        Console.WriteLine("=================================");

        string? idSelecionado;

        do
        {
            Console.WriteLine("Digite o ID do registro que deseja editar");
            idSelecionado = Console.ReadLine();

            if(!string.IsNullOrWhiteSpace(idSelecionado) && idSelecionado.Length == 7)
                break;
        }while(true);

        Console.WriteLine("=================================");

       
        EntidadeBase novaEntidade = ObterDatosCadatrais();

        string[] erros = novaEntidade.Validar();

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

            Editar();
            return;
        }
        Console.ResetColor();

        bool conseguiuEditar = repositorio.Editar(idSelecionado, novaEntidade);

        if (!conseguiuEditar)
        {
            ExibirMensagem($"Nao foi possivel encontrar o registro requisitado");
            return;
        }
        
        ExibirMensagem($"O registro \"{idSelecionado}\" foi editado com sucesso");
    }

    public void Excluir()
    {
        ExibirCabecalho("Exclusao de Caixa");
        
        VisualizarTodos(deveExibirCabecalho: false);

        Console.WriteLine("=================================");

        string? idSelecionado;

        do
        {
            Console.WriteLine("Digite o ID do registro que deseja editar");
            idSelecionado = Console.ReadLine();

            if(!string.IsNullOrWhiteSpace(idSelecionado) && idSelecionado.Length == 7)
                break;
        }while(true);

        bool conseguiuExcluir = repositorio.Excluir(idSelecionado);

        if (!conseguiuExcluir)
        {
            ExibirMensagem($"Nao foi possivel encontrar o registro requisitado");
            return;
        }
        
        ExibirMensagem($"O registro \"{idSelecionado}\" foi excluido com sucesso");

    }
    public abstract void VisualizarTodos(bool deveExibirCabecalho);
    public string? ObterOpcaoMenu()
    {   
        string nomeMinuscula = nomeEntidade.ToLower();

        Console.Clear();
        Console.WriteLine("=================================");
        Console.WriteLine($"Clube da {nomeEntidade}");
        Console.WriteLine("=================================");
        Console.WriteLine($"1 - Cadastrar {nomeMinuscula}");
        Console.WriteLine($"2 - Editar {nomeMinuscula}");
        Console.WriteLine($"3 - Excluir {nomeMinuscula}");
        Console.WriteLine($"4 - Vizualizar {nomeMinuscula}");
        Console.WriteLine("S - Voltar Munu Principal");
        Console.WriteLine("=================================");
        Console.Write("> ");
        string? opcaoMenu = Console.ReadLine()?.ToUpper();

        return opcaoMenu;
    }
    protected void ExibirCabecalho(string titulo)
    {   
        Console.Clear();
        Console.WriteLine("=================================");
        Console.WriteLine($"Gestao de {nomeEntidade}");
        Console.WriteLine("=================================");
        Console.WriteLine(titulo);
        Console.WriteLine("=================================");
    }
    protected static void ExibirMensagem(string mesagem)
    {
        Console.WriteLine("=================================");
        Console.WriteLine(mesagem);
        Console.WriteLine("=================================");
        Console.WriteLine("Digite ENTER para continuar...");
        Console.ReadLine();
    }

    protected abstract EntidadeBase ObterDatosCadatrais();
    

}
