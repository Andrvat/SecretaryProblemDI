namespace SecretaryProblemDI;

public class Hall
{
    private readonly Queue<RatingContender> _contendersQueue = new();
    public int QueueInitialCount { get; private set; }

    public void InviteContenders(List<RatingContender> contenders)
    {
        foreach (var contender in contenders)
        {
            _contendersQueue.Enqueue(contender);
        }

        QueueInitialCount = _contendersQueue.Count;
    }

    public RatingContender GetNextContender()
    {
        return _contendersQueue.Dequeue();
    }

    public int GetQueueCount()
    {
        return _contendersQueue.Count;
    }
}