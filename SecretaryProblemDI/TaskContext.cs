namespace SecretaryProblemDI;

public class TaskContext
{
    public Princess Princess { get; }
    public Friend Friend { get; }
    public Hall Hall { get; }
    
    public ContendersGenerator Generator { get; }

    public TaskContext(ContendersGenerator generator)
    {
        Generator = generator;
        Princess = new Princess(this);
        Friend = new Friend();
        Hall = new Hall();
    }
}