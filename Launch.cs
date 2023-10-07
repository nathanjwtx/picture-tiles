using Godot;

public partial class Launch : Node
{
    private Timer ShowTitle { get; set; }
    
    public override void _Ready()
    {
        GD.Print("launched");
        ShowTitle = GetNode<Timer>("ShowTitle");
        ShowTitle.Start();
        ShowTitle.Timeout += OnTimeoutShowTitle;
    }

    private void OnTimeoutShowTitle()
    {
        GD.Print("show title");
        var titleScene = (PackedScene)ResourceLoader.Load(AutoLoadGlobals.TitleScene);
        GetTree().ChangeSceneToPacked(titleScene);
    }
}