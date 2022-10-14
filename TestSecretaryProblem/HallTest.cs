using SecretaryProblemDI;

namespace TestSecretaryProblem;

public class HallTest
{
    [Fact]
    public void NotNullNextContenderTest()
    {
        var hall = new Hall();
        var (first, second) = TestsHelper.GetTwoRandomContenders(40, 60);
        hall.InviteContenders(new List<RatingContender>
        {
            first,
            second
        });

        var firstFromHall = hall.GetNextContender();
        Assert.NotNull(firstFromHall);
        Assert.Equal(first, firstFromHall);
        
        var secondFromHall = hall.GetNextContender();
        Assert.NotNull(secondFromHall);
        Assert.Equal(second, secondFromHall);
    }

    [Fact]
    public void ExceptionWhileGetNonexistentTest()
    {
        var hall = new Hall();
        hall.InviteContenders(new List<RatingContender>());
        Assert.Throws<InvalidOperationException>(() => hall.GetNextContender());
    }
}