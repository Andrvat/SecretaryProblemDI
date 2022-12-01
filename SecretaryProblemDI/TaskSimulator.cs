using Microsoft.Extensions.Hosting;

namespace SecretaryProblemDI;

public class TaskSimulator : IHostedService
{
    private readonly IHostApplicationLifetime _applicationLifetime;

    private readonly Task _makeChoiceTask;

    private readonly TaskContext _context;

    private readonly ContendersFileGenerator _fileGenerator;

    public TaskSimulator(ContendersFileGenerator fileGenerator, TaskContext context, IHostApplicationLifetime applicationLifetime)
    {
        _fileGenerator = fileGenerator;
        _applicationLifetime = applicationLifetime;
        _context = context;
        _makeChoiceTask = new Task(Simulate);
    }

    private void Simulate()
    {
        try
        {
            _fileGenerator.CreateContenders();
            _context.Hall.InviteContenders(_fileGenerator.GetContenders());
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