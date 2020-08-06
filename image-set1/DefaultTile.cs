using System;
using Godot;

namespace PictureTiles
{
    
    public class DefaultTile : Area2D
    {
        private RayCast2D _raycastNodeUp { get; set; }
        private RayCast2D _raycastNodeDown { get; set; }
        private RayCast2D _raycastNodeLeft { get; set; }
        private RayCast2D _raycastNodeRight { get; set; }
        private Godot.Object _objCollideUp { get; set; }
        private Godot.Object _objCollideDown { get; set; }
        private Godot.Object _objCollideLeft { get; set; }
        private Godot.Object _objCollideRight { get; set; }

        public override void _Ready()
        {
            _raycastNodeUp = GetNode<RayCast2D>("RayCastUp");
            _raycastNodeDown = GetNode<RayCast2D>("RayCastDown");
            _raycastNodeLeft = GetNode<RayCast2D>("RayCastLeft");
            _raycastNodeRight = GetNode<RayCast2D>("RayCastRight");
            _objCollideUp = new Godot.Object();
            _objCollideDown = new Godot.Object();
            _objCollideLeft = new Godot.Object();
            _objCollideRight = new Godot.Object();
        }

        public override void _Input(InputEvent @event)
        {
            if (!AutoloadClicked.Solved && @event is InputEventMouseButton eventMouseButton && eventMouseButton.Pressed)
            {
                if ((eventMouseButton.Position - Position).Length() < 32)
                {
                    if (_raycastNodeUp.GetCollider() == null)
                    {
                        Position = new Vector2(GlobalPosition.x, GlobalPosition.y - 64);
                        AutoloadClicked.Instance.EmitSignal("TileClicked");
                    }
                    else if (_raycastNodeDown.GetCollider() == null)
                    {
                        Position = new Vector2(GlobalPosition.x, GlobalPosition.y + 64);
                        AutoloadClicked.Instance.EmitSignal("TileClicked");
                    }
                    else if (_raycastNodeLeft.GetCollider() == null)
                    {
                        Position = new Vector2(GlobalPosition.x - 64, GlobalPosition.y);
                        AutoloadClicked.Instance.EmitSignal("TileClicked");
                    }
                    else if (_raycastNodeRight.GetCollider() == null)
                    {
                        Position = new Vector2(GlobalPosition.x + 64, GlobalPosition.y);
                        AutoloadClicked.Instance.EmitSignal("TileClicked");
                    }
                }
            }
        }
    }
}
