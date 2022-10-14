using SecretaryProblemDI;

namespace TestSecretaryProblem;
using Xunit;

public class ContenderGeneratorTest
{
    [Fact]
    public void ContendersUniqueSetTest()
    {
        const int contendersNumber = 100;
        var contenders = new ContendersGenerator().GetShuffledContenders();
        Assert.Equal(contendersNumber, contenders.Count);

        var contendersSet = new HashSet<RatingContender>();
        foreach (var contender in contenders)
        {
            contendersSet.Add(contender);
        }
        
        Assert.Equal(contendersNumber, contendersSet.Count);
    }
}