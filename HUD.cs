using System;
using System.Globalization;
using Godot;

namespace PictureTiles
{
    public class HUD : CanvasLayer
    {
        private int _moveCounter;
        private Label _counterNode;
        private Label _shuffleLabel;
        private HSlider _shuffleSlider;
        private bool _timerStarted;

        public override void _Ready()
        {
            // Connect signals
            AutoLoadGlobals.Instance.Connect("TileClicked", this, nameof(UpdateMoveCounter));
            GetNode<Button>("Start").Connect("pressed", this, nameof(OnPressedStart));
            GetNode<Button>("Main").Connect("pressed", this, nameof(OnPressedMain));
            GetNode<Godot.Timer>("HideSolved").Connect("timeout", this, nameof(OnHideSolvedTimeout));
            
            _shuffleSlider = GetNode<HSlider>("SliderContainer/ShuffleSlider");
            _shuffleSlider.MinValue = AutoLoadGlobals.InitialShuffles;
            _shuffleSlider.Connect("value_changed", this, nameof(OnShuffleSliderValueChanged));

            GetNode<CenterContainer>("SolvedContainer").Visible = false;
            _counterNode = GetNode<Label>("VBoxContainer/HBoxContainer/Moves");
            _moveCounter = 0;
            _shuffleLabel = GetNode<Label>("ShuffleMoves/Shuffles");
            _shuffleLabel.Text = AutoLoadGlobals.InitialShuffles.ToString();
        }

        public override void _PhysicsProcess(float delta)
        {
            // _timerStarted ensures StartTimer is only called once
            if (GetNode<CenterContainer>("SolvedContainer").Visible && !_timerStarted)
            {
                _timerStarted = true;
                StartTimer();
            }
        }

        private void StartTimer()
        {
            GetNode<Godot.Timer>("HideSolved").Start();
        }

        private void UpdateMoveCounter()
        {
            _moveCounter++;
            _counterNode.Text = _moveCounter.ToString();
        }

        private void OnPressedStart()
        {
            AutoLoadGlobals.Solved = false;
            _moveCounter = 0;
            _counterNode.Text = _moveCounter.ToString();
            _timerStarted = false;
            AutoLoadGlobals.Instance.EmitSignal("ShuffleTiles");
        }

        private void OnPressedMain()
        {
            GetTree().ChangeScene(AutoLoadGlobals.TitleScene);
        }

        private void OnShuffleSliderValueChanged(float value)
        {
            _shuffleLabel.Text = value.ToString(CultureInfo.InvariantCulture);
            AutoLoadGlobals.InitialShuffles = (int) value;
        }

        private void OnHideSolvedTimeout()
        {
            GetNode<CenterContainer>("SolvedContainer").Visible = false;
        }
    }
}




