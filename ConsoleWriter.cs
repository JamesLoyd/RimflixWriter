using System.Drawing;
using Pastel;

namespace RimflixShowMaker;

public static class ConsoleWriter
{
    //TODO: This will be replaced with a proper logging framework in the future.
    // I just copied it over from existing code cause, it was simple and effective.
    public static void WriteInformation(string message)
    {
        var infoLabel = "SYSTEM".Pastel(Color.Chartreuse);
        Console.WriteLine($"[{infoLabel}] {message}");
    }
}