using ClubeDaLeitura.ConsoleApp.Dominio;

namespace ClubeDaLeitura.ConsoleApp.Infraestrutura;

public class RepositorioRevista
{
    private Revista?[] revistas = new Revista[100];

    public void Cadastrar(Revista novaRevista)
    {
         for(int i = 0; i < revistas.Length; i++)
        {
            if(revistas[i]== null)
            {
                revistas[i] = novaRevista;
                break;
            }
        }
    }

    public bool Editar(string idSelecionado, Revista novaRevista)
    {   
        Revista? revistaSeleccionada = SelecionarPorId(idSelecionado);


        if(revistaSeleccionada == null)
            return false;
        
        revistaSeleccionada.AtualizarRegistro(novaRevista);
        

        return true;
    }

    public bool Excluir(string idSeleccionado)
    {

        for(int i = 0; i < revistas.Length; i++)
        {   
            Revista? r= revistas[i];

            if(r == null)
                continue;

            if (r.Id == idSeleccionado)
            {
                revistas[i] = null;
                return true;
            }
        }
        return false;
    }

    public Revista? SelecionarPorId(string idSelecionado)
    {
        Revista? revistaSelecionada = null;

        for(int i = 0; i < revistas.Length; i++)
        {   
            Revista? r= revistas[i];

            if(r == null)
                continue;

            if (r.Id == idSelecionado)
            {
                revistaSelecionada = r;
                break;
            }
        }

        return revistaSelecionada;
    }

    internal Revista?[] SelecionarTodas()
    {
        return revistas;
    }

}
