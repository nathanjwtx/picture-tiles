using System;
using Godot;

namespace PictureTiles
{
    public class Launch : Node
    {
        private string _titleScreen = "res://Title.tscn";
        
        public override void _Ready()
        {
            GD.Print("launched");
            GetNode<Timer>("ShowTitle").Connect("timeout", this, "OnTimeoutShowTitle");
        }

        private void OnTimeoutShowTitle()
        {
            GD.Print("show title");
            GetTree().ChangeScene(_titleScreen);
        }
    }
}
