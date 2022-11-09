using System;
using Unity.Mathematics;

public static class Utils
{
    public static float Distance(float2 a, float2 b)
    {
        float dis = math.sqrt(math.pow((b.x - a.x), 2) + math.pow((b.y - a.y), 2));
        return dis;
    }

    public static float Magnitude(float2 a)
    {
        float mag = math.sqrt(math.pow(a.x, 2) + math.pow(a.y, 2));
        return mag;
    }

    public static float2 Normalize(float2 a)
    {
        float mag = Magnitude(a);

        if (mag <= 0) 
            throw new ArgumentException("Magnitude is zero");

        float2 b = new float2();
        b.x = a.x / mag;
        b.y = a.y / mag;
        return b;
    }
}
