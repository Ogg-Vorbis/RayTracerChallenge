using RayTracerChallenge.Features.DataStructures;

namespace RayTracerChallenge.Exercises.Exercises;

public class SphereHitsExerciseBookSolution : IExercise
{
    private readonly ConditionalConsoleWriter _consoleWriter;

    public SphereHitsExerciseBookSolution(bool writeToConsole)
    {
        _consoleWriter= new ConditionalConsoleWriter(writeToConsole);
    }

    public Canvas Run()
    {
        throw new NotImplementedException();
    }
}
