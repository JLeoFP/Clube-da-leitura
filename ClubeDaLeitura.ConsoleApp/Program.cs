using ClubeDaLeitura.ConsoleApp.Apresentacao;
using ClubeDaLeitura.ConsoleApp.Dominio;
using ClubeDaLeitura.ConsoleApp.Dominio.Base;
using ClubeDaLeitura.ConsoleApp.Infraestrutura;

RepositorioCaixa repositorioCaixa = new RepositorioCaixa();
RepositorioRevista repositorioRevista = new RepositorioRevista();
RepositorioAmigo repositorioAmigo = new RepositorioAmigo();
RepositorioEmprestimo repositorioEmprestimo = new RepositorioEmprestimo();

TelaCaixa telaCaixa = new TelaCaixa(repositorioCaixa);
TelaRevista telaRevista = new TelaRevista(repositorioRevista, repositorioCaixa);
TelaAmigo telaAmigo = new TelaAmigo(repositorioAmigo);
TelaEmprestimo telaEmprestimo = new TelaEmprestimo(repositorioEmprestimo, repositorioRevista, repositorioAmigo);


Caixa caixa= new Caixa("lanzamiento", "rojo",3);
repositorioCaixa.Cadastrar(caixa);
Amigo amigo = new Amigo("Leo", "patricia", "49 98222-4353");
Revista revista = new Revista("action comic", 152,1993,caixa);
Emprestimo emprestimo = new Emprestimo(revista, amigo);
emprestimo.Abrir();
repositorioEmprestimo.Cadastrar(emprestimo);

while (true)
{
    Console.Clear();
    Console.WriteLine("=================================");
    Console.WriteLine("Clube da Leitura");
    Console.WriteLine("=================================");
    Console.WriteLine("1 - Gerenciar caixas de revistas");
    Console.WriteLine("2 - Gerenciar revistas");
    Console.WriteLine("3 - Gerenciar amigos");
    Console.WriteLine("4 - Gerenciar empréstimos");
    Console.WriteLine("S - Sair");
    Console.WriteLine("=================================");
    Console.Write("> ");
    string? opcaoMenuPrincipal = Console.ReadLine()?.ToUpper();

    if (opcaoMenuPrincipal == "S")
    {
        Console.Clear();
        break;
    }

    while (true)
    {   
        
        string? opcaoMenuInterno = string.Empty;

        if (opcaoMenuPrincipal == "1") //caixas
        {
            opcaoMenuInterno = telaCaixa.ObterOpcaoMenu();

            if (opcaoMenuInterno == "S")
            {
                Console.Clear();
                break;
            }

            if(opcaoMenuInterno == "1")
            {
                telaCaixa.Cadastrar();
            }
            else if(opcaoMenuInterno == "2")
            {
                telaCaixa.Editar();
            }
            else if(opcaoMenuInterno == "3")
            {
                telaCaixa.Excluir();
            }
            else if(opcaoMenuInterno == "4")
            {
                telaCaixa.VisualizarTodos(deveExibirCabecalho: true);
            }
                       
        }
        else if (opcaoMenuPrincipal == "2") // Revistas
        {
            opcaoMenuInterno = telaRevista.ObterOpcaoMenu();

            if (opcaoMenuInterno == "S")
            {
                Console.Clear();
                break;
            }

            if(opcaoMenuInterno == "1")
            {
                telaRevista.Cadastrar();
            }
            else if(opcaoMenuInterno == "2")
            {
                telaRevista.Editar();
            }
            else if(opcaoMenuInterno == "3")
            {
                telaRevista.Excluir();
            }
            else if(opcaoMenuInterno == "4")
            {
                telaRevista.VisualizarTodos(deveExibirCabecalho: true);
            }
        }
        else if(opcaoMenuPrincipal == "3")
        {
            opcaoMenuInterno = telaAmigo.ObterOpcaoMenu();

            if (opcaoMenuInterno == "S")
            {
                Console.Clear();
                break;
            }

            if(opcaoMenuInterno == "1")
            {
                telaAmigo.Cadastrar();
            }
            else if(opcaoMenuInterno == "2")
            {
                telaAmigo.Editar();
            }
            else if(opcaoMenuInterno == "3")
            {
                telaAmigo.Excluir();
            }
            else if(opcaoMenuInterno == "4")
            {
                telaAmigo.VisualizarTodos(deveExibirCabecalho: true);
            }

        }
        else if (opcaoMenuPrincipal == "4")
        {
            opcaoMenuInterno = telaEmprestimo.ObterOpcaoMenu();

            if (opcaoMenuInterno == "S")
            {
                Console.Clear();
                break;
            }

            if(opcaoMenuInterno == "1")
            {
                telaEmprestimo.Abrir();
            }
            else if (opcaoMenuInterno == "2")
            {   
                telaEmprestimo.Concluir();
            }
            else if (opcaoMenuInterno == "3")
            {
                telaEmprestimo.VisualizarTodos(deveExibirCabecalho: true);
            }
        }

    }

}