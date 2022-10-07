﻿namespace SecretaryProblemDI;

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
            >= 50 => ratingContender.Rating + 1,
            <= 0 => 10,
            _ => 0
        };
    }
}