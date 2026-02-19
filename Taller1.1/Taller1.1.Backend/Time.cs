using System.Numerics;
using System.Reflection.Metadata.Ecma335;

namespace Taller1._1.Backend;

public class Time
{
    private int _hour;
    private int _minute;
    private int _second;
    private int _millisecond;

    public Time()
    {
        _hour = 0;
        _minute = 0;
        _second = 0;
        _millisecond = 0;
    }
    public Time(int hour)
    {
        Hour = hour;
    }
    public Time(int hour,int minute)
    {
        Hour = hour;
        Minute = minute;
    }
    public Time(int hour, int minute, int second)
    {
        Hour = hour;
        Minute = minute;
        Second = second;
    }
    public Time(int hour, int minute, int second, int milisecond)
    {
        Hour = hour;
        Minute = minute;
        Second = second;
        Millisecond = milisecond;
    }

    public int Hour 
    { 
        get => _hour; 
        set => _hour = ValidHour(value); 
    }
    public int Minute
    {
        get => _minute; 
        set => _minute = ValidMinute(value);
    }
    public int Second
    {
        get => _second; 
        set => _second = ValidSecond(value);
    }
    public int Millisecond
    {
        get => _millisecond;
        set => _millisecond = ValidMillisecond(value);
    }
    public override string ToString()
    {
        int hour12 = Hour % 12;
        if (hour12 == 0)
        {
            hour12 = 12;
        }
        string tt = Hour < 12 ? "AM" : "PM";
        return $"{hour12:00}:{Minute:00}:{Second:00}:{Millisecond:000} {tt}";
    }
    public long ToMilliseconds()
    {
        long totalMilliseconds = Hour * 3600000L + Minute * 60000L + Second * 1000L + Millisecond;
        return totalMilliseconds;
    }
    public long ToSeconds()
    {
        long totalSeconds = Hour * 3600L + Minute * 60L + Second + Millisecond / 1000L;
        return totalSeconds;
    }
    public long ToMinutes()
    {
        long totalMinutes = Hour * 60L + Minute + Second / 60L + Millisecond / 60000L;
        return totalMinutes;
    }
    public bool IsOtherDay(Time other)
    {
        int totalHours = this.Hour + other.Hour;
        if (totalHours >= 24)
        {
            return true;
        }
        return false;
    }
    public Time Add (Time other)
    {
        long totalMilliseconds = this.ToMilliseconds() + other.ToMilliseconds();
        int newHour = (int)(totalMilliseconds / 3600000L) % 24;
        int newMinute = (int)((totalMilliseconds % 3600000L) / 60000L);
        int newSecond = (int)((totalMilliseconds % 60000L) / 1000L);
        int newMillisecond = (int)(totalMilliseconds % 1000L);
        return new Time(newHour, newMinute, newSecond, newMillisecond);
    }
    private int ValidHour(int hour) 
    {
        if (hour < 0 || hour > 23)
        {
            throw new ArgumentOutOfRangeException(nameof(hour), $"The hour: {hour}, is not valid.");
        }
        return hour;
    }
    private int ValidMinute(int minute)
    {
        if (minute < 0 || minute > 59)
        {
            throw new ArgumentOutOfRangeException(nameof(minute), $"The minute: {minute}, is not valid.");
        }
        return minute;
    }
    private int ValidSecond(int second)
    {
        if (second < 0 || second > 59)
        {
            throw new ArgumentOutOfRangeException(nameof(second), $"The second: {second}, is not valid.");
        }
        return second;
    }
    private int ValidMillisecond(int millisecond)
    {
        if (millisecond < 0 || millisecond > 999)
        {
            throw new ArgumentOutOfRangeException(nameof(millisecond), $"The millisecond: {millisecond}, is not valid.");
        }
        return millisecond;
    }
}
