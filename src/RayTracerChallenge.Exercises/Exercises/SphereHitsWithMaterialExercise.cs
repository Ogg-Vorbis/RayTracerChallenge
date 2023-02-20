using RayTracerChallenge.Features;
using RayTracerChallenge.Features.DataStructures;
using RayTracerChallenge.Features.Primitives;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RayTracerChallenge.Exercises.Exercises
{
    public class SphereHitsWithMaterialExercise : IExercise
    {
        private readonly ConditionalConsoleWriter _consoleWriter;

        public SphereHitsWithMaterialExercise(bool writeToConsole)
        {
            _consoleWriter = new ConditionalConsoleWriter(writeToConsole);
        }

        public Canvas Run()
        {
            int canvasPixels = 256;
            // Canvas Setup
            Canvas canvas = new(canvasPixels, canvasPixels);
            Color BackgroundColor = new("36213e");
            Color PixelColor = new("b8f3ff");
            canvas.WriteAllPixels(BackgroundColor);

            // Exercise
            Element RayOrigin = Element.CreatePoint(0, 0, -5);
            float wallZ = 10f;
            float wallSize = 7f;
            float pixelSize = wallSize / canvasPixels;
            float halfWallSize = wallSize / 2;

            Sphere sphere = new();
            sphere.Material.Color = PixelColor;

            // Add Light Source
            var lightPosition = Element.CreatePoint(-10, 10, -10);
            var lightColor = new Color(1, 1, 1);
            var light = new PointLight(lightPosition, lightColor);

            for (int y = 0; y < canvasPixels; y++)
            {
                var worldY = halfWallSize - pixelSize * y;
                for (int x = 0; x < canvasPixels; x++)
                {
                    var worldX = -halfWallSize + pixelSize * x;

                    var position = Element.CreatePoint(worldX, worldY, wallZ);
                    var r = new Ray(RayOrigin, (position - RayOrigin).Normalize());
                    var xs = sphere.Intersect(r);
                    var hit = Intersection.Hit(xs);
                    if (hit is not null)
                    {
                        // Calculate Eye Vector
                        var point = r.Position(hit.T);
                        var normal = hit.Object.NormalAt(point);
                        var eye = -r.Direction;
                        var calculatedColor = hit.Object.Material.Lighting(light, point, eye, normal);

                        _consoleWriter.WriteLine($"Hit at {hit.T}");
                        canvas.WritePixel(x, y, calculatedColor);
                    }
                }
            }
            return canvas;
        }
    }
}
