using Moq;
using Moq.Protected;
using SecretaryProblemDI;

namespace TestSecretaryProblem;

public class PrincessTest
{
    [Fact]
    public void ChooseBestContenderTest()
    {
        var contenders = new List<RatingContender>();
        for (var i = TestsHelper.ContendersNumber - 2; i >= 0; --i)
        {
            contenders.Add(new RatingContender("", "", "", i));
        }

        contenders.Add(new RatingContender("", "", "", TestsHelper.ContendersNumber - 1));

        var context = new TaskContext();
        context.Hall.InviteContenders(contenders);
        var chosenContender = context.Princess.MakeChoice();
        Assert.NotNull(chosenContender);
        Assert.Equal(TestsHelper.ContendersNumber - 1, ((RatingContender)chosenContender).Rating);
    }

    [Fact]
    public void NotChooseAnyContenderTest()
    {
        var contenders = new List<RatingContender>();
        for (var i = TestsHelper.ContendersNumber - 1; i >= 0; --i)
        {
            contenders.Add(new RatingContender("", "", "", i));
        }
        
        var context = new TaskContext();
        context.Hall.InviteContenders(contenders);
        var chosenContender = context.Princess.MakeChoice();
        Assert.Null(chosenContender);
    }

    [Fact]
    public void ExceptionWhileAskNextTest()
    {
        var contenders = new List<RatingContender>();
        var context = new TaskContext();
        context.Hall.InviteContenders(contenders);
        Assert.Throws<ArgumentException>(() => context.Princess.MakeChoice());
    }
}