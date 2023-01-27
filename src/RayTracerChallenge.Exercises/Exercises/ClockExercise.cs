using RayTracerChallenge.Features.DataStructures;
using RayTracerChallenge.Features.Extensions;
using RayTracerChallenge.Features.Enums;

namespace RayTracerChallenge.Exercises.Exercises;

public class ClockExercise : IExercise
{
    public bool WriteToConsole { get; set; }

    public ClockExercise(bool writeToConsole)
    {
        WriteToConsole=writeToConsole;
    }

    public Canvas Run()
    {
        // Canvas Setup
        Canvas canvas = new(256, 256);
        Color BackgroundColor = new("36213e");
        Color PixelColor = new("b8f3ff");
        canvas.WriteAllPixels(BackgroundColor);
        // Exercise
        Element CenterPoint = Element.CreatePoint(canvas.Width / 2f, canvas.Height / 2f, 0);
        Element Twelve = Element.CreatePoint(0, 1, 0);
        float clockRadius = canvas.Width * .375f;
        int rotation = 30;
        for (int i = 0; i < 12; i++)
        {
            Element point = Matrix.IdentityMatrix.Rotate(Axis.Z, rotation) * Twelve;
            canvas.WritePixel((int)(-(point.X * clockRadius) + CenterPoint.X), (int)(-(point.Y * clockRadius) + CenterPoint.Y), PixelColor);
            rotation += 30;
        }
        return canvas;
    }
}
