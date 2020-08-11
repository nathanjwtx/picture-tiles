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

        // scenes
        public static string TitleScene = "res://Title.tscn";
        public static string MainScene = "res://Main.tscn";
        public static string ThreeByThree = "res://ThreeByThree.tscn";
        public static string FourByFour= "res://FourByFour.tscn";
        
        // used to stop tiles from being moved once solved
        public static bool Solved;

        public static string LevelToLoad;

        private static readonly AutoLoadGlobals _Instance = new AutoLoadGlobals();

        private AutoLoadGlobals()
        {}
        
        public static AutoLoadGlobals Instance => _Instance;

        static AutoLoadGlobals()
        {
            Solved = false;
        }
    }
}