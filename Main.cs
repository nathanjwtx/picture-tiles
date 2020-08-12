using Godot;

namespace PictureTiles
{
    public class Main : Node
    {
        public override void _Ready()
        {
            PackedScene level = (PackedScene) ResourceLoader.Load(AutoLoadGlobals.LevelToLoad);
            AddChild(level.Instance());
        }
    }
}
