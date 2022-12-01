using SecretaryProblemDI;

namespace TestSecretaryProblem;
using Xunit;

public class ContenderGeneratorTest
{
    [Fact]
    public void ContendersUniqueSetTest()
    {
        var contenders = new ContendersGenerator().GetContenders();
        Assert.Equal(TestsHelper.ContendersNumber, contenders.Count);

        var contendersSet = new HashSet<Contender>();
        foreach (var contender in contenders)
        {
            contendersSet.Add(contender);
        }
        
        Assert.Equal(TestsHelper.ContendersNumber, contendersSet.Count);
    }
}