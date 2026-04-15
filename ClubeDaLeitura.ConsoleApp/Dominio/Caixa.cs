using System;

namespace ClubeDaLeitura.ConsoleApp.Dominio;

public class Caixa
{
    public string Eqtiqueta {get; set;} = string.Empty;
    public string Cor {get; set;} = string.Empty;
    public int DiasDeEmprestimo {get; set;} = 7;

    public Caixa(string eqtiqueta, string cor, int diasDeEmprestimo)
    {
        Eqtiqueta = eqtiqueta;
        Cor = cor;
        DiasDeEmprestimo = diasDeEmprestimo;
    }
}
