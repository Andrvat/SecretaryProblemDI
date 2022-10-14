using Microsoft.Extensions.Hosting;

namespace SecretaryProblemDI;

public class TaskSimulator : IHostedService
{
    private readonly IHostApplicationLifetime _applicationLifetime;

    private readonly Task _makeChoiceTask;

    private readonly TaskContext _context;

    private readonly ContendersGenerator _generator;

    public TaskSimulator(ContendersGenerator generator, TaskContext context, IHostApplicationLifetime applicationLifetime)
    {
        _generator = generator;
        _applicationLifetime = applicationLifetime;
        _context = context;
        _makeChoiceTask = new Task(Simulate);
    }

    private void Simulate()
    {
        try
        {
            _context.Hall.InviteContenders(_generator.GetContenders());
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
        finally
        {
            _applicationLifetime.StopApplication();
        }
    }

    public Task StartAsync(CancellationToken cancellationToken)
    {
        _makeChoiceTask.Start();
        return Task.CompletedTask;
    }

    public Task StopAsync(CancellationToken cancellationToken)
    {
        return Task.CompletedTask;
    }
}