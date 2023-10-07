using System;
using System.Globalization;
using Godot;

    public partial class HUD : CanvasLayer
    {
        private int _moveCounter;
        private Label _counterNode;
        private Label _shuffleLabel;
        private HSlider _shuffleSlider;
        private bool _timerStarted;

        public override void _Ready()
        {
            // Connect signals
            AutoLoadGlobals.GlobalsSingleton.TileClicked += UpdateMoveCounter;
            GetNode<Button>("Start").Pressed += OnPressedStart;
            GetNode<Button>("Main").Pressed += OnPressedMain;
            GetNode<Timer>("HideSolved").Timeout += OnHideSolvedTimeout;
            
            _shuffleSlider = GetNode<HSlider>("SliderContainer/ShuffleSlider");
            _shuffleSlider.MinValue = AutoLoadGlobals.InitialShuffles;
            _shuffleSlider.ValueChanged += OnShuffleSliderValueChanged;

            GetNode<CenterContainer>("SolvedContainer").Visible = false;
            _counterNode = GetNode<Label>("VBoxContainer/HBoxContainer/Moves");
            _moveCounter = 0;
            _shuffleLabel = GetNode<Label>("ShuffleMoves/Shuffles");
            _shuffleLabel.Text = AutoLoadGlobals.InitialShuffles.ToString();
        }

        public override void _PhysicsProcess(double delta)
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
            GetNode<Timer>("HideSolved").Start();
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
            // AutoLoadGlobals.Instance.EmitSignal("ShuffleTiles");
            AutoLoadGlobals.GlobalsSingleton.EmitSignal(nameof(AutoLoadGlobals.GlobalsSingleton.ShuffleTiles));
        }

        private void OnPressedMain()
        {
            // GetTree().ChangeScene(AutoLoadGlobals.TitleScene);
            GetTree().ChangeSceneToFile(AutoLoadGlobals.TitleScene);
        }

        private void OnShuffleSliderValueChanged(double value)
        {
            _shuffleLabel.Text = value.ToString(CultureInfo.InvariantCulture);
            AutoLoadGlobals.InitialShuffles = (int) value;
        }

        private void OnHideSolvedTimeout()
        {
            GetNode<CenterContainer>("SolvedContainer").Visible = false;
        }
    }
