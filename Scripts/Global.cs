using Godot;
using System;

public class Global : Node {
    private int _lapCounter = 0;
    private int _maxLaps = 3;


    public int LapCounter {
        get { return _lapCounter; }
        set {
            _lapCounter++;

            GD.Print(_lapCounter);
        }
    }


}
