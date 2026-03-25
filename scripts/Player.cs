
using Godot;
using System;

public partial class Player : CharacterBody2D
{
	private const float Speed = 200.0f;
	private const float JumpVelocity = -300.0f;
	private AnimatedSprite2D character;

	public override void _Ready()
	{
		base._Ready();	
		character = GetNode<AnimatedSprite2D>("AnimatedSprite2D");
	}

	public override void _PhysicsProcess(double delta)
	{
		Vector2 velocity = Velocity;

		if (!IsOnFloor())
		{
			velocity += GetGravity() * (float)delta;
		}

		if (Input.IsActionJustPressed("jump") && IsOnFloor())
		{
			velocity.Y = JumpVelocity;
		}

		float direction = Input.GetAxis("move_left", "move_right");
		if (direction != 0)
		{
			character.Play("walk");
			velocity.X = direction * Speed;
			character.FlipH = direction < 0;
		}
		else
		{
			character.Play("idle");
			velocity.X = Mathf.MoveToward(Velocity.X, 0, Speed);
		}
		

		Velocity = velocity;
		MoveAndSlide();
	}
	
}
