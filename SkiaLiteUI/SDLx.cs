using SDL3;
using System;
using System.Collections.Generic;


namespace SkiaLiteUI;

public static class SDLx
{   // todo: Refactoring to remove duplicate code
    public static void Init(SDL.InitFlags flags)
    {
        var ret = SDL.Init(flags);

        if (!ret)
        {
            var text = $"SDL could not initialize: {SDL.GetError()}";
            SDL.LogError(SDL.LogCategory.System, text);
            throw new Exception(text);
        }
    }
    public static nint CreateWindow(string title, int w, int h, SDL.WindowFlags flags)
    {
        var window = SDL.CreateWindow(title, w, h, flags);

        if (window == 0)
        {
            var text = $"Error creating window and rendering: {SDL.GetError()}";
            SDL.LogError(SDL.LogCategory.Application, text);
            throw new Exception(text);
        }

        return window;
    }

    public static void GLSwapWindow(nint window)
    {
        var ret = SDL.GLSwapWindow(window);

        if(!ret)
        {
            var text = $"SDL Error: GLSwapWindow: window={window}";
            SDL.LogError(SDL.LogCategory.Application, text);
            throw new Exception(text);
        }
    }
}
