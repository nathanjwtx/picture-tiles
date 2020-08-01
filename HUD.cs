using System;
using Godot;

namespace PictureTiles
{
    public class HUD : CanvasLayer
    {
        public override void _Ready()
        {
            AutoloadClicked.Instance.Connect("TileClicked", this, "UpdateMoveCounter");
        }

        private void UpdateMoveCounter()
        {
            Console.WriteLine("tile clicked");
        }

//  // Called every frame. 'delta' is the elapsed time since the previous frame.
//  public override void _Process(float delta)
//  {
//      
//  }
    }
}
