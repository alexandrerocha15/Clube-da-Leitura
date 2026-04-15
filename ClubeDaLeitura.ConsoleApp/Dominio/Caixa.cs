using System.Security.Cryptography;

namespace ClubeDaLeitura.ConsoleApp.Dominio;

public class Caixa
{
    public string Id {get;set;} = string.Empty;
    public string Eqtiqueta {get; set;} = string.Empty;
    public string Cor {get; set;} = string.Empty;
    public int DiasDeEmprestimo {get; set;} = 7;

    public Caixa(string eqtiqueta, string cor, int diasDeEmprestimo)
    {
        Id = Convert
            .ToHexString(RandomNumberGenerator.GetBytes(20))
            .ToLower()
            .Substring(0, 7);

        Eqtiqueta = eqtiqueta;
        Cor = cor;
        DiasDeEmprestimo = diasDeEmprestimo;
    }
    public void AtualizarRegistro(Caixa caixaAtualizada)
    {
        Eqtiqueta = caixaAtualizada.Eqtiqueta;
        Cor = caixaAtualizada.Cor;
        DiasDeEmprestimo = caixaAtualizada.DiasDeEmprestimo;
    }
}
