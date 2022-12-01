namespace SecretaryProblemDI;

public class Princess
{
    private const double ContendersToSkipFactor = 1 / Math.E;
    private const double ContendersLimitFactor = 0.96;

    private readonly List<Contender> _visitedContenders = new();

    private readonly TaskContext _context;

    public Princess(TaskContext taskContext)
    {
        _context = taskContext;
    }

    private void RememberVisitedContender(Contender contender, Friend friend)
    {
        _visitedContenders.Add(contender);
        friend.NotifyAboutContender((RatingContender)contender);
        //Console.WriteLine(contender.GetFullName());
    }

    private void SkipForeverByFactor(Hall hall, Friend friend)
    {
        var queueCount = hall.QueueInitialCount;
        if (queueCount == 0)
        {
            throw new ArgumentException("Empty contenders collection");
        }
        for (var i = 0; i < queueCount * ContendersToSkipFactor; i++)
        {
            RememberVisitedContender(hall.GetNextContender(), friend);
        }
    }

    public Contender? MakeChoice()
    {
        SkipForeverByFactor(_context.Hall, _context.Friend);
        while (_context.Hall.GetQueueCount() > 0)
        {
            var contender = _context.Hall.GetNextContender();
            var contendersCounter = 0;
            foreach (var visitedContender in _visitedContenders)
            {
                var friendAnswer = _context.Friend.ReplyToComparison(
                    newContender: contender,
                    oldContender: visitedContender);
                if (friendAnswer)
                {
                    contendersCounter++;
                }
            }

            if (contendersCounter >= _context.Hall.QueueInitialCount * ContendersToSkipFactor * ContendersLimitFactor)
            {
                return contender;
            }

            RememberVisitedContender(contender, _context.Friend);
        }

        return null;
    }
}