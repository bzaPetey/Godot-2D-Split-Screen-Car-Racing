using Godot;
using System;

public class Global : Node {
    private int _lapCounter = 0;
    public int MaxLaps {get;set;}
    private CustomSignals _cs;


    public override void _Ready() {
        _cs = GetNode<CustomSignals>("/root/CS");
        MaxLaps = 3;
    }

    public int LapCounter {
        get { return _lapCounter; }
        set {
            _lapCounter++;
            _cs.EmitSignal("lapOver");
            GD.Print(_lapCounter);
 
            if(_lapCounter >= MaxLaps)
                _cs.EmitSignal("raceOver");
        }
    }
}
