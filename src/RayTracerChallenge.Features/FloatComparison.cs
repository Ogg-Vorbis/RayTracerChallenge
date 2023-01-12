namespace RayTracerChallenge.Features;

public static class FloatComparison
{
    const float EPSILON = 0.00001f;

    /// <summary>
    /// Returns true if the two floats are equal, within a small epsilon.
    /// </summary>
    public static bool Equal(float a, float b)
    {
        if (a == b)
        {
            return true;
        }
        
        return Math.Abs(a - b) < EPSILON;
    }
}
