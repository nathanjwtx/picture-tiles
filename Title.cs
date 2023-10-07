using Godot;

public partial class Title : Node
{
    private Button ThreeButton { get; set; }
    private Button FourButton { get; set; }

    public override void _Ready()
    {
        ThreeButton = GetNode<Button>("GridContainer/HBoxContainer/VBoxContainer/Three");
        FourButton = GetNode<Button>("GridContainer/HBoxContainer/VBoxContainer/Four");
        
        ThreeButton.Pressed += OnLevelThreePressed;
        FourButton.Pressed += OnLevelFourPressed;
    }

    private void OnLevelThreePressed()
    {
        AutoLoadGlobals.InitialShuffles = 10;
        ThreeButton.Disabled = true;

        GetTree().ChangeSceneToFile(AutoLoadGlobals.ThreeByThree);
    }

    private void OnLevelFourPressed()
    {
        AutoLoadGlobals.InitialShuffles = 20;
        FourButton.Disabled = true;

        GetTree().ChangeSceneToFile(AutoLoadGlobals.FourByFour);
    }
}