using RayTracerChallenge.Features.Actions;
using RayTracerChallenge.Features.DataStructures;
using RayTracerChallenge.Features.Enums;
using RayTracerChallenge.Features.Extensions;
using RayTracerChallenge.Features.Primitives;

namespace RayTracerChallenge.Exercises.Exercises;

public class MakingASceneExercise : IExercise
{
    private readonly ConditionalConsoleWriter _consoleWriter;

    public MakingASceneExercise(bool writeToConsole)
    {
        _consoleWriter = new ConditionalConsoleWriter(writeToConsole);
    }

    public Canvas Run()
    {
        // Setup
        int imageHeight = 256;
        int imageWidth = 256;

        // Exercise

        // Create the world
        _consoleWriter.WriteLine("Creating world..");
        World world = new()
        {
            Light = new(Element.CreatePoint(-10, 10, -10), new Color(1, 1, 1))
        };

        // Create world objects
        _consoleWriter.WriteLine("Creating world objects..");
        // Creating the floor
        var floor = new Sphere();
        floor.Transform = floor.Transform.Scale(10, 0.01f, 10);
        floor.Material.Color = new("36213e");
        floor.Material.Specular = 0;

        // Creating the left wall
        var leftWall = new Sphere();
        leftWall.Transform = leftWall.Transform.Scale(10, 0.01f, 10).Rotate(Axis.X, AngleUnits.Radians, MathF.PI/2).Rotate(Axis.Y, AngleUnits.Radians, -MathF.PI/4).Translate(0, 0, 5);
        leftWall.Material = floor.Material;

        // Creating the right wall
        var rightWall = new Sphere();
        rightWall.Transform = rightWall.Transform.Scale(10, 0.01f, 10).Rotate(Axis.X, AngleUnits.Radians, MathF.PI / 2).Rotate(Axis.Y, AngleUnits.Radians, MathF.PI / 4).Translate(0, 0, 5);
        rightWall.Material = floor.Material;

        // Create some poles
        List<Sphere> poles = new();
        for (int i = 0; i < 7; i++)
        {
            var pole = new Sphere();
            pole.Transform = pole.Transform.Scale(0.1f, 4, 0.1f).Translate(-2.4f + (i * 0.7f), 0.5f, -2.75f);
            pole.Material.Color = new("#404040");
            pole.Material.Specular = 0.2f;
            poles.Add(pole);
        }

        // Add a jailed sphere
        var jailedSphere = new Sphere();
        jailedSphere.Transform = jailedSphere.Transform.Scale(1.5f, 1.5f, 1.5f).Translate(0, 1.5f, -0.5f);
        jailedSphere.Material.Color = new("#b8f3ff");
        jailedSphere.Material.Shininess = 150;

        // Add objects to world
        world.Objects.Add(floor);
        world.Objects.Add(leftWall);
        world.Objects.Add(rightWall);
        world.Objects.AddRange(poles);
        world.Objects.Add(jailedSphere);

        // Create the camera
        _consoleWriter.WriteLine($"Creating camera with height of {imageHeight}px and width of {imageWidth}px");
        var camera = new Camera(imageHeight, imageWidth, MathF.PI / 3)
        {
            Transform = Transformations.ViewTransform(Element.CreatePoint(0, 1.5f, -5),
                                                      Element.CreatePoint(0, 1, 0),
                                                      Element.CreateVector(0, 1, 0))
        };

        _consoleWriter.WriteLine("Rendering scene...");
        return camera.Render(world);
    }
}
