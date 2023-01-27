namespace RayTracerChallenge.Exercises;

internal class ConditionalConsoleWriter
{
    public static void WriteLine(string message, bool enabled = false)
    {
        if (enabled)
        {
            Console.WriteLine(message);
        }
    }
}
