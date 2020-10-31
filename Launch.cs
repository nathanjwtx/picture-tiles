using Godot;

namespace PictureTiles
{
    public class Launch : Node
    {
        public override void _Ready()
        {
            // GD.Print("launched");
            GetNode<Timer>("ShowTitle").Connect("timeout", this, nameof(OnTimeoutShowTitle));
        }

        private void OnTimeoutShowTitle()
        {
            // GD.Print("show title");
            GetTree().ChangeScene(AutoLoadGlobals.TitleScene);
            QueueFree();
        }
    }
}
