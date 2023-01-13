using RayTracerChallenge.Features.DataStructures;
using RayTracerChallenge.Features.Interfaces;
using System.Text;

namespace RayTracerChallenge.Features.Services;

public class PPMImageGenerationService : IImageGenerationService
{
    const int _maximumColorValue = 255;

    public Canvas Canvas { get; set; }

    public PPMImageGenerationService(Canvas canvas)
    {
        Canvas=canvas;
    }

    public string Generate()
    {
        StringBuilder PPMBuilder = new();
        BuildHeader(PPMBuilder);
        BuildContents(PPMBuilder);

        return PPMBuilder.ToString();
    }

    private void BuildHeader(StringBuilder sb)
    {
        sb.AppendLine("P3");
        sb.AppendLine($"{Canvas.Width} {Canvas.Height}");
        sb.AppendLine(_maximumColorValue.ToString());
    }

    private void BuildContents(StringBuilder sb)
    {
        var colorCodes = GetAllColorCodes();
        string line = "";
        foreach (var color in colorCodes)
        {
            if (color != Environment.NewLine && (color.Length + line.Length) <= 70)
            {
                line += color + " ";
            }
            else
            {
                sb.AppendLine(line.Trim());
                line = color + " ";
            }
        }

    }

    private List<string> GetAllColorCodes()
    {
        List<string> colorCodes = new();
        for (int i = 0; i < Canvas.Height; i++)
        {
            for (int j = 0; j < Canvas.Width; j++)
            {
                colorCodes.Add(ScaleColorValue(Canvas.Pixels[j, i].Color.Red));
                colorCodes.Add(ScaleColorValue(Canvas.Pixels[j, i].Color.Green));
                colorCodes.Add(ScaleColorValue(Canvas.Pixels[j, i].Color.Blue));
            }
            colorCodes.Add(Environment.NewLine);
        }
        return colorCodes;
    }

    private static string ScaleColorValue(float colorValue)
    {
        if (colorValue > 1) colorValue = 1;
        else if (colorValue < 0) colorValue = 0;
        return ((int)Math.Round(colorValue * _maximumColorValue)).ToString();
    }

    private void BuildFooter(StringBuilder sb)
    {

    }


}