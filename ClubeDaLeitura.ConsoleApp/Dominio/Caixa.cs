using System.Security.Cryptography;

namespace ClubeDaLeitura.ConsoleApp.Dominio;

/*
    ● Campos obrigatórios:
    ○ Etiqueta (texto único, máximo 50 caracteres)
    ○ Cor (seleção de paleta ou hexadecimal)
    ○ Dias de empréstimo (número, padrão 7)
    ● Não pode haver etiquetas duplicadas
    ● Não permitir excluir uma caixa caso tenha revistas vinculadas
    ● Cada caixa define o prazo máximo para empréstimo de suas revistas
*/

public class Caixa
{   
    public string Id {get; set;} = string.Empty;

    public string Etiqueta {get; set;} = string.Empty;
    public string Cor {get; set;} = string.Empty;
    public int DiasDeEmprestimo {get; set;} = 7;

    public Caixa(string etiqueta, string cor, int diasDeEmprestimo)      //constructor de clase
    {   
        Id = Convert.ToHexString(RandomNumberGenerator.GetBytes(20))
        .ToLower()
        .Substring(0, 7);
        Etiqueta = etiqueta;
        Cor = cor;
        DiasDeEmprestimo = diasDeEmprestimo;
    }

    public void AtualizarRegistro(Caixa caixaAtualizada)
    {
        Etiqueta = caixaAtualizada.Etiqueta;
        Cor = caixaAtualizada.Cor;
        DiasDeEmprestimo = caixaAtualizada.DiasDeEmprestimo;
    }

}
