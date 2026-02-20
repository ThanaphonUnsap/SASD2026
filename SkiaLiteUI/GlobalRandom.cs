using System;
using System.Collections.Generic;

namespace SkiaLiteUI;

// Global Object : ถือเป็น pattern ที่ดัดแปลงจาก Singleton
/*public static class GlobalRandom
{
    public static Random Obj { get; } = new Random();
}*/

// 04 Singleton : Original from the Design Patterns book
/*public class GlobalRandom 
{
    Random random;
    static GlobalRandom? obj = null;

    GlobalRandom() // private constructor
    {
        random = new Random();
    }

    public static Random Obj
    {
        get
        {
            if (obj == null)
                obj = new GlobalRandom();
            return obj.random;
        }
    }
}*/
