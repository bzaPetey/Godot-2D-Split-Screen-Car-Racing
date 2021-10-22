using Godot;
using System;

public class CheckPoint : Area2D {
    [Export]private bool _isActive = false;
    [Export]private bool _isFinishLine = false;
    [Export]private NodePath _nextCheckPoint;
    private Global GLOBAL;


 
    public override void _Ready() {
        GLOBAL = GetNode<Global>("/root/Global");
    }



    public void _on_CheckPoint_body_entered(Node body) {
        if(_isActive) {
            if(_isFinishLine)
                GLOBAL.LapCounter++;
   
            _isActive = false;
            GetNode<CheckPoint>(_nextCheckPoint).Activate();
        }
    }


    public void Activate() {
        _isActive = true;
    }
}
