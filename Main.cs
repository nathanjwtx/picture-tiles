using Godot;

namespace PictureTiles
{
    public partial class Main : Node
    {
        public override void _Ready()
        {
            PackedScene level = (PackedScene) ResourceLoader.Load(AutoLoadGlobals.LevelToLoad);
            AddChild(level.Instantiate());
        }
    }
}
