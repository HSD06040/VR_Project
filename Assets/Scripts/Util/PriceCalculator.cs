using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class PriceCalculator
{
    private static readonly int basePrice = 1;

    public static int CalculatePrice(ArtData art)
    {
        int total = basePrice + (int)art.timeTaken;

        total += (int)art.varietyScore;

        total *= (int)Manager.Data.fameLevel;

        return total;
    }
}

