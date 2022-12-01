namespace SecretaryProblemDI;

public class AttemptsDbConfigurator
{
    private AttemptsDbContext _context;

    public AttemptsDbConfigurator(AttemptsDbContext context)
    {
        _context = context;
    }

    public void ConfigureAttempts()
    {
        
    }
}