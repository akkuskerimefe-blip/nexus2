using System.Text.RegularExpressions;

public static class StringHelpers
{
    public static string GenerateSlug(string title)
    {
        string str = title.ToLower().Trim();
        str = Regex.Replace(str, @"[^a-z0-9\s-]", "");
        str = Regex.Replace(str, @"\s+", " ").Replace(" ", "-");
        return str;
    }
}