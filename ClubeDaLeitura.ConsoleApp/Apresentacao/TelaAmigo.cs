using System;
using ClubeDaLeitura.ConsoleApp.Dominio;
using ClubeDaLeitura.ConsoleApp.Infraestrutura;

namespace ClubeDaLeitura.ConsoleApp.Apresentacao;

public class TelaAmigo
{
    private RepositorioAmigo repositorioAmigo;

    internal void Cadastrar()
    {
        throw new NotImplementedException();
    }

    internal void Editar()
    {
        throw new NotImplementedException();
    }

    internal void Excluir()
    {
        throw new NotImplementedException();
    }

    internal void VisualizarTodos(bool deveExibirCabecalho)
    {
        throw new NotImplementedException();
    }

    public void ObterDadosCadastrais()
    {
        Console.Write("Digite o nome do amigo: ");
        string? nomeAmigo = Console.ReadLine();

        Console.Write("Digite o nome do reponsável: ");
        string? nomeResponsavel = Console.ReadLine();

        Console.Write("Digite o número de Telefone: ");
        string? numeroTelefone = Console.ReadLine();

       
    }
    protected void ExibirCabecalho(string titulo)
    {
        // Console.Clear();
        Console.WriteLine("---------------------------------");
        Console.WriteLine("Gestão de Amigos");
        Console.WriteLine("---------------------------------");
        Console.WriteLine(titulo);
        Console.WriteLine("---------------------------------");
    }

    protected void ExibirMensagem(string mensagem)
    {
        Console.WriteLine("---------------------------------");
        Console.WriteLine(mensagem);
        Console.WriteLine("---------------------------------");
        Console.Write("Digite ENTER para continuar...");
        Console.ReadLine();
    }
}
