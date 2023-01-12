using RayTracerChallenge.Features.Factory;
using RayTracerChallenge.Features.Interfaces;
using RayTracerChallenge.Features.Services;

namespace RayTracerChallenge.Features.Tests.Services;

public class PPMSavingServiceTests
{
    [Fact]
    public void ConstructPPMHeader()
    {
        Canvas c = new(5, 3);
        ISavingService ppms = SavingServiceFactory.Create(c);
        string ppm = ppms.Generate();
        var splitString = ppm.Split(Environment.NewLine);
        splitString[0].ShouldBe("P3");
        splitString[1].ShouldBe("5 3");
        splitString[2].ShouldBe("255");
    }

    [Fact]
    public void ConstructPPMPixelData()
    {
        Canvas canvas = new(5, 3);
        Color c1 = new(1.5f, 0, 0);
        Color c2 = new(0f, 0.5f, 0);
        Color c3 = new(-0.5f, 0, 1);

        canvas.WritePixel(0, 0, c1);
        canvas.WritePixel(2, 1, c2);
        canvas.WritePixel(4, 2, c3);

        ISavingService ppms = SavingServiceFactory.Create(canvas);
        string ppm = ppms.Generate();
        var splitString = ppm.Split(Environment.NewLine);
        splitString[3].ShouldBe("255 0 0 0 0 0 0 0 0 0 0 0 0 0 0");
        splitString[4].ShouldBe("0 0 0 0 0 0 0 128 0 0 0 0 0 0 0");
        splitString[5].ShouldBe("0 0 0 0 0 0 0 0 0 0 0 0 0 0 255");
    }

    [Fact]
    public void ConstructPPM_SplitLongLines()
    {
        Canvas canvas = new(10, 2);
        Color c = new(1, 0.8f, 0.6f);
        for (int i = 0; i < canvas.Height; i++)
        {
            for (int j = 0; j < canvas.Width; j++)
            {
                canvas.WritePixel(j, i, c);
            }
        }
        ISavingService ppms = SavingServiceFactory.Create(canvas);
        string ppm = ppms.Generate();
        var splitString = ppm.Split(Environment.NewLine);
        splitString[3].ShouldBe("255 204 153 255 204 153 255 204 153 255 204 153 255 204 153 255 204");
        splitString[4].ShouldBe("153 255 204 153 255 204 153 255 204 153 255 204 153");
        splitString[5].ShouldBe("255 204 153 255 204 153 255 204 153 255 204 153 255 204 153 255 204");
        splitString[6].ShouldBe("153 255 204 153 255 204 153 255 204 153 255 204 153");
    }
}
