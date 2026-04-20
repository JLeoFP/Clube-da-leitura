using ClubeDaLeitura.ConsoleApp.Dominio;

namespace ClubeDaLeitura.ConsoleApp.Infraestrutura;

public class RepositorioCaixa
{
    private Caixa?[] caixas = new Caixa[100];

    public void Cadastrar(Caixa novaCaixa)         //pega info de la tela para trabajar
    {
        for(int i = 0; i < caixas.Length; i++)
        {
            if(caixas[i]== null)
            {
                caixas[i] = novaCaixa;
                break;
            }
        }
    }

    public bool Editar(string idSeleccionado, Caixa novaCaixa)
    {   
        Caixa? caixaSeleccionada = null;

        for(int i = 0; i < caixas.Length; i++)
        {   
            Caixa? c= caixas[i];

            if(c == null)
                continue;

            if (c.Id == idSeleccionado)
            {
                caixaSeleccionada = c;
                break;
            }
        }

        if(caixaSeleccionada == null)
            return false;
        
        caixaSeleccionada.AtualizarRegistro(novaCaixa);
        

        return true;
    }

    public bool Excluir(string idSeleccionado)
    {

        for(int i = 0; i < caixas.Length; i++)
        {   
            Caixa? c= caixas[i];

            if(c == null)
                continue;

            if (c.Id == idSeleccionado)
            {
                caixas[i] = null;
                return true;
            }
        }
        return false;
    }

    internal Caixa?[] SelecionarTodas()
    {
        return caixas;
    }

    
}
