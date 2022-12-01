namespace SecretaryProblemDI.Generators;

public interface IGenerator
{
    public List<Contender>? GetContenders();
    
    public void CreateContenders();
}