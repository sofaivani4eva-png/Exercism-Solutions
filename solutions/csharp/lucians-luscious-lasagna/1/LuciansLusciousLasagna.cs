class Lasagna
{
    public int ExpectedMinutesInOven()
    {
        return 40;
    }

    public int RemainingMinutesInOven(int actualMinutesInOven)
    {
        return 40 - actualMinutesInOven;
    }

    public int PreparationTimeInMinutes(int layers)
    {
        return layers * 2;
    }

    public int ElapsedTimeInMinutes(int layers, int actualMinutesInOven)
    {
        return layers * 2 + actualMinutesInOven;
    }
}

