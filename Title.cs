using Godot;

namespace PictureTiles
{
    public class Title : Node
    {
        public override void _Ready()
        {
            GetNode<Button>("Three").Connect("pressed", this, nameof(LevelPressed), 
                new Godot.Collections.Array(){AutoLoadGlobals.ThreeByThree} );
            GetNode<Button>("Four").Connect("pressed", this, nameof(LevelPressed),
                new Godot.Collections.Array() {AutoLoadGlobals.FourByFour});
        }

        private void LevelPressed(string level)
        {
            if (level == AutoLoadGlobals.ThreeByThree)
            {
                GetNode<Button>("Four").Disabled = true;
            }
            else
            {
                GetNode<Button>("Three").Disabled = true;
            }

            GD.Print(level);
            GetTree().ChangeScene(AutoLoadGlobals.MainScene);
            AutoLoadGlobals.LevelToLoad = level;
        }
    }
}
