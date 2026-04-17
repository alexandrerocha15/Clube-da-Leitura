using ClubeDaLeitura.ConsoleApp.Apresentacao;
using ClubeDaLeitura.ConsoleApp.Dominio;

namespace ClubeDaLeitura.ConsoleApp.Infraestrutura;

public class RepositorioRevista
{
    private Revista?[] revistas = new Revista[100];

    public void Cadastrar(Revista novaRevista)
    {
        for (int i = 0; i < revistas.Length; i++)
        {
            if (revistas[i] == null)
            {
                revistas[i] = novaRevista;
                break;
            }
        }
    }

    public Revista? SelecionarPorId(string idSelecionado)
    {
        Revista? RevistaSelecionada = null;

        for (int i = 0; i < revistas.Length; i++)
        {
            Revista? r = revistas[i];

            if (r == null)
                continue;

            if (r.Id == idSelecionado)
            {
                RevistaSelecionada = r;
                break;
            }
        }

        return RevistaSelecionada;
    }


    public bool Editar(string idSelecionado, Revista novaRevista)
    {
        Revista? revistaSelecionada = null;

        for (int i = 0; i < revistas.Length; i++)
        {
            Revista? r = revistas[i];
            if (r == null)
                continue;

            if (r.Id == idSelecionado)
            {
                revistaSelecionada = r;
                break;
            }
        }
        if (revistaSelecionada == null)
            return false;

        revistaSelecionada.AtualizarRegistro(novaRevista);

        return true;
    }
    public bool Excluir(string idSelecionado)
    {
        for (int i = 0; i < revistas.Length; i++)
        {
            Revista? r = revistas[i];

            if (r == null)
                continue;

            if (r.Id == idSelecionado)
            {
                revistas[i] = null;
                return true;
            }
        }

        return false;
    }

    public Revista?[] SelecionarTodas()
    {
        return revistas;
    }

}
