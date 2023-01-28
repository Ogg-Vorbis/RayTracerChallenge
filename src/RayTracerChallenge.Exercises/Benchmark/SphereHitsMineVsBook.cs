using RayTracerChallenge.Exercises.Exercises;
using RayTracerChallenge.Features.DataStructures;

namespace RayTracerChallenge.Exercises.Benchmark
{
    public class SphereHitsMineVsBook
    {
        private readonly SphereHitsExerciseMySolution _mySolution;
        private readonly SphereHitsExerciseBookSolution _bookSolution;

        public SphereHitsMineVsBook()
        {
            _mySolution = new(false);
            _bookSolution = new(false);
        }

        [Benchmark]
        public Canvas RunMySolution() => _mySolution.Run();

        [Benchmark]
        public Canvas RunBookSolution() => _bookSolution.Run();
    }
}
