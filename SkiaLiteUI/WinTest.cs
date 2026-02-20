using SDL3;
using System.Diagnostics;


namespace SkiaLiteUI;

// https://github.com/edwardgushchin/SDL3-CS/blob/master/SDL3-CS.Examples/Create%20Window/Program.cs
// good article on keyboard: https://wiki.libsdl.org/SDL3/BestKeyboardPractices

public class WinTest
{
    public void Run()
    {
        new GLWindow("Title", 1920, 1080).Run();
    }
}
