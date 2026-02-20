using System;
using System.Collections.Generic;

namespace SkiaLiteUI;

public readonly struct Vector
{
    public float X { get; init; }
    public float Y { get; init; }

    public Vector(float x, float y)
    {
        X = x;
        Y = y;
    }
    public void Deconstruct(out float x, out float y)
    {
        x = X; 
        y = Y;
    }
    public static Vector operator +(Vector a, Vector b)
    {
        return new Vector(a.X + b.X, a.Y + b.Y);
    }
    public static Vector operator -(Vector a, Vector b)
    {
        return new Vector(a.X - b.X, a.Y - b.Y);
    }
    public static Vector operator *(Vector a, float factor)
    {
        return new Vector(a.X * factor, a.Y * factor);
    }
    public static Vector operator *(float factor, Vector a)
    {
        return new Vector(a.X * factor, a.Y * factor);
    }
    public static Vector operator /(Vector a, float divider)
    {
        return new Vector(a.X / divider, a.Y / divider);
    }
}
