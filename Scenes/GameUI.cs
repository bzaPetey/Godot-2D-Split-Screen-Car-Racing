using Godot;
using System;

public class GameUI : Control {
    [Export]private NodePath _followTarget;
    private Label lblLapCounter;


    private Global _global;
    private CustomSignals _cs;
    private Car _follow;

 public override void _Ready() {
        _global = GetNode<Global>("/root/Global");
        _cs = GetNode<CustomSignals>("/root/CS");
        _cs.Connect("lapOver", this, "UpdateLapCounter");
 
       
        lblLapCounter = GetNode<Label>("lblLapCounter");
 
        _follow = GetNode<Car>(_followTarget);
 
    }
 
 
 
    public override void _Process(float delta) {
        Vector2 followPos = new Vector2(_follow.Position.x - RectSize.x,_follow.Position.y - RectSize.y);
 
        RectPosition = followPos;
    }
 
 
 
    //we have to make sure that the lapcounter in global is updated before this is called
    public void UpdateLapCounter() {
        lblLapCounter.Text = "Lap: " + _global.LapCounter.ToString() + "/"  + _global.MaxLaps;
    }
 
}
