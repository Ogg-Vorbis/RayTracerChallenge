using RayTracerChallenge.Features.DataStructures;
using RayTracerChallenge.Features.Interfaces;
using RayTracerChallenge.Features.Services;

namespace RayTracerChallenge.Features.Factory;

public static class ServicesFactory
{
    public static IImageGenerationService CreateImageGenerationService(Canvas canvas)
    {
        return new PPMImageGenerationService(canvas);
    }
}
