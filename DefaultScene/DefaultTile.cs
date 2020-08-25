using Godot;

namespace PictureTiles
{
    public class DefaultTile : Area2D
    {
        private RayCast2D _raycastNodeUp { get; set; }
        private RayCast2D _raycastNodeDown { get; set; }
        private RayCast2D _raycastNodeLeft { get; set; }
        private RayCast2D _raycastNodeRight { get; set; }
        private AudioStreamPlayer StreamPlayer { get; set; }

        public override void _Ready()
        {
            _raycastNodeUp = GetNode<RayCast2D>("RayCastUp");
            _raycastNodeDown = GetNode<RayCast2D>("RayCastDown");
            _raycastNodeLeft = GetNode<RayCast2D>("RayCastLeft");
            _raycastNodeRight = GetNode<RayCast2D>("RayCastRight");
            StreamPlayer = GetNode<AudioStreamPlayer>("Audio/ClickAudio");
            StreamPlayer.Connect("finished", this, nameof(OnAudioFinished));
        }

        public override void _Input(InputEvent @event)
        {
            if (!AutoLoadGlobals.Solved && @event is InputEventMouseButton eventMouseButton && eventMouseButton.Pressed)
            {
                if ((eventMouseButton.Position - Position).Length() < 32)
                {
                    if (_raycastNodeUp.GetCollider() == null)
                    {
                        Position = new Vector2(GlobalPosition.x, GlobalPosition.y - 64);
                        AutoLoadGlobals.Instance.EmitSignal("TileClicked");
                        StreamPlayer.Play();
                    }
                    else if (_raycastNodeDown.GetCollider() == null)
                    {
                        Position = new Vector2(GlobalPosition.x, GlobalPosition.y + 64);
                        AutoLoadGlobals.Instance.EmitSignal("TileClicked");
                        StreamPlayer.Play();
                    }
                    else if (_raycastNodeLeft.GetCollider() == null)
                    {
                        Position = new Vector2(GlobalPosition.x - 64, GlobalPosition.y);
                        AutoLoadGlobals.Instance.EmitSignal("TileClicked");
                        StreamPlayer.Play();
                    }
                    else if (_raycastNodeRight.GetCollider() == null)
                    {
                        Position = new Vector2(GlobalPosition.x + 64, GlobalPosition.y);
                        AutoLoadGlobals.Instance.EmitSignal("TileClicked");
                        StreamPlayer.Play();
                    }
                }
            }
            @event.Dispose();
        }

        private void OnAudioFinished()
        {
            GD.Print("finished");
        }
    }
}
