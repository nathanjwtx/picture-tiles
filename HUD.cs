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
            AutoLoadGlobals.Instance.Connect("TileClicked", this, "UpdateMoveCounter");
            GetNode<Button>("CenterContainer/Start").Connect("pressed", this, "_on_pressed_Start");
            GetNode<CenterContainer>("SolvedContainer").Visible = false;
            counterNode = GetNode<Label>("VBoxContainer/HBoxContainer/Moves");
            _moveCounter = 0;
        }

        private void UpdateMoveCounter()
        {
            _moveCounter++;
            counterNode.Text = _moveCounter.ToString();
        }

        private void _on_pressed_Start()
        {
            AutoLoadGlobals.Instance.EmitSignal("ShuffleTiles");
        }
    }
}
