using System.Diagnostics;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using SecretaryProblemDI.Generators;

namespace SecretaryProblemDI;

public class TaskSimulator : IHostedService
{
    private readonly IHostApplicationLifetime _applicationLifetime;

    private readonly Task _makeChoiceTask;

    private TaskContext _context;

    private readonly ContendersDbGenerator _generator;

    private readonly CliArgumentsParser _cliArguments;

    private readonly AttemptsDbConfigurator _configurator;

    private readonly IServiceScopeFactory _serviceScopeFactory;

    public TaskSimulator(IServiceScopeFactory serviceScopeFactory, AttemptsDbConfigurator configurator,
        CliArgumentsParser cliArguments,
        ContendersDbGenerator generator, TaskContext context, IHostApplicationLifetime applicationLifetime)
    {
        _serviceScopeFactory = serviceScopeFactory;
        _generator = generator;
        _cliArguments = cliArguments;
        _configurator = configurator;
        _applicationLifetime = applicationLifetime;
        _context = context;
        _makeChoiceTask = new Task(Simulate);
    }

    private void Simulate()
    {
        try
        {
            _configurator.ConfigureAttempts();

            var happiness = _cliArguments.AttemptNumber switch
            {
                null => GetAverageHappiness(),
                _ => GetHappinessByAttempt()
            };
            Console.WriteLine("_____");
            Console.WriteLine(happiness);
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

    private double GetAverageHappiness()
    {
        var attemptsNumber = AttemptsDbConfigurator.AttemptsNumber;
        double totalHappiness = 0;
        for (var i = 0; i < attemptsNumber; ++i)
        {
            using (IServiceScope scope = _serviceScopeFactory.CreateScope())
            {
                _context = scope.ServiceProvider.GetService<TaskContext>() ?? throw new InvalidOperationException();
                var happiness = GetHappinessByAttempt();
                totalHappiness += happiness;
                Console.WriteLine($"{i} : {happiness}");
            }
        }

        return totalHappiness / attemptsNumber;
    }

    private double GetHappinessByAttempt()
    {
        _generator.CreateContenders();
        _context.Hall.InviteContenders(_generator.GetContenders());
        var princessChoice = _context.Princess.MakeChoice();
        return HappinessEstimator.EstimatePrincessHappiness(princessChoice);
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