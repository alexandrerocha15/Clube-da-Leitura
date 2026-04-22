using System.Runtime;
using System.Security.Cryptography;
using ClubeDaLeitura.ConsoleApp.Dominio.Base;

namespace ClubeDaLeitura.ConsoleApp.Dominio;
public class Emprestimo
{
    public string Id { get; set; } = string.Empty;

    public Revista Revista { get; set; }
    public Amigo Amigo { get; set; }
    public DateTime Abertura { get; set; }
    public DateTime ConclusaoPrevista { get; set; }


    public StatusEmprestimo Status { get; set; } = StatusEmprestimo.Indefinido;

    public Emprestimo(Revista revista, Amigo amigo)
    {
        Id = Convert
            .ToHexString(RandomNumberGenerator.GetBytes(20))
            .ToLower()
            .Substring(0, 7);
        Revista = revista;
        Amigo = amigo;
    }

    public string[] Validar() // Necessario
    {
        string erros = string.Empty;

        if (Revista == null)
            erros += "O campo \"Revista\" deve ser preenchido.;";

        if (Amigo == null)
            erros += "O campo \"Amigo\" deve ser preenchido.;";

        return erros.Split(';', StringSplitOptions.RemoveEmptyEntries);
    }

}