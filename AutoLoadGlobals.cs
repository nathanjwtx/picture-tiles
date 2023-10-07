using System;
using Godot;

// https://csharpindepth.com/articles/singleton

public partial class AutoLoadGlobals : Node
{
    [Signal]
    public delegate void TileClickedEventHandler();

    [Signal]
    public delegate void ShuffleTilesEventHandler();

    // scenes
    public const string TitleScene = "res://Title.tscn";
    public const string MainScene = "res://Main.tscn";
    public const string ThreeByThree = "res://ThreeByThree.tscn";
    public const string FourByFour = "res://FourByFour.tscn";

    // used to stop tiles from being moved once solved
    public static bool Solved;

    // used to pass which level was selected to the main scene
    public static string LevelToLoad;

    // number of initial shuffles to make
    public static int InitialShuffles;

    #region Singleton Setup

    public static AutoLoadGlobals GlobalsSingleton { get; private set; }

    public AutoLoadGlobals()
    {
        GlobalsSingleton = this;
    }

    // static AutoLoadGlobals()
    // {
    // Solved = false;
    // }

    #endregion
}