using Aula04.Models;

namespace Aula04.ViewModels;

public class AlunoDetalhesViewModel
{
    public string NomeCompleto { get; set; }
    public int Idade { get; set; }
    public string Email { get; set; }

    public string Saudacao => $"Bem vindo, {NomeCompleto}!";
    
    /// <summary>
    /// Converte um objeto AlunoModel para AlunoDetalhesViewModel
    /// </summary>
    /// <param name="aluno">O modelo AlunoModel a ser convertido</param>
    /// <returns>Uma nova instancia de AlunoDetalhesViewModel</returns>
    public static AlunoDetalhesViewModel FromModel(AlunoModel aluno)
    {
        return new AlunoDetalhesViewModel
        {
            NomeCompleto = aluno.nome,
            Email = aluno.email,
            Idade = aluno.Idade
        };

    }
    
}