using Microsoft.VisualBasic;
using SecretaryProblemDI;

namespace TestSecretaryProblem;

public class FriendTest
{
    [Fact]
    public void UnknownContenderTest()
    {
        var friend = new Friend();
        var (first, second) = TestsHelper.GetTwoRandomContenders(50, 50);
        Assert.Throws<InvalidOperationException>(() => friend.ReplyToComparison(first, second));
    }

    [Fact]
    public void CorrectComparisonTest()
    {
        var friend = new Friend();                                                                  
        var (first, second) = TestsHelper.GetTwoRandomContenders(50, 60);
        friend.NotifyAboutContender(first);
        Assert.True(friend.ReplyToComparison(second, first));
    }
}