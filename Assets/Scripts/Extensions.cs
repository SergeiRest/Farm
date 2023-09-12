using System;

public static class Extensions
{
    public static TimeSpan Sec(this int timer)
    {
        int milisec = timer * 1000;
        return new TimeSpan(0, 0, 0, 0, milisec);
    }
}
