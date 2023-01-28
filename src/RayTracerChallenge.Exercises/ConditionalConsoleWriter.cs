namespace RayTracerChallenge.Exercises;

internal class ConditionalConsoleWriter
{
    public bool Enabled { get; set; } = false;

    public ConditionalConsoleWriter(bool enabled)
    {
        Enabled = enabled;
    }

    public void WriteLine(string message)
    {
        if (Enabled)
        {
            Console.WriteLine(message);
        }
    }
}
