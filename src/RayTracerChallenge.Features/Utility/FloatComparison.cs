namespace RayTracerChallenge.Features.Utility;

public static class FloatComparison
{
    const float _epsilon = 0.0001f;

    /// <summary>
    /// Returns true if the two floats are equal, within a small epsilon.
    /// </summary>
    public static bool AboutEqual(float a, float b)
    {
        if (a == b)
        {
            return true;
        }

        return Math.Abs(a - b) < _epsilon;
    }
}
