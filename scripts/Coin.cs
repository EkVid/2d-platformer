using Godot;
	
public partial class Coin : Area2D
{
	public void OnBodyEntered(Node2D body)
	{
		if (body.Name == "player")
		{
		   QueueFree();
		}
	}
	
}
