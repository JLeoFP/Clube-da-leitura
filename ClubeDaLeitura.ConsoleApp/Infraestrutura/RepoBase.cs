using System;
using ClubeDaLeitura.ConsoleApp.Dominio;

namespace ClubeDaLeitura.ConsoleApp.Infraestrutura;

public  class RepoBase
{
    public bool Editar(string idSelecionado, EntidadeBase novaEntidade)
    {   
        EntidadeBase? entidadeSeleccionada = SelecionarPorId(idSelecionado);


        if(entidadeSeleccionada == null)
            return false;
        
        entidadeSeleccionada.AtualizarRegistro(novaEntidade);
        

        return true;
    }

    public EntidadeBase? SelecinarPorId(string idSelecionado)
    {
        return null;
    }

}
