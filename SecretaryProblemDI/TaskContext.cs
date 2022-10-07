namespace SecretaryProblemDI;

public class TaskContext
{
    public Princess Princess { get; }
    public Friend Friend { get; }
    public Hall Hall { get; }

    public TaskContext()
    {
        Princess = new Princess(this);
        Friend = new Friend();
        Hall = new Hall();
    }
}