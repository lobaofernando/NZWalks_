namespace NZWalksAPI;

public class DevHelper
{
    public static string RandomStringGenerator(int length)
    {
        var random = new Random();
        var chars = new char[length];
        for (int i = 0; i < length; i++)
        {
            chars[i] = (char)random.Next(65, 90);
        }
        return new string(chars);
    }
}
