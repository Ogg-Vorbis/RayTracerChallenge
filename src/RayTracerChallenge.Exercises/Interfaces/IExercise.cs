using RayTracerChallenge.Features.DataStructures;

namespace RayTracerChallenge.Exercises.Interfaces;

public interface IExercise
{
    public bool WriteToConsole { get; set; }
    Canvas Run();
}
