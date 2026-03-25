using Godot;
	
public partial class Coin : Area2D
{
	public override void _Ready()
	{
		base._Ready();
		BodyEntered += (Node2D body) =>
		{
			if (body.Name == "player")
				QueueFree();
		};
	}
}
