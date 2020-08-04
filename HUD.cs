using System;
using Godot;

namespace PictureTiles
{
    public class HUD : CanvasLayer
    {
        private int _moveCounter;
        private Label counterNode;

        public HUD()
        {
            _moveCounter = 0;
            Console.WriteLine("hud constructor");
        }

        public override void _Ready()
        {
            AutoloadClicked.Instance.Connect("TileClicked", this, "UpdateMoveCounter");
            GetNode<Button>("CenterContainer/Start").Connect("pressed", this, "_on_Start_pressed");
            counterNode = GetNode<Label>("VBoxContainer/HBoxContainer/Moves");
            Console.WriteLine("hud _ready");
        }

        private void UpdateMoveCounter()
        {
            _moveCounter++;
            counterNode.Text = _moveCounter.ToString();
        }

        private void _on_Start_pressed()
        {
            AutoloadClicked.Instance.EmitSignal("ShuffleTiles");
        }
    }
}
