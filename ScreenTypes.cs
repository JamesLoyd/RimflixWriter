namespace RimflixShowMaker;

public enum ScreenTypes
{
    Flat,
    Mega,
    Tube
}

public static class ScreenTypeHelper
{
    public static ScreenTypes GetScreenType(string type)
    {
        switch (type.ToLower())
        {
            case "flatscreen":
            case "flat":
                return ScreenTypes.Flat;
            case "mega":
                return ScreenTypes.Mega;
            case "tube":
                return ScreenTypes.Tube;
        }
        
        throw new ApplicationException("Invalid screen type: " + type);
    }
}