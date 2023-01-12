using RayTracerChallenge.Features.DataStructures;
using RayTracerChallenge.Features.Interfaces;
using RayTracerChallenge.Features.Services;

namespace RayTracerChallenge.Features.Factory;

public class SavingServiceFactory
{
    public static ISavingService Create(Canvas canvas)
    {
        return new PPMSavingService(canvas);
    }
}
