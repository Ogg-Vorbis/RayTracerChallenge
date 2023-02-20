using RayTracerChallenge.Features.DataStructures;

namespace RayTracerChallenge.Features
{
    public class PointLight
    {
        public PointLight(Element position, Color intensity)
        {
            Position = position;
            Intensity = intensity;
        }

        public Element Position { get; }
        public Color Intensity { get; }
    }
}