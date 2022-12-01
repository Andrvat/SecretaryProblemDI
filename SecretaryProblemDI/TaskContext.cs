namespace SecretaryProblemDI;

public class TaskContext
{
    public Princess Princess { get; set; }
    public Friend Friend { get; set; }
    public Hall Hall { get; set; }

    public TaskContext()
    {
        Princess = new Princess(this);
        Friend = new Friend();
        Hall = new Hall();
    }
}