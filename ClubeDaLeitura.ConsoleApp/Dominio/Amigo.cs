using System;
using ClubeDaLeitura.ConsoleApp.Apresentacao;
using ClubeDaLeitura.ConsoleApp.Infraestrutura;
using Microsoft.Win32;

namespace ClubeDaLeitura.ConsoleApp.Dominio.Base;

public class Amigo : EntidadeBase
{
    public string Nome { get; set; } = string.Empty;
    public string NomeResponsavel { get; set; } = string.Empty;
    public string NumeroTelefone { get; set; } = string.Empty;
    public Emprestimo[] Emprestimos = new Emprestimo[100];

    public Amigo(string nome, string nomeResponsavel, string numeroTelefone)
    {
        Nome = nome;
        NomeResponsavel = nomeResponsavel;
        NumeroTelefone = numeroTelefone;
    }
    public override void AtualizarRegistro(EntidadeBase entidadeAtualizada)
    {
        Amigo amigoAtualizado = (Amigo)entidadeAtualizada;

        Nome = amigoAtualizado.Nome;
        NomeResponsavel = amigoAtualizado.NomeResponsavel;
        NumeroTelefone = amigoAtualizado.NumeroTelefone;
    }
    public override string[] Validar()
    {
        string erros = string.Empty;

        if (string.IsNullOrWhiteSpace(Nome))
            erros += "O campo \"Nome\" é obrigatório;";
        else if (Nome.Length < 3 || Nome.Length > 100)
            erros += "O campo \"Nome\" deve ter de 3 a 100 caracteres;";

        if (string.IsNullOrWhiteSpace(NomeResponsavel))
            erros += "O campo \"Nome do Responsável\" é obrigatório;";
        else if (NomeResponsavel.Length < 3 || NomeResponsavel.Length > 100)
            erros += "O campo \"Nome do Responsavel\" deve ter de 3 a 100 caracteres;";

        if (string.IsNullOrWhiteSpace(NumeroTelefone))
            erros += "O campo \"Número do Telefone\" é obrigatório;";

        string numTelefone = NumeroTelefone.Replace(" ", "").Replace("-", "");

        if (ValidarTelefone())
            erros += "O \"Número do Telefone\" ja está cadastrado no sistema;";

        int contadorDigitos = 0;
        for (int i = 0; i < numTelefone.Length; i++)
        {
            char caractereAtual = numTelefone[i];
            if (char.IsDigit(caractereAtual)) contadorDigitos++;
            if (char.IsLetter(caractereAtual))
            {
                erros += "O campo \"Número do Telefone\" deve conter apenas dígitos;";
                break;
            }
        }
        if (NumeroTelefone.Length < 10 || NumeroTelefone.Length > 11)
            erros += "O campo \"Número do Telefone\" deve conter 10 ou 11 dígitos;";

        return erros.Split(';', StringSplitOptions.RemoveEmptyEntries);
    }
    public bool ValidarTelefone()
    {
        
        return false;
    }

    public void AdicionarEmprestimo(Emprestimo emprestimo)
    {
        for (int i = 0; i < Emprestimos.Length; i++)
        {
            Emprestimo e = Emprestimos[i];

            if (e == null)
                Emprestimos[i] = emprestimo;
                break;
        }
    }
}