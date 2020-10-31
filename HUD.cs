using Godot;

namespace PictureTiles
{
    public class HUD : CanvasLayer
    {
        private int _moveCounter;
        private Label counterNode;
        private Label _shuffleLabel;
        private HSlider _shuffleSlider;

        public override void _Ready()
        {
            // Connect signals
            AutoLoadGlobals.Instance.Connect("TileClicked", this, nameof(UpdateMoveCounter));
            GetNode<Button>("Start").Connect("pressed", this, nameof(OnPressedStart));
            GetNode<Button>("Main").Connect("pressed", this, nameof(OnPressedMain));
            // GetNode<Button>("CenterContainer/Start").Connect("pressed", this, nameof(OnPressedStart));
            _shuffleSlider = GetNode<HSlider>("SliderContainer/ShuffleSlider");
            _shuffleSlider.MinValue = AutoLoadGlobals.InitialShuffles;
            _shuffleSlider.Connect("value_changed", this, nameof(OnShuffleSliderValueChanged));
            
            GetNode<CenterContainer>("SolvedContainer").Visible = false;
            counterNode = GetNode<Label>("VBoxContainer/HBoxContainer/Moves");
            _moveCounter = 0;
            _shuffleLabel = GetNode<Label>("ShuffleMoves/Shuffles");
            _shuffleLabel.Text = AutoLoadGlobals.InitialShuffles.ToString();
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

        private void OnPressedMain()
        {
            GetTree().ChangeScene(AutoLoadGlobals.TitleScene);
        }
        
        private void OnShuffleSliderValueChanged(float value)
        {
            _shuffleLabel.Text = value.ToString();
            AutoLoadGlobals.InitialShuffles = (int) value;
        }
    }
}
