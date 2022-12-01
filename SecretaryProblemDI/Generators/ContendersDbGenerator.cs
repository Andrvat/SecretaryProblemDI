using System.Diagnostics;

namespace SecretaryProblemDI.Generators;

public class ContendersDbGenerator : IGenerator
{
    private readonly AttemptsDbContext _context;
    private readonly CliArgumentsParser _cliArguments;

    private int? _currentAttempt;
    private List<Contender>? _currentContenders;

    public ContendersDbGenerator(AttemptsDbContext context, CliArgumentsParser cliArguments)
    {
        _context = context;
        _cliArguments = cliArguments;
    }

    public List<Contender>? GetContenders()
    {
        return _currentContenders;
    }

    private List<Contender> GetContendersByAttempt()
    {
        var recordEntities = _context.AttemptRecordEntities
            .Where(record => Equals(record.AttemptNumber, _currentAttempt))
            .Select(record => record.ContenderEntity);

        var contenders = new List<Contender>();
        foreach (var recordEntity in recordEntities)
        {
            Debug.Assert(recordEntity != null, nameof(recordEntity) + " != null");
            contenders.Add(new RatingContender(
                surname: recordEntity.Surname,
                name: recordEntity.Name,
                patronymic: recordEntity.Patronymic,
                rating: recordEntity.Rating
                ));
        }

        return contenders;
    }

    public void CreateContenders()
    {
        var attempt = _cliArguments.AttemptNumber;

        _currentAttempt = attempt switch
        {
            null => (_currentAttempt is null) ? 0 : _currentAttempt + 1,
            _ => attempt
        };

        _currentContenders = GetContendersByAttempt();
    }
}