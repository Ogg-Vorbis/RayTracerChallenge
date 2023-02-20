using RayTracerChallenge.Features.DataStructures;

namespace RayTracerChallenge.Features
{
    public struct Material
    {
        public Material()
        {
        }

        public Color Color { get; set; } = new(1, 1, 1);
        public float Ambient { get; set; } = 0.1f;
        public float Diffuse { get; set; } = 0.9f;
        public float Specular { get; set; } = 0.9f;
        public float Shininess { get; set; } = 200f;

        public Color Lighting(PointLight light, Element point, Element eyev, Element normalv)
        {
            var effectiveColor = Color * light.Intensity;
            var lightv = (light.Position - point).Normalize();
            var ambient = effectiveColor * Ambient;
            var lightDotNormal = Element.Dot(lightv, normalv);
            Color diffuse = new(0,0,0);
            Color specular = new(0, 0, 0);
            if (lightDotNormal >= 0)
            {
                diffuse = effectiveColor * Diffuse * lightDotNormal;
                var reflectv = -lightv.Reflect(normalv);
                var reflectDotEye = Element.Dot(reflectv, eyev);
                if(reflectDotEye > 0)
                {
                    var factor = float.Pow(reflectDotEye, Shininess);
                    specular = light.Intensity * Specular * factor;
                }
            }
            return ambient + diffuse + specular;
        }
    }
}