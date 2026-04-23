using System.Runtime;
using System.Security.Cryptography;
using ClubeDaLeitura.ConsoleApp.Dominio.Base;

/*
    Regras de Negócio:
    ● Campos obrigatórios:
        ○ Amigo
        ○ Revista (disponível no momento)
        ○ Data empréstimo (automática)
        ○ Data devolução (calculada conforme caixa)
    ● Status possíveis: Aberto / Concluído / Atrasado
    ● Cada amigo só pode ter um empréstimo ativo por vez
    ● Empréstimos atrasados devem ser destacados visualmente
    ● A data de devolução é calculada automaticamente (data empréstimo + dias da
    caixa)
*/

namespace ClubeDaLeitura.ConsoleApp.Dominio;

public class Emprestimo
{
    public string Id { get; set; } = string.Empty;
    public Revista Revista { get; set; }
    public Amigo Amigo { get; set; }
    public DateTime Abertura { get; set; }
    public DateTime ConclusaoPrevista
    {
        // encapsular essa logica da leitura da Conclusão Prevista 
        get
        {
            int diasDeEmprestimo = Revista.Caixa.DiasDeEmprestimo;

            DateTime conclusao = Abertura.AddDays(diasDeEmprestimo);

            return conclusao;
        }
    }

    public bool EstaAtrasado
    {
        get
        {
            return Status == StatusEmprestimo.Aberto && DateTime.Now > ConclusaoPrevista;
        }
    }

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
    public void Abrir()
    {
        Abertura = DateTime.Now;
        Status = StatusEmprestimo.Aberto;

        Revista.Emprestar();
        Amigo.AdicionarEmprestimo(this);
    }

    public void Concluir()
    {
        Status = StatusEmprestimo.Concluido;
    }
}