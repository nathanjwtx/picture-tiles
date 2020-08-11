using Godot;

namespace PictureTiles
{
    public class Main : Node
    {
        public override void _Ready()
        {
            GD.Print("main");
            PackedScene level = (PackedScene) ResourceLoader.Load(AutoLoadGlobals.LevelToLoad);
            AddChild(level.Instance());
        }

        private void LevelLoading(string level)
        {
            GD.Print($"load: {level}");
        }
    }
}
