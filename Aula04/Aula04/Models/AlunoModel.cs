namespace Aula04.Models;

public class AlunoModel
{
    public int id { get; set; }
    public string nome { get; set; }
    
    public string sobrenome { get; set; }
    public DateOnly dataNascimento { get; set; }
    public string email { get; set; }
    
    public int Idade => DateOnly.FromDateTime(DateTime.Now).Year - dataNascimento.Year;
}