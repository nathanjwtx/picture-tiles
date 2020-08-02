using System;
using Godot;

// https://csharpindepth.com/articles/singleton

namespace PictureTiles
{
    public sealed class AutoloadClicked : Node
    {
        [Signal]
        public delegate void TileClicked();

        private static readonly AutoloadClicked _Instance = new AutoloadClicked();

        private AutoloadClicked()
        {}
        
        public static AutoloadClicked Instance => _Instance;

        static AutoloadClicked()
        {
            Console.WriteLine("created");
        }
    }
}
