using System;
using Godot;

// https://csharpindepth.com/articles/singleton

namespace PictureTiles
{
    public sealed class AutoloadClicked : Node
    {
        [Signal]
        public delegate void TileClicked();
        
        [Signal]
        public delegate void ShuffleTiles();

        // used to stop tiles from being moved once solved
        public static bool Solved;

        private static readonly AutoloadClicked _Instance = new AutoloadClicked();

        private AutoloadClicked()
        {}
        
        public static AutoloadClicked Instance => _Instance;

        static AutoloadClicked()
        {
            Solved = false;
            Console.WriteLine("created");
        }
    }
}
