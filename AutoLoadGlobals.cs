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

        // used to pass which level was selected to the main scene
        public static string LevelToLoad;
        
        // number of initial shuffles to make
        public int InitialShuffles = 10;

        #region Singleton Setup
        private static readonly AutoLoadGlobals _Instance = new AutoLoadGlobals();

        private AutoLoadGlobals()
        {}
        
        public static AutoLoadGlobals Instance => _Instance;

        static AutoLoadGlobals()
        {
            Solved = false;
        }
        #endregion
    }
}
