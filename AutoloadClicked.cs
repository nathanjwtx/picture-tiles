using System;
using Godot;

namespace PictureTiles
{
    public class AutoloadClicked : Node
    {
        [Signal]
        public delegate void TileClicked();

        public static AutoloadClicked Instance = new AutoloadClicked();

        private AutoloadClicked()
        {
        }
    }
}
