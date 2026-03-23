using Godot;
using System;

public partial class Slime : CharacterBody2D
{
	private const float Speed = 80.0f;       
	private int Direction = 1;

	public override void _PhysicsProcess(double delta)
	{
		
		Vector2 velocity = Velocity;
		var groundRay = GetNode<RayCast2D>("RayCastDown");

		if (IsOnWall())
		{
			var sprite = GetNode<AnimatedSprite2D>("AnimatedSprite2D");
			sprite.FlipH = Direction < 0;
			Direction *= -1;
		}
		else if (!groundRay.IsColliding())
			Direction *= -1;

		velocity.X = Direction * Speed;

		Velocity = velocity;
		MoveAndSlide();
	}
}
