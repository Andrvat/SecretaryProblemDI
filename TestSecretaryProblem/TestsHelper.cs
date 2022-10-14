using SecretaryProblemDI;

namespace TestSecretaryProblem;

public class TestsHelper
{
    public static (RatingContender, RatingContender) GetTwoRandomContenders(int firstRating, int secondRating)
    {
        return (new RatingContender("C", "B", "A", firstRating),
            new RatingContender("X", "Y", "Z", secondRating));
    }
}