using System;
using Godot;

namespace PictureTiles
{
    public class HUD : CanvasLayer
    {
        private int _moveCounter;
        private Label counterNode;

        public override void _Ready()
        {
            AutoloadClicked.Instance.Connect("TileClicked", this, "UpdateMoveCounter");
            counterNode = GetNode<Label>("VBoxContainer/HBoxContainer/Moves");
            _moveCounter = 0;
        }

        private void UpdateMoveCounter()
        {
            _moveCounter++;
            counterNode.Text = _moveCounter.ToString();
        }
    }
}
