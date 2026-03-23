using Godot;
using System;

public partial class KillZone : Area2D
{
    private Timer _timer;
    
    public void OnBodyEntered(Node2D body)
    {
        if (body.Name == "player")
        {
            _timer = GetNode<Timer>("Timer");
            _timer.Start();   
        }
    }

    private void OnTimerTimeOut()
    {
        RestartGame();
    }

    private void RestartGame()
    {
        GetTree().ReloadCurrentScene();
    }
}
