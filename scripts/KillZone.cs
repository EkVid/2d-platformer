using Godot;
using System;
using System.Threading;
using Timer = Godot.Timer;

public partial class KillZone : Area2D
{
    private Timer _timer;

    public override void _Ready()
    {
        _timer = GetNode<Timer>("Timer");

        BodyEntered += (Node2D body) =>
        {
            if (body.Name == "player")
            {
                _timer.WaitTime = 2f;
                _timer.Start();
                body.GetNode<CollisionShape2D>("CollisionShape2D").QueueFree();
            }
        };

        _timer.Timeout += () =>
        {
            _timer.WaitTime = 1;
            RestartGame();
        };
    }
    

    private void RestartGame()
    {
        GetTree().ReloadCurrentScene();
    }
}
