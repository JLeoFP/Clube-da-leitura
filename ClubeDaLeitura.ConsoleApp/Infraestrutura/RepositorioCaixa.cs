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

    public bool Editar(string idSelecionado, Caixa novaCaixa)
    {   
        Caixa? caixaSeleccionada = SelecionarPorId(idSelecionado);


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

    public Caixa? SelecionarPorId(string idSelecionado)
    {
        Caixa? caixaSelecionada = null;

        for(int i = 0; i < caixas.Length; i++)
        {   
            Caixa? c= caixas[i];

            if(c == null)
                continue;

            if (c.Id == idSelecionado)
            {
                caixaSelecionada = c;
                break;
            }
        }

        return caixaSelecionada;
    }

    internal Caixa?[] SelecionarTodas()
    {
        return caixas;
    }

    
}
