using ClubeDaLeitura.ConsoleApp.Dominio;
using ClubeDaLeitura.ConsoleApp.Infraestrutura;

namespace ClubeDaLeitura.ConsoleApp.Apresentacao;

public class TelaCaixa
{   
    private RepositorioCaixa repositorioCaixa;
    
    public TelaCaixa(RepositorioCaixa rC)
    {
        repositorioCaixa = rC;
    }

    public string ObterOpcaoMenu()
    {
        Console.Clear();
        Console.WriteLine("=================================");
        Console.WriteLine("Clube da Leitura");
        Console.WriteLine("=================================");
        Console.WriteLine("1 - Cadastrar caixas");
        Console.WriteLine("2 - Editar caixas");
        Console.WriteLine("3 - Excluir caixas");
        Console.WriteLine("4 - Vizualizar caixas");
        Console.WriteLine("S - Voltar Munu Principal");
        Console.WriteLine("=================================");
        Console.Write("> ");
        string? opcaoMenu = Console.ReadLine()?.ToUpper();

        return opcaoMenu;
    }

    public void Cadastrar()
    {   
        ExibirCabecalho("Cadastro de Caixa");

        Caixa novaCaixa = ObterDatosCadatras();

        //VALIDACION.
        
        string[] erros = novaCaixa.Validar();

        if(erros.Length > 0)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            
            for(int i = 0; i < erros.Length; i++)
            {
                string erro = erros[i];
                Console.WriteLine(erro);
            }

            Console.ResetColor();
            Console.ReadLine();
            return;
        }

        repositorioCaixa.Cadastrar(novaCaixa);

        Console.WriteLine("=================================");
        Console.WriteLine($"O registro \"{novaCaixa.Id}\" foi cadastrado com sucesso! ");
        Console.WriteLine("=================================");
        Console.WriteLine("Digite ENTER para continuar...");
        Console.ReadLine();

    }
    public void ExibirCabecalho(string titulo)
    {
        Console.WriteLine("=================================");
        Console.WriteLine("Gestao de Caixa");
        Console.WriteLine("=================================");
        Console.WriteLine(titulo);
        Console.WriteLine("=================================");
    }

    public void Editar()
    {
        ExibirCabecalho("Edican de Caixa");
        
        VizualizarTodos(deveExibirCabecalho: false);

        Console.WriteLine("=================================");

        string? idSeleccionado;

        do
        {
            Console.WriteLine("Digite o ID do registro que deseja editar");
            idSeleccionado = Console.ReadLine();

            if(!string.IsNullOrWhiteSpace(idSeleccionado) && idSeleccionado.Length == 7)
                break;
        }while(true);

        Console.WriteLine("=================================");

        //pasage de info para edicion
        Caixa novaCaixa = ObterDatosCadatras();

        bool conseguiuEditar = repositorioCaixa.Editar(idSeleccionado, novaCaixa);

        if (!conseguiuEditar)
        {
            Console.WriteLine("=================================");
            Console.WriteLine($"Nao foi possivel encontrar o registro requisitado");
            Console.WriteLine("=================================");
            Console.WriteLine("Digite ENTER para continuar...");
            Console.ReadLine();
            return;
        }
        
        Console.WriteLine("=================================");
        Console.WriteLine($"O registro \"{idSeleccionado}\" foi editado com sucesso");
        Console.WriteLine("=================================");
        Console.WriteLine("Digite ENTER para continuar...");
        Console.ReadLine();
    }

    public void Excluir()
    {
        ExibirCabecalho("Exclusao de Caixa");
        
        VizualizarTodos(deveExibirCabecalho: false);

        Console.WriteLine("=================================");

        string? idSeleccionado;

        do
        {
            Console.WriteLine("Digite o ID do registro que deseja editar");
            idSeleccionado = Console.ReadLine();

            if(!string.IsNullOrWhiteSpace(idSeleccionado) && idSeleccionado.Length == 7)
                break;
        }while(true);

        bool conseguiuExcluir = repositorioCaixa.Excluir(idSeleccionado);

        if (!conseguiuExcluir)
        {
            Console.WriteLine("=================================");
            Console.WriteLine($"Nao foi possivel encontrar o registro requisitado");
            Console.WriteLine("=================================");
            Console.WriteLine("Digite ENTER para continuar...");
            Console.ReadLine();
            return;
        }
        
        Console.WriteLine("=================================");
        Console.WriteLine($"O registro \"{idSeleccionado}\" foi excluido com sucesso");
        Console.WriteLine("=================================");
        Console.WriteLine("Digite ENTER para continuar...");
        Console.ReadLine();
    }

    public void VizualizarTodos(bool deveExibirCabecalho)
    {
        if(deveExibirCabecalho)
            ExibirCabecalho("Visualizacao de Caixas");
        

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

        if(deveExibirCabecalho)
        {
            Console.WriteLine("=================================");
            Console.WriteLine("Digite ENTER para continuar...");
            Console.ReadLine();
        }    

    }

    public Caixa ObterDatosCadatras()
    {
        Console.WriteLine("Informe a etiqueta da caixa");
        string? etiqueta = Console.ReadLine();

        Console.WriteLine("=================================");
        Console.WriteLine("Selecione uma das cores da caixa");
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine("1 - Vermelho");
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine("2 - Verde");
        Console.ForegroundColor = ConsoleColor.Blue;
        Console.WriteLine("3 - Azul");
        Console.ResetColor();
        Console.WriteLine("3 - Branco (Padrão) ");
        Console.WriteLine("=================================");


        Console.WriteLine("Informe a cor da caixa");
        string? codigoCor = Console.ReadLine();

        string cor;

        if(codigoCor == "1")
            cor= "Vermelho";
        else if(codigoCor == "2")
            cor = "Verde";
        else if(codigoCor == "3")
            cor= "Azul";
        else
            cor="Branco";
        
        Console.WriteLine("Informe o tempo de emprestimo das revista da caixa");
        int diasdDeEmprestimo = Convert.ToInt32(Console.ReadLine());

        Caixa novaCaixa = new Caixa(etiqueta, cor, diasdDeEmprestimo);

        return novaCaixa;
    }
}
