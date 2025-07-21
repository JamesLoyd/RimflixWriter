using System.Drawing;
using Pastel;

namespace RimflixShowMaker;

public static class ConsoleWriter
{
    //TODO: This will be replaced with a proper logging framework in the future.
    // I just copied it over from existing code cause, it was simple and effective.
    public static void Write(string message, ConsoleMessageType messageType = ConsoleMessageType.Information)
    {
        var color = messageType switch
        {
            ConsoleMessageType.Warning => Color.Yellow,
            ConsoleMessageType.Error => Color.Red,
            _ => Color.Chartreuse
        };
        var infoLabel = $"{messageType}".Pastel(color);
        Console.WriteLine($"[{infoLabel}] {message}");
    }
}

public enum ConsoleMessageType
{
    Information,
    Warning,
    Error
}