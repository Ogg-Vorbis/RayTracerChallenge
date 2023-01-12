using RayTracerChallenge.Features.DataStructures;
using RayTracerChallenge.Features.Interfaces;
using System.Text;

namespace RayTracerChallenge.Features.Services;

public class PPMSavingService : ISavingService
{
    const int _maximumColorValue = 255;

    public Canvas Canvas { get; set; }

    public PPMSavingService(Canvas canvas)
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
        var data = GetAllColorCodes();
        var splitData = data.Split(' ');
        string line = "";
        foreach (var s in splitData)
        {
            if (s.Length + line.Length <= 70)
            {
                line += s + " ";
            }
            else
            {
                sb.AppendLine(line);
                line = s + " ";
            }
        }

    }

    private string GetAllColorCodes()
    {
        StringBuilder sb = new();
        for (int i = 0; i < Canvas.Height; i++)
        {
            for (int j = 0; j < Canvas.Width; j++)
            {
                sb.Append($"{ScaleColorValue(Canvas.Pixels[j, i].Color.Red)} " +
                    $"{ScaleColorValue(Canvas.Pixels[j, i].Color.Green)} " +
                    $"{ScaleColorValue(Canvas.Pixels[j, i].Color.Blue)}");
                if (j < Canvas.Width - 1)
                {
                    sb.Append(' ');
                }
            }
            sb.Append(Environment.NewLine);
        }
        return sb.ToString();
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