using Microsoft.Extensions.Hosting;

namespace SecretaryProblemDI;

public class TaskSimulator : IHostedService
{
    private readonly IHostApplicationLifetime _applicationLifetime;

    private readonly Task<Contender?> _makeChoiseTask;

    private TaskContext _context;

    public TaskSimulator(TaskContext context, IHostApplicationLifetime applicationLifetime)
    {
        _applicationLifetime = applicationLifetime;
        _context = context;
        _makeChoiseTask = new Task<Contender?>(Simulate);
    }

    public void Simulate()
    {
        try
        {
            var contendersGenerator = new ContendersGenerator(sourceFilePath: "data/RussianNames.txt");
            _context.Hall.InviteContenders(contendersGenerator.GetShuffledContenders());
            var princessChoice = _context.Princess.MakeChoice();
            Console.WriteLine("_____");
            var princessHappiness = HappinessEstimator.EstimatePrincessHappiness(princessChoice);
            Console.WriteLine(princessHappiness);
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Data);
            Console.WriteLine(e.Message);
        }
    }

    public Task StartAsync(CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    public Task StopAsync(CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}