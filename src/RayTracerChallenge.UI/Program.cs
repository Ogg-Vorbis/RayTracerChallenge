using BenchmarkDotNet.Running;
using RayTracerChallenge.Exercises.Benchmark;
using RayTracerChallenge.Exercises.Exercises;
using RayTracerChallenge.Exercises.Interfaces;
using RayTracerChallenge.Features.DataStructures;
using RayTracerChallenge.Features.Factory;
using System.Diagnostics;

List<IExercise> exercises = new()
{
    //new ProjectileExercise(new(Element.CreatePoint(0, 1, 0), Element.CreateVector(1, 1.8f, 0).Normalize() * 11.25f),
    //    new(Element.CreateVector(0, -0.1f, 0), Element.CreateVector(-0.01f, 0, 0)), false),
    //new ClockExercise(),
    //new SphereHitsExerciseMySolution(false),
    //new SphereHitsExerciseBookSolution(false),
    //new SphereHitsWithMaterialExercise(true),
    new MakingASceneExercise(true)
};


foreach (var exercise in exercises)
{
    var ppm = ServicesFactory.CreateImageGenerationService(exercise.Run()).Generate();
    File.WriteAllText($"{exercise.GetType().Name}.ppm", ppm);
}

Process.Start(new ProcessStartInfo()
{
    FileName = Path.GetDirectoryName(System.Reflection.Assembly.GetEntryAssembly().Location),
    UseShellExecute = true,
    Verb = "open"
});

// var summary = BenchmarkRunner.Run<SphereHitsMineVsBook>();
