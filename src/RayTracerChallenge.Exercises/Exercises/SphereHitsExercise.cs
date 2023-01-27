using RayTracerChallenge.Features.Actions;
using RayTracerChallenge.Features.DataStructures;
using RayTracerChallenge.Features.Extensions;
using RayTracerChallenge.Features.Primitives;

namespace RayTracerChallenge.Exercises.Exercises;

public class SphereHitsExercise : IExercise
{
    public bool WriteToConsole { get; set; }

    public SphereHitsExercise(bool writeToConsole)
    {
        WriteToConsole=writeToConsole;
    }

    public Canvas Run()
    {
        // Canvas Setup
        Canvas canvas = new(256, 256);
        Color BackgroundColor = new("36213e");
        Color PixelColor = new("5C7A80");
        canvas.WriteAllPixels(BackgroundColor);

        // Exercise
        Sphere s = new();
        s.Transform = s.Transform.Scale(75, 75, 75).Translate(256 / 2, 256/2, 0);
        for (int i = 0; i < canvas.Height; i++)
        {
            for (int j = 0; j < canvas.Width; j++)
            {
                Ray r = new(Element.CreatePoint(i, j, 0), Element.CreateVector(0, 0, 1));
                var xs = s.Intersect(r);
                var hit = Intersection.Hit(xs);

                if (hit != null)
                {
                    ConditionalConsoleWriter.WriteLine(hit.T.ToString(), WriteToConsole);
                    canvas.WritePixel(j, i, PixelColor.ChangeColorBrightness((hit.T/2) * .02f));
                }
            }
        }
        return canvas;
    }
}
