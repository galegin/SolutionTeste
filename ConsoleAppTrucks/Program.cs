using System;
using System.Collections.Generic;
using System.Linq;

public class UnloadingTime
{
    public DateTime Start { get; private set; }
    public DateTime End { get; private set; }

    public UnloadingTime(DateTime start, DateTime end)
    {
        this.Start = start;
        this.End = end;
    }
}

public static class UnloadingTrucks
{
    public static bool CanUnloadAll(IEnumerable<UnloadingTime> unloadingTimes)
    {
        var unloadingTimesSort = unloadingTimes.OrderBy(s => s.Start);
        UnloadingTime unloadingTimeAnt = null;

        foreach (var unloadingTime in unloadingTimesSort)
        {
            Console.WriteLine($"{unloadingTime.Start} ~ {unloadingTime.End}");

            if (unloadingTimeAnt?.End > unloadingTime.Start)
            {
                return false;
            }

            unloadingTimeAnt = unloadingTime;
        }

        return true;
    }

    public static void Main(string[] args)
    {
        var format = System.Globalization.CultureInfo.InvariantCulture.DateTimeFormat;

        UnloadingTime[] unloadingTimes = new UnloadingTime[]
        {
            new UnloadingTime(DateTime.Parse("3/4/2019 19:00", format), DateTime.Parse("3/4/2019 20:30", format)),
            new UnloadingTime(DateTime.Parse("3/4/2019 22:10", format), DateTime.Parse("3/4/2019 22:30", format)),
            new UnloadingTime(DateTime.Parse("3/4/2019 20:30", format), DateTime.Parse("3/4/2019 22:00", format))
        };

        Console.WriteLine(UnloadingTrucks.CanUnloadAll(unloadingTimes));
        Console.ReadLine();
    }
}