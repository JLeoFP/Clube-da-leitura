using ClubeDaLeitura.ConsoleApp.Dominio;
using ClubeDaLeitura.ConsoleApp.Dominio.Base;

namespace ClubeDaLeitura.ConsoleApp.Infraestrutura;

public class RepositorioEmprestimo
{
    private Emprestimo?[] emprestimos = new Emprestimo[100];

    public void Cadastrar(Emprestimo empristimo)         
    {
        for(int i = 0; i < emprestimos.Length; i++)
        {
            if(emprestimos[i]== null)
            {
                emprestimos[i] = empristimo;
                break;
            }
        }
    }

    public Emprestimo?[] SelecionarTodos()
    {
        return emprestimos;
    }

    public Emprestimo? SelecionarPorId(string idSelecionado)
    {

        for(int i = 0; i < emprestimos.Length; i++)
        {   
            Emprestimo? e = emprestimos[i];

            if(e == null)
                continue;

            if (e.Id == idSelecionado)
            {
                return e;
            }
        }

        return null;
    }
}
