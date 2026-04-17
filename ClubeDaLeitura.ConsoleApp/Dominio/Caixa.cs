using System.Security.Cryptography;

namespace ClubeDaLeitura.ConsoleApp.Dominio;

public class Caixa
{
    public string Id { get; set; } = string.Empty;
    public string Etiqueta { get; set; } = string.Empty;
    public string Cor { get; set; } = string.Empty;
    public int DiasDeEmprestimo { get; set; } = 7;

    public Caixa(string eqtiqueta, string cor, int diasDeEmprestimo)
    {
        Id = Convert
            .ToHexString(RandomNumberGenerator.GetBytes(20))
            .ToLower()
            .Substring(0, 7);

        Etiqueta = eqtiqueta;
        Cor = cor;
        DiasDeEmprestimo = diasDeEmprestimo;
    }

    public string[] Validar()
    {
        string erros = string.Empty;

        if (string.IsNullOrWhiteSpace(Etiqueta))
        {
            erros += "O campo \"Etiqueta\" é obrigatório;";
        }

        else if (Etiqueta.Length > 50)
        {
            erros += "O campo \"Etiqueta\" deve conter no máximo 50 caracteres;";
        }

        if (DiasDeEmprestimo < 1)
        {
            erros += "O campo \"Dias de Emprestimo\" deve conter o valor maior que 0;";  
        }
        
        return erros.Split(';', StringSplitOptions.RemoveEmptyEntries); // separar
    }
    public void AtualizarRegistro(Caixa caixaAtualizada)
    {
        Etiqueta = caixaAtualizada.Etiqueta;
        Cor = caixaAtualizada.Cor;
        DiasDeEmprestimo = caixaAtualizada.DiasDeEmprestimo;
    }
}
