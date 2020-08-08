using System;
using Godot;

// https://csharpindepth.com/articles/singleton

namespace PictureTiles
{
    public sealed class AutoLoadGlobals : Node
    {
        [Signal]
        public delegate void TileClicked();
        
        [Signal]
        public delegate void ShuffleTiles();

        public static string TitleScene = "res://Title.tscn";
        // used to stop tiles from being moved once solved
        public static bool Solved;

        private static readonly AutoLoadGlobals _Instance = new AutoLoadGlobals();

        private AutoLoadGlobals()
        {}
        
        public static AutoLoadGlobals Instance => _Instance;

        static AutoLoadGlobals()
        {
            Solved = false;
            Console.WriteLine("created");
        }
    }
}
