namespace RayTracerChallenge.Features.DataStructures;

public struct Camera
{
    public Camera(int hsize, int vsize, float fov)
    {
        HorizontalSize = hsize;
        VerticalSize = vsize;
        FieldOfView = fov;
        var halfView = MathF.Tan(FieldOfView / 2f);
        AspectRatio = (float)HorizontalSize / VerticalSize;
        if (AspectRatio >= 1)
        {
            HalfWidth = halfView;
            HalfHeight = halfView / AspectRatio;
        }
        else
        {
            HalfWidth = halfView * AspectRatio;
            HalfHeight = halfView;
        }
        PixelSize = (HalfWidth * 2) / HorizontalSize;

    }

    public int HorizontalSize { get; }
    public int VerticalSize { get; }
    public float FieldOfView { get; }
    public float AspectRatio { get; }
    public float HalfWidth { get; }
    public float HalfHeight { get; }
    public float PixelSize { get; }
    public Matrix Transform { get; set; } = Matrix.IdentityMatrix;

    public Ray RayForPixel(int px, int py)
    {
        var xoffset = (px + 0.5f) * PixelSize;
        var yoffset = (py + 0.5f) * PixelSize;
        
        var worldX = HalfWidth - xoffset;
        var worldY = HalfHeight - yoffset;

        var pixel = Transform.Inverse() * Element.CreatePoint(worldX, worldY, -1);
        var origin = Transform.Inverse() * Element.CreatePoint(0, 0, 0);
        var direction = (pixel - origin).Normalize();

        return new Ray(origin, direction);
    }

    public Canvas Render(World w)
    {
        var image = new Canvas(HorizontalSize, VerticalSize);

        for (int y = 0; y < VerticalSize; y++)
        {
            for (int x = 0; x < HorizontalSize; x++)
            {
                var ray = RayForPixel(x, y);
                var color = w.ColorAt(ray);
                image.WritePixel(x, y, color);
            }
        }

        return image;
    }
}
