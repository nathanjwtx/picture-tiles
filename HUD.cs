using Godot;

namespace PictureTiles
{
    public class HUD : CanvasLayer
    {
        private int _moveCounter;
        private Label counterNode;
        private Label _shuffleLabel;

        public override void _Ready()
        {
            // Connect signals
            AutoLoadGlobals.Instance.Connect("TileClicked", this, nameof(UpdateMoveCounter));
            GetNode<Button>("CenterContainer/Start").Connect("pressed", this, nameof(OnPressedStart));
            GetNode<HSlider>("SliderContainer/ShuffleSlider")
                .Connect("value_changed", this, nameof(OnShuffleSliderValueChanged));
            
            GetNode<CenterContainer>("SolvedContainer").Visible = false;
            counterNode = GetNode<Label>("VBoxContainer/HBoxContainer/Moves");
            _moveCounter = 0;
            _shuffleLabel = GetNode<Label>("ShuffleMoves/Shuffles");
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

        private void OnShuffleSliderValueChanged(float value)
        {
            _shuffleLabel.Text = value.ToString();
            AutoLoadGlobals.Instance.InitialShuffles = (int) value;
        }
    }
}
