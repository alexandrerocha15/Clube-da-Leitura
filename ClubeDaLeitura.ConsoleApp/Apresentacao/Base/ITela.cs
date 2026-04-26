using System;

namespace ClubeDaLeitura.ConsoleApp.Apresentacao.Base;

public interface ITela // conceito de abstração
{
    string? ObterOpcaoMenu(); // toda classe que implementa a interface, precisa implementar esse metodo
}