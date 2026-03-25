using Godot;
using System;

public partial class Slime : CharacterBody2D
{
	private const float Speed = 60.0f;       
	private int Direction = 1;
	private RayCast2D groundRayLeft;
	private RayCast2D groundRayRight;
	private RayCast2D topRay;
	private AnimatedSprite2D sprite;

	
	public override void _Ready()
	{
		base._Ready();
		groundRayLeft = GetNode<RayCast2D>("RayCastDownLeft");
		groundRayRight = GetNode<RayCast2D>("RayCastDownRight");

		topRay = GetNode<RayCast2D>("RayCastUp");
		sprite = GetNode<AnimatedSprite2D>("AnimatedSprite2D");
	}

	public override void _PhysicsProcess(double delta)
	{
		
		Vector2 velocity = Velocity;
		
		if (IsOnWall() || !groundRayLeft.IsColliding() || !groundRayRight.IsColliding())
		{
			sprite.FlipH = Direction < 0;
			Direction *= -1;
		}

		velocity.X = Direction * Speed;

		Velocity = velocity;
		MoveAndSlide();
			
		if(HitByPlayer())
			QueueFree();

	}

	private bool HitByPlayer()
	{
		return (topRay.IsColliding() && (topRay.GetCollider() is Node2D node && node.Name == "player"));
	}
}
