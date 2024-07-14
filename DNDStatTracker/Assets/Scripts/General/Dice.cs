using System;

public class Dice
{
    public int sides;
    public int count;

    public Dice(int sides, int count)
    {
        this.sides = sides;
        this.count = count;
    }
    
    public string ToString()
    {
        return $"{count}d{sides}";
    }

    public int MaxRoll()
    {
        return sides * count;
    }
}
