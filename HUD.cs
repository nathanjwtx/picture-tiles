using Godot;

namespace PictureTiles
{
    public class HUD : CanvasLayer
    {
        private int _moveCounter;
        private Label counterNode;

        public override void _Ready()
        {
            AutoLoadGlobals.Instance.Connect("TileClicked", this, nameof(UpdateMoveCounter));
            GetNode<Button>("CenterContainer/Start").Connect("pressed", this, nameof(OnPressedStart));
            GetNode<CenterContainer>("SolvedContainer").Visible = false;
            counterNode = GetNode<Label>("VBoxContainer/HBoxContainer/Moves");
            _moveCounter = 0;
        }

        private void UpdateMoveCounter()
        {
            _moveCounter++;
            counterNode.Text = _moveCounter.ToString();
        }
        
        private void OnPressedStart()
        {
            AutoLoadGlobals.Instance.EmitSignal("ShuffleTiles");
        }
    }
}
