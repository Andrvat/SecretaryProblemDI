namespace SecretaryProblemDI;

public static class HappinessEstimator
{
    public static int EstimatePrincessHappiness(Contender? contender)
    {
        if (contender == null)
        {
            return 10;
        }

        var ratingContender = (RatingContender)contender;
        return ratingContender.Rating switch
        {
            99 => 20,
            97 => 50,
            95 => 100,
            _ => 0
        };
    }
}