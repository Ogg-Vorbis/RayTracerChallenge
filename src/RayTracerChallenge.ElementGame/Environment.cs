using RayTracerChallenge.Features.DataStructures;

namespace RayTracerChallenge.ElementGame;

public class Environment
{
    public Environment(Element gravity, Element wind)
    {
        if (!gravity.IsAVector() || !wind.IsAVector())
        {
            throw new ArgumentException("Both elements must be vectors.");
        }

        Gravity = gravity;
        Wind = wind;
    }

    public Element Gravity { get; }
    public Element Wind { get; }
}
